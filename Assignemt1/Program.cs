using System;

class Program
{
    static void Main()
    {
        
        ProcessMatrix();
        Console.ReadLine();
    }

    
    static void ProcessMatrix()
    {
        
        int[,,] matrix = new int[3, 3, 3];

        
        Console.WriteLine("Enter the elements of the 3x3x3 matrix:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write($"matrix[{i},{j},{k}] = ");
                    matrix[i, j, k] = int.Parse(Console.ReadLine());
                }
            }
        }

        
        DisplayMatrix(matrix);

       
        int diagonalSum = 0;

        
        for (int i = 0; i < 3; i++)
        {
            diagonalSum += matrix[i, i, i];
        }

        
        Console.WriteLine($"The sum of the diagonal elements is: {diagonalSum}");
    }

    
    static void DisplayMatrix(int[,,] matrix)
    {
        Console.WriteLine("\nThe 3x3x3 matrix is:");
        
        for (int i = 0; i < 3; i++)

        {
            Console.WriteLine($"Layer {i + 1}:");
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write($"{matrix[i, j, k]} ");
                }
                Console.WriteLine(); 
            }
            Console.WriteLine(); 
        }
    }
}
