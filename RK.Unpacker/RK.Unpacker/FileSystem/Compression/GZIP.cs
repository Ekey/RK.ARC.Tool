using System;
using System.IO;
using System.IO.Compression;

namespace RK.Unpacker
{
    class GZIP
    {
        public static Byte[] iDecompress(Byte[] lpBuffer)
        {
            var TOutMemoryStream = new MemoryStream();
            using (MemoryStream TMemoryStream = new MemoryStream(lpBuffer))
            {
                using (GZipStream TGZipStream = new GZipStream(TMemoryStream, CompressionMode.Decompress, false))
                {
                    TGZipStream.CopyTo(TOutMemoryStream);
                    TGZipStream.Dispose();
                }

                TMemoryStream.Dispose();
            }

            return TOutMemoryStream.ToArray();
        }
    }
}
