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
            Console.WriteLine("Sum of numbers[] : ");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Average of numbers[] : ");
            Console.WriteLine(numbers.Average());
            Console.WriteLine("---------------------------------------");


            //Order numbers in ascending order and decsending order. Print each to console.
            var numasc = numbers.OrderBy(num => num);
            Console.WriteLine("Print numbers[] in ascending order  :");
            foreach (var num in numasc)
            {
                Console.WriteLine(num);

            }

            Console.WriteLine("---------------------------------------");
            var numdesc = numbers.OrderByDescending(num => num);
            Console.WriteLine("Print numbers[] in descending order  :");
            foreach (var num in numdesc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("---------------------------------------");



            //Print to the console only the numbers greater than 6
            Console.WriteLine("Print numbers[] greater than 6 : ");
            var num6 = numbers.Where(num => num > 6);
            foreach (var num in num6)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("---------------------------------------");


            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Print numbers[] first 4 : ");
            var num4 = numbers.Take(4);
            foreach (var num in num4)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("---------------------------------------");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 46;
            var num4desc = numbers.OrderByDescending(num => num);
            Console.WriteLine("Change [4] to age, print numbers[] first 4 by descending: ");
            foreach (var num in num4desc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("---------------------------------------");


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            var empnamecs = employees.Where(emp => emp.FirstName[0] == 'C' || emp.FirstName[0] == 'S');
            Console.WriteLine("Employee's Fullname where name starts with c or s :");
            foreach(var emp in empnamecs)
            {
                Console.WriteLine(emp.FullName);
            }
            Console.WriteLine("---------------------------------------");
            //Order this in acesnding order by FirstName.
            var empnameasc = empnamecs.OrderBy(emp => emp.FirstName);
            Console.WriteLine("Ordered by first name. Instructions didnt say to print this list, but Im doing it  anyway in case it was an oversight.");
            foreach(var emp in empnameasc)
            {
                Console.WriteLine(emp.FullName);
            }
            Console.WriteLine("---------------------------------------");


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            var empover26 = employees.Where(emp => emp.Age > 26);
            Console.WriteLine("FullName and Age over 26 : ");
            foreach(var emp in empover26)
            {
                Console.WriteLine(emp.FullName, emp.Age);
            }
            Console.WriteLine("---------------------------------------");
            //Order this by Age first and then by FirstName in the same result.
            var empordered = empover26.OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);
            Console.WriteLine("Ordered by Age first, then by FirstName : ");

            foreach (var item in empordered)
            {
                Console.WriteLine($"{item.FullName}, {item.Age}");
            }
               
            
            Console.WriteLine("---------------------------------------");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var emp1035 = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35);
            Console.WriteLine("Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35");
            Console.WriteLine($"Sum of years of experience : {emp1035.Sum(emp => emp.YearsOfExperience)} , average of years of experience : {emp1035.Average(emp => emp.YearsOfExperience)}");
            Console.WriteLine("---------------------------------------");


            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Add an employee to the end of the list without using employees.Add()");
            employees = employees.Append(new Employee(firstName: "Adam", lastName: "Brannon", age: 46, yearsOfExperience: 10)).ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"Name : {emp.FirstName} {emp.LastName}, Age : {emp.Age}, Years of experience : {emp.YearsOfExperience}"); 
            }
            Console.WriteLine("---------------------------------------");

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
