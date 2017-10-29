// Kangaroo
// https://www.hackerrank.com/challenges/kangaroo/problem

using System;
using System.Linq;

namespace CsharpPractice.Source.HackerRank.Implementation
{
    internal static class P003_Kangaroo
    {
        public static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int kangaroo1Position = inputs[0], kangaroo1Velocity = inputs[1];
            int kangaroo2Position = inputs[2], kangaroo2Velocity = inputs[3];

            PrintDoKangaroosMeet(kangaroo1Position, kangaroo1Velocity, kangaroo2Position, kangaroo2Velocity);
        }

        private static void PrintDoKangaroosMeet(int kangaroo1Position, int kangaroo1Velocity, int kangaroo2Position, int kangaroo2Velocity)
        {
            int positionDifference = kangaroo2Position - kangaroo1Position;
            int velocityDifference = kangaroo2Velocity - kangaroo1Velocity;

            Console.WriteLine(velocityDifference < 0 && positionDifference % velocityDifference == 0 ? "YES" : "NO");
        }
    }
}
