using System;
using System.Collections.Generic;
using System.Dynamic;
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


            //ExpandObject -- can add properties or methods dynamically
            dynamic nk = new ExpandoObject();
            Console.WriteLine(nk.GetType());
            Console.WriteLine(nk + "\n\n");

            try
            {
                Console.WriteLine(nk.name);
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            nk.name = " Navneet";
            Console.WriteLine(nk.name);

        }
    }
}
