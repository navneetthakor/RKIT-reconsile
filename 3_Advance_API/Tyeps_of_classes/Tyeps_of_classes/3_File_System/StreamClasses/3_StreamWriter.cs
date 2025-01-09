using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceAPI.File_System.Stream.Stream_Writer
{
    internal class Tester
    {
        public static void TestNow()
        {
            //Stream writer class : provides efficient way to write data.
            //-> data can be in the format of string, int or custom object too.
            string path = "F:\\Navneetkumar_421\\Hello\\sample.txt";

            //Constructor ---- 
            //StreamWriter(string path)
            //StreamWriter(Stream stream)
            //StreamWriter(Stream stream, Encoding encoding)
            //StreamWriter(Stream stream, Encoding encoding, int bufferSize) 
            StreamWriter sw = new StreamWriter(path);

            //Methods & properties ----
            //1) Write() : Writes single character, string, char[] 
            sw.Write("\n from StreamWriter class\n");

            //2) flush() : to flush the data from primary memory to secondary memory
            sw.Flush();

            //3) WriteLine() : writes a line of text (string, char, object [in string representation] )
            //by adding line terminator 
            //-> internally both methods convets input value to their string format by using ToString method
            //so it is important to overrie 'ToString' method for custom objects
            sw.WriteLine("From StreamWriter class with WriteLine Method");

            //4) AutoFlush : to set or unset autoflusing
            Console.WriteLine(sw.AutoFlush);
            sw.AutoFlush = true; // now we not need to execute Flush() method

            //5) Encoding: to get character encoding being used
            Console.WriteLine(sw.Encoding);

            //4) close(): to close the stream 
            sw.Close();
        }
    }
}
