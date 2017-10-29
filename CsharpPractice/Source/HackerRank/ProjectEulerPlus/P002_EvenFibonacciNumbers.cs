// Project Euler #2: Even Fibonacci numbers
// https://www.hackerrank.com/contests/projecteuler/challenges/euler002

using System;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P002_EvenFibonacciNumbers
    {
        public static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                PrintSumOfEvenFibonacciNumbers(long.Parse(Console.ReadLine()));
            }
        }

        private static void PrintSumOfEvenFibonacciNumbers(long limit)
        {
            // f(n) = f(n-1) + f(n-2)
            //      = 2f(n-2) + f(n-3)
            //      = 3f(n-3) + 2f(n-4)
            //      = 4f(n-3) + f(n-4) - f(n-5)
            //      = 4f(n-3) + f(n-6)

            long sumOfFibonacciNumbers = 0;

            for (long fibn_6 = 0, fibn_3 = 0, fibn = 2;
                fibn <= limit;
                fibn_6 = fibn_3, fibn_3 = fibn, fibn = 4 * fibn_3 + fibn_6)
            {
                sumOfFibonacciNumbers = checked (sumOfFibonacciNumbers + fibn);
            }

            Console.WriteLine(sumOfFibonacciNumbers);
        }
    }
}
