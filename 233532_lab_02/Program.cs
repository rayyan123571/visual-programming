using System;

namespace UserInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------task 1-------------------------------------------------");
            Console.WriteLine();
            Task1();
            Console.WriteLine("-------------------------------------------task 2-------------------------------------------------");
            Console.WriteLine();
            Task2(args);
        }

        static void Task1()
        {
            string name, regNumber, address;
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter your registration number:");
            regNumber = Console.ReadLine();
            Console.WriteLine("Enter your address:");
            address = Console.ReadLine();
            Console.WriteLine("\n--- User Information ---");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Registration Number: " + regNumber);
            Console.WriteLine("Address: " + address);
        }

        static void Task2(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No command-line arguments were provided.");
            }
            else
            {
                Console.WriteLine("Command-line arguments:");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine($"Argument {i + 1}: {args[i]}");
                }
            }
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
