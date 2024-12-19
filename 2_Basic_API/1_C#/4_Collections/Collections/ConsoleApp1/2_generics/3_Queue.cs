using System;
using System.Collections.Generic;

//Queue: first in first out (FIFO)


namespace ConsoleApp1._2_generics
{
    internal class _3_Queue
    {
        static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>()

            //to add values 
            q.Enqueue(1);   // O(1)
            q.Enqueue(2);

            Console.WriteLine(q.Dequeue()); // removes and returns object at begining O(1)
            Console.WriteLine(q.Peek());    // returns peek value O(1)
            // both of above throws : InvalidOperationException if size is 0

            //safe options 
            int result;
            Console.WriteLine(q.TryPeek(out result));
            Console.WriteLine(q.TryDequeue(out result));
            // returns true or false [use in if else]

            //or we can check size first 
            Console.WriteLine(q.Count); // only 'get' implemented O(1)

            q.Clear(); // clears queue O(n)


            //Convert queue to array O(n)
            int[] qArr = q.ToArray();

            //checke existance of any element 
            q.Contains(1); // params: item [ bool return ]
        }
    }
}
