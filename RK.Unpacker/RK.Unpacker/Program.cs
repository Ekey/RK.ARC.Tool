using System;
using System.IO;

namespace RK.Unpacker
{
    class Program
    {
        private static String m_Title = "Rocket Knight ARC Unpacker";

        static void Main(String[] args)
        {
            Console.Title = m_Title;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(m_Title);
            Console.WriteLine("(c) 2022 Ekey (h4x0r) / v{0}\n", Utils.iGetApplicationVersion());
            Console.ResetColor();

            if (args.Length != 2)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[Usage]");
                Console.WriteLine("    RK.Unpacker <m_File> <m_Directory>\n");
                Console.WriteLine("    m_File - Source of ARC file");
                Console.WriteLine("    m_Directory - Destination directory\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[Examples]");
                Console.WriteLine("    RK.Unpacker E:\\Games\\RK\\DATA.ARC D:\\Unpacked");
                Console.ResetColor();
                return;
            }

            String m_ArcFile = args[0];
            String m_Output = Utils.iCheckArgumentsPath(args[1]);

            if (!File.Exists(m_ArcFile))
            {
                Utils.iSetError("[ERROR]: Input ARC file -> " + m_ArcFile + " <- does not exist");
                return;
            }

            ArcUnpack.iDoIt(m_ArcFile, m_Output);
        }
    }
}