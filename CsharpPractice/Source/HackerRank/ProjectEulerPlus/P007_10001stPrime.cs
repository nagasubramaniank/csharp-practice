// Project Euler #7: 10001st prime
// https://www.hackerrank.com/contests/projecteuler/challenges/euler007

using System;
using System.Collections.Generic;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P007_10001stPrime
    {
        public static void Main(string[] args)
        {
            int[] primes = GetPrimesUpto(104729);

            int testCases = int.Parse(Console.ReadLine());

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                PrintNthPrime(int.Parse(Console.ReadLine()), primes);
            }
        }

        private static int[] GetPrimesUpto(int limit)
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

            return primes.ToArray();
        }

        private static void PrintNthPrime(int index, int[] primes)
        {
            Console.WriteLine(primes[index - 1]);
        }
    }
}
