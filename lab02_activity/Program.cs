using System;
using Person;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------Task 1------------------------------------------------");
            Console.WriteLine();
            Task1();

            Console.WriteLine("-----------------------------------------Task 2------------------------------------------------");
            Console.WriteLine();

            Task2();
            Task2("Rey");
            Task2("James", "Bond");

            Console.WriteLine("-----------------------------------------Task 3------------------------------------------------");
            Console.WriteLine();

            Task3();
            Console.WriteLine("-----------------------------------------Task 4------------------------------------------------");
            Console.WriteLine();

            Task4(1, 10);
            Console.WriteLine("-----------------------------------------Task 5------------------------------------------------");
            Console.WriteLine();

            Task5();
            Console.ReadLine();
        }

        private static void Task1()
        {
            var FirstName = "James";
            var LastName = "Bond";
            var FullName = FirstName + " " + LastName;
            Console.WriteLine("My Name is: " + FullName);
        }

        private static void Task2()
        {
            Console.WriteLine("I don't even know your name. Don't order me.");
        }

        private static void Task2(string first)
        {
            Console.WriteLine($"Cheers, {first}");
        }

        private static void Task2(string first, string last)
        {
            Console.WriteLine($"Cheers, {first} {last}");
        }

        private static void Task3()
        {
            Female female = new Female();
            female.Name = "Cindy";
            Console.WriteLine($"Her name is {female.Name}");
        }

        private static void Task4(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }

        private static void Task5()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Numbers in the array:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}

namespace Person
{
    public class Female
    {
        public string Name { get; set; }
    }
}
