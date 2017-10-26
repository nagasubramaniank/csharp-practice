// Grading Students
// https://www.hackerrank.com/challenges/grading/problem

using System;

namespace CsharpPractice.Source.HackerRank.Implementation
{
    internal static class P001_GradingStudents
    {
        public static void Main(string[] args)
        {
            int studentCount = int.Parse(Console.ReadLine());

            int[] grades = new int[studentCount];
            for (int studentIndex = 0; studentIndex < studentCount; studentIndex++)
            {
                PrintRoundedGrade(int.Parse(Console.ReadLine()));
            }
        }

        private static void PrintRoundedGrade(int grade)
        {
            int roundedGrade =  grade >= 38 && grade % 5 >= 3 ? grade + (5 - grade % 5) : grade;
            Console.WriteLine(roundedGrade);
        }
    }
}
