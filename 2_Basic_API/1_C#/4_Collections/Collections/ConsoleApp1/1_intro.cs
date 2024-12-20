using System;
using System.Collections;   // non-generic
using System.Collections.Generic;   // generic

//two types of collections 

//1) Non-generic collections 
/*
-> stores everthing in terms of 'object', means Boxing and unboxing is major part
-> type safety is concern (it is in our hand -> correct type casting)
-> performance overhead due to boxing and unboxing
-> can store multiple type of data -> because internally it takes object -> ever data types are object
 */

//2) Generic collections
/*
-> comperatively newer then non-generic collections
-> directly stores items in their actual data type. 
-> therefore ( -> boxing/unboxing, type safty or performance issues does not arrises)
 */

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList: one  of non-generic data type
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("navneet");   // storing mixture of data-types

            foreach (object i in arrayList)
            {
                Console.WriteLine(i);
            }


            //List<T> : Generic data-type
            List<int> lst = new List<int>();
            lst.Add(1);
            lst.Add(2);
            //lst.Add("navneet"); //throws error CS1503: Argument 1: cannot convert from 'string' to 'int'

            Console.WriteLine("Generics :");
            foreach (int i in lst)
            {
                Console.WriteLine(i);
            }
        }
    }
}


/*

                                     ┌────────────────────────────┐
                                     │     IEnumerable<T>         │
                                     └────────────────────────────┘
                                                ▲
                                                │
                                     ┌────────────────────────────┐
                                     │     ICollection<T>         │
                                     └────────────────────────────┘
           ┌──────────────────────────────┬───────────────────────────────┬───────────────────────────────┬───────────────────────────────┐
           │                              │                               │                               │                               │
     ┌───────────────┐            ┌───────────────┐              ┌────────────────────┐         ┌───────────────────────┐      ┌──────────────────┐
     │   IList<T>    │            │   ISet<T>     │              │   IDictionary<K,V> │         │ IReadOnlyCollection<T> │      │    Queue<T>       │
     └───────────────┘            └───────────────┘              └────────────────────┘         └───────────────────────┘      └──────────────────┘
           ▲                              ▲                               ▲                              ▲                               ▲
           │                              │                               │                              │                               │
 ┌─────────────────┐         ┌────────────────────┐         ┌───────────────────────┐       ┌────────────────────┐         ┌─────────────────┐
 │     List<T>     │         │     HashSet<T>     │         │   Dictionary<K, V>    │       │ ReadOnlyCollection<T> │       │      Stack<T>     │
 └─────────────────┘         └────────────────────┘         └───────────────────────┘       └────────────────────┘         └─────────────────┘
                                   ▲                               ▲                                                               ▲
                                   │                               │                                                               │
                        ┌──────────────────────┐        ┌───────────────────────┐                                         ┌──────────────────────┐
                        │     SortedSet<T>     │        │  SortedDictionary<K,V> │                                         │      LinkedList<T>    │
                        └──────────────────────┘        └───────────────────────┘                                         └──────────────────────┘


iCollection : Add, Remove, Clear, Contains ...

*/
