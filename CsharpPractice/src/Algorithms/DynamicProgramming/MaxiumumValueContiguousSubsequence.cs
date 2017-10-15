// Problem 1. Maximum Value Contiguous Subsequence
//
// Given a sequence of n real numbers A(1) ... A(n), determine a contiguous subsequence A(i) ... A(j) for which the sum
// of elements in the subsequence is maximized.

using System;

namespace Algorithms
{
    internal static class MaxiumumValueContiguousSubsequence
    {
        public static void Main(string[] args)
        {
            PrintMaxSubsequence(new int[] { });
            PrintMaxSubsequence(new int[] { 0 });
            PrintMaxSubsequence(new int[] { 1 });
            PrintMaxSubsequence(new int[] { -1 });
            PrintMaxSubsequence(new int[] { 3, -1, -1, 3 });
            PrintMaxSubsequence(new int[] { 0, 2, -1, 3, -2, 4 });
        }

        private static void PrintMaxSubsequence(int[] sequence)
        {
            int maxTill = 0, maxTillStartIndex = 0;
            int maxAll = 0, maxAllStartIndex = 0, maxAllEndIndex = -1;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (maxTill > 0)
                {
                    // Continue the sequence.
                    maxTill = maxTill + sequence[i];
                }
                else
                {
                    // Start a new sequence.
                    maxTill = sequence[i];
                    maxTillStartIndex = i;
                }

                if (maxAll < maxTill)
                {
                    maxAll = maxTill;
                    maxAllStartIndex = maxTillStartIndex;
                    maxAllEndIndex = i;
                }
            }

            printSequence($"Sequence: ", sequence, 0, sequence.Length - 1);
            printSequence($"Maximum Value Contiguous Subsequence: ", sequence, maxAllStartIndex, maxAllEndIndex);
        }

        private static void printSequence(string prefix, int[] sequence, int startIndex, int endIndex)
        {
            Console.Write(prefix);

            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.Write(sequence[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
