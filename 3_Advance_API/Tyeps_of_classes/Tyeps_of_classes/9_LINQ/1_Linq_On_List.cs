using AdvanceAPI.LINQ.DataWearHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceAPI.LINQ.Linq_On_List
{
    internal class Tester
    {
        public static void TestNow()
        {
            List<Employee> employees = DataWearHouse.DataWearHouse.GetData();

            //1) Select ----
            // select column_name from table;

            // method syntx:
            var selectedEmployee1 = employees.Select(e => new { e.Name, e.Gender}).ToList();
            //selectedEmployee1.ForEach(e => Console.WriteLine(string.Concat(e.Name, " , " ,e.Gender)));

            // query syntx:
            var selectedEmployee2 = (from e in employees
                                select new {e.Name, e.Gender}).ToList();
            //selectedEmployee2.ForEach(e => Console.WriteLine(string.Concat(e.Name, " , ", e.Gender)));

            //2) Where ----
            //select column_name from table where condition;

            //Method Syntx:
            List<Employee> whereEmployee1 = employees.Where(e => e.Salary > 45000).ToList();
            //whereEmployee1.ForEach(e => Console.WriteLine(string.Concat(e.Name, " , ", e.Salary)));

            //query syntx:
            List<Employee> whereEmployee2 = (from e in employees
                                             where e.Salary > 45000
                                             select e).ToList();
            //whereEmployee2.ForEach(e => Console.WriteLine(string.Concat(e.Name, " , ", e.Salary)));

            //3) Order By ----
            //SELECT column_name FROM table ORDER BY column_name ASC| DESC;

            //Method syntax ----
            List<Employee> orderedEmployee1 = employees.OrderBy(e => e.Name).ToList();
            //orderedEmployee1.ForEach(e => Console.WriteLine(e.Name));

            //Query syntx:
            List<Employee> orderedEmployee2 = (from e in employees
                                               orderby e.Name
                                               select e).ToList();
            //orderedEmployee2.ForEach(e => Console.WriteLine(e.Name));

            // multiple orders ---- 
            orderedEmployee1 = employees.OrderBy(e => e.Name).ThenBy(e => e.Salary).ToList();
            //orderedEmployee1.ForEach(e => Console.WriteLine(String.Concat(e.Name, " , ", e.Salary))); 
            orderedEmployee2 = (from e in employees
                                orderby e.Name, e.Age
                                select e).ToList();
            orderedEmployee2.ForEach(e => Console.WriteLine(String.Concat(e.Name, " , ", e.Salary)));
        }
    }
}
