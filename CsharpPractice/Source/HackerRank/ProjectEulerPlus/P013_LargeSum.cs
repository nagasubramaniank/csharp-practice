// Project Euler #13: Large sum
// https://www.hackerrank.com/contests/projecteuler/challenges/euler013

using System;
using System.Numerics;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P013_LargeSum
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            BigInteger[] numbers = new BigInteger[lines];

            for (int index = 0; index < lines; index++)
            {
                numbers[index] = BigInteger.Parse(Console.ReadLine());
            }

            PrintLargeSum(numbers);
        }

        private static void PrintLargeSum(BigInteger[] numbers)
        {
            BigInteger sum = 0;

            foreach (BigInteger number in numbers)
            {
                sum += number;
            }

            Console.WriteLine(sum.ToString().Substring(0, 10));
        }
    }
}
