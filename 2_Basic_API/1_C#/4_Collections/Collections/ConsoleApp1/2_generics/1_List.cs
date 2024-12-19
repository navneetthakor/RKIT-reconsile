using System;
using System.Collections.Generic;

//List is generic version of ArrayList
//it is strongly typed 
//no boxing/unboxing, provides type-safty

//behind the scene 
/*
 internally uses array with defaul size of '4'. (which we can get by 'Capacity' property of list) 
Once it runs out of space, it allocates new array of size double then previous and copies all the
old value to it.
 */

namespace ConsoleApp1._2_generics
{
    internal class _1_List
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            //list.Add("Navneet"); // throw error 

            Console.WriteLine(list.Count);  // actual filled number of positions
            Console.WriteLine(list.Capacity); // size of internal array

            // it has all the method as ArrayList has
            // difference is data_type change (object -> specific)

            list.Insert(0, 31);      // params: index, T
            list.Remove(1);      //params: T [ removes first occurence of T]
            list.RemoveAt(0);    // params: index
            list.Contains(1);    // params: T [bool return]
            list.Clear();    // makes list empty
            list.IndexOf(1); //params: T [first occurence from lhs, -1 if not found]
            //and many more 
        }
    }
}


