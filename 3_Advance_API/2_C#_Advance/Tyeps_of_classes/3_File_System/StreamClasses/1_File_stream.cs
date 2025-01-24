using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdvanceAPI.File_System.Stream.File_Stream
{
    internal class Tester
    {
        public static void TestNow()
        {
            //It provides a byte-level (low - level) interface for working with files.
            //supports both synchrouns and asynchrouns operations 

            //Constructor ---- 
            //FileStream(string path, FileMode mode, FileAccess? access, FileShare? share)
            FileStream fs = new FileStream("F:\\Navneetkumar_421\\Hello\\sample.txt", FileMode.Open, FileAccess.Read, FileShare.Read);

            //Methods ----
            //1) Read(byte[] array, int offset, int count)
            //offset: from where to start writing the data in byte array
            //count : maximum number of bytes to write in array
            byte[] byteArr = new byte[10];
            fs.Read(byteArr, 0, 10);
                
            foreach (byte b in byteArr)
            {
                Console.Write(Convert.ToChar(b));
            }
            Console.WriteLine();
            fs.Close();

            //2) Write(byte[] array, int offset, int count)
            fs = new FileStream("F:\\Navneetkumar_421\\Hello\\sample.txt", FileMode.Append, FileAccess.Write, FileShare.None);
            fs.Write(byteArr, 0, 10);
            fs.Close();

            //3) Seek(long offset, SeekOrigin origin)
            //offset: The byte position relative to the origin.
            //origin: A SeekOrigin value
            //-> seek not works with append mode
            fs = new FileStream("F:\\Navneetkumar_421\\Hello\\sample.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            fs.Seek(10, SeekOrigin.Begin);
            fs.Read(byteArr,0,10);

            foreach (byte b in byteArr)
            {
                Console.Write(Convert.ToChar(b));
            }

            fs.Close();



        }
    }
}
