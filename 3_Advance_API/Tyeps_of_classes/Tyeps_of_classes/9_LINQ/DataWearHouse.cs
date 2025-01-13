using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceAPI.LINQ.DataWearHouse
{
    public enum GenderEnum
    {
        Male,
        Female,
        Others
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }

        public Employee(string name,int salary, int age, GenderEnum gender)
        {
            this.Name = name;
            this.Salary = salary;
            this.Age = age;
            this.Gender = gender;
        }
    }
    public class DataWearHouse
    {
        public static List<Employee> GetData()
        {
            return new List<Employee>()
            {
                new Employee("Navneet",46000,21,GenderEnum.Male),
                new Employee("Meet",42000,22,GenderEnum.Male),
                new Employee("Rohanshu",40000,26,GenderEnum.Male),
                new Employee("Riya",38000,27,GenderEnum.Female),
                new Employee("Richa",27000,20,GenderEnum.Female),
                new Employee("John",48000,29,GenderEnum.Male),
                new Employee("Sarah",50000,25,GenderEnum.Female),
                new Employee("Alex",47000,28,GenderEnum.Male),
                new Employee("Emily",45000,24,GenderEnum.Female),
                new Employee("David",49000,30,GenderEnum.Male),
                new Employee("Sophia",46000,23,GenderEnum.Female),
                new Employee("James",43000,32,GenderEnum.Male),
                new Employee("Olivia",52000,26,GenderEnum.Female),
                new Employee("William",51000,35,GenderEnum.Male),
                new Employee("Ella",55000,27,GenderEnum.Female),
                new Employee("Liam",54000,34,GenderEnum.Male),
                new Employee("Chloe",48000,22,GenderEnum.Female),
                new Employee("Benjamin",56000,31,GenderEnum.Male),
                new Employee("Mia",57000,33,GenderEnum.Female),
                new Employee("Isaac",59000,28,GenderEnum.Male),
                new Employee("Amelia",60000,29,GenderEnum.Female)
            };
        }
    }
}

