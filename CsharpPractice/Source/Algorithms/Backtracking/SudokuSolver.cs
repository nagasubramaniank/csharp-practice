// Solve Sudoku puzzle.

using System;

namespace CsharpPractice.Source.Algorithms.Backtracking
{
    internal static class SudokuSolver
    {
        public static void Main(string[] args)
        {
            // World's hardest sudoku (http://www.conceptispuzzles.com/index.aspx?uri=info/article/424).
            int[,] sudokuPuzzle = new int[9, 9]
            {
                { 8, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 3, 6, 0, 0, 0, 0, 0 },
                { 0, 7, 0, 0, 9, 0, 2, 0, 0 },
                { 0, 5, 0, 0, 0, 7, 0, 0, 0 },
                { 0, 0, 0, 0, 4, 5, 7, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 3, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 6, 8 },
                { 0, 0, 8, 5, 0, 0, 0, 1, 0 },
                { 0, 9, 0, 0, 0, 0, 4, 0, 0 }
            };

            PrintSudokuPuzzle("Problem", sudokuPuzzle);

            Solve(sudokuPuzzle);

            PrintSudokuPuzzle("Solution", sudokuPuzzle);
        }

        private static void Solve(int[,] sudokuPuzzle)
        {
            int[] filledRows = new int[9];
            int[] filledColumns = new int[9];
            int[] filledSquares = new int[9];

            Initialize(sudokuPuzzle, filledRows, filledColumns, filledSquares);
            Solve(sudokuPuzzle, 0, 0, filledRows, filledColumns, filledSquares);
        }

        private static void Initialize(int[,] sudokuPuzzle, int[] filledRows, int[] filledColumns, int[] filledSquares)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    if (sudokuPuzzle[row, column] != 0)
                    {
                        FillCell(sudokuPuzzle, sudokuPuzzle[row, column], row, column, filledRows, filledColumns, filledSquares);
                    }
                }
            }
        }

        private static bool Solve(int[,] sudokuPuzzle, int row, int column, int[] filledRows, int[] filledColumns, int[] filledSquares)
        {
            if (row == 9)
            {
                return true;
            }

            int nextRow = row + (column / 8), nextColumn = (column + 1) % 9;

            if (sudokuPuzzle[row, column] != 0)
            {
                return Solve(sudokuPuzzle, nextRow, nextColumn, filledRows, filledColumns, filledSquares);
            }

            for (int number = 1; number <= 9; number++)
            {
                if (CanFillCell(number, row, column, filledRows, filledColumns, filledSquares))
                {
                    FillCell(sudokuPuzzle, number, row, column, filledRows, filledColumns, filledSquares);

                    if (Solve(sudokuPuzzle, nextRow, nextColumn, filledRows, filledColumns, filledSquares))
                    {
                        return true;
                    }

                    UnfillCell(sudokuPuzzle, number, row, column, filledRows, filledColumns, filledSquares);
                }
            }

            return false;
        }

        private static bool CanFillCell(int number, int row, int column, int[] filledRows, int[] filledColumns, int[] filledSquares)
        {
            int flag = 1 << number;
            int square = row / 3 + 3 * (column / 3);

            return (filledRows[row] & flag) == 0 && (filledColumns[column] & flag) == 0 && (filledSquares[square] & flag) == 0;
        }

        private static void FillCell(int[,] sudokuPuzzle, int number, int row, int column, int[] filledRows, int[] filledColumns, int[] filledSquares)
        {
            sudokuPuzzle[row, column] = number;

            int flag = 1 << number;
            int square = row / 3 + 3 * (column / 3);

            filledRows[row] |= flag;
            filledColumns[column] |= flag;
            filledSquares[square] |= flag;
        }

        private static void UnfillCell(int[,] sudokuPuzzle, int number, int row, int column, int[] filledRows, int[] filledColumns, int[] filledSquares)
        {
            sudokuPuzzle[row, column] = 0;

            int flag = 1 << number;
            int square = row / 3 + 3 * (column / 3);

            filledRows[row] &= ~flag;
            filledColumns[column] &= ~flag;
            filledSquares[square] &= ~flag;
        }

        private static void PrintSudokuPuzzle(string title, int[,] sudokuPuzzle)
        {
            Console.WriteLine(title);
            Console.WriteLine("╔═══╤═══╤═══╦═══╤═══╤═══╦═══╤═══╤═══╗");
            Console.WriteLine($"║ {CellCharacter(sudokuPuzzle[0,0])} │ {CellCharacter(sudokuPuzzle[0,1])} │ {CellCharacter(sudokuPuzzle[0,2])} ║ {CellCharacter(sudokuPuzzle[0,3])} │ {CellCharacter(sudokuPuzzle[0,4])} │ {CellCharacter(sudokuPuzzle[0,5])} ║ {CellCharacter(sudokuPuzzle[0,6])} │ {CellCharacter(sudokuPuzzle[0,7])} │ {CellCharacter(sudokuPuzzle[0,8])} ║");
            Console.WriteLine("╟───┼───┼───╫───┼───┼───╫───┼───┼───╢");
            Console.WriteLine($"║ {CellCharacter(sudokuPuzzle[1,0])} │ {CellCharacter(sudokuPuzzle[1,1])} │ {CellCharacter(sudokuPuzzle[1,2])} ║ {CellCharacter(sudokuPuzzle[1,3])} │ {CellCharacter(sudokuPuzzle[1,4])} │ {CellCharacter(sudokuPuzzle[1,5])} ║ {CellCharacter(sudokuPuzzle[1,6])} │ {CellCharacter(sudokuPuzzle[1,7])} │ {CellCharacter(sudokuPuzzle[1,8])} ║");
            Console.WriteLine("╟───┼───┼───╫───┼───┼───╫───┼───┼───╢");
            Console.WriteLine($"║ {CellCharacter(sudokuPuzzle[2,0])} │ {CellCharacter(sudokuPuzzle[2,1])} │ {CellCharacter(sudokuPuzzle[2,2])} ║ {CellCharacter(sudokuPuzzle[2,3])} │ {CellCharacter(sudokuPuzzle[2,4])} │ {CellCharacter(sudokuPuzzle[2,5])} ║ {CellCharacter(sudokuPuzzle[2,6])} │ {CellCharacter(sudokuPuzzle[2,7])} │ {CellCharacter(sudokuPuzzle[2,8])} ║");
            Console.WriteLine("╠═══╪═══╪═══╬═══╪═══╪═══╬═══╪═══╪═══╣");
            Console.WriteLine($"║ {CellCharacter(sudokuPuzzle[3,0])} │ {CellCharacter(sudokuPuzzle[3,1])} │ {CellCharacter(sudokuPuzzle[3,2])} ║ {CellCharacter(sudokuPuzzle[3,3])} │ {CellCharacter(sudokuPuzzle[3,4])} │ {CellCharacter(sudokuPuzzle[3,5])} ║ {CellCharacter(sudokuPuzzle[3,6])} │ {CellCharacter(sudokuPuzzle[3,7])} │ {CellCharacter(sudokuPuzzle[3,8])} ║");
            Console.WriteLine("╟───┼───┼───╫───┼───┼───╫───┼───┼───╢");
            Console.WriteLine($"║ {CellCharacter(sudokuPuzzle[4,0])} │ {CellCharacter(sudokuPuzzle[4,1])} │ {CellCharacter(sudokuPuzzle[4,2])} ║ {CellCharacter(sudokuPuzzle[4,3])} │ {CellCharacter(sudokuPuzzle[4,4])} │ {CellCharacter(sudokuPuzzle[4,5])} ║ {CellCharacter(sudokuPuzzle[4,6])} │ {CellCharacter(sudokuPuzzle[4,7])} │ {CellCharacter(sudokuPuzzle[4,8])} ║");
            Console.WriteLine("╟───┼───┼───╫───┼───┼───╫───┼───┼───╢");
            Console.WriteLine($"║ {CellCharacter(sudokuPuzzle[5,0])} │ {CellCharacter(sudokuPuzzle[5,1])} │ {CellCharacter(sudokuPuzzle[5,2])} ║ {CellCharacter(sudokuPuzzle[5,3])} │ {CellCharacter(sudokuPuzzle[5,4])} │ {CellCharacter(sudokuPuzzle[5,5])} ║ {CellCharacter(sudokuPuzzle[5,6])} │ {CellCharacter(sudokuPuzzle[5,7])} │ {CellCharacter(sudokuPuzzle[5,8])} ║");
            Console.WriteLine("╠═══╪═══╪═══╬═══╪═══╪═══╬═══╪═══╪═══╣");
            Console.WriteLine($"║ {CellCharacter(sudokuPuzzle[6,0])} │ {CellCharacter(sudokuPuzzle[6,1])} │ {CellCharacter(sudokuPuzzle[6,2])} ║ {CellCharacter(sudokuPuzzle[6,3])} │ {CellCharacter(sudokuPuzzle[6,4])} │ {CellCharacter(sudokuPuzzle[6,5])} ║ {CellCharacter(sudokuPuzzle[6,6])} │ {CellCharacter(sudokuPuzzle[6,7])} │ {CellCharacter(sudokuPuzzle[6,8])} ║");
            Console.WriteLine("╟───┼───┼───╫───┼───┼───╫───┼───┼───╢");
            Console.WriteLine($"║ {CellCharacter(sudokuPuzzle[7,0])} │ {CellCharacter(sudokuPuzzle[7,1])} │ {CellCharacter(sudokuPuzzle[7,2])} ║ {CellCharacter(sudokuPuzzle[7,3])} │ {CellCharacter(sudokuPuzzle[7,4])} │ {CellCharacter(sudokuPuzzle[7,5])} ║ {CellCharacter(sudokuPuzzle[7,6])} │ {CellCharacter(sudokuPuzzle[7,7])} │ {CellCharacter(sudokuPuzzle[7,8])} ║");
            Console.WriteLine("╟───┼───┼───╫───┼───┼───╫───┼───┼───╢");
            Console.WriteLine($"║ {CellCharacter(sudokuPuzzle[8,0])} │ {CellCharacter(sudokuPuzzle[8,1])} │ {CellCharacter(sudokuPuzzle[8,2])} ║ {CellCharacter(sudokuPuzzle[8,3])} │ {CellCharacter(sudokuPuzzle[8,4])} │ {CellCharacter(sudokuPuzzle[8,5])} ║ {CellCharacter(sudokuPuzzle[8,6])} │ {CellCharacter(sudokuPuzzle[8,7])} │ {CellCharacter(sudokuPuzzle[8,8])} ║");
            Console.WriteLine("╚═══╧═══╧═══╩═══╧═══╧═══╩═══╧═══╧═══╝");
            Console.WriteLine();
        }

        private static char CellCharacter(int number)
        {
            return number != 0 ? (char) ('0' + number) : ' ';
        }
    }
}
