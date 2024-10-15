using System;

namespace MultipleTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------Task 1-----------------------------------------------------");
            Console.WriteLine();
            Task1();
            Console.WriteLine("-------------------------------------Task 2-----------------------------------------------------");
            Console.WriteLine();
            Task2();
            Console.WriteLine("-------------------------------------Task 3-----------------------------------------------------");
            Console.WriteLine();
            Task3();
            Console.WriteLine("-------------------------------------Task 4-----------------------------------------------------");
            Console.WriteLine();
            Task4();
            Console.WriteLine("-------------------------------------Task 5-----------------------------------------------------");
            Console.WriteLine();
            Task5();
            Console.WriteLine("-------------------------------------Task 6-----------------------------------------------------");
            Console.WriteLine();
            Task6();
            Console.WriteLine("-------------------------------------Task 7-----------------------------------------------------");
            Console.WriteLine();
            Task7();
        }

        static void Task1()
        {
            Console.WriteLine("Task 1: Perform Basic Operations");
            Console.Write("Enter the first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double sum = num1 + num2;
            double difference = num1 - num2;
            double product = num1 * num2;
            double quotient = num2 != 0 ? num1 / num2 : double.NaN;

            Console.WriteLine($"\nResults:");
            Console.WriteLine($"{num1} + {num2} = {sum}");
            Console.WriteLine($"{num1} - {num2} = {difference}");
            Console.WriteLine($"{num1} * {num2} = {product}");

            if (num2 != 0)
            {
                Console.WriteLine($"{num1} / {num2} = {quotient}");
            }
            else
            {
                Console.WriteLine("Division by zero is undefined.");
            }
        }

        static void Task2()
        {
            Console.WriteLine("\nTask 2: Calculate Square of Numbers 1 to 10");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"The square of {i} is {CalculateSquare(i)}");
            }
        }

        static int CalculateSquare(int number)
        {
            return number * number;
        }

        static void Task3()
        {
            Console.WriteLine("\nTask 3: Temperature Conversion from Fahrenheit to Celsius");
            Console.Write("Enter temperature in Fahrenheit: ");
            double fahrenheit = Convert.ToDouble(Console.ReadLine());
            double celsius = ConvertFahrenheitToCelsius(fahrenheit);
            Console.WriteLine($"{fahrenheit} Fahrenheit is equal to {celsius} Celsius.");
        }

        static double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        static void Task4()
        {
            Console.WriteLine("\nTask 4: Calculate Factorial of a Given Number");
            Console.Write("Enter a number to calculate its factorial: ");
            int number = Convert.ToInt32(Console.ReadLine());
            long factorial = CalculateFactorial(number);
            Console.WriteLine($"The factorial of {number} is {factorial}");
        }

        static long CalculateFactorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            else
            {
                return number * CalculateFactorial(number - 1);
            }
        }

        static void Task5()
        {
            Console.WriteLine("\nTask 5: Check if a Number is Odd or Even");
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (IsEven(number))
            {
                Console.WriteLine($"{number} is even.");
            }
            else
            {
                Console.WriteLine($"{number} is odd.");
            }
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        static void Task6()
        {
            Console.WriteLine("\nTask 6: Calculate the Average Marks of the Class");
            Console.Write("Enter the number of students: ");
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());

            double totalMarks = 0;
            for (int i = 1; i <= numberOfStudents; i++)
            {
                Console.Write($"Enter the marks of student {i}: ");
                double marks = Convert.ToDouble(Console.ReadLine());
                totalMarks += marks;
            }

            double averageMarks = totalMarks / numberOfStudents;
            Console.WriteLine($"\nThe average marks of the class is: {averageMarks}");
        }

        static void Task7()
        {
            Console.WriteLine("\nTask 7: Find the Smallest Number Among Three Numbers");
            Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the third number: ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            int smallest = FindSmallest(num1, num2, num3);
            Console.WriteLine($"\nThe smallest number is: {smallest}");
        }

        static int FindSmallest(int num1, int num2, int num3)
        {
            if (num1 <= num2 && num1 <= num3)
            {
                return num1;
            }
            else if (num2 <= num1 && num2 <= num3)
            {
                return num2;
            }
            else
            {
                return num3;
            }
        }
    }
}
