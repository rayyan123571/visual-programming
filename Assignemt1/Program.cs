using System;

class Program
{
    static void Main()
    {
        // Start the matrix processing function
        ProcessMatrix();
        Console.ReadLine(); // Wait for user input before closing the console
    }

    // Function to process the matrix (input, display, and calculate diagonal sum)
    static void ProcessMatrix()
    {
        // Declare a 3x3x3 matrix (3D array)
        int[,,] matrix = new int[3, 3, 3];

        // Prompt the user to input the elements of the 3x3x3 matrix
        Console.WriteLine("Enter the elements of the 3x3x3 matrix:");
        for (int i = 0; i < 3; i++) // Loop through layers
        {
            for (int j = 0; j < 3; j++) // Loop through rows
            {
                for (int k = 0; k < 3; k++) // Loop through columns
                {
                    // Ask user to input value for each matrix element
                    Console.Write($"matrix[{i},{j},{k}] = ");
                    matrix[i, j, k] = int.Parse(Console.ReadLine()); // Store input in matrix
                }
            }
        }

        // Call the DisplayMatrix function to show the matrix contents
        DisplayMatrix(matrix);

        // Initialize a variable to store the sum of the diagonal elements
        int diagonalSum = 0;

        // Loop through the diagonal elements (i == j == k for diagonal in 3D matrix)
        for (int i = 0; i < 3; i++)
        {
            diagonalSum += matrix[i, i, i]; // Add diagonal element to the sum
        }

        // Display the sum of the diagonal elements
        Console.WriteLine($"The sum of the diagonal elements is: {diagonalSum}");
    }

    // Function to display the 3x3x3 matrix
    static void DisplayMatrix(int[,,] matrix)
    {
        Console.WriteLine("\nThe 3x3x3 matrix is:");

        // Loop through the matrix to display each element
        for (int i = 0; i < 3; i++) // Loop through layers
        {
            Console.WriteLine($"Layer {i + 1}:"); // Print the current layer number
            for (int j = 0; j < 3; j++) // Loop through rows
            {
                for (int k = 0; k < 3; k++) // Loop through columns
                {
                    // Print the matrix element at position [i, j, k]
                    Console.Write($"{matrix[i, j, k]} ");
                }
                Console.WriteLine(); // Move to the next line after each row
            }
            Console.WriteLine(); // Add a blank line between layers
        }
    }
}
