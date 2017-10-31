// Project Euler #10: Summation of primes
// https://www.hackerrank.com/contests/projecteuler/challenges/euler010

using System;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P010_SummationOfPrimes
    {
        public static void Main(string[] args)
        {
            long[] sumsOfPrimes = GetSumOfPrimesUpto(1000000);

            int testCases = int.Parse(Console.ReadLine());

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                PrintSummationOfPrimes(int.Parse(Console.ReadLine()), sumsOfPrimes);
            }
        }

        private static long[] GetSumOfPrimesUpto(int limit)
        {
            bool[] isNotPrime = new bool[limit + 1];

            isNotPrime[0] = isNotPrime[1] = true;

            for (int number = 2; number * number <= limit; number++)
            {
                if (!isNotPrime[number])
                {
                    for (int multiple = 2 * number; multiple <= limit; multiple += number)
                    {
                        isNotPrime[multiple] = true;
                    }
                }
            }

            long[] sumsOfPrimes = new long[limit + 1];

            long sumOfPrimes = 0;

            for (int number = 0; number <= limit; number++)
            {
                if (!isNotPrime[number])
                {
                    sumOfPrimes = checked (sumOfPrimes + number);
                }

                sumsOfPrimes[number] = sumOfPrimes;
            }

            return sumsOfPrimes;
        }

        private static void PrintSummationOfPrimes(int number, long[] sumsOfPrimes)
        {
            Console.WriteLine(sumsOfPrimes[number]);
        }
    }
}
