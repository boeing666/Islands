using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace islands
{
    public class Logic
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Counter { get; set; } = 2;
        public int[][] Matrix { get; set; }

        public List<ConsoleColor> Colors = new List<ConsoleColor>()
        {
            ConsoleColor.White,
            ConsoleColor.DarkGray,
            ConsoleColor.DarkBlue,
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkYellow
        };

        public void FillMatrix(int height, int width)
        {
            Height = height + 2;
            Width = width + 2;
            var rand = new Random();

            Matrix = new int[Height][];
            for (var i = 0; i < Matrix.Length; i++)
            {
                Matrix[i] = new int[Width];
                for (int j = 0; j < Matrix[i].Length; j++)
                {
                    if (i == 0 || j == 0 || i == Height - 1 || j == Width - 1)
                    {
                        Matrix[i][j] = 0;
                    }
                    else
                    {
                        Matrix[i][j] = rand.Next(1, 4) % 3 == 1 ? 1 : 0;
                    }
                }
            }

            PrintMatrix();

            CalculateIslands();

            Counter -= 2;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Islands Count {Counter}" );
            PrintResult();
        }
        private void PrintMatrix()
        {
            foreach (var row in Matrix)
            {
                for (int j = 0; j < row.Length; j++)
                {
                    Console.ForegroundColor = Colors[row[j]];
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(row[j] + " ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }

        private void PrintResult()
        {
            foreach (var row in Matrix)
            {
                for (int j = 0; j < row.Length; j++)
                {
                    Console.ForegroundColor = Colors[row[j]];
                    Console.BackgroundColor = ConsoleColor.Black;
                    var str = row[j] - 1 == -1 ? 0 : row[j] - 1;
                    Console.Write(str + " ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
        public void CalculateIslands()
        {
            for (int i = 0; i < Matrix.Length; i++)
            {
                for (int j = 0; j < Matrix[i].Length; j++)
                {
                    if (Matrix[i][j] == 1)
                    {
                        MarkWholeIsland(i, j, Counter);
                        Counter++;
                    }

                }
            }
        }

        public void MarkWholeIsland(int i, int j, int count)
        {
            Matrix[i][j] = count;
            if (Matrix[i - 1][j] == 1)
            {
                MarkWholeIsland(i-1, j, count);
            }

            if (Matrix[i - 1][j + 1] == 1)
            {
                MarkWholeIsland(i-1, j+1, count);
            }
            if (Matrix[i][j + 1] == 1)
            {
                MarkWholeIsland(i, j + 1, count);
            }

            if (Matrix[i + 1][j + 1] == 1)
            {
                MarkWholeIsland(i + 1, j + 1, count);
            }

            if (Matrix[i + 1][j] == 1)
            {
                MarkWholeIsland(i + 1, j, count);
            }

            if (Matrix[i + 1][j - 1] == 1)
            {
                MarkWholeIsland(i + 1, j - 1, count);
            }

            if (Matrix[i][j - 1] == 1)
            {
                MarkWholeIsland(i, j - 1, count);
            }

            if (Matrix[i - 1][j - 1] == 1)
            {
                MarkWholeIsland(i-1, j - 1, count);
            }

            if (Matrix[i - 1][j] == 1)
            {
                MarkWholeIsland(i - 1, j, count);
            }
        }

    }
}
