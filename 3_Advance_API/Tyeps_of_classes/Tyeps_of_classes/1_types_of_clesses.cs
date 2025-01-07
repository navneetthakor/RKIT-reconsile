using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceAPI.Typs_of_classes
{
    //1) normal class
    internal class NormalClass
    {
        public string Name { get; set; }
        public NormalClass(string name)
        {
            Name = name;
        }
    }

    //2) Abstract class : cannot be instantiated
    abstract class MyAbstractClass
    {
        public string Name { get; set; }
        public MyAbstractClass(string name)
        {
            Name = name;
        }
    }

    //3) Sealed class : cannot be inherited
    sealed class FinalClass
    {
        public string Name { get; set; }
        public FinalClass(string name)
        {
            Name = name;
        }
    }

    //4) static class : A static class cannot be instantiated and can only contain static members
    static class MyStatic
    {
        //public string hello; // throws compile time error

        static public string hello = "hello team"; // we have to initilized it over here
        //MyStatic() { } // error : static class cannot have constructor

        public static void HelloMethod()
        {
            Console.WriteLine(hello);
        }
    }

    //5) partical classes
    // - A partial class allows a class to be split across multiple files.This is helpful for large projects or for auto-generated code.
    // - All parts of the partial class must have the same access modifier and namespace, and they must be defined with the partial keyword.
    partial class Person
    {
        public string Name { get; set; }
    }
    partial class Person
    {
        Person(string name)
        {
            Name = name;
        }
    }

    //6) Nested class
    // - It is a class defined within another class
    // - it can assess private members of out class
    // - mainly used for creating a data sturcture

    class Register
    {
        private class Employee
        {
            static int IdCounter = 0;
            public string Name { get; set; }
            public int Id { get; set; }

            public Employee(string name)
            {
                Name = name;
                Id = ++IdCounter;
            }
        }

        List<Employee> empList = new List<Employee>();

        public int AddEmploye(string name)
        {
            Employee newEmployee = new Employee(name);
            empList.Add(newEmployee);
            return newEmployee.Id;

        }
    }

    //7) generic class
    // - A generic class is a class that can work with any data type. The data type is specified at the time of instantiation.
    class MyGeneric <T>
    {
        public T id;

        public MyGeneric(T userID) { id = userID; }

        public T GetId()
        {
            return id;
        }
    }

    //9) record class : find more things

    public class Tester
    {
        public static void TestNow()
        {
            MyGeneric<int> ng = new MyGeneric<int>(1);
            Console.WriteLine(ng.GetId());
        }
    }

}
