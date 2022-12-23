using System;

namespace RK.Unpacker
{
    class ArcEntry
    {
        public UInt32 dwNameHash { get; set; }
        public UInt32 dwOffset { get; set; }
        public Int32 dwCompressedSize { get; set; }
        public Int32 dwDecompressedSize { get; set; }
    }
}
