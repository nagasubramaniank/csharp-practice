// Problem 3. Longest Increasing Subsequence
//
// Given a sequence of n real numbers A(1) ... A(n), determine a subsequence (not necessarily contiguous) of maximum
// length in which the values in the subsequence form a strictly increasing sequence.using System;

using System;
using System.Collections.Generic;

namespace CsharpPractice.Source.Algorithms.DynamicProgramming
{
    internal static class LongestIncreasingSubsequence
    {
        public static void Main(string[] args)
        {
            PrintLongestIncreasingSubsequence(new int[] { });
            PrintLongestIncreasingSubsequence(new int[] { 0 });
            PrintLongestIncreasingSubsequence(new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 });
            PrintLongestIncreasingSubsequence(new int[] { 15, 7, 11, 3, 13, 5, 9, 1, 14, 6, 10, 2, 12, 4, 8, 0 });
            PrintLongestIncreasingSubsequence(new int[] { 0, -8, 4, -12, 2, -10, 6, -14, 1, -9, 5, -13, 3, -11, 7, -15 });
        }

        private static void PrintLongestIncreasingSubsequence(int[] sequence)
        {
            int[] longestSequenceSizes = new int[sequence.Length];
            int[] lastIndexes = new int[sequence.Length];

            int longestSequenceSize = 0;
            int longestSequenceEndIndex = -1;

            for (int endIndex = 0; endIndex < sequence.Length; endIndex++)
            {
                longestSequenceSizes[endIndex] = 1;
                lastIndexes[endIndex] = -1;

                for (int lastIndex = 0; lastIndex < endIndex; lastIndex++)
                {
                    if (sequence[lastIndex] < sequence[endIndex] &&
                        longestSequenceSizes[endIndex] < longestSequenceSizes[lastIndex] + 1)
                    {
                        longestSequenceSizes[endIndex] = longestSequenceSizes[lastIndex] + 1;
                        lastIndexes[endIndex] = lastIndex;
                    }
                }

                if (longestSequenceSize < longestSequenceSizes[endIndex])
                {
                    longestSequenceSize = longestSequenceSizes[endIndex];
                    longestSequenceEndIndex = endIndex;
                }
            }

            Console.Write("Sequence: ");

            for (int index = 0; index < sequence.Length; index++)
            {
                Console.Write(sequence[index] + " ");
            }

            Console.WriteLine();

            // Use stack to display numbers within the sequence in increasing order.
            Stack<int> longestSubsequence = new Stack<int>();

            for (int index = longestSequenceEndIndex; index != -1; index = lastIndexes[index])
            {
                longestSubsequence.Push(sequence[index]);
            }

            Console.Write("Longest Increasing Subsequence: ");

            while (longestSubsequence.Count > 0)
            {
                Console.Write(longestSubsequence.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
