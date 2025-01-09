using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceAPI.Lamda_Expression
{
    internal class Tester
    {

        public static void TestNow()
        {
            // Lamda-Expression is basically shorthand for writting anonymous functions
            //-> mostly useful LINQ operations

            // syntx --
            //(parameters) => expression_or_block_of_code
            // - parameters : zero or more
            // - expression or block of code.

            //there are 3 types of Delegets use with Lambda expression
            //1) Func<> : Represents a method that returns a value
            //2) Action: Represents a method that does not return a value
            //3) Predicate: A special type of Func that takes one parameter and returns a boolean value

            /*
             * if lambda has single expression statemnet then it will be automatically returned
             * if it have block of code then explicit return statement required
             * Note that, if 'Action' deleget is used for inference then return void
             */

            //Single expression ----
            //1) Func
            Func<int,int,int> lmd1 = (a, b) => a + b;
            // - < ...variables, return_type>
            //- last type is always return type. in our case it's 'int'

            Func<int, string> lmd6 = n =>
            {
                Console.WriteLine("Input is : " + n);
                return "Fine";
            };

            //2) Action 
            Action lmd2 = () => Console.WriteLine(lmd1);
            Action<int> lmd3 = message => Console.WriteLine(message);
            //- < ...variable_type>

            Action<string> lmd5 = message =>
            {
                Console.WriteLine(message);
            };

            //3) Predicate 
            Predicate<int> lmd4 = n => n == 10;
           
        }
    }
}
