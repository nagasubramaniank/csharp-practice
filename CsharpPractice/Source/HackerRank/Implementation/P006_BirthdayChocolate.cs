// Birthday Chocolate
// https://www.hackerrank.com/challenges/the-birthday-bar/problem

using System;
using System.Linq;

namespace CsharpPractice.Source.HackerRank.Implementation
{
    internal static class P006_BirthdayChocolate
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();

            int[] squareValues = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] dayMonth = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            PrintPieceCombinations(squareValues, dayMonth[0], dayMonth[1]);
        }

        private static void PrintPieceCombinations(int[] squareValues, int day, int month)
        {
            int pieceCombinations = 0;

            int sumSquareValues = 0;

            for (int square = 0; square < squareValues.Length; square++)
            {
                sumSquareValues += squareValues[square];

                if (square >= month)
                {
                    sumSquareValues -= squareValues[square - month];
                }

                if (square >= month - 1 && sumSquareValues == day)
                {
                    pieceCombinations += 1;
                }
            }

            Console.WriteLine(pieceCombinations);
        }
    }
}
