using System;
using System.Collections.Generic;

//Stack: Last in, first out

//Behind  the scene:
/*
-> internally uses array,
-> if capacity over -> allocate new one with double size then older -> copy all values
-> uses 'top' pointer mechanism to implement stack.
 */

namespace ConsoleApp1._2_generics
{
    internal class _4_Stack
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            //stack.Add(11);    // convert to ICollection and then use it
            stack.Push(1);
            stack.Push(42);
            stack.Push(43); // best & avg: O(1) , worst: O(n) due to resizing

            Console.WriteLine(stack.Pop()); // removes and returns top element  O(1)
            Console.WriteLine(stack.Peek()); // returns top element without removal O(1)
            // both of this operation throws runtime Exception: InvalidOperationException
            // if performed on empty stack
            // so, always look for Count first

            Console.WriteLine(stack.Count); // 'get' implementation O(1)
            Console.WriteLine(stack.Contains(42)); // params: data_type_value, bool return  O(n)

            int[] intArr = stack.ToArray(); // order is reverse of push O(n)

            foreach (int item in intArr)
            {
                Console.Write(item + " ");
            }

            stack.Clear(); // makes stack emptu O(1) [resets 'top' pointer, values are there]
        }
    }
}
