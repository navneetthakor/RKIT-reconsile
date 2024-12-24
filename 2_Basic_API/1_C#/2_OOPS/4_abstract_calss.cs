using System;

/*
 * content about : abstract class and method
 */

//abstraction: process of hidding certain details and showing only essential information 

//-> abstract class : which can't be instantiated (main goal),
//-> inherite it first and define all the abstract methods of it and then,
//-> we able to create object of derived class.
//-> it can have zero or more abstract and concrete both methods 

//-> abstract method : which have only signature no body
//-> can only be written in abstract class 

namespace AbstractCalss
{
    abstract class Base
    {
        //add virtual keyword here 
        public abstract string Speak();
        public void MyType()
        {
            Console.WriteLine("Animal");
        }
    }

    class Derived : Base 
    {
        //hidding not valid
        //throws error CS0534: 'Derived' does not implement inherited abstract member 'Base.Speak()'
        //public string Speak()
        //{
        //    Console.WriteLine("I am Animal");
        //}

        //override like this 
        public override string Speak()
        {
            Console.WriteLine("I am Animal");
            return "nk";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Base obj1 = new Base(); // thorws error CS0144: Cannot create an instance of the abstract type or interface 'Base'

            Derived obj2 = new Derived();
            obj2.Speak();
            obj2.MyType();

        }
    }

}