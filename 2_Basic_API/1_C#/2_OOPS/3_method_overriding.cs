using MethodOverriding1;
using System;

/*
 * contains: method overriding
 */

// method overriding in C# have to important keywords 
//1) virtual : add to base class (allow overriding)
//2) override : add to child class (override any previous method if that is virtual)

//method hidding 

namespace MethodOverriding1
{

    class BaseClass
    {
        public  void Speak()
        {
            Console.WriteLine("Base class speaking.");
        }
    }

    class DerivedClass : BaseClass
    {
        public  void Speak()
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

            BaseClass obj2 = new DerivedClass();
            obj2.Speak();  // Calls the base class method
        }
    }

}


//method overriding
//mark the base class method as virtual and derived class method as override 

namespace MethodOverriding2
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

            BaseClass obj2 = new DerivedClass();
            obj2.Speak();  // Calls the derived class method
        }
    }

}

//pitfalls:
//BaseClass: virtual, DerivedClass: none -> method hidding 
//BaseClass: virtual, DerivedClass: override -> Method overriding
//BaseClass: none, DerivedClass: none -> method hidding 
//BaseClass: none, DerivedClass: override -> compilation error

