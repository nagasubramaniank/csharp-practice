// Apple and Orange
// https://www.hackerrank.com/challenges/apple-and-orange/problem

using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPractice.Source.HackerRank.Implementation
{
    internal static class P002_AppleAndOrange
    {
        public static void Main(string[] args)
        {
            string[] startEnd = Console.ReadLine().Split(' ');
            int startPoint = int.Parse(startEnd[0]);
            int endPoint = int.Parse(startEnd[1]);

            string[] treePoints = Console.ReadLine().Split(' ');
            int appleTreePoint = int.Parse(treePoints[0]);
            int orangeTreePoint = int.Parse(treePoints[1]);

            Console.ReadLine().Split(' ');

            IEnumerable<int> appleDistances = Console.ReadLine().Split(' ').Select(int.Parse);
            IEnumerable<int> orangeDistances = Console.ReadLine().Split(' ').Select(int.Parse);

            PrintAppleAndOrangeCount(startPoint, endPoint, appleTreePoint, orangeTreePoint, appleDistances, orangeDistances);
        }

        private static void PrintAppleAndOrangeCount(int startPoint, int endPoint, int appleTreePoint, int orangeTreePoint, IEnumerable<int> appleDistances, IEnumerable<int> orangeDistances)
        {
            PrintFruitCount(startPoint, endPoint, appleTreePoint, appleDistances);
            PrintFruitCount(startPoint, endPoint, orangeTreePoint, orangeDistances);
        }

        private static void PrintFruitCount(int startPoint, int endPoint, int fruitTreePoint, IEnumerable<int> fruitDistances)
        {
            int fruitCount = 0;

            foreach (int fruitDistance in fruitDistances)
            {
                int fallPoint = fruitTreePoint + fruitDistance;
                if (fallPoint >= startPoint && fallPoint <= endPoint)
                {
                    fruitCount += 1;
                }
            }

            Console.WriteLine(fruitCount);
        }
    }
}
