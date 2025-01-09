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
            sr.Close();

            //2) Read() : Reads the next character, returns '-1' when reaches EOF
            sr = new StreamReader(pathLocal);
            int? charValue;
            while ((charValue = sr.Read()) != -1)
            {
                Console.Write((char)charValue);
            }

            //3) ReadToEnd : To read entire content 
            sr = new StreamReader(pathLocal);
            line = sr.ReadToEnd();
            Console.WriteLine(line);

            //4) Peek : simillar to 'Read' but only difference is, this is not consuming character
            Console.WriteLine(sr.Peek());
            sr.Close();
    
            //--------------------------------------- 
            //-> Although StreamReader provides efficient way to read from file, but where we loss conrol
            //over setting byte pointer as this file not have byte level control

            //-> So, solution fo this is
            //- create FileStream object (other then append mode)
            //- now pass this object to StreamReader class\
            //- whenever you need to change position at that moment
            //use FileStream object to do that
        }
    }
}
