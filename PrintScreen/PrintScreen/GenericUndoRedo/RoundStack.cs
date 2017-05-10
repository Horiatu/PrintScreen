using System;

namespace FlexScreen.GenericUndoRedo
{
    /// <summary>
    /// Stack with capacity, bottom items beyond the capacity are discarded.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class RoundStack<T>
    {
        private readonly T[] m_items; // items.Length is Capacity + 1

        // top == bottom ==> full
        private int m_top = 1;
        private int m_bottom = 0;

        /// <summary>
        /// Gets if the <see cref="RoundStack&lt;T&gt;"/> is full.
        /// </summary>
        public bool IsFull => m_top == m_bottom;

        /// <summary>
        /// Gets the number of elements contained in the <see cref="RoundStack&lt;T&gt;"/>.
        /// </summary>
        public int Count
        {
            get
            {
                var count = m_top - m_bottom - 1;
                if (count < 0)
                {
                    count += m_items.Length;
                }
                return count;
            }
        }

        /// <summary>
        /// Gets the capacity of the <see cref="RoundStack&lt;T&gt;"/>.
        /// </summary>
        public int Capacity => m_items.Length - 1;

        /// <summary>
        /// Creates <see cref="RoundStack&lt;T&gt;"/> with given capacity
        /// </summary>
        /// <param name="capacity"></param>
        public RoundStack(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException("Capacity need to be at least 1");
            }
            m_items = new T[capacity + 1];
        }

        /// <summary>
        /// Removes and returns the object at the top of the <see cref="RoundStack&lt;T&gt;"/>.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (Count <= 0) throw new InvalidOperationException("Cannot pop from emtpy stack");

            var removed = m_items[m_top];
            m_items[m_top--] = default(T);
            if (m_top < 0)
            {
                m_top += m_items.Length;
            }
            return removed;
        }

        /// <summary>
        /// Inserts an object at the top of the <see cref="RoundStack&lt;T&gt;"/>.
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (IsFull)
            {
                m_bottom++;
                if (m_bottom >= m_items.Length)
                {
                    m_bottom -= m_items.Length;
                }
            }
            if (++m_top >= m_items.Length)
            {
                m_top -= m_items.Length;
            }
            m_items[m_top] = item;
        }

        /// <summary>
        /// Returns the object at the top of the <see cref="RoundStack&lt;T&gt;"/> without removing it.
        /// </summary>
        public T Peek()
        {
            return m_items[m_top];
        }

        /// <summary>
        /// Removes all the objects from the <see cref="RoundStack&lt;T&gt;"/>.
        /// </summary>
        public void Clear()
        {
            if (Count <= 0) return;

            for (var i = 0; i < m_items.Length; i++)
            {
                m_items[i] = default(T);
            }
            m_top = 1;
            m_bottom = 0;
        }
    }
}
