using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm.Graph
{
    public class Graph
    {
        /// <summary>
        /// Find the shortest path in a grid from point a to point b. The code use BFS to find the shortest path.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>The shortest path between two points</returns>
        public static int ShortestPathInGrid(char[][] grid)
        {
            //'O' -> free path
            //'X' -> blocked path
            //'*' -> starting point
            //'#' -> end points, could have multiple, find the closest one.
            int row = grid.Length;
            int col = grid[0].Length;

            int[,] count = new int[row, col];
            int[] person = new int[2];
            List<int[]> food = new List<int[]>();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    count[i, j] = -1;
                    if (grid[i][j] == '*')
                    {
                        person[0] = i;
                        person[1] = j;
                    }
                }
            }

            Queue<(int, int)> queue = new Queue<(int, int)>();
            count[person[0], person[1]] = 0;
            queue.Enqueue((person[0], person[1]));

            while (queue.Count > 0)
            {
                (int i, int j) = queue.Dequeue();
                if (i != 0)
                {
                    if (grid[i - 1][j] == 'O' && count[i - 1, j] < 0)
                    {
                        count[i - 1, j] = count[i, j] + 1;
                        queue.Enqueue((i - 1, j));
                    }
                    if (grid[i - 1][j] == '#')
                    {
                        return count[i, j] + 1;
                    }
                }

                if (j != 0)
                {
                    if (grid[i][j - 1] == 'O' && count[i, j - 1] < 0)
                    {
                        count[i, j - 1] = count[i, j] + 1;
                        queue.Enqueue((i, j - 1));
                    }
                    if (grid[i][j - 1] == '#')
                    {
                        return count[i, j] + 1;
                    }
                }
                if (i != row - 1)
                {
                    if (grid[i + 1][j] == 'O' && count[i + 1, j] < 0)
                    {
                        count[i + 1, j] = count[i, j] + 1;
                        queue.Enqueue((i + 1, j));
                    }

                    if (grid[i + 1][j] == '#')
                    {
                        return count[i, j] + 1;
                    }
                }

                if (j != col - 1)
                {
                    if (grid[i][j + 1] == 'O' && count[i, j + 1] < 0)
                    {
                        count[i, j + 1] = count[i, j] + 1;
                        queue.Enqueue((i, j + 1));
                    }
                    if (grid[i][j + 1] == '#')
                    {
                        return count[i, j] + 1;
                    }
                }

            }

            return -1;

        }
    }
}
