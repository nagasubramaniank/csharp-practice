// Given knight's position on a chess board, find the probability that it will stay on the board after given moves.

using System;
using System.Collections.Generic;

namespace Hashing
{
    public static class KnightStayProbability
    {
        private static Dictionary<KnightStatus, double> stayProbabilities = new Dictionary<KnightStatus, double>();

        public static void Main(string[] args)
        {
            for (int moves = 0; moves < 16; moves++)
            {
                PrintStayProbability(8, moves, 1, 3);
            }
        }

        private static void PrintStayProbability(int boardSize, int moves, int row, int column)
        {
            double stayProbability = StayProbability(boardSize, moves, row, column);

            Console.WriteLine($"Knight Stay Probability (Board Size: [{boardSize}], Moves: [{moves}], " +
                $"Row Position: [{row}], Column Position: [{column}]): [{stayProbability}].");
        }

        private static double StayProbability(int boardSize, int remainingMoves, int row, int column)
        {
            if (row < 0 || row >= boardSize || column < 0 || column >= boardSize)
            {
                return 0.0;
            }

            if (remainingMoves == 0)
            {
                return 1.0;
            }

            KnightStatus knightStatus = new KnightStatus(boardSize, remainingMoves, row, column);

            if (!stayProbabilities.ContainsKey(knightStatus))
            {
                double stayProbability = (
                    StayProbability(boardSize, remainingMoves - 1, row - 2, column - 1) +
                    StayProbability(boardSize, remainingMoves - 1, row - 2, column + 1) +
                    StayProbability(boardSize, remainingMoves - 1, row - 1, column - 2) +
                    StayProbability(boardSize, remainingMoves - 1, row - 1, column + 2) +
                    StayProbability(boardSize, remainingMoves - 1, row + 1, column - 2) +
                    StayProbability(boardSize, remainingMoves - 1, row + 1, column + 2) +
                    StayProbability(boardSize, remainingMoves - 1, row + 2, column - 1) +
                    StayProbability(boardSize, remainingMoves - 1, row + 2, column + 1)
                    ) / 8.0;

                stayProbabilities.Add(knightStatus, stayProbability);
            }

            return stayProbabilities[knightStatus];
        }

        private struct KnightStatus
        {
            public readonly int boardSize;
            public readonly int moves;
            public readonly int row;
            public readonly int column;

            public KnightStatus(int boardSize, int moves, int row, int column)
            {
                this.boardSize = boardSize;
                this.moves = moves;
                this.row = row;
                this.column = column;
            }
        }
    }
}
