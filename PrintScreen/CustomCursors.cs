using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace FlexScreen
{
    public class CustomCursors
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Iconinfo
        {
            public bool fIcon;
            // Specifies whether this structure defines an icon or a cursor. A value of TRUE specifies 
            // an icon; FALSE specifies a cursor. 

            public Int32 xHotspot;
            // Specifies the x-coordinate of a cursor's hot spot. If this structure defines an icon, the hot 
            // spot is always in the center of the icon, and this member is ignored.

            public Int32 yHotspot;
            // Specifies the y-coordinate of the cursor's hot spot. If this structure defines an icon, the hot 
            // spot is always in the center of the icon, and this member is ignored. 

            public IntPtr hbmMask;
            // (HBITMAP) Specifies the icon bitmask bitmap. If this structure defines a black and white icon, 
            // this bitmask is formatted so that the upper half is the icon AND bitmask and the lower half is 
            // the icon XOR bitmask. Under this condition, the height should be an even multiple of two. If 
            // this structure defines a color icon, this mask only defines the AND bitmask of the icon. 

            public IntPtr hbmColor;
            // (HBITMAP) Handle to the icon color bitmap. This member can be optional if this 
            // structure defines a black and white icon. The AND bitmask of hbmMask is applied with the SRCAND 
            // flag to the destination; subsequently, the color bitmap is applied (using XOR) to the 
            // destination by using the SRCINVERT flag. 
        }

        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref Iconinfo icon);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref Iconinfo pIconInfo);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr handle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        public static IntPtr pointeurCurseur;

        public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
        {
            IntPtr ptr = bmp.GetHicon();
            Iconinfo tmp = new Iconinfo();
            GetIconInfo(ptr, ref tmp);
            tmp.xHotspot = xHotSpot;
            tmp.yHotspot = yHotSpot;
            tmp.fIcon = false;
            pointeurCurseur = CreateIconIndirect(ref tmp);

            if (tmp.hbmColor != IntPtr.Zero) DeleteObject(tmp.hbmColor);
            if (tmp.hbmMask != IntPtr.Zero) DeleteObject(tmp.hbmMask);
            if (ptr != IntPtr.Zero) DestroyIcon(ptr);

            return new Cursor(pointeurCurseur);
        }

        public static Cursor None()
        {
            using (Bitmap cursorBmp = new Bitmap(1,1))
            {
                return CreateCursor(cursorBmp, 1, 1);
            }
        }

        internal static Bitmap CursorImage(int size)
        {
            var bitmap = new Bitmap(size * 2, size * 2);

            var cursorPen = new Pen(Color.Black);//Program.MySettings.CursorColor);
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.FillEllipse(new SolidBrush(Color.FromArgb(10, Color.White)), new Rectangle(3 * size / 4, 3 * size / 4, size / 2, size / 2));
            g.DrawLine(cursorPen, 0, size, size - 2, size);
            g.DrawLine(cursorPen, size + 2, size, 2 * size, size);
            g.DrawLine(cursorPen, size, 0, size, size - 2);
            g.DrawLine(cursorPen, size, size + 2, size, 2 * size);

            return bitmap;
        }
    }
}
