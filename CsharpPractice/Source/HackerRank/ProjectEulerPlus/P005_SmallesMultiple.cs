// Project Euler #5: Smallest multiple
// https://www.hackerrank.com/contests/projecteuler/challenges/euler005

using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P005_SmallesMultiple
    {
        public static void Main(string[] args)
        {
            long[] smallestMultiples = GetSmallestMultiples(40);

            int testCases = int.Parse(Console.ReadLine());

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                PrintSmallestMultiples(int.Parse(Console.ReadLine()), smallestMultiples);
            }
        }

        private static long[] GetSmallestMultiples(int limit)
        {
            long[] smallestMultiples = new long[limit + 1];
            smallestMultiples[0] = 1;

            for (int number = 1; number <= limit; number++)
            {
                smallestMultiples[number] = LeastCommonMultiple(smallestMultiples[number - 1], number);
            }

            return smallestMultiples;
        }

        private static long LeastCommonMultiple(long number1, long number2)
        {
            return checked ((number1 * number2) / GreatestCommonDivisor(number1, number2));
        }

        private static long GreatestCommonDivisor(long number1, long number2)
        {
            return checked (number2 == 0 ? number1 : GreatestCommonDivisor(number2, number1 % number2));
        }

        private static void PrintSmallestMultiples(int limit, long[] smallestMultiples)
        {
            Console.WriteLine(smallestMultiples[limit]);
        }
    }
}
