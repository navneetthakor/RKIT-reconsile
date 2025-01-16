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
                //-> it can through several exception so make sure that file path is correct, and user haver writes 

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
            //1) create : Creates a new file or overwrites an existing file if it already exists.
            FileStream fs = fileInfo.Create();

            //2) open: opens file represented by file_info object with specified access
            fs = fileInfo.Open(FileMode.Append, FileAccess.Read, FileShare.None); // return 'FileStream' object
                //-> params: mode, access, share ( type of access that other objects can have onb this file)

            //3) refresh : resets the metadata of the file.
            fileInfo.Refresh(); // return : none

            //4) CopyTo : copy the current file to the new location
            fileInfo.CopyTo("C:\\Users\\navneetkumar.t\\source\\repos");
            //-> params: destination_location
            //-> it can through several exceptions 
            //i) UnauthorizedAccessException : when current user not have write access on destination location
            //ii) DirectoryNotFoundException : when any directory mentioned in the path not found
            //iii) IOException : related to any IO issue
            //etc ...

            //5) MoveTo : moves current file to destination location
            fileInfo.MoveTo("C:\\Users\\navneetkumar.t\\source\\repos");
                //-> it can through all the above exceptions 
            
        }
    }
}
