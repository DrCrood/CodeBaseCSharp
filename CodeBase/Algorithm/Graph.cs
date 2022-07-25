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

        /// <summary>
        /// Find the number of islands (represent by 1's) separated by water (0's) in a grid.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>The number of islands</returns>
        public static int NumberOfIslands(char[][] grid)
        {
            int row = grid.Length;
            int col = grid[0].Length;

            int count = 0;

            for(int i=0; i<row; i++)
            {
                for(int j=0; j<col; j++)
                {
                    if (grid[i][j] != '1')
                    {
                        continue;
                    }
                    
                    CoverIsland(i, j, row, col, grid);
                    count++;
                }
            }

            return count;
        }

        private static void CoverIsland(int i, int j, int row, int col, char[][] grid)
        {
            grid[i][j] = '2';
            if (i != 0 && grid[i - 1][j] == '1')
            {
                grid[i - 1][j] = '2';
                CoverIsland(i - 1, j, row, col, grid);
            }

            if (j != 0 && grid[i][j - 1] == '1')
            {
                grid[i][j - 1] = '2';
                CoverIsland(i, j - 1, row, col, grid);
            }
            if (i != row - 1 && grid[i + 1][j] == '1')
            {
                grid[i + 1][j] = '2';
                CoverIsland(i + 1, j, row, col, grid);
            }

            if (j != col - 1 && grid[i][j + 1] == '1')
            {
                grid[i][j + 1] = '2';
                CoverIsland(i, j + 1, row, col, grid);
            }
        }
    }
}
