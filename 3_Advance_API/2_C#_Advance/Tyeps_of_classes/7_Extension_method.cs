using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceAPI.Extension_Method
{
    /// <summary>
    /// Extension method : is a type-specific static method that "extends" the functionality of existing types
    /// 
    /// How to do it:
    /// - create static class
    /// - create static method in that
    /// - first parameter must be 'this' keyword in front of the type it extends
    /// </summary>
    /// 

    static class StringFirstChar
    {
        public static char GetStrFirstChar(this string s) { return s[0]; }
    }

    internal class Tester
    {
        public static void TestNow()
        {
            string nk = "Navneetkumar";
            Console.WriteLine(nk.GetStrFirstChar());
            Console.WriteLine(StringFirstChar.GetStrFirstChar(nk)); // internall call like this
        }
    }
}
