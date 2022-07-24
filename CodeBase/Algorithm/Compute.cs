using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algoriths
{
    public static class Compute
    {
        public static bool IsPrime(int n)
        {
            if (n < 2)
            {
                return false;
            }
            int s = 2;
            int e = (int)Math.Sqrt(n);

            for (int k = s; k <= e; k++)
            {
                if (n % k == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int ReverseNumber(int i)
        {
            if (i < 0)
            {
                return 0;
            }
            int r = 0;
            while (i > 0)
            {
                int d = i % 10;
                r = r * 10 + d;
                i = (i - d) / 10;
            }
            return r;
        }

        public static int[] SquentialNumbers(int low, int high)
        {
            List<int> result = new List<int>();

            for (int i = low; i <= high; i++)
            {
                if (IsSequential(i))
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }

        public static bool IsSequential(int n)
        {
            if (n < 11)
            {
                return false;
            }
            int predig = -1;
            while (n > 0)
            {
                int d = -1;
                d = n % 10;
                n = (n - d) / 10;
                if (predig < 0)
                {
                    predig = d;
                }
                else
                {
                    if (predig - d != 1)
                    {
                        return false;
                    }
                    predig = d;
                }
            }
            return true;
        }

        public static int MinimumSwaps(int[] data)
        {
            int sum = 0;
            int size = data.Length;
            foreach (int i in data)
            {
                sum += i;
            }

            int ones = sum;
            int minSwaps = 0;
            for(int i=0; i<ones; i++)
            {
                if (data[i] ==0)
                {
                    minSwaps++;
                }
            }

            int swaps = minSwaps;
            for(int j = ones; j<size; j++)
            {
                if(data[j] > data[j-ones])
                {
                    swaps--;
                }
                else if(data[j] < data[j-ones])
                {
                    swaps++;
                }
                if(swaps < minSwaps)
                {
                    minSwaps = swaps;
                }
            }
            return minSwaps;
        }

        public static int RottingOranges(int[][] orgs)
        {
            int row = orgs.Length;
            int col = orgs[0].Length;

            int minutes = 0;
            int freshes = 0;
            int maxMin = row + col;
            while(maxMin > 0)
            {
                minutes++;
                freshes = 0;
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if(orgs[i][j] == 0 || orgs[i][j] == 2)
                        {
                            continue;
                        }

                        if( (i!=0 && orgs[i-1][j] == 2) || (i != row-1 && orgs[i+1][j] == 2) || (j != 0 && orgs[i][j-1] == 2) || (j != col-1 && orgs[i][j+1] == 2))
                        {
                            orgs[i][j] = 5;
                        }
                    }
                }

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (orgs[i][j] == 5)
                        {
                            orgs[i][j] = 2;
                        }

                        if (orgs[i][j] == 1)
                        {
                            freshes++;
                        }
                    }
                }

                if (freshes == 0)
                {
                    return minutes;
                }
                maxMin--;
            }

            return -1;
        }

        public static int RottingOranges_BFS(int[][] orgs)
        {
            int row = orgs.Length;
            int col = orgs[0].Length;
            int freshes = 0;
            Queue<(int i, int j, int m)> rotted = new Queue<(int i, int j, int m)>();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if(orgs[i][j] == 2)
                    {
                        rotted.Enqueue((i,j,0));
                    }else if
                    (orgs[i][j] == 1)
                    {
                        freshes++;
                    }
                }
            }
            int max = 0;
            while (rotted.Count > 0)
            {
                (int i, int j, int m) = rotted.Dequeue();
                int k = m;
                m++;
                if(i !=0 && orgs[i - 1][j] == 1)
                {
                    orgs[i - 1][j] = 2;
                    rotted.Enqueue((i-1,j,m));
                    k = m;
                    freshes--;
                }

                if (i != row-1 && orgs[i+1][j] == 1)
                {
                    orgs[i+1][j] = 2;
                    rotted.Enqueue((i+1, j, m));
                    k = m;
                    freshes--;
                }

                if (j != 0 && orgs[i][j-1] == 1)
                {
                    orgs[i][j-1] = 2;
                    rotted.Enqueue((i, j-1, m));
                    k = m;
                    freshes--;
                }

                if (j != col-1 && orgs[i][j+1] == 1)
                {
                    orgs[i][j+1] = 2;
                    rotted.Enqueue((i, j+1, m));
                    k = m;
                    freshes--;
                }

                if(k>max)
                {
                    max = k;
                }
            }

            return freshes == 0? max : -1;

        }


        public static int[][] KClosestPoints(int x, int y, int[][] points, int k)
        {
            int[][] npoints = new int[points.Length][];

            int[][] result = new int[k][];

            for(int i = 0; i < points.Length; i++)
            {
                npoints[i] = new int[3] { points[i][0], points[i][1], (points[i][0]-x)*(points[i][0]-x) + (points[i][1]-y)*(points[i][1]-y)};
            }

            QuickSortObject(npoints, 0, npoints.Length-1);

            for(int i = 0; i < k; i++)
            {
                result[i] = new int[] { npoints[i][0], npoints[i][1]};
            }

            return result;
        }

        public static void QuickSortObject(int[][] points, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(points, start, end);
                QuickSortObject(points, start, pivot - 1);
                QuickSortObject(points, pivot + 1, end);
            }
        }

        public static int Partition(int[][] a, int start, int end)
        {
            int index = start;

            for (int i = start; i < end; i++)
            {
                if (a[i][2] <= a[end][2]) //Sort ascending
                {
                    int[] tmp = a[i];
                    a[i] = a[index];
                    a[index] = tmp;
                    index++;
                }
            }

            int[] t = a[index];
            a[index] = a[end];
            a[end] = t;

            return index;
        }

        public static int SumSubarrayMins(int[] arr)
        {
            int re = 0;

            int size = arr.Length;
            int min = 100000;

            long sum = 0;
            int minIndex = 0;
            for(int i=0; i< size; i++)
            {
                if(arr[i] < min)
                {
                    minIndex = i;
                }
            }        





            return re;
        }

        //Find the shortest path in a grid from point a to point b.
        //The algorithm is like the BFS in Graph.
        public static int ShortestPathInGrid(char[][] grid)
        {
            int row = grid.Length;
            int col = grid[0].Length;

            int[,] count = new int[row, col];
            int[] person = new int[2];
            List<int[]> food = new List<int[]>();
            

            for(int i=0; i<row; i++)
            {
                for(int j=0; j<col; j++)
                {
                    count[i,j] = -1;
                    if (grid[i][j] == '*')
                    {
                        person[0] = i;
                        person[1] = j;
                    }
                }
            }

            Queue <(int, int)> queue = new Queue<(int,int)>();
            count[person[0], person[1]] = 0;
            queue.Enqueue((person[0], person[1]));

            while(queue.Count > 0)
            {
                (int i, int j) = queue.Dequeue();
                if (i != 0)
                {
                    if (grid[i-1][j] == 'O' && count[i - 1, j] < 0 )
                    {
                        count[i-1, j] = count[i, j] + 1;
                        queue.Enqueue((i-1, j));
                    }
                    if (grid[i-1][j] == '#')
                    {
                        return count[i, j] + 1;
                    }
                }

                if (j != 0)
                {
                    if (grid[i][j - 1] == 'O' && count[i, j-1] < 0)
                    {
                        count[i, j-1] = count[i, j] + 1;
                        queue.Enqueue((i,j-1));
                    }
                    if (grid[i][j - 1] == '#')
                    {
                        return count[i, j] + 1;
                    }
                }
                if (i != row- 1)
                {
                    if (grid[i + 1][j] == 'O' && count[i + 1, j] < 0)
                    {
                        count[i + 1, j] = count[i, j] + 1;
                        queue.Enqueue((i+1,j));
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


        public static int FlipStringtoMonoIncreasing(string s)
        {
            int re = 0;

            int ones = 0;
            foreach(char c in s)
            {
                if(c == '1')
                {
                    ones++;
                }
            }
            int zeros = s.Length - ones;
            int min = ones < zeros? ones:zeros;

            int i = 0;
            int j = s.Length - 1;
            int zerosFound = 0;
            int onesFound = 0;
            int flips = 0;
            while(i<j)
            {
                if (s[i] == '0' && s[j] == '1')
                {
                    zerosFound++;
                    onesFound++;
                    i++;
                    j--;
                    continue;
                }

                if (s[i] == '0' && s[j] == '0')
                {

                }

                if (s[j] == '1')
                {
                    onesFound++;
                }

                i++;
                j--;
            }


            return re;
        }


    }
}
