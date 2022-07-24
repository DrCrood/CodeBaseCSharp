using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    internal class TicTacToe
    {
        private char[,] grid;
        private int[] rowCounts;
        private int[] colCounts;
        private int leftdown;
        private int leftup;
        private int[] rowCounts2;
        private int[] colCounts2;
        private int leftdown2;
        private int leftup2;
        private int WIN;
        public TicTacToe(int n)
        {
            rowCounts = new int[n];
            colCounts = new int[n];
            leftdown = 0;
            leftup = 0;
            rowCounts2 = new int[n];
            colCounts2 = new int[n];
            leftdown2 = 0;
            leftup2 = 0;
            WIN = n;
            grid = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }

        public int Move(int row, int col, int player)
        {
            if (player == 1)
            {
                grid[row, col] = 'X';
                if (row == col)
                {
                    leftdown++;
                    if (leftdown == WIN)
                    {
                        return 1;
                    }
                }
                if (row + col == WIN - 1)
                {
                    leftup++;
                    if (leftup == WIN)
                    {
                        return 1;
                    }
                }
                if (rowCounts[row] == WIN - 1 || colCounts[col] == WIN - 1)
                {
                    return 1;
                }
                rowCounts[row]++;
                colCounts[col]++;
            }
            else
            {
                grid[row, col] = 'O';
                if (row == col)
                {
                    leftdown2++;
                    if (leftdown2 == WIN)
                    {
                        return 2;
                    }
                }
                if (row + col == WIN - 1)
                {
                    leftup2++;
                    if (leftup2 == WIN)
                    {
                        return 2;
                    }
                }
                if (rowCounts2[row] == WIN - 1 || colCounts2[col] == WIN - 1)
                {
                    return 2;
                }
                rowCounts2[row]++;
                colCounts2[col]++;
            }

            return 0;
        }

    }
}
