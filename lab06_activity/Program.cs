using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab6ac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running List Program:");
            Console.WriteLine("-------------------------------------Activity 01------------------------------------------------------");
            ListProgram(); // Call to the List-based program

            Console.WriteLine("\n---------------------------\n");

            Console.WriteLine("Running Dictionary Program:");
            Console.WriteLine("-------------------------------------Activity 02------------------------------------------------------");
            DictionaryProgram(); // Call to the Dictionary-based program

            Console.WriteLine("\n---------------------------\n");

            Console.WriteLine("Running ArrayList Program:");
            Console.WriteLine("-------------------------------------Activity 03------------------------------------------------------");
            ArrayListProgram(); // Call to the ArrayList-based program

            Console.WriteLine("\n---------------------------\n");

            Console.WriteLine("Running Student Grades Program:");
            Console.WriteLine("-------------------------------------Activity 04------------------------------------------------------");
            StudentGradesProgram(); // Call to the Student Grades program

            Console.ReadLine();
        }

        // List-based program
        static void ListProgram()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter 5 numbers:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Number {i + 1}: ");
                int num = int.Parse(Console.ReadLine());
                numbers.Add(num);
            }

            DisplayNumbers(numbers, "Numbers in the list:");

            numbers.Sort();
            DisplayNumbers(numbers, "Sorted numbers in the list:");

            Console.WriteLine("\nEnter a number to remove from the list:");
            int numberToRemove = int.Parse(Console.ReadLine());

            if (numbers.Contains(numberToRemove))
            {
                numbers.Remove(numberToRemove);
                Console.WriteLine($"\nNumber {numberToRemove} has been removed.");
            }
            else
            {
                Console.WriteLine($"\nNumber {numberToRemove} is not in the list.");
            }

            DisplayNumbers(numbers, "Numbers in the list after removal:");
        }

        static void DisplayNumbers(List<int> numbers, string message)
        {
            Console.WriteLine($"\n{message}");
            foreach (int n in numbers)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }

        // Dictionary-based program
        static void DictionaryProgram()
        {
            Dictionary<string, int> countries = new Dictionary<string, int>()
            {
                { "USA", 1 },
                { "France", 2 },
                { "Japan", 3 },
                { "India", 4 }
            };

            DisplayDictionary(countries, "Original dictionary:");

            var sortedCountries = countries.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            DisplayDictionary(sortedCountries, "Sorted dictionary:");

            int numberToCheck = 3;
            if (countries.ContainsValue(numberToCheck))
            {
                string country = countries.First(pair => pair.Value == numberToCheck).Key;
                Console.WriteLine($"\nThe dictionary contains the number {numberToCheck}, which is associated with {country}.");
            }
            else
            {
                Console.WriteLine($"\nThe number {numberToCheck} is not found in the dictionary.");
            }

            string countryToRemove = "France";
            if (countries.ContainsKey(countryToRemove))
            {
                countries.Remove(countryToRemove);
                Console.WriteLine($"\n{countryToRemove} has been removed from the dictionary.");
            }
            else
            {
                Console.WriteLine($"\n{countryToRemove} is not found in the dictionary.");
            }

            DisplayDictionary(countries, "Dictionary after removal:");
        }

        static void DisplayDictionary(Dictionary<string, int> dict, string message)
        {
            Console.WriteLine($"\n{message}");
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        // ArrayList-based program
        static void ArrayListProgram()
        {
            ArrayList numbers = new ArrayList() { 1, 2, "rayyan", "taha", 5 };

            DisplayArrayList(numbers, "ArrayList elements:");

            RemoveElementFromArrayList(numbers, 2);
            DisplayArrayList(numbers, "ArrayList after removal:");

            CheckContainsInArrayList(numbers, 3);
        }

        static void DisplayArrayList(ArrayList arrayList, string message)
        {
            Console.WriteLine($"\n{message}");
            foreach (var item in arrayList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void RemoveElementFromArrayList(ArrayList arrayList, int element)
        {
            if (arrayList.Contains(element))
            {
                arrayList.Remove(element);
                Console.WriteLine($"\nElement {element} has been removed.");
            }
            else
            {
                Console.WriteLine($"\nElement {element} is not in the ArrayList.");
            }
        }

        static void CheckContainsInArrayList(ArrayList arrayList, int element)
        {
            if (arrayList.Contains(element))
            {
                Console.WriteLine($"\nArrayList contains the element {element}.");
            }
            else
            {
                Console.WriteLine($"\nArrayList does not contain the element {element}.");
            }
        }

        // Student Grades Program
        static void StudentGradesProgram()
        {
            Dictionary<string, List<int>> studentsDictionary = new Dictionary<string, List<int>>()
            {
                { "Alice", new List<int> { 85, 90, 88 } },
                { "Bob", new List<int> { 78, 82, 91 } },
                { "Charlie", new List<int> { 92, 87, 94 } }
            };

            DisplayStudentDictionary(studentsDictionary);

            AddStudent(studentsDictionary, "David", new List<int> { 88, 93, 85 });
            RemoveStudent(studentsDictionary, "Bob");

            Console.WriteLine("\nStudents sorted by ascending average grade:");
            DisplaySortedByAverage(studentsDictionary, ascending: true);

            Console.WriteLine("\nStudents sorted by descending average grade:");
            DisplaySortedByAverage(studentsDictionary, ascending: false);

            DisplayHighestAndLowestAverage(studentsDictionary);

            Console.WriteLine("\nFinal student records with average grades:");
            DisplayStudentDictionary(studentsDictionary);
        }

        static void DisplayStudentDictionary(Dictionary<string, List<int>> dict)
        {
            Console.WriteLine("\nStudent names, their marks, and average grade:");
            foreach (var entry in dict)
            {
                double average = CalculateAverageGrade(entry.Value);
                Console.WriteLine($"{entry.Key}: Marks: {string.Join(", ", entry.Value)} | Average grade: {average:F2}");
            }
        }

        static void AddStudent(Dictionary<string, List<int>> dict, string name, List<int> marks)
        {
            if (!dict.ContainsKey(name))
            {
                dict.Add(name, marks);
                Console.WriteLine($"\n{name} has been added with marks {string.Join(", ", marks)}.");
            }
            else
            {
                Console.WriteLine($"\n{name} already exists.");
            }
        }

        static void RemoveStudent(Dictionary<string, List<int>> dict, string name)
        {
            if (dict.ContainsKey(name))
            {
                dict.Remove(name);
                Console.WriteLine($"\n{name} has been removed from the dictionary.");
            }
            else
            {
                Console.WriteLine($"\n{name} not found in the dictionary.");
            }
        }

        static double CalculateAverageGrade(List<int> marks)
        {
            if (marks.Count == 0) return 0;
            return (double)marks.Sum() / marks.Count;
        }

        static void DisplaySortedByAverage(Dictionary<string, List<int>> dict, bool ascending)
        {
            var sortedStudents = dict
                .Select(entry => new { Name = entry.Key, Average = CalculateAverageGrade(entry.Value) })
                .OrderBy(student => ascending ? student.Average : -student.Average);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{student.Name}: Average grade: {student.Average:F2}");
            }
        }

        static void DisplayHighestAndLowestAverage(Dictionary<string, List<int>> dict)
        {
            var sortedStudents = dict
                .Select(entry => new { Name = entry.Key, Average = CalculateAverageGrade(entry.Value) })
                .OrderBy(student => student.Average)
                .ToList();

            var lowestStudent = sortedStudents.First();
            var highestStudent = sortedStudents.Last();

            Console.WriteLine($"\nStudent with the lowest average grade: {lowestStudent.Name} | Average grade: {lowestStudent.Average:F2}");
            Console.WriteLine($"Student with the highest average grade: {highestStudent.Name} | Average grade: {highestStudent.Average:F2}");
        }
    }
}
