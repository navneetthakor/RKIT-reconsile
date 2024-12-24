using System;

namespace MethodOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello("Navneet");
            Hello(21);

            MyMethod("Navneet");
            MyMethod(123);
            MyMethod("nk", 1);
            MyMethod(10L, 25);
            MyMethod(true, "nk");
        }

        static void Hello(string name)
        {
            Console.WriteLine($"My name is {name}.");
        }

        static void Hello(int age)
        {
            Console.WriteLine($"My age is {age}.");
        }

        //return type can't contribute to method overloading
        //error CS0111: Type 'Program' already defines a member called 'Hello' with the same parameter types
        //static int Hello(int age)
        //{
        //    Console.WriteLine($"My age is {age}.");
        //}

        //Methods are called overloaded iff:
        //they differes in number of params, types of params, order of params or any combination of this three

        //ambigoutiy will result in compile time error 
        //ambigouty can happen due to: 1) Default arguments & 2) implicity type conversion 
        //but C# have strong rules to select specific method, like in below methods there is no ambiguity

        // prefered when only string is passed
        static void MyMethod(string message)
        {
            Console.WriteLine($"Message is : {message}");
        }

        //when non-string object 
        static void MyMethod(object obj)
        {
            Console.WriteLine("only Object method");
        }

        //when string and int 
        static void MyMethod(string message, int a = 10)
        {
            Console.WriteLine($"Message is : {message} and 'a' is : {a}");
        }
        
        //when non-string with int
        static void MyMethod(object obj, int a = 10)
        {
            Console.WriteLine("Object method");
        }


        //--> order for method resoulution 
        //- exact mathch 
        //- implicit conversion 
        //- default arguments 
        //- ref/out/in Differentiation
        //- now throw error 

    }

}