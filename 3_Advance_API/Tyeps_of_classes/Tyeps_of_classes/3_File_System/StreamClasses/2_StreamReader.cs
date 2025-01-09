using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceAPI.File_System.Stream.Stream_Reader
{
    internal class Tester
    {
        //StreamReader provides efficient way to read data compare to File_Stream
        public static void TestNow()
        {
            string pathLocal = "F:\\Navneetkumar_421\\Hello\\sample.txt";

            //Constructor ---- 
            // StreamReader(string path) -> Encoding will be detected automatically (on the basis of Byte order Mark [BOM]
            // StreamReader(string path, Encoding encoding)
            //StreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks)
            StreamReader sr = new StreamReader(pathLocal);

            //methods ---- 
            //1) ReadLine : reads entire line. returns 'null' when reaches EOF
            String? line;
            while((line = sr.ReadLine()) != null) 
            {
                Console.WriteLine(line);
                Console.WriteLine();
            }

            //2) Read() : Reads the next character, returns '-1' when reaches EOF
            int? charValue;
            while ((charValue = sr.Read()) != -1)
            {
                Console.Write((char)charValue);
            }

        }
    }
}
