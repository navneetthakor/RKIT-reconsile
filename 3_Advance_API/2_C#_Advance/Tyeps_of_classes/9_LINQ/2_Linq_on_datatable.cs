
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Tyeps_of_classes._9_LINQ
{
    class Tester
    {
        public static void TestNow()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Department", typeof(string));
            dataTable.Columns.Add("Salary", typeof(long));

            dataTable.Rows.Add(1, "Navneet", "IT", 90000);
            dataTable.Rows.Add(2, "Meet", "IT", 62000);
            dataTable.Rows.Add(3, "Varun", "HR", 55000);
            dataTable.Rows.Add(4, "Rohanshu", "IT", 50000);

            // LINQ Queries on DataTable

            // 1. WHERE: Filter employees with Salary > 58000
            var highSalaryEmployees = dataTable.AsEnumerable()
                .Where(row => row.Field<long>("Salary") > 58000)
                .Select(row => new { Name = row.Field<string>("Name"), Salary = row.Field<long>("Salary") });
            Console.WriteLine("Employees with Salary > 58000:");
            foreach (var emp in highSalaryEmployees)
                Console.WriteLine($"Name: {emp.Name}, Salary: {emp.Salary}");

            // 2. SELECT: Project only Name and Department columns
            var selectedColumns = dataTable.AsEnumerable()
                .Select(row => new { Name = row.Field<string>("Name"), Department = row.Field<string>("Department") });
            Console.WriteLine("\nName and Department:");
            foreach (var emp in selectedColumns)
                Console.WriteLine($"Name: {emp.Name}, Department: {emp.Department}");

            // 3. ORDERBY: Order employees by Salary
            var orderedBySalary = dataTable.AsEnumerable()
                .OrderBy(row => row.Field<long>("Salary"));
            Console.WriteLine("\nEmployees Ordered by Salary:");
            foreach (var emp in orderedBySalary)
                Console.WriteLine($"Name: {emp.Field<string>("Name")}, Salary: {emp.Field<long>("Salary")}");

            // 4. THENBY: Order by Department, then by Name
            var orderedByDeptAndName = dataTable.AsEnumerable()
                .OrderBy(row => row.Field<string>("Department"))
                .ThenBy(row => row.Field<string>("Name"));
            Console.WriteLine("\nEmployees Ordered by Department and then Name:");
            foreach (var emp in orderedByDeptAndName)
                Console.WriteLine($"Department: {emp.Field<string>("Department")}, Name: {emp.Field<string>("Name")}");

            // 5. GROUPBY: Group employees by Department
            var groupedByDepartment = dataTable.AsEnumerable()
                .GroupBy(row => row.Field<string>("Department"));
            Console.WriteLine("\nEmployees Grouped by Department:");
            foreach (var group in groupedByDepartment)
            {
                Console.WriteLine($"Department: {group.Key}");
                foreach (var emp in group)
                    Console.WriteLine($"  Name: {emp.Field<string>("Name")}, Salary: {emp.Field<long>("Salary")}");
            }

            // 6. AGGREGATE: Calculate Total and Average Salary
            long totalSalary = dataTable.AsEnumerable().Sum(row => row.Field<long>("Salary"));
            double averageSalary = dataTable.AsEnumerable().Average(row => row.Field<long>("Salary"));
            Console.WriteLine($"\nTotal Salary: {totalSalary}");
            Console.WriteLine($"Average Salary: {averageSalary}");

            // 7. COUNT: Count employees in each Department
            var countByDepartment = dataTable.AsEnumerable()
                .GroupBy(row => row.Field<string>("Department"))
                .Select(group => new { Department = group.Key, Count = group.Count() });
            Console.WriteLine("\nEmployee Count by Department:");
            foreach (var dept in countByDepartment)
                Console.WriteLine($"Department: {dept.Department}, Count: {dept.Count}");
        }
    }

}