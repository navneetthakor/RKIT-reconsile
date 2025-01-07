using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdvanceAPI.File_System.File_Info
{
    internal class Tester
    {
        public static void TestNow()
        {
            // give absolute path, otherwise it will run into the trouble
            FileInfo fileInfo = new FileInfo("C:\\Users\\navneetkumar.t\\source\\repos\\navneetthakor\\RKIT-reconsile\\3_Advance_API\\Tyeps_of_classes\\Tyeps_of_classes\\3_File_System\\sample.txt");

            //attributes ----
            Console.WriteLine(fileInfo.FullName); // C:\Users\navneetkumar.t\Source\Repos\navneetthakor\RKIT-reconsile\3_Advance_API\Tyeps_of_classes\Tyeps_of_classes\bin\Debug\net7.0\sample.txt
            Console.WriteLine(fileInfo.Name);   // sample.txt
            Console.WriteLine(fileInfo.Extension); //.txt
            Console.WriteLine(fileInfo.CreationTime); // 01-01-1601 05:30:00
            Console.WriteLine(fileInfo.LastWriteTime); // 01-01-1601 05:35:00
            Console.WriteLine(fileInfo.LastAccessTime); // 01-01-1601 05:35:00
            Console.WriteLine(fileInfo.LastWriteTimeUtc); // 01-01-1601 00:00:00
            Console.WriteLine(fileInfo.Length); // 11
            Console.WriteLine(fileInfo.Directory); // C:\Users\navneetkumar.t\source\repos\navneetthakor\RKIT-reconsile\3_Advance_API\Tyeps_of_classes\Tyeps_of_classes\3_File_System

            //methods ---- 
            FileStream openfile = fileInfo.Open(FileMode.Append); // return 'FileStream' object
            fileInfo.Refresh(); // to referse state of file
               
            
        }
    }
}
