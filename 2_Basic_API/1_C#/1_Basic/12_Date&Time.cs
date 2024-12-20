using System;

//DateTime object represnts instance in time
//this objects are immutable in nature 

namespace MyDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            //properties 
            DateTime currentDate = DateTime.Now;
            Console.WriteLine(currentDate);  // result: Current date and time

            DateTime today = DateTime.Today;
            Console.WriteLine(today);  // result: Current date with time set to 00:00:00

            DateTime utcNow = DateTime.UtcNow;
            Console.WriteLine(utcNow);  // result: Current date and time in UTC

            DateTime minDate = DateTime.MinValue;
            Console.WriteLine(minDate);  // result: 01/01/0001 00:00:00

            //methods 
            //Add days, hours [double] , months, years [int] etc
            
            DateTime addDay = DateTime.Now.AddDays(1.5);
            Console.WriteLine(addDay);  // 36 hours added

            DateTime addYears = DateTime.Now.AddYears(1);
            Console.WriteLine(addYears); // 1 year added

            //comparistions 
            int comparision = DateTime.Compare(addDay, minDate); 
            Console.WriteLine(comparision);
            // -1 (first smaller) , 0 (equal), 1 (first greater)

            bool comparision2 = addDay.Equals(addYears); // checks for equality
            Console.WriteLine(comparision2);


            //time span object 
            TimeSpan diffr = addDay - addYears;
            Console.WriteLine(diffr);   // -363.12:00:00


            //methods for parsing 
            //ToString, Parse, TryParse 

            //etc...


        }

    }
}