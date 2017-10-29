// Between Two Sets
// https://www.hackerrank.com/challenges/between-two-sets/problem

using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPractice.Source.HackerRank.Implementation
{
    internal static class P004_BetweenTwoSets
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();

            IEnumerable<int> setA = Console.ReadLine().Split(' ').Select(int.Parse);
            IEnumerable<int> setB = Console.ReadLine().Split(' ').Select(int.Parse);

            PrintBetweenTwoSets(setA, setB);
        }

        private static void PrintBetweenTwoSets(IEnumerable<int> setA, IEnumerable<int> setB)
        {
            int lcmA = setA.First();
            foreach (int number in setA)
            {
                lcmA = LeastCommonMultiple(lcmA, number);
            }

            int gcdB = setB.First();
            foreach (int number in setB)
            {
                gcdB = GreatestCommonDivisor(gcdB, number);
            }

            Console.WriteLine(gcdB % lcmA == 0 ? FactorCount(gcdB / lcmA) : 0);
        }

        private static int LeastCommonMultiple(int number1, int number2)
        {
            return (number1 * number2) / GreatestCommonDivisor(number1, number2);
        }

        private static int GreatestCommonDivisor(int number1, int number2)
        {
            return number2 == 0 ? number1 : GreatestCommonDivisor(number2, number1 % number2);
        }

        private static int FactorCount(int number)
        {
            int factorCount = 1;

            for (int factor = 2; factor <= number; factor++)
            {
                int primeFactorCount = 0;

                while (number % factor == 0)
                {
                    number /= factor;
                    primeFactorCount += 1;
                }

                factorCount *= (primeFactorCount + 1);
            }

            return factorCount;
        }
    }
}
