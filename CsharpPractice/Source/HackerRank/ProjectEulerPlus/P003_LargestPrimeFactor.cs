// Project Euler #3: Largest prime factor
// https://www.hackerrank.com/contests/projecteuler/challenges/euler003

using System;
using System.Collections.Generic;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P003_LargestPrimeFactor
    {
        public static void Main(string[] args)
        {
            IEnumerable<int> primes = GetPrimesUpto(1000000);

            int testCases = int.Parse(Console.ReadLine());

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                PrintLargestPrimeFactor(long.Parse(Console.ReadLine()), primes);
            }
        }

        private static IEnumerable<int> GetPrimesUpto(int limit)
        {
            bool[] isNotPrime = new bool[limit + 1];

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

            List<int> primes = new List<int>();

            for (int number = 2; number <= limit; number++)
            {
                if (!isNotPrime[number])
                {
                    primes.Add(number);
                }
            }

            return primes;
        }

        private static void PrintLargestPrimeFactor(long number, IEnumerable<int> primes)
        {
            long remainingNumber = number;

            foreach (long prime in primes)
            {
                if (prime * prime > remainingNumber)
                {
                    break;
                }

                while (remainingNumber % prime == 0)
                {
                    remainingNumber /= prime;

                    if (prime * prime > remainingNumber)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(remainingNumber);
        }
    }
}
