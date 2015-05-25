using System;

namespace FlexScreen
{
    public class UnZipEventArgs : EventArgs
    {
        public int Count { get; set; }
        public int Index { get; set; }
        public string zipName { get; set; }
        public string EntryName { get; set; }
        public Exception exception { get; set; }
    }
}
