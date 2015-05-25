using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using AxSHDocVw; // Use `aximp %SystemRoot%\system32\shdocvw.dll`
using IECaptComImports;

namespace FlexScreen
{
    public class RTFUtility
    {
        /*
         * http://iecapt.sourceforge.net/
         * 
        midl IECaptComImports.idl
        tlbimp IECaptComImports.tlb
        aximp %SystemRoot%\system32\shdocvw.dll
        csc /r:IECaptComImports.dll /r:AxSHDocVw.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll IECapt.cs
        */
        public Image RtfToImage(string rtf)
        {
            IHTMLDocument2 doc2 = (IHTMLDocument2)mWb.Document;
            IHTMLDocument3 doc3 = (IHTMLDocument3)mWb.Document;
            IHTMLElement2 body2 = (IHTMLElement2)doc2.body;
            IHTMLElement2 root2 = (IHTMLElement2)doc3.documentElement;

            // Determine dimensions for the image; we could add minWidth here
            // to ensure that we get closer to the minimal width (the width
            // computed might be a few pixels less than what we want).
            int width = Math.Max(body2.scrollWidth, root2.scrollWidth);
            int height = Math.Max(root2.scrollHeight, body2.scrollHeight);

            // Resize the web browser control
            mWb.SetBounds(0, 0, width, height);

            // Do it a second time; in some cases the initial values are
            // off by quite a lot, for as yet unknown reasons. We could
            // also do this in a loop until the values stop changing with
            // some additional terminating condition like n attempts.
            width = Math.Max(body2.scrollWidth, root2.scrollWidth);
            height = Math.Max(root2.scrollHeight, body2.scrollHeight);
            mWb.SetBounds(0, 0, width, height);

            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);

            _RECTL bounds;
            bounds.left = 0;
            bounds.top = 0;
            bounds.right = width;
            bounds.bottom = height;

            IntPtr hdc = g.GetHdc();
            IViewObject iv = doc2 as IViewObject;

            // TODO: Write to Metafile instead if requested.

            iv.Draw(1, -1, (IntPtr)0, (IntPtr)0, (IntPtr)0,
              (IntPtr)hdc, ref bounds, (IntPtr)0, (IntPtr)0, 0);

            g.ReleaseHdc(hdc);
            return image;

        }
    }
}
