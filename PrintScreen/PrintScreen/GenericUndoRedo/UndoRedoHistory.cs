using System;
using System.Collections.Generic;

namespace FlexScreen.GenericUndoRedo
{
    /// <summary>
    /// This class represents an undo and redo history.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IMemento&lt;T&gt;"/>
    [Serializable]
    public class UndoRedoHistory<T>
    {
        private const int DEFAULT_CAPACITY = 100;

        private bool m_supportRedo;

        [NonSerialized]
        private CompoundMemento<T> m_tempMemento;

        /// <summary>
        /// The subject that this undo redo history is about.
        /// </summary>
        protected T Subject;

#if LIMITED_CAPACITY
/// <summary>
/// Undo stack with capacity
/// </summary>
protected RoundStack<IMemento<T>> undoStack;

/// <summary>
/// Redo stack with capacity
/// </summary>
protected RoundStack<IMemento<T>> redoStack;

/// <summary>
/// Creates <see cref="UndoRedoHistory&lt;T&gt;"/> with default capacity.
/// </summary>
/// <param name="subject"></param>
public UndoRedoHistory(T subject)
: this(subject, DEFAULT_CAPACITY)
{
}

/// <summary>
/// Creates <see cref="UndoRedoHistory&lt;T&gt;"/> with given capacity.
/// </summary>
/// <param name="subject"></param>
/// <param name="capacity"></param>
public UndoRedoHistory(T subject, int capacity)
{
this.subject = subject;
undoStack = new RoundStack<IMemento<T>>(capacity);
redoStack = new RoundStack<IMemento<T>>(capacity);
}
#else
        /// <summary>
        /// Undo stack
        /// </summary>
        protected Stack<IMemento<T>> UndoStack = new Stack<IMemento<T>>(DEFAULT_CAPACITY);

        /// <summary>
        /// Redo stack
        /// </summary>
        protected Stack<IMemento<T>> RedoStack = new Stack<IMemento<T>>(DEFAULT_CAPACITY);

        ///// <summary>
        ///// Creates <see cref="UndoRedoHistory&lt;T&gt;"/>.
        ///// </summary>
        ///// <param name="subject"></param>
        ///// <param name="supportRedo"></param>
        //public UndoRedoHistory(T subject, bool supportRedo)
        //{
        //    Subject = subject;
        //    SupportRedo = supportRedo;
        //}
#endif

        /// <summary>
        /// Gets a value indicating if the history is in the process of undoing or redoing.
        /// </summary>
        /// <remarks>
        /// This property is extremely useful to prevent undesired "Do" being executed. 
        /// That could occur in the following scenario:
        /// event X causees a Do action and certain Undo / Redo action causes event X, 
        /// i.e. Undo / Redo causes a Do action, which will render history in a incorrect state.
        /// So whenever <see cref="Do(IMemento&lt;T&gt;)"/> is called, the status of <see cref="InUndoRedo"/> 
        /// should aways be checked first. Example:
        /// <code>
        /// void SomeEventHandler() 
        /// {
        ///     if(!history.InUndoRedo) 
        ///         history.Do(...);
        /// }
        /// </code>
        /// </remarks>
        public bool InUndoRedo { get; private set; } = false;

        /// <summary>
        /// Gets number of undo actions available
        /// </summary>
        public int UndoCount => UndoStack.Count;

        /// <summary>
        /// Gets number of redo actions available
        /// </summary>
        public int RedoCount => RedoStack.Count;

        ///// <summary>
        ///// Gets or sets whether the history supports redo.
        ///// </summary>
        //public bool SupportRedo { get; set; }

        /// <summary>
        /// Begins a complex memento for grouping.
        /// </summary>
        /// <remarks>
        /// From the time this method is called till the time 
        /// <see cref=" EndCompoundDo()"/> is called, all the <i>DO</i> actions (by calling 
        /// <see cref="Do(IMemento&lt;T&gt;)"/>) are added into a temporary 
        /// <see cref="CompoundMemento&lt;T&gt;"/> and this memnto will be pushed into the undo 
        /// stack when <see cref="EndCompoundDo()"/> is called. 
        /// <br/>
        /// If this method is called, it's programmer's responsibility to call <see cref="EndCompoundDo()"/>, 
        /// or else this history will be in incorrect state and stop functioning.
        /// <br/>
        /// Sample Code:
        /// <br/>
        /// <code>
        /// // Version 1: Without grouping
        /// UndoRedoHistory&lt;Foo&gt; history = new UndoRedoHistory&lt;Foo&gt;();
        /// history.Clear();
        /// history.Do(memento1);
        /// history.Do(memento2);
        /// history.Do(memento3);
        /// // history has 3 actions on its undo stack.
        /// 
        /// // Version 1: With grouping
        /// history.BeginCompoundDo(); // starting grouping
        /// history.Do(memento1);
        /// history.Do(memento2);
        /// history.Do(memento3);
        /// hisotry.EndCompoundDo(); // must be called to finish grouping
        /// // history has only 1 action on its undo stack instead 3. 
        /// // This single undo action will undo all actions memorized by memento 1 to 3.
        /// </code>
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown if previous grouping wasn't ended. See <see cref="EndCompoundDo"/>.
        /// </exception>
        /// <seealso cref="EndCompoundDo()"/>
        public void BeginCompoundDo()
        {
            if (m_tempMemento != null)
                throw new InvalidOperationException("Previous complex memento wasn't commited.");

            m_tempMemento = new CompoundMemento<T>();
        }

        /// <summary>
        /// Ends grouping by pushing the complext memento created by <see cref="BeginCompoundDo"/> into the undo stack.
        /// </summary>
        /// <remarks>
        /// For details on how <i>grouping</i> works, see <see cref="BeginCompoundDo"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown if grouping wasn't started. See <see cref="BeginCompoundDo"/>.
        /// </exception>/// <seealso cref="BeginCompoundDo()"/>
        public void EndCompoundDo()
        {
            if (m_tempMemento == null)
                throw new InvalidOperationException("Ending a non-existing complex memento");

            _Do(m_tempMemento);
            m_tempMemento = null;
        }

        /// <summary>
        /// Pushes an memento into the undo stack, any time the state of <see cref="Subject"/> changes. 
        /// </summary>
        /// <param name="m"></param>
        /// <remarks>
        /// This method MUST be properly involked by programmers right before (preferably) or right after 
        /// the state of <see cref="Subject"/> is changed. 
        /// Whenever <see cref="Do(IMemento&lt;T&gt;)"/> is called, the status of <see cref="InUndoRedo"/> 
        /// should aways be checked first. See details at <see cref="InUndoRedo"/>. 
        /// This method causes redo stack to be cleared.
        /// </remarks>
        /// <seealso cref="InUndoRedo"/>
        /// <seealso cref="Undo()"/>
        /// <seealso cref="Redo()"/>
        public void Do(IMemento<T> m)
        {
            if (InUndoRedo)
                throw new InvalidOperationException("Involking do within an undo/redo action.");

            if (m_tempMemento != null)
            {
                m_tempMemento.Add(m);
                return;
            }
            _Do(m);
        }

        /// <summary>
        /// Internal <b>DO</b> action with no error checking
        /// </summary>
        /// <param name="m"></param>
        private void _Do(IMemento<T> m)
        {
            RedoStack.Clear();
            UndoStack.Push(m);
        }

        /// <summary>
        /// Restores the subject to the previous state on the undo stack, and stores the state before undoing to redo stack.
        /// Method <see cref="CanUndo()"/> can be called before calling this method.
        /// </summary>
        /// <seealso cref="Redo()"/>
        public void Undo()
        {
            if (m_tempMemento != null)
                throw new InvalidOperationException("The complex memento wasn't commited.");

            InUndoRedo = true;
            var top = UndoStack.Pop();
            RedoStack.Push(top.Restore(Subject));
            InUndoRedo = false;
        }

        /// <summary>
        /// Restores the subject to the next state on the redo stack, and stores the state before redoing to undo stack. 
        /// Method <see cref="CanRedo()"/> can be called before calling this method.
        /// </summary>
        /// <seealso cref="Undo()"/>
        public void Redo()
        {
            if (m_tempMemento != null)
                throw new InvalidOperationException("The complex memento wasn't commited.");

            InUndoRedo = true;
            var top = RedoStack.Pop();
            UndoStack.Push(top.Restore(Subject));
            InUndoRedo = false;
        }

        /// <summary>
        /// Checks if there are any stored state available on the undo stack.
        /// </summary>
        public bool CanUndo => (UndoStack.Count != 0);

        /// <summary>
        /// Checks if there are any stored state available on the redo stack.
        /// </summary>
        public bool CanRedo => (RedoStack.Count != 0);

        ///// <summary>
        ///// Clear the entire undo and redo stacks.
        ///// </summary>
        //public void Clear()
        //{
        //    UndoStack.Clear();
        //    RedoStack.Clear();
        //}

        ///// <summary>
        ///// Gets, without removing, the top memento on the undo stack.
        ///// </summary>
        ///// <returns></returns>
        //public IMemento<T> PeekUndo()
        //{
        //    if (UndoStack.Count > 0)
        //        return UndoStack.Peek();
        //    else
        //        return null;
        //}

        ///// <summary>
        ///// Gets, without removing, the top memento on the redo stack.
        ///// </summary>
        ///// <returns></returns>
        //public IMemento<T> PeekRedo()
        //{
        //    if (RedoStack.Count > 0)
        //        return RedoStack.Peek();
        //    else
        //        return null;
        //}
    }
}
