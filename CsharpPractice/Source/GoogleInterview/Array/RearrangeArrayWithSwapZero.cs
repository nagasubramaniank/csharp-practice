// Rearrange an array using swaps with 0.

// You have two arrays src, tgt, containing two permutations of the numbers 0..n-1. You would like to rearrange src so that
// it equals tgt. The only allowed operations is 'swap a number with 0', e.g. {1,0,2,3} -> {1,3,2,0} ("swap 3 with 0").
// Write a program that prints to stdout the list of required operations

using System;

namespace CsharpPractice.Source.GoogleInterview.Array
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
