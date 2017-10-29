// Project Euler #4: Largest palindrome product
// https://www.hackerrank.com/contests/projecteuler/challenges/euler004

using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P004_LargestPalindromeProduct
    {
        public static void Main(string[] args)
        {
            int[] palindromeProducts = GetPalindromeProducts();

            int testCases = int.Parse(Console.ReadLine());

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                PrintLargestPalindromeProduct(int.Parse(Console.ReadLine()), palindromeProducts);
            }
        }

        private static int[] GetPalindromeProducts()
        {
            bool[] isProduct = new bool[1000000];

            for (int multiplier1 = 100; multiplier1 < 1000; multiplier1++)
            {
                for (int multiplier2 = Math.Max(multiplier1, 100000 / multiplier1); multiplier2 < 1000; multiplier2++)
                {
                    isProduct[multiplier1 * multiplier2] = true;
                }
            }

            List<int> palindromeProducts = new List<int>();

            for (int number = 100000; number < 1000000; number++)
            {
                if (isProduct[number] && IsPalindrome(number.ToString()))
                {
                    palindromeProducts.Add(number);
                }
            }

            return palindromeProducts.ToArray();
        }

        private static bool IsPalindrome(string number)
        {
            return number.SequenceEqual(number.Reverse());
        }

        private static void PrintLargestPalindromeProduct(int number, int[] palindromeProducts)
        {
            Console.WriteLine(GetLargestNumber(number, palindromeProducts, 0, palindromeProducts.Length - 1));
        }

        private static int GetLargestNumber(int number, int[] sequence, int beginIndex, int endIndex)
        {
            if (beginIndex == endIndex)
            {
                return sequence[endIndex] < number ? sequence[endIndex] : -1;
            }

            if (beginIndex + 1 == endIndex)
            {
                return sequence[endIndex] < number ? sequence[endIndex] : (sequence[beginIndex] < number ? sequence[beginIndex] : -1);
            }

            int middleIndex = (beginIndex + endIndex) / 2;

            if (sequence[middleIndex] < number)
            {
                return GetLargestNumber(number, sequence, middleIndex, endIndex);
            }
            else
            {
                return GetLargestNumber(number, sequence, beginIndex, middleIndex - 1);
            }
        }
    }
}
