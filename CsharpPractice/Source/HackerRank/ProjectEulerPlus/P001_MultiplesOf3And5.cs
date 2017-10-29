// Project Euler #1: Multiples of 3 and 5
// https://www.hackerrank.com/contests/projecteuler/challenges/euler001

using System;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P001_MultiplesOf3And5
    {
        public static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                PrintSumOfMultiples(int.Parse(Console.ReadLine()));
            }
        }

        private static void PrintSumOfMultiples(int limit)
        {
            Console.WriteLine(SumOfMultiples(3, limit) + SumOfMultiples(5, limit) - SumOfMultiples(15, limit));
        }

        private static long SumOfMultiples(int number, int limit)
        {
            long numberOfMultiples = (limit - 1) / number;

            return checked (number * numberOfMultiples * (numberOfMultiples + 1) / 2);
        }
    }
}
