using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace RK.Unpacker
{
    class ArcUnpack
    {
        private static List<ArcEntry> m_EntryTable = new List<ArcEntry>();

        public static void iDoIt(String m_Archive, String m_DstFolder)
        {
            ArcHashList.iLoadProject();
            using (FileStream TArcStream = File.OpenRead(m_Archive))
            {
                var m_Header = new ArcHeader();

                m_Header.dwUnknown = TArcStream.ReadUInt32();
                m_Header.dwTotalFiles = TArcStream.ReadInt32();
                m_Header.dwTableSize = TArcStream.ReadInt32();
                m_Header.dwPadded = TArcStream.ReadInt32();

                m_EntryTable.Clear();
                for (Int32 i = 0; i < m_Header.dwTotalFiles; i++)
                {
                    var m_Entry = new ArcEntry();

                    m_Entry.dwNameHash = TArcStream.ReadUInt32();
                    m_Entry.dwOffset = TArcStream.ReadUInt32();
                    m_Entry.dwCompressedSize = TArcStream.ReadInt32();
                    m_Entry.dwDecompressedSize = TArcStream.ReadInt32();

                    m_EntryTable.Add(m_Entry);
                }

                foreach (var m_Entry in m_EntryTable)
                {
                    String m_FileName = ArcHashList.iGetNameFromHashList(m_Entry.dwNameHash);
                    String m_FullPath = m_DstFolder + m_FileName;

                    Utils.iSetInfo("[UNPACKING]: " + m_FileName);

                    Utils.iCreateDirectory(m_FullPath);

                    TArcStream.Seek(m_Entry.dwOffset, SeekOrigin.Begin);

                    if (m_Entry.dwDecompressedSize == 0)
                    {
                        var lpSrcBuffer = TArcStream.ReadBytes(m_Entry.dwCompressedSize);
                        File.WriteAllBytes(m_FullPath, lpSrcBuffer);
                    }
                    else
                    {
                        var lpSrcBuffer = TArcStream.ReadBytes(m_Entry.dwCompressedSize);
                        var lpDstBuffer = GZIP.iDecompress(lpSrcBuffer);

                        File.WriteAllBytes(m_FullPath, lpDstBuffer);
                    }
                }

                TArcStream.Dispose();
            }
        }
    }
}
