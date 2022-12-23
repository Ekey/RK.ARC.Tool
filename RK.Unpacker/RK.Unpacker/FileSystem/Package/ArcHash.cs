using System;

namespace RK.Unpacker
{
    class ArcHash
    {
        public static UInt32 iGetHash(String m_String)
        {
            UInt32 dwHash = 0;

            for (Int32 i = 0; i < m_String.Length; i++)
            {
                dwHash = m_String[i] ^ 33 * dwHash;
            }

            return dwHash;
        }
    }
}
