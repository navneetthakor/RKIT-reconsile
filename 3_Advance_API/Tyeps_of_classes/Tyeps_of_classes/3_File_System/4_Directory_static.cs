using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//only about System.IO.Directory class 
/*
Directory class provides static methods for common file operations,
such as creating, reading, writing, deleting, and checking if a file exists.
 */

// it is light weight version compare to DirectoryInfo class
//mostly used when we required single operation to perform 

namespace AdvanceAPI.File_System.Directory_static
{
    internal class Tester
    {
        public static void TestNow()
        {
            //1) CreateDirectory : isPresent ? ignore_operation : create_new_directory;
            var dd = Directory.CreateDirectory("F:\\Navneetkumar_421\\Hello");
                //-> params: path

            //2) Delete: deletes directory 
            Directory.Delete("F:\\Navneetkumar_421\\Hello"); // isDirectory_present && empty ? delete : Exception;
            Directory.Delete("F:\\Navneetkumar_421\\Hello", true); // isDirectory_present ? delete : Exception;
                                                             //-> params: path, (true/falst) (should be empty or not)

            //3) Exists
            Directory.Exists("./directory_static_nk"); // return : bool

            //4) GetFiles 
            string[] files = Directory.GetFiles("F:\\Navneetkumar_421\\Hello"); // returns fullpath
            foreach (string file in files) { Console.WriteLine(file); } 

            files = Directory.GetFiles("F:\\Navneetkumar_421\\Hello", "s*.txt"); // search option

            //5) GetDirectories 
            string[] directories = Directory.GetDirectories("F:\\Navneetkumar_421\\Hello"); //returns fullpath

            directories = Directory.GetDirectories("F:\\Navneetkumar_421\\Hello", "N*"); // search option

            //6) GetCreationTime 
            DateTime creationTime = Directory.GetCreationTime("F:\\Navneetkumar_421\\Hello");

            //7) SetCreationTime 
            Directory.SetCreationTime("F:\\Navneetkumar_421\\Hello", DateTime.Now); // return : void
        }
    }
}
