using System;

namespace ExplicitImplementaion
{


interface IMyInterface
{
    void Display();
}

class MyClass : IMyInterface
{
    // Explicit implementation
    void IMyInterface.Display()
    {
        Console.WriteLine("Explicitly implemented Display method");
    }

    // A public method of MyClass
    public void Show()
    {
        Console.WriteLine("Public method of MyClass");
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyClass obj = new MyClass();

        // Accessing the public method
        obj.Show(); // Output: Public method of MyClass

         //obj.Display(); // Compile-time error: MyClass does not contain a definition for 'Display'

        // Accessing the explicitly implemented method
        IMyInterface interfaceObj = obj;
        interfaceObj.Display(); // Output: Explicitly implemented Display method
    }
}


}