using System;

/*
 * content about : enums
 */

//enums: a special "class" that represents a group of constants
//-> this constants can have integaral types only like (byte, sbyte, int, uint, long etc...)
//-> by default data type is : int 
//-> all constants in single enum must have same data type 

namespace Enums
{
    enum DaysOfWeek
    {
        Sunday,    // 0
        Monday,    // 1
        Tuesday,   // 2
        Wednesday, // 3
        Thursday,  // 4
        Friday,    // 5
        Saturday   // 6
    }

    //defining data type 
    enum Name : long
    {
        Navneet = 10L,
        Meet,   // 11L 
        Rohanshu = 15L,
        Kartavy // 16L (auto increment)
    }

    class Program
    {
        static void Main()
        {
            DaysOfWeek today = DaysOfWeek.Monday;
            Console.WriteLine(today);
            Console.WriteLine((int)DaysOfWeek.Monday);

            Name name = Name.Meet;
            Console.WriteLine(name);
            Console.WriteLine((long)name);
            Console.WriteLine((long)Name.Rohanshu);
            Console.WriteLine((long)Name.Kartavy);
        }
    }

}