using System;
using System.Collections.Generic;

namespace CombinedProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Initialize a two-dimensional array and print it
            Console.WriteLine("Task 1");
            InitializeAndPrint2DArray();
            Console.WriteLine();

            // Task 2: Combine strings
            Console.WriteLine("Task 2");
            CombineStrings();
            Console.WriteLine();

            // Task 3: Extract words with specified criteria
            Console.WriteLine("Task 3");
            ExtractAndPrintWords();
            Console.WriteLine();

            // Task 4: Summarize the frequency of ratings
            Console.WriteLine("Task 4");
            CalculateAndPrintRatingFrequency();
            Console.WriteLine();

            // Task 5: Convert Decimal to Binary and vice versa
            Console.WriteLine("Task 5");
            ConvertAndPrintNumbers();
            Console.WriteLine();

            // Task 6: Store and print test marks for 5 courses
            Console.WriteLine("Task 6");
            StoreAndPrintTestMarks();
            Console.WriteLine();

            // Task 7: Multiply two 3x3 matrices
            Console.WriteLine("Task 7");
            MultiplyMatrices();
            Console.WriteLine();

            Console.ReadLine(); // Wait for user input before closing
        }

        // Task 1: Print a two-dimensional array
        static void InitializeAndPrint2DArray()
        {
            int[,] numbers = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Print2DArray(numbers);
        }

        static void Print2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        // Task 2: Combine strings
        static void CombineStrings()
        {
            string[] s = { "hello ", "and ", "welcome ", "to ", "this ", "demo!" };
            string result = Merger(s);
            Console.WriteLine(result);
        }

        static string Merger(string[] strings)
        {
            return string.Concat(strings);
        }

        // Task 3: Extract words of length 4 to 5 that contain vowels
        static void ExtractAndPrintWords()
        {
            string input = "This is a sample text with various words";
            string[] extractedWords = ExtractWords(input);

            Console.WriteLine("Extracted Words:");
            foreach (string word in extractedWords)
            {
                Console.WriteLine(word);
            }
        }

        static string[] ExtractWords(string text)
        {
            string[] words = text.Split(' ');
            List<string> result = new List<string>();

            foreach (string word in words)
            {
                if (word.Length >= 4 && word.Length <= 5 && ContainsVowel(word))
                {
                    result.Add(word);
                }
            }

            return result.ToArray();
        }

        static bool ContainsVowel(string word)
        {
            return word.IndexOfAny(new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' }) >= 0;
        }

        // Task 4: Summarize the frequency of ratings
        static void CalculateAndPrintRatingFrequency()
        {
            int[] ratings = { 1, 2, 3, 2, 4, 5, 5, 3, 1, 2, 5, 4, 3, 1, 2, 3, 5, 4, 4, 5,
                              1, 2, 3, 2, 4, 5, 5, 3, 1, 2, 5, 4, 3, 1, 2, 3, 5, 4, 4, 5 };

            int[] frequency = new int[5];

            foreach (int rating in ratings)
            {
                if (rating >= 1 && rating <= 5)
                {
                    frequency[rating - 1]++;
                }
            }

            for (int i = 0; i < frequency.Length; i++)
            {
                Console.WriteLine($"Response {i + 1} given by: {frequency[i]} people");
            }
        }

        // Task 5: Convert Decimal to Binary and vice versa
        static void ConvertAndPrintNumbers()
        {
            Console.WriteLine("Enter a decimal number:");
            int decimalNumber = int.Parse(Console.ReadLine());
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine($"Binary of {decimalNumber} is {binary}");

            Console.WriteLine("Enter a binary number:");
            string binaryInput = Console.ReadLine();
            int decimalValue = BinaryToDecimal(binaryInput);
            Console.WriteLine($"Decimal of {binaryInput} is {decimalValue}");
        }

        static string DecimalToBinary(int number)
        {
            return Convert.ToString(number, 2);
        }

        static int BinaryToDecimal(string binary)
        {
            return Convert.ToInt32(binary, 2);
        }

        // Task 6: Store and print test marks for 5 courses
        static void StoreAndPrintTestMarks()
        {
            int[,] marks = new int[5, 10] // 5 Tests, 10 Students
            {
                { 92, 73, 86, 71, 97, 93, 95, 97, 80, 91 },
                { 90, 86, 81, 80, 78, 78, 82, 88, 88, 88 },
                { 99, 97, 89, 100, 77, 90, 78, 80, 78, 97 },
                { 79, 95, 79, 77, 89, 84, 81, 92, 80, 88 },
                { 72, 82, 97, 88, 90, 88, 80, 82, 83, 80 }
            };

            Console.WriteLine("Student Marks:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Test 1\tTest 2\tTest 3\tTest 4\tTest 5\tTest 6\tTest 7\tTest 8\tTest 9\tTest 10");

            for (int i = 0; i < marks.GetLength(0); i++)
            {
                Console.Write($"Test {i + 1}\t");
                for (int j = 0; j < marks.GetLength(1); j++)
                {
                    Console.Write(marks[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Calculate averages
            Console.WriteLine("Avg:");
            for (int j = 0; j < marks.GetLength(1); j++)
            {
                int sum = 0;
                for (int i = 0; i < marks.GetLength(0); i++)
                {
                    sum += marks[i, j];
                }
                Console.Write(sum / marks.GetLength(0) + "\t");
            }
            Console.WriteLine();
        }

        // Task 7: Multiply two 3x3 matrices
        static void MultiplyMatrices()
        {
            int[,] matrixA = new int[3, 3];
            int[,] matrixB = new int[3, 3];

            Console.WriteLine("Enter elements of Matrix A (3x3):");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"A[{i + 1},{j + 1}]: ");
                    matrixA[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Enter elements of Matrix B (3x3):");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"B[{i + 1},{j + 1}]: ");
                    matrixB[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int[,] result = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            Console.WriteLine("Resultant Matrix:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(result[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
