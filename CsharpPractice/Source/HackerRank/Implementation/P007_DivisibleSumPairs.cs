// Divisible Sum Pairs
// https://www.hackerrank.com/challenges/divisible-sum-pairs/problem

using System;
using System.Linq;

namespace CsharpPractice.Source.HackerRank.Implementation
{
    internal static class P007_DivisibleSumPairs
    {
        public static void Main(string[] args)
        {
            int dividend = Console.ReadLine().Split(' ').Select(int.Parse).ToArray()[1];

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            PrintDivisibleSumPairs(numbers, dividend);
        }

        private static void PrintDivisibleSumPairs(int[] numbers, int dividend)
        {
            int[] moduloNumbers = new int[dividend];

            foreach (int number in numbers)
            {
                moduloNumbers[number % dividend] += 1;
            }

            // Numbers that are multiples of dividend.
            int divisibleSumPairs = (moduloNumbers[0] * (moduloNumbers[0] - 1)) / 2;
            
            // Numbers that are odd multiples of dividend / 2.
            if (dividend % 2 == 0)
            {
                divisibleSumPairs += (moduloNumbers[dividend / 2] * (moduloNumbers[dividend / 2] - 1)) / 2;
            }

            // Numbers that are not multiples of dividend / 2.
            for (int moduloNumber = 1; moduloNumber < dividend - moduloNumber; moduloNumber++)
            {
                divisibleSumPairs += moduloNumbers[moduloNumber] * moduloNumbers[dividend - moduloNumber];
            }

            Console.WriteLine(divisibleSumPairs);
        }
    }
}
