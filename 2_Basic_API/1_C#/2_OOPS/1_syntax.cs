using System;

/*
 * content about : class structur, access specifier, constructor, getter-setter
 */

//OOPs: Object-Oritented Programming 
//two important things 
//1) class : template to create instance/object
//2) object : instance of class which have memory associated (in heap)

namespace OOPS
{
    //Access modifiers
    /*
    - private : within a class
    - public : from any class
    - protected : same class and derived classes
    - internal : own assembly
    - protected internal : own assembly and and derived class outside of assembly
    - private protected : in same class and derived class but within same assembly
    */

    //Default behaviours 
    //- Top-level items like class, interface : default internal 
    //- all members within class : default private 

    class Animal
    {
        public string name;
        private int age;

        //constructor 
        //if we not specify constructor then C# create defualt constructor for us 
        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        //overloaded constructor 
        public Animal(string name)
        {
            this.name = name;
            this.age = 18;
        }

        //getter - setter for private fields 
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 18) age = value;
            }
        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal dog = new Animal("Rocky", 5);
            Animal Lion = new Animal("Mac");

            Console.WriteLine(dog.Age);
            Console.WriteLine(Lion.Age);

            Lion.Age = 5; // not work as we set condition in setter for Age
            //Lion.age = 10; //throws error CS0122: 'Animal.age' is inaccessible due to its protection level

            Console.WriteLine(Lion.Age);
        }
    }
}