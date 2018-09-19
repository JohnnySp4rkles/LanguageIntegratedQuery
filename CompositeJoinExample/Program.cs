using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeJoinExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CompositeKeyJoinExample();
            Console.WriteLine();
            Console.Write("Press any key to continue. . .");
            Console.ReadLine();
        }

        public static void CompositeKeyJoinExample()
        {
            // Create a list of employees
            List<Employee> employees = new List<Employee> {
                new Employee { FirstName = "Terry", LastName = "Adams", EmployeeID = 522459 },
                new Employee { FirstName = "Charlotte", LastName = "Weiss", EmployeeID = 204467 },
                new Employee { FirstName = "Magnus", LastName = "Hedland", EmployeeID = 866200 },
                new Employee { FirstName = "Vernette", LastName = "Price", EmployeeID = 437139 }
            };

            // Create a list of Students
            List<Student> students = new List<Student>
            {
                new Student { FirstName = "Vernette", LastName = "Price", StudentID = 9562 },
                new Student { FirstName = "Terry", LastName = "Earls", StudentID = 9870 },
                new Student { FirstName = "Terry", LastName = "Adams", StudentID = 9913 }
            };

            IEnumerable<string> query =
                from employee in employees
                join student in students
                on new { employee.FirstName, employee.LastName }
                equals new { student.FirstName, student.LastName }
                select employee.FirstName + " " + employee.LastName;

            // Output the result to screen
            System.Console.WriteLine("These people are both, students and employees:");
            foreach (var item in query)
            {
                System.Console.WriteLine($"{item}");
            }
        }

        private class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int EmployeeID { get; set; }
        }

        private class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int StudentID { get; set; }
        }
    }
}