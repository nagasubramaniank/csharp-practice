// Project Euler #8: Largest product in a series
// https://www.hackerrank.com/contests/projecteuler/challenges/euler008

using System;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P008_LargestProductInASeries
    {
        public static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                int length = int.Parse(Console.ReadLine().Split(' ')[1]);
                string number = Console.ReadLine();

                PrintLargestProduct(number, length);
            }
        }

        private static void PrintLargestProduct(string number, int length)
        {
            int largestProduct = 0;

            for (int index = 0, ignoreLength = length - 1, product = 1; index < number.Length; index++, ignoreLength--)
            {
                if (number[index] == '0')
                {
                    ignoreLength = length;
                    product = 1;
                    continue;
                }

                if (ignoreLength < 0)
                {
                    product /= (number[index - length] - '0');
                }

                product *= (number[index] - '0');

                if (ignoreLength <= 0 && largestProduct < product)
                {
                    largestProduct = product;
                }
            }

            Console.WriteLine(largestProduct);
        }
    }
}
