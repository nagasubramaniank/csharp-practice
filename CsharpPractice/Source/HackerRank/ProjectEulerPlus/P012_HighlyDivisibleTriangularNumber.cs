// Project Euler #12: Highly divisible triangular number
// https://www.hackerrank.com/contests/projecteuler/challenges/euler012

using System;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P012_HighlyDivisibleTriangularNumber
    {
        public static void Main(string[] args)
        {
            long[] firstTriangularNumbers = GetFirstTriangularNumbers(1000);

            int testCases = int.Parse(Console.ReadLine());

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                PrintFirstTriangularNumber(int.Parse(Console.ReadLine()), firstTriangularNumbers);
            }
        }

        private static long[] GetFirstTriangularNumbers(int maximumDivisors)
        {
            long[] firstTriangularNumbers = new long[maximumDivisors + 1];

            for (int number = 0, currentDivisor = 0, divisors1 = 0, divisors2 = 0; ; number++)
            {
                if (number % 2 != 0)
                {
                    divisors1 = CountFactors((number + 1) / 2);
                }
                else
                {
                    divisors2 = CountFactors(number + 1);
                }

                // This works since the greatest common divisor of n and (2n +/- 1) is 1 for all values of n.
                int divisors = divisors1 * divisors2;

                for (; currentDivisor < divisors && currentDivisor <= maximumDivisors; currentDivisor++)
                {
                    firstTriangularNumbers[currentDivisor] = checked (((long) number * (number + 1)) / 2);
                }

                if (divisors > maximumDivisors)
                {
                    break;
                }
            }

            return firstTriangularNumbers;
        }

        private static int CountFactors(int number)
        {
            int factors = 1;

            for (int divisor = 2; divisor * divisor <= number; divisor++)
            {
                int primeFactors = 0;

                while (number % divisor == 0)
                {
                    number /= divisor;
                    primeFactors += 1;
                }

                factors *= (primeFactors + 1);
            }

            return number > 1 ? 2 * factors : factors;
        }


        private static void PrintFirstTriangularNumber(int number, long[] firstTriangularNumbers)
        {
            Console.WriteLine(firstTriangularNumbers[number]);
        }
    }
}
