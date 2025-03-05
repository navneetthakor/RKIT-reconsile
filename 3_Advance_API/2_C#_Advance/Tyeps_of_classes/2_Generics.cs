using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceAPI.Generics
{
    //Generics 
        //-> This are  classes, methods, interface etc. that have placeholders for one or more types that they used
        //-> It provides type safety, code reusability and performance

    //1) generic method
    class GenericMethod
    {
        public static T GetData<T>(T data_type)
        {
            return data_type;
        }
    }

    //2) generic class 
    class GenericClass <T> where T : struct // other : class, new(), someBaseClassName, someInteraceName
    {
        public T data_type;
        public GenericClass(T data_type) 
        {
            this.data_type = data_type;
        }

        public T GetData() { return data_type; }

        public void PrintData() { Console.WriteLine(this.data_type); }
    }

    //3) generic Interface 
    interface IGeneric<T>
    {
        T GetData();
        void PrintData(T data);
    }

    //here we can make Derived class generic or we can directl pass data type like 'IGeneric<int>'
    class GenericInterface<T> : IGeneric<T>
    {
        public T data_type;
        public GenericInterface(T data_type)
        {
            this.data_type = data_type;
        }

        public T GetData() { return data_type; }

        public void PrintData(T data) { Console.WriteLine(this.data_type); }
    }

    class Tester
    {
        public static void TestNow()
        {
            //testing method 
            Console.WriteLine("Testing Generic Method");
            Console.WriteLine(GenericMethod.GetData<int>(10));

            //testing class 
            Console.WriteLine("\n\nTesting Generic Class");
            GenericClass<int> gc = new GenericClass<int>(11);
            Console.WriteLine(gc.GetData());
            gc.PrintData();

            //testing interface implementation 
            Console.WriteLine("\n\nTesting Generic Interface");
            GenericInterface<int> gi = new GenericInterface<int>(12);
            gi.PrintData(gc.GetData());
        }
    }
}
