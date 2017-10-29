// Breaking the Records
// https://www.hackerrank.com/challenges/breaking-best-and-worst-records/problem

using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPractice.Source.HackerRank.Implementation
{
    internal static class P005_BreakingTheRecords
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();

            IEnumerable<int> scores = Console.ReadLine().Split(' ').Select(int.Parse);
            PrintRecordBreakCounts(scores);
        }

        private static void PrintRecordBreakCounts(IEnumerable<int> scores)
        {
            int highestScore = scores.First(), lowestScore = scores.First();
            int highestScoreCount = 0, lowestScoreCount = 0;

            foreach (int score in scores)
            {
                if (highestScore < score)
                {
                    highestScore = score;
                    highestScoreCount += 1;
                }

                if (lowestScore > score)
                {
                    lowestScore = score;
                    lowestScoreCount += 1;
                }
            }

            Console.WriteLine(highestScoreCount + " " + lowestScoreCount);
        }
    }
}
