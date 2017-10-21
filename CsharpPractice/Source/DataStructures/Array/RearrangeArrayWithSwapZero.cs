// We have two arrays, source and reference of size N, both containing two permutations of the numbers from 0 to N-1. The
// only allowed operation on source array is 'Swap a number with zero'. Rearrange the source array to match with the
// reference array using minimum operations.

using System;

namespace CsharpPractice.Source.DataStructures.Array
{
    internal static class RearrangeArrayWithSwapZero
    {
        public static void Main(string[] args)
        {
            PrintSequenceOfSwaps(new int[] { 0 }, new int[] { 0 });
            PrintSequenceOfSwaps(new int[] { 0, 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1, 0 });
            PrintSequenceOfSwaps(new int[] { 0, 2, 1, 4, 3 }, new int[] { 0, 1, 2, 3, 4 });
            PrintSequenceOfSwaps(new int[] { 1, 0, 3, 6, 5, 4, 2 }, new int[] { 6, 5, 4, 3, 2, 1, 0 });
        }

        private static void PrintSequenceOfSwaps(int[] sourceSequence, int[] referenceSequence)
        {
            Console.WriteLine("Source Positions: " + string.Join(" ", sourceSequence));
            Console.WriteLine("Target Positions: " + string.Join(" ", referenceSequence));
            Console.WriteLine();
            Console.WriteLine("Sequence of Swaps:");

            ZeroSwapper zeroSwapper = new ZeroSwapper(sourceSequence);

            for (int position = 0; position < sourceSequence.Length; position++)
            {
                if (sourceSequence[position] != referenceSequence[position])
                {
                    int newZeroPosition = zeroSwapper.Swap(sourceSequence[position]);

                    while (referenceSequence[newZeroPosition] != 0)
                    {
                        newZeroPosition = zeroSwapper.Swap(referenceSequence[newZeroPosition]);
                    }
                }
            }

            Console.WriteLine();
        }

        private sealed class ZeroSwapper
        {
            private readonly int[] sequence;
            private readonly int[] positions;
            private int step = 0;

            public ZeroSwapper(int[] sequence)
            {
                this.sequence = sequence;
                this.positions = new int[sequence.Length];

                for (int position = 0; position < this.sequence.Length; position++)
                {
                    this.positions[this.sequence[position]] = position;
                }
            }

            public int Swap(int swapNumber)
            {
                if (swapNumber != 0)
                {
                    this.sequence[this.positions[0]] = this.sequence[this.positions[swapNumber]];
                    this.sequence[this.positions[swapNumber]] = 0;

                    int tempPosition = this.positions[0];
                    this.positions[0] = this.positions[swapNumber];
                    this.positions[swapNumber] = tempPosition;

                    step += 1;

                    Console.Write($"{step}. ");

                    foreach (int number in sequence)
                    {
                        Console.ForegroundColor = number == swapNumber ? ConsoleColor.White : ConsoleColor.DarkGray;
                        Console.Write($"{number} ");
                    }

                    Console.ResetColor();
                    Console.WriteLine();
                }

                return this.positions[0];
            }
        }
    }
}
