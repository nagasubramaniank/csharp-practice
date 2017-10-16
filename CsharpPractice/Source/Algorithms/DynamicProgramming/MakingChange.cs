// Problem 2. Making Change
//
// You are given n types of coin denominations of values v(1) < v(2) < ... < v(n) (all integers). Assume v(1) = 1, so
// you can always make change for any amount of money C. Give an algorithm which makes change for an amount of money C
// with as few coins as possible.

using System;

namespace CsharpPractice.Source.Algorithms.DynamicProgramming
{
    internal static class MakingChange
    {
        public static void Main(string[] args)
        {
            PrintChangeUpto(100, new int[] { 1, 2, 5, 10, 20, 25, 50, 100 });
            PrintChangeUpto(100, new int[] { 1, 3, 9, 27, 81 });
        }

        private static void PrintChangeUpto(int maxValue, int[] denominations)
        {
            int[] minDenominations = new int[maxValue + 1];
            int[] lastValues = new int[maxValue + 1];

            minDenominations[0] = 0;
            lastValues[0] = -1;

            for (int value = 1; value <= maxValue; value++)
            {
                minDenominations[value] = int.MaxValue;
                lastValues[value] = -1;

                foreach (int denomination in denominations)
                {
                    int lastValue = value - denomination;
                    if (lastValue < 0)
                    {
                        break;
                    }

                    if (minDenominations[value] > minDenominations[lastValue] + 1)
                    {
                        minDenominations[value] = minDenominations[lastValue] + 1;
                        lastValues[value] = lastValue;
                    }
                }

                Console.Write("Value: " + value + ", Denominations: ");

                for (int remainingValue = value; remainingValue > 0; remainingValue = lastValues[remainingValue])
                {
                    Console.Write((remainingValue - lastValues[remainingValue]) + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
