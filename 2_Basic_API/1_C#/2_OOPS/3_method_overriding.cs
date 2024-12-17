using System;

/*
 * contains: method overriding
 */

// method overriding in C# have to important keywords 
//1) virtual : add to base class (allow overriding)
//2) override : add to child class (override any previous method if that is virtual)

//mark the base class method as virtual and derived class method as override 

namespace MethodOverriding
{

    class BaseClass
    {
        public virtual void Speak()
        {
            Console.WriteLine("Base class speaking.");
        }
    }

    class DerivedClass : BaseClass
    {
        public override void Speak()
        {
            Console.WriteLine("Derived class speaking.");
        }
    }

    class Program
    {
        static void Main()
        {
            DerivedClass obj = new DerivedClass();
            obj.Speak();  // Calls the derived class method
        }
    }

}