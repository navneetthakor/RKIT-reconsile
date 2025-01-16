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
        private static int joinedEmployee2;

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

            //3) Order By ---->
            //SELECT column_name FROM table ORDER BY column_name ASC| DESC;

            //Method syntax --
            List<Employee> orderedEmployee1 = employees.OrderBy(e => e.Name).ToList();
            //orderedEmployee1.ForEach(e => Console.WriteLine(e.Name));

            //Query syntx:
            List<Employee> orderedEmployee2 = (from e in employees
                                               orderby e.Name
                                               select e).ToList();
            //orderedEmployee2.ForEach(e => Console.WriteLine(e.Name));

            // multiple orders --
            orderedEmployee1 = employees.OrderBy(e => e.Name).ThenBy(e => e.Salary).ToList();
            //orderedEmployee1.ForEach(e => Console.WriteLine(String.Concat(e.Name, " , ", e.Salary))); 
            orderedEmployee2 = (from e in employees
                                orderby e.Name, e.Age
                                select e).ToList();
            //orderedEmployee2.ForEach(e => Console.WriteLine(String.Concat(e.Name, " , ", e.Salary)));

            // descending order --
            orderedEmployee1 = employees.OrderByDescending(e => e.Name).ThenByDescending(e => e.Salary).ToList();
            //orderedEmployee1.ForEach(e => Console.WriteLine(String.Concat(e.Name, " , ", e.Salary))); 
            orderedEmployee2 = (from e in employees
                                orderby e.Name descending, e.Age descending
                                select e).ToList();
            //orderedEmployee2.ForEach(e => Console.WriteLine(String.Concat(e.Name, " , ", e.Salary)));

            //4) Group By: ---->

            //Method syntx -- 
            var groupedEmployee1 = employees.GroupBy(e => e.Age).ToList();
            //groupedEmployee1.ForEach(e =>
            //{
            //    Console.WriteLine("Age : " + e.Key);

            //    var empl = e.ToList();
            //    empl.ForEach(e => Console.WriteLine(e.Name));
            //    Console.WriteLine();
            //});

            // Query Syntx: --
            var groupedEmployee2 = (from e in employees
                                    group e by e.Age into grouped
                                    select grouped).ToList();
            //groupedEmployee2.ForEach(e =>
            //{
            //    Console.WriteLine("Age : " + e.Key);

            //    var empl = e.ToList();
            //    empl.ForEach(e => Console.WriteLine(e.Name));
            //    Console.WriteLine();
            //});

            //5) Join ---->

            //Method Syntx: --
            var joinedEmployee1 = employees.Join(employees, emp1 => emp1.Name, emp2 => emp2.Name, (emp1, emp2) => new { Name1 = emp1.Name, Name2 = emp2.Name }).ToList();
            //joinedEmployee1.ForEach(e => Console.WriteLine(string.Concat(e.Name1, " , ", e.Name2)));

            //Query Syntx: -- 
            var joinedEmployee2 = (from e1 in employees
                                  join e2 in employees 
                                  on e1.Name equals e2.Name
                                  select new {Name1 = e1.Name, Name2 = e2.Name}).ToList();
            //joinedEmployee1.ForEach(e => Console.WriteLine(string.Concat(e.Name1, " , ", e.Name2)));

            //6) Having ---->

            //Method Syntx: --
            var havingEmployee1 = employees.GroupBy(e => e.Age).Where(gp => gp.Count() > 1).ToList();
            //havingEmployee1.ForEach(e =>
            //{
            //    Console.WriteLine("Age : " + e.Key);

            //    var empl = e.ToList();
            //    empl.ForEach(e => Console.WriteLine(e.Name));
            //    Console.WriteLine();
            //});

            var havingEmployee2 = (from e in employees
                                   group e by e.Age into grouped
                                   where grouped.Count() > 1
                                   select grouped).ToList();
            //havingEmployee2.ForEach(e =>
            //{
            //    Console.WriteLine("Age : " + e.Key);

            //    List<Employee> empl = e.ToList();
            //    empl.ForEach(e => Console.WriteLine(e.Name));
            //    Console.WriteLine();
            //});


            //------------------------------------------------------------------------------------
            /// <summary>
            /// Below methods may not have direct relation with any wel-known sql kewywords
            /// </summary>
            Employee eTemp = new Employee("Navneet", 46000, 21, GenderEnum.Male);

            //1) Any
            //-> checks if any  elements in the collection satisfy a given condition or not
            //-> if collecion is empty then : NullReferenceException
            //Console.WriteLine(employees.Any(e => e.Name == "Navneet"));

            //2) All
            //-> checks if all elements in the collection satisfy a given condition or not
            //-> for empty collection it return : true
            //Console.WriteLine(employees.All(e => e.Name == "Navneet"));

            //3) Contains
            //-> checks if a collection contains a specific value.
            //Console.WriteLine(employees.Contains(eTemp));

            //4) First 
            //-> returns first element of a collection which matches condition 
            //-> if collection is empty or no match then it will through exception
            //Console.WriteLine(employees.First(e => e.Age > 500)); // throws exception
            //Console.WriteLine(employees.First(e => e.Age > 20).Name);

            //5) FirstOrDefault
            //-> returns first or defualt element
            //Console.WriteLine(employees.FirstOrDefault(e => e.Age > 500)); // returns : null
            //Console.WriteLine(employees.First(e => e.Age > 20).Name);

            //6) Last 
            //-> returns last element which matches condition 
            //-> for empty collection it throughs exception 
            //Console.WriteLine(employees.Last(e => e.Age > 500)); // throws exception : invalid arguments
            //Console.WriteLine(employees.Last().Name);

            //6) LastOrDefault 
            //-> similar to FirstOrDefault but returns last element
            //Console.WriteLine(employees.FirstOrDefault(e => e.Age > 500)); // returns : null
            //Console.WriteLine(employees.First(e => e.Age > 20).Name);

            //7) Aggregate
            //-> similar to 'reduce' function in javascript 
            //-> it takes seed value and accumulator function
            //int totalSalary = employees.Aggregate(0,(acc, e) => acc + e.Salary);
            //Console.WriteLine(totalSalary);

            //8) Count 
            //-> counts the number of elements in a collection,
            //Console.WriteLine(employees.Count(e => e.Age == 21));

            //9) Skip
            //-> skips specified number of element

            //10) Take
            //-> Takes a specidfied number of element
            //employees.Skip(2).Take(5).ToList().ForEach(e => Console.WriteLine(e.Name));


            //11) Reverse
            //-> Reverse the order of elements in a collection 
            //-> it doesn't modify colleciton but, creates a reversed view
            //employees.Reverse();

            //12) DefaultIfEmpty -------------->>>>>>>><<<<<<<<<<<<
            //-> returns

            //13) Range ---->
            //-> generates a sequence of integers in a specified range 
            List<int> numbers = Enumerable.Range(1, 10).ToList();
            //numbers.ForEach(i => Console.WriteLine(i));

            //-----------------------------------------------------------------------------------
            /// <summary>
            /// Set related operations
            /// </summary>
            
            int[] set1 = new[] { 1, 2, 3, 4 };
            int[] set2 = new[] { 3, 4, 5, 6 };


            //1) Except ---->
            //-> returns set difference

            //set1.Except(set2).ToList().ForEach(i => Console.Write(i + " "));
            //Console.WriteLine();

            //2) Intersect ---->
            //-> returns common elements between two sequences.

            //set1.Intersect(set2).ToList().ForEach(i => Console.Write(i + " "));
            //Console.WriteLine();

            //3) union ---->
            //-> returns uninon of two sequences
            //set1.Union(set2).ToList().ForEach(i => Console.Write(i + " "));
            //Console.WriteLine();
        }
    }   
}
