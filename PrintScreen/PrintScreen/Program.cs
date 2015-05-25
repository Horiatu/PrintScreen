using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;

namespace FlexScreen
{
    static class Program
    {
        public static SplashScreen MainForm { get { return MyContext.SplashScreenForm; } }
        public static OptionsDialog OptionsDialog { get { return MyContext.OptionsDialogForm; } }

        static readonly object syncObj = new Object();
        static MyApplicationContext _myContext;
        public static MyApplicationContext MyContext
        {
            get
            {
                lock (syncObj)
                {
                    return _myContext ?? (_myContext = new MyApplicationContext());
                }
            }
        }

        static ApplicationSettings _mySettings;
        public static ApplicationSettings MySettings
        {
            get
            {
                if (_mySettings == null)
                {
                    _mySettings = new ApplicationSettings();
                    if (_mySettings.Restore())
                    {
                    }
                }
                return _mySettings;
            }
        }

        public static List<CaptureForm> CaptureForms = new List<CaptureForm>();

        internal static CaptureForm GetCaptureForm(Image img)
        {
            var form = GetCaptureForm(img, null);
            return form;
        }

        internal static CaptureForm GetCaptureForm(Image img, Screen screen)
        {
            var form = new CaptureForm(img)
                           {
                               StartPosition = FormStartPosition.CenterScreen,
                               WindowState = FormWindowState.Normal,
                               Width = img.Width,
                               Height = img.Height
                           };
            form.Show();
            if (screen != null)
            {
                form.StartPosition = FormStartPosition.Manual;
                form.SetBounds(screen.Bounds.X, screen.Bounds.Y, screen.Bounds.Width, screen.Bounds.Height);
            }
            CaptureForms.Add(form);
            return form;
        }

        internal static CaptureForm GetCaptureForm()
        {
            return SplashScreen.CaptureImage(Screen.FromPoint(Cursor.Position));
            //var form = new CaptureForm(ScreenCapture.CaptureScreen());
            //CaptureForms.Add(form);
            //form.Visible = true;
            //return form;
        }

        internal static CaptureForm GetCaptureForm(IntPtr winHandle)
        {
            var form = new CaptureForm(ScreenCapture.CaptureScreen(winHandle));

            CaptureForms.Add(form);
            form.WindowState = FormWindowState.Normal;
            form.IsCroped = true;
            form.Show();
            form.StartPosition = FormStartPosition.Manual;

            RECT rct;
            if (GetWindowRect(new HandleRef(form, winHandle), out rct))
            {
                form.Left = rct.Left;
                form.Top = rct.Top;
            }
            return form;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            Application.ApplicationExit += Application_ApplicationExit;
            _hookID = SetHook(_proc);

            _myContext = null;
            _mySettings = null;
            Application.Run(MyContext);
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
        }

        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(Utils.WH_KEYBOARD_LL, proc,
                GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public delegate void EscapeKeyPressedHandler();
        public static event EscapeKeyPressedHandler EscapeKeyPressed;
        private static void OnEscapeKeyPressed()
        {
            if (EscapeKeyPressed != null) EscapeKeyPressed();
        }

        public delegate void SpaceKeyPressedHandler();
        public static event SpaceKeyPressedHandler SpaceKeyPressed;
        private static void OnSpaceKeyPressed()
        {
            if (SpaceKeyPressed != null) SpaceKeyPressed();
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var number = (Keys)Marshal.ReadInt32(lParam);
                if (number == Keys.PrintScreen)
                {
                    if ((wParam == (IntPtr)260 && Keys.Alt == Control.ModifierKeys && number == Keys.PrintScreen))
                    {
                        //MessageBox.Show("You've pressed alt + print screen");
                        if (!CaptureForm.Capturing)
                        {
                            CaptureForm.Capturing = true;
                            GetCaptureForm(GetForegroundWindow());
                        }
                    }
                    else
                    {
                        if (!CaptureForm.Capturing)
                        {
                            CaptureForm.Capturing = true;
                            GetCaptureForm();
                        }
                    }
                }
                else if (number == Keys.Escape)
                {
                    OnEscapeKeyPressed();
                    //SplashScreen.MinimizeAll();
                }
                else if (number == Keys.Space)
                {
                    OnSpaceKeyPressed();
                }
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
        IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }


    }
}
