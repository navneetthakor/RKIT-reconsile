using Interface;
using System;

/*
 * content about : Interface
 */

//interface : complete abstract class 
//-> all members by default : abstract and public 
//-> derived class have to implement all the abstract members 
//-> do not have to use 'override' keyword here 
//-> it doesn't has constructor but, abstract class has 
//-> Interfaces can contain properties and methods, but not fields.

namespace Interface
{
    interface Base
    {
        void SayName(string name);
    }

    class Derived1 : Base
    {
        //access specifier for implemented or inherited methods can't be change
        public void SayName(string name)
        {
            Console.WriteLine(name);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //single interface 
            Derived1 obj1 = new Derived1();
            obj1.SayName("navneet");

            //class + multiple interface 
            Interface2.Derived2 obj2 = new Interface2.Derived2();
            obj2.SayName("navneet");
            obj2.SayName2();
            obj2.SayABCHello();
        }
    }
}

//deriving class + multiple interfaces 
namespace Interface2
{
    class ABC
    {
        public void SayABCHello()
        {
            Console.WriteLine("SayABCHello");
        }
    }

    interface Base2
    {
        void SayName2();
    }

    //first class (atmost one) then all the interfaces in list 
    class Derived2 : ABC, Base2, Interface.Base
    {
        public void SayName2()
        {
            Console.WriteLine("SayName2");
        }

        public void SayName(string name)
        {
            Console.WriteLine(name);
        }
    }

}
