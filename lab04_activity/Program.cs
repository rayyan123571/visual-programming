using System;

namespace JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------task 1-----------------------------------");
            activity1();
            Console.WriteLine();
            Console.WriteLine("----------------------------------task 2-------------------------------------");
            activity2();
            Console.WriteLine();
            Console.WriteLine("----------------------------------task 3-------------------------------------");
            activity3();
            Console.WriteLine();
            Console.WriteLine("----------------------------------task 4-------------------------------------");
            activity4();
            Console.WriteLine();
        }

        private static void activity1()
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[2] { 7, 9 };
            jaggedArray[1] = new int[4] { 12, 42, 26, 38 };
            jaggedArray[2] = new int[6] { 3, 5, 7, 9, 11, 13 };
            jaggedArray[3] = new int[3] { 4, 6, 8 };

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write("Element({0}): ", i + 1);
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        private static void activity2()
        {
            int[][] jaggedArray1D = new int[3][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5 },
                new int[] { 6, 7, 8, 9 }
            };

            Console.WriteLine("1D Jagged Array:");
            for (int i = 0; i < jaggedArray1D.Length; i++)
            {
                Console.Write($"Array {i + 1}: ");
                foreach (int value in jaggedArray1D[i])
                {
                    Console.Write(value + "\t");
                }
                Console.WriteLine();
            }
        }

        private static void activity3()
        {
            int[][,] jaggedArray2D = new int[2][,]
            {
                new int[,] { {1, 2}, {3, 4} },
                new int[,] { {5, 6, 7}, {8, 9, 10} }
            };

            Console.WriteLine("\n2D Jagged Array (Formatted):");
            for (int i = 0; i < jaggedArray2D.Length; i++)
            {
                Console.WriteLine($"2D Array {i + 1}:");
                int rows = jaggedArray2D[i].GetLength(0);
                int cols = jaggedArray2D[i].GetLength(1);

                Console.Write("    ");
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"Col{col + 1}\t");
                }
                Console.WriteLine();

                for (int row = 0; row < rows; row++)
                {
                    Console.Write($"Row {row + 1}: ");
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(jaggedArray2D[i][row, col] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        private static void activity4()
        {
            string[] weekdays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            PrintArray(weekdays);
            ChangeArray(weekdays);
            Console.WriteLine("Arrays after the call to ChangeArray (reversed):");
            PrintArray(weekdays);
            Console.WriteLine();
            ChangeArrayElements(weekdays);
            Console.WriteLine("Arrays after changing individual elements:");
            PrintArray(weekdays);
            Console.ReadLine();
        }

        static void PrintArray(string[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }

        static void ChangeArray(string[] array)
        {
            Array.Reverse(array);
            Console.WriteLine("The first element after reversing is: {0}", array[0]);
        }

        static void ChangeArrayElements(string[] array)
        {
            if (array.Length > 2)
            {
                array[2] = "Tuesday";
            }
            if (array.Length > 3)
            {
                array[3] = "Wednesday";
            }
        }
    }
}
