using System;
using System.Collections.Generic;
using System.Linq;

namespace MyPrims
{
    public class SinglePrimeNumber
    {
        static void Main(string[] args)
        {
            //for single integer number 
            //-> if number 'n' is not prime then it must be divisible by at least one number
            //  between 2 <= x <= sqrt(n)
            //time Complexity : O(sqrt(n))

            int n = Convert.ToInt32(Console.ReadLine());

            bool isPrime = true;
            int upperBound = Convert.ToInt32(Math.Ceiling(Math.Sqrt(n)));

            for (int i = 2; i <= upperBound; i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine("It is a prime");
            }
            else
            {
                Console.WriteLine("Not a prime");
            }

#if DEBUG
            Console.WriteLine("Debug mode");
#else
            Console.WriteLine("Reales mode");
#endif

        }
    }


}
/*
namespace MyPrime2
{
    public class PrimeInRange
    {
        static void Main(string[] args)
        {
            //-> for range of prime numbers we could use sieve of erathosthenes algorithm 
            //-> only check for sqrt(limit) numbers to mark in range 
            //-> time complexity : O (n log log n) ( i just remembered not calculated)

            int n = Convert.ToInt32(Console.ReadLine());

            bool[] isPrimes = new bool[n + 1];  // default value: false
            isPrimes[0] = isPrimes[1] = true; // 0 - we not use, 1 - not a prime

            int upperBound = Convert.ToInt32(Math.Ceiling(Math.Sqrt(n)));

            for (int i = 2; i <= upperBound; i++)
            {
                for (int j = i * 2; j <= n; j += i)
                {
                    if (j % i == 0)
                    {
                        isPrimes[j] = true;
                    }
                }
            }

            for (int i = 2; i <= n; i++)
            {
                if (!isPrimes[i])
                {
                    Console.Write(i + ", ");
                }
            }

        }
    }
}
*/

// there are other probabilistic algorithms are there for very large nubmers 
//like : miller - Rabin test (we studied in Information Security Subject)