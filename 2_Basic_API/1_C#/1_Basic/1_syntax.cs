//C# is strongly Object-oriented programming language 
//it have many simillarities with JAVA programming language
//C# files have '.cs' extension
//commenting is simillar to javascript 

//Basic code: 
using System;
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("helloworld");
            Console.Write("Navneet"); // not adds '\n' at the end
        }
    }
}

//let's understand above code in brief
    //-> using System: indicates that we are using System namespace
        //-> here namespace means logic/declarative region or scope 
        //-> we can group related classes etc.. 
        //-> it's simillar to JAVA packages but, only difference is that it's logical -> one file may have multiple namespaces 
    //-> Console: it's class of System namespace 