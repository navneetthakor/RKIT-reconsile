using System;

namespace MyMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //static: means method belongs to class not it's instance 
            //void: returns type 
            //name_of_method: Pascal case 

            int sum = MySum(5, 10); // 5 and 10 arguments
            Console.WriteLine(sum);
            sum = MySum(5); // use of default params
            Console.WriteLine(sum);
            sum = MySub(b: 5, a: 10); // use of named args
            Console.WriteLine(sum);
            
            MyRef(ref sum);
            Console.WriteLine(sum);

            int b;
            MyOut(out b);
            Console.WriteLine(b);

            int a = 10;
            MyIn(in a);
        }

        //a and b : parameters
        static int MySum(int a, int b = 10)
        {
            return a + b;
        }

        static int MySub(int a, int b)
        {
            return a - b;
        }

        static void MyRef(ref int a)
        {
            a++;
            return; // optionl 
        }

        static void MyOut(out int b)
        {
            b = 31;
            return; //optional
        }

        static void MyIn(in int a)
        {
            //a++; // will throw error : cannot use 'a' right hand side
            Console.WriteLine(a);
            return; //optional
        }
    }
}

//types of params:
//1) Positional arguments
//2) Default arguments
    //-> this are optional
    //-> must be at the end of parms list 
    //-> means any non-default paramter is not allowd after encounter of default parameter in params list 
//3) named arguments 
//4) reference argument 
    //-> The variable must be initialized before being passed.
    //-> Use the ref keyword in both the method signature and the method call.
//5) output arguments 
    //-> to return multiple values from function 
    //-> very simillar to reference arguments, but only difference is:
            //-> out variable not need to be initialized before passing to method 
//6) in arguments 
    //-> to prevent mutability, means 'in' variable can't be modified inside function
    //-> same as reference variable, initialization is required before passing to method 
