using System;
using System.Collections.Generic;

// HashSet: stores unique elements in unorder collection

//Efficient operations : Add, Remove, Contains in O(1) under normal condition
//set operations: union, intersect, except with other collections O(n)

//Behind the scene
/*
-> internally uses bucket (array)
-> using hash function -> calcuates has value -> put's in approriate bucket -> if collision happens
    - chaining will happend on the same bucket
-> if array runs out of space then resize it.
 */

namespace ConsoleApp1._2_generics
{
    internal class _5_HashSet
    {
        static void Main(string[] args)
        {
            HashSet<int> set = new HashSet<int>();
            set.Add(1); // O(1) generally
            set.Add(2);
            set.Add(1); // ommited

            foreach (int item in set)
            {
                Console.Write(item + " , ");
            } // output: 1 , 2

            set.Remove(1); // O(1) generally
            set.Contains(1); // bool return, O(1) generally

            // above methods can take O(n) in worst case but, it's extremly rare
            // as their hashfunction is powerful to avoid this condition

            set.Clear(); // O(n) [iterates over buckets]


            //below methods can take input: 
            //Array, Hashset, List, and other which implements IEnumerable<T> interface

            //examples 
            int[] arr = new int[] { 5, 2, 2, 3, 4, 5 };

            Console.WriteLine(set.IsSubsetOf(arr)); // O(n)
            Console.WriteLine(set.IsSupersetOf(arr)); // O(n)
            set.UnionWith(arr); // O(n)
            set.IntersectWith(arr); // O(n)
            set.ExceptWith(arr);    // removes all elements from current set which present in input collection

            

        }
    }
}
