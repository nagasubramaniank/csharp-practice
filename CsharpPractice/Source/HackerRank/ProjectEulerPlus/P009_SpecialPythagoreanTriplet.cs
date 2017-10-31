// Project Euler #9: Special Pythagorean triplet
// https://www.hackerrank.com/contests/projecteuler/challenges/euler009

using System;

namespace CsharpPractice.Source.HackerRank.ProjectEulerPlus
{
    internal static class P009_SpecialPythagoreanTriplet
    {
        public static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                PrintSpecialPythagoreanTriplet(int.Parse(Console.ReadLine()));
            }
        }

        private static void PrintSpecialPythagoreanTriplet(int sum)
        {
            // Sum of three sides should always be an even value.
            if (sum % 2 != 0)
            {
                Console.WriteLine(-1);
                return;
            }

            int maximumProduct = -1;

            // Substituting value of c as N - a - b in equation a^2 + b^2 == c^2 gives value of b (side2) in terms of
            // a (side1) and N. b = (N / 2) * (N - 2 * a) / (N - a).

            for (int side1 = 3; side1 < sum / 3; side1++)
            {
                int side2Numerator = sum / 2 * (sum - 2 * side1);
                int side2Denominator = sum - side1;

                if (side2Numerator % side2Denominator != 0)
                {
                    continue;
                }

                int side2 = side2Numerator / side2Denominator;
                int hypotenuse = sum - side1 - side2;

                maximumProduct = Math.Max(maximumProduct, side1 * side2 * hypotenuse);
            }

            Console.WriteLine(maximumProduct);
        }
    }
}
