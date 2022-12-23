using System;

namespace RK.Unpacker
{
    class ArcHeader
    {
        public UInt32 dwUnknown { get; set; } // 64016
        public Int32 dwTotalFiles { get; set; }
        public Int32 dwTableSize { get; set; }
        public Int32 dwPadded { get; set; } // 0
    }
}
