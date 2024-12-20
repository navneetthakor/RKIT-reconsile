using System;
using System.IO;

//file hierarchi 

/*

Object
 ├── FileSystemInfo (abstract class)
 │    ├── FileInfo
 │    └── DirectoryInfo
 ├── File
 ├── Directory
 ├── Stream
 │    ├── FileStream
 │    ├── StreamReader
 │    ├── StreamWriter
 │    ├── BinaryReader
 │    └── BinaryWriter
 └── Path

 */

//only about System.IO.File class 
/*
File class provides static methods for common file operations,
such as creating, reading, writing, deleting, and checking if a file exists.
 */


namespace BasicFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "./sample.txt";

            //check existance of file ----
            Console.WriteLine(File.Exists(path));

            //writing in file ----
            //-> below methods will create file if not exist and then write 
            //-> also they will remove older content 

            string myContent = "I live in India.";
            string[] myArrContent = { "hello.", "how are you?" };

            File.WriteAllText(path, myContent); // to write string
            File.WriteAllLines(path, myArrContent); // to write array of strings


            //below methods will append text ----
            File.AppendAllText(path, myContent); // append text
            File.AppendAllLines(path, myArrContent); //append array


            //Reading files ----
            string text = File.ReadAllText(path);
            string[] allText = File.ReadAllLines(path);

            //for lazy reading 
            Console.WriteLine("\n--- Lazy reading ---\n");
            foreach (string line in File.ReadLines(path))
            {
                Console.WriteLine(line);
            }

            //delete file 
            File.Delete(path); 
                // we must have access and rights to this file
                // file must be exist

            //and many more methods are there for move, copy etc... purpose
        }
    }
}