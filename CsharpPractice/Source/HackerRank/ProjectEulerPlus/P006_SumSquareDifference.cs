// Project Euler #6: Sum square difference
// https://www.hackerrank.com/contests/projecteuler/challenges/euler006

using System;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P006_SumSquareDifference
    {
        public static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                PrintSumSquareDifference(long.Parse(Console.ReadLine()));
            }
        }

        private static void PrintSumSquareDifference(long number)
        {
            long squareOfSum = checked ((((number) * (number + 1)) / 2) * (((number) * (number + 1)) / 2));
            long sumOfSquares = checked ((number * (number + 1) * (2 * number + 1)) / 6);
            long sumSquareDifferences = checked(squareOfSum - sumOfSquares);

            Console.WriteLine(sumSquareDifferences);
        }
    }
}
