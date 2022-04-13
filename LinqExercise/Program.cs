using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.WriteLine($"Average: {numbers.Average()}");


            //Order numbers in ascending order and decsending order. Print each to console.
            Console.WriteLine("-------");

            var ascOrder = numbers.OrderBy(x => x); 
            var descOrder = numbers.OrderByDescending(y => y);

            Console.WriteLine(("Ascending:"));
            foreach (var num in ascOrder)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("Descending:");
            foreach (var num in descOrder)
            {
                Console.WriteLine(num);
            }

            //Print to the console only the numbers greater than 6

            var greaterThanSix = numbers.Where(x => x > 6);
            Console.WriteLine("----");
            Console.WriteLine("Greater Than Six");
            foreach (var num in greaterThanSix)
            {
                Console.WriteLine(num);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("----");
            Console.WriteLine("Print 4 only");
            foreach (var num in descOrder.Take(4))
            {
                Console.WriteLine(num);
            }


            //Change the value at index 4 to your age, then print the numbers in decsending order
            
            Console.WriteLine("Change value [4] to age");
            numbers.SetValue(26, 4);

            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("Names C or S ascending");

            var filtered = employees.Where(person => person.FirstName
            .ToLower()
            .StartsWith('c') || person.FirstName
            .ToLower()[0] == 's')
            .OrderBy(person => person.FirstName);

            filtered.ToList().ForEach(x => Console.WriteLine(x.FirstName));

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            Console.WriteLine("Over 26 and order by Age then FirstName");
            var twentySix = employees.Where(x => x.Age > 26).OrderByDescending(x => x.Age).ThenBy(x=> x.FirstName);
            twentySix.ToList().ForEach(x => Console.Write(x.FirstName));

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            Console.WriteLine("YOE");
            var sumAndYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($"Total YOE: {sumAndYOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average YOE: {sumAndYOE.Average(x => x.YearsOfExperience)}");

            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Tylor", "Moore", 26, 1)).ToList();
            Console.WriteLine("Added Employee");

            employees.ForEach(x => Console.WriteLine(x.FullName));

            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
