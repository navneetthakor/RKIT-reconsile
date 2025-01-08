using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdvanceAPI.File_System.Directory_Info
{
    internal class Tester
    {
        public static void TestNow()
        {
            //Creating directory info object 
            DirectoryInfo directoryInfo = new DirectoryInfo("./");

            //attributes ----
            Console.WriteLine(directoryInfo.FullName); // C:\Users\navneetkumar.t\source\repos\navneetthakor\RKIT-reconsile\3_Advance_API\Tyeps_of_classes\Tyeps_of_classes\bin\Debug\net7.0\
            Console.WriteLine(directoryInfo.Name); // net7.0
            Console.WriteLine(directoryInfo.Parent); // C:\Users\navneetkumar.t\source\repos\navneetthakor\RKIT-reconsile\3_Advance_API\Tyeps_of_classes\Tyeps_of_classes\bin\Debug
            Console.WriteLine(directoryInfo.Root); // C:\
            Console.WriteLine(directoryInfo.Exists); // True
            Console.WriteLine(directoryInfo.CreationTime); // 07-01-2025 11:31:05
            Console.WriteLine(directoryInfo.LastWriteTime); // 07-01-2025 13:11:06
            Console.WriteLine(directoryInfo.LastAccessTime); // 07-01-2025 13:11:06

            //methods ----
            //1) Create: creates the directory if it not exist 
            directoryInfo.Create();

            //2) CreateSubdirectory : creates sub directory with given name 
            directoryInfo.CreateSubdirectory("MySubDirectory_421_nk");

            //3) to delete the directory 
            directoryInfo.Delete(); // isEmpty ? delete_it : throw_IOException
            directoryInfo.Delete(true); // deletes directory with all its content

            //4) GetFiles 
            //returns array of fileInfo for each file  for current level only
            FileInfo[] fileInfoArr = directoryInfo.GetFiles();

            //filter at current level 
            fileInfoArr = directoryInfo.GetFiles("Na*t.{txt,c}");

            //returns file from each subdirector too 
            fileInfoArr = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
            //-> params: search_pattern, serach_option 

            //5) MoveTo 
            directoryInfo.MoveTo("../hello");

            //6) GetDirectories
            //at current level
            DirectoryInfo[] directoryInfoArr = directoryInfo.GetDirectories();

            //filter at current level 
            directoryInfoArr = directoryInfo.GetDirectories("Na*t"); // starting with "Na" and ending with "t"

            // from all the levels
            directoryInfoArr = directoryInfo.GetDirectories("*", SearchOption.AllDirectories);
        }
    }
}
