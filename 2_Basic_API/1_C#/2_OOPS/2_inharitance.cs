using System;

/*
 * contains: inheritance
 */

//inheritance: deriving properties from one class to another class. (a way to reuse the class)
//two main things: 
//1) base class (parent) : The class whose members are inherited 
//2) derived class (child) : The class which inherites base class. 

//possible inheritances 
/*
 * 1) single 
 * 2) multilevel
 * 3) hierarchical
 * 4) hybrid
*/

namespace Inheritance
{
    class Base
    {
        public int value;

        public Base(int value)
        {
            this.value = value;
            Console.WriteLine("Base class constructor completed");

        }

        //not be inherited 
        private void SayHello()
        {
            Console.WriteLine("Hello from Base");
        }

        public void MyValue()
        {
            Console.WriteLine(this.value);
        }
    }

    class Child : Base
    {
        public Child(int value) : base(value)
        {
            Console.WriteLine("Child class constructor completed");
        }

        public void ChildValue()
        {
            base.MyValue();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Child obj = new Child(5);

            obj.MyValue();
            obj.ChildValue();
            //obj.SayHello(); //throws error CS0122: 'Base.SayHello()' is inaccessible due to its protection level
            Console.WriteLine(obj.value);
        }

        
    }
}