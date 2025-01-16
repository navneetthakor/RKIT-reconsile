using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//only about System.IO.Path class 
/*
Path class provides static methods for working with path
 */

namespace AdvanceAPI.File_System.Path_static
{
    internal class Tester
    {
        public static void TestNow()
        {
            string pathLocal = "F:\\Navneetkumar_421\\Hello\\sample.txt";

            //attributes ---- 
            Console.WriteLine(Path.DirectorySeparatorChar); // windows ? \ : /
            Console.WriteLine(Path.PathSeparator); // windows ? ';' : ':'
            //etc ... 

            //Methods ----- 
            
            Console.WriteLine(Path.GetExtension(pathLocal)); // result : .txt
            Console.WriteLine(Path.GetFileName(pathLocal)); // result : sample.txt
            Console.WriteLine(Path.GetFileNameWithoutExtension(pathLocal)); // result : sample
            Console.WriteLine(Path.GetFullPath(pathLocal)); // converts relative path to absolute
            Console.WriteLine(Path.GetDirectoryName(pathLocal)); // result : Hello
        }
    }
}
