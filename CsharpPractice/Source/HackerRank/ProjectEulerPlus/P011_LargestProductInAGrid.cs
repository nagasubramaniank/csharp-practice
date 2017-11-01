// Project Euler #11: Largest product in a grid
// https://www.hackerrank.com/contests/projecteuler/challenges/euler011

using System;
using System.Linq;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P011_LargestProductInAGrid
    {
        public static void Main(string[] args)
        {
            int[][] grid = new int[20][];

            for (int row = 0; row < 20; row++)
            {
                grid[row] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            PrintLargestProduct(grid);
        }

        private static void PrintLargestProduct(int[][] grid)
        {
            int largestProduct = 0;

            int rows = grid.Length, columns = grid[0].Length;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    // Horizontal sum.
                    if (column < columns - 3)
                    {
                        largestProduct = Math.Max(largestProduct, grid[row][column] * grid[row][column + 1] * grid[row][column + 2] * grid[row][column + 3]);
                    }

                    // Vertical sum.
                    if (row < rows - 3)
                    {
                        largestProduct = Math.Max(largestProduct, grid[row][column] * grid[row + 1][column] * grid[row + 2][column] * grid[row + 3][column]);
                    }

                    // Front diagonal sum.
                    if (row < rows - 3 && column < columns - 3)
                    {
                        largestProduct = Math.Max(largestProduct, grid[row][column] * grid[row + 1][column + 1] * grid[row + 2][column + 2] * grid[row + 3][column + 3]);
                    }

                    // Back diagonal sum.
                    if (row >= 3 && column < columns - 3)
                    {
                        largestProduct = Math.Max(largestProduct, grid[row][column] * grid[row - 1][column + 1] * grid[row - 2][column + 2] * grid[row - 3][column + 3]);
                    }
                }
            }

            Console.WriteLine(largestProduct);
        }
    }
}
