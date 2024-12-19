using System;
using System.Collections;
using System.Collections.Generic;

//alternative generic : List<T>

//-> arraylist dynamically grows 
//-> internally array stores data -> if array runns out of space 
//    - new array allocated with twice of length 

namespace ConsoleApp1._1_non_generics
{
    internal class MyArrayList
    {
        static void Main(string[] args)
        {
            ArrayList lst = new ArrayList();

            // methods
            lst.Add(1);     // params: object
            lst.Add("navneet");

            lst.Insert(0, 31);      // params: index, object
            lst.Remove(1);      //params: object [ removes first occurence of object]
            lst.RemoveAt(0);    // params: index
            lst.Contains(1);    // params: object [bool return]
            lst.Clear();    // makes arraylist empty
            lst.IndexOf(1); //params: object [first occurence from lhs, -1 if not found]
            Console.WriteLine(lst.Count);   // property : only 'get' implementation is there

        }
    }
}
