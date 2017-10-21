// There is a party where everyone has to bring a gift. Your job is to come up with a random solution for who will gift
// whom. Note that a person can gift to himself/herself.

using System;
using System.Collections.Generic;

namespace CsharpPractice.Source.General.RandomSolution
{
    internal static class RandomGiftSequence
    {
        public static void Main(string[] args)
        {
            // Reusing a single instance of class Random throughout the solutions, since if we instead, initialize multiple
            // instances in a short period of time, they all tend to generate the same psuedo-random sequence.
            Random random = new Random();

            for (int numberOfPeople = 1; numberOfPeople < 16; numberOfPeople++)
            {
                PrintRandomGiftSequence(numberOfPeople, random);
            }

            Console.WriteLine();

            PrintGiftDistribution(6, 100000, random);
        }

        private static void PrintRandomGiftSequence(int numberOfPeople, Random random)
        {
            Console.Write($"Gift Sequence ({numberOfPeople} people): ");

            int[] giftReceiverFor = GetRandomGiftSequence(numberOfPeople, random);

            for (int giftSender = 0; giftSender < numberOfPeople; giftSender++)
            {
                Console.Write($"{giftSender} -> {giftReceiverFor[giftSender]}  ");
            }

            Console.WriteLine();
        }

        private static void PrintGiftDistribution(int numberOfPeople, int runs, Random random)
        {
            Console.WriteLine($"Gift Distribution ({numberOfPeople} people, {runs} runs): ");

            int[,] giftSenderReceiver = new int[numberOfPeople, numberOfPeople];

            for (int run = 0; run < runs; run++)
            {
                int[] giftReceiverFor = GetRandomGiftSequence(numberOfPeople, random);

                for (int giftSender = 0; giftSender < numberOfPeople; giftSender++)
                {
                    giftSenderReceiver[giftSender, giftReceiverFor[giftSender]] += 1;
                }
            }

            for (int giftSender = 0; giftSender < numberOfPeople; giftSender++)
            {
                for (int giftReceiver = 0; giftReceiver < numberOfPeople; giftReceiver++)
                {
                    Console.Write(giftSenderReceiver[giftSender, giftReceiver] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static int[] GetRandomGiftSequence(int numberOfPeople, Random random)
        {
            int[] giftReceiverFor = new int[numberOfPeople];
            for (int giftSender = 0; giftSender < numberOfPeople; giftSender++)
            {
                giftReceiverFor[giftSender] = giftSender;
            }

            for (int giftSender = 0; giftSender < numberOfPeople - 1; giftSender++)
            {
                int randomGiftSender = random.Next(giftSender + 1, numberOfPeople);
                int randomGiftReceiver = giftReceiverFor[randomGiftSender];
                giftReceiverFor[randomGiftSender] = giftReceiverFor[giftSender];
                giftReceiverFor[giftSender] = randomGiftReceiver;
            }

            return giftReceiverFor;
        }
    }
}
