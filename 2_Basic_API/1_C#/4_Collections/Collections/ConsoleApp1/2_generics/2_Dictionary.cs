using System;
using System.Collections.Generic;

//Dictionary is collection key - value pair 
//where key is unique in entire dictionary

//behind the scene
/*
-> internally it uses Hashtable, where it generates hash using hash_function for each key and then
stores it in internal array of hashtable.
-> if collision happens then, concept of bucket chainning used
-> if internal array is filled 75% (load factor) then size of internal array will be increase to 
provide better time complexity performance.
-> time complexity: best & average -> O(1), worst case -> O(n)
 */

namespace ConsoleApp1._2_generics
{
    internal class _2_Dictionary
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> dict = new Dictionary<int,string>();

            dict.Add(1, "navneet");
            dict.Add(24, "Meet");
            dict.Add(31, "nk");
            dict.Add(33, "RB");
            //dict.Add(1, "meet");    // throws runtime error: iteam with same key exist
            Console.WriteLine(dict[1]);

            //----
            dict.Remove(31); // params: key
            //Console.WriteLine(dict[31]);    // throws runtime error: key not present 

            string value;
            if (dict.TryGetValue(31, out value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("key not exists");
            }

            //----
            Console.WriteLine(dict.ContainsKey(33));    // bool return
            Console.WriteLine(dict.ContainsValue("RB"));    // bool return [iterate over all values:  O(n) ]
            dict.Clear(); // clears dictionary

            Console.WriteLine(dict.Count); // only 'get' is implemented [always O(1)]

            Dictionary<int,string>.KeyCollection keys = dict.Keys;
            Dictionary<int, string>.ValueCollection values = dict.Values;




        }
    }
}
