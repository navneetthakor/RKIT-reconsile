using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceAPI.Dynamic_Type
{
    /// <summary>
    /// Dynamic Type : allows for dynamic programming
    /// -> it bypasses compile-time type checking
    /// -> it defers type checking until runtime
    /// </summary>
    internal class Tester
    {
        public static void TestNow()
        {
            dynamic anjan = 10;
            Console.WriteLine(anjan.GetType());
            Console.WriteLine(anjan + "\n\n");

            anjan = "Navneet";
            Console.WriteLine(anjan.GetType());
            Console.WriteLine(anjan + "\n\n");


            /*
             *The object assigned to a dynamic variable may implement the IDynamicMetaObjectProvider interface, which provides more control over how dynamic behavior works.
                A well-known class that implements this interface is ExpandoObject. It allows you to add properties, methods, and events dynamically at runtime.
            */

        }
    }
}
