using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    public static class Compute
    {
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

        /// <summary>
        /// Group anagram strings together in a list of strings
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static IList<IList<string>> GroupAnagrams(string[] strings)
        {
            int size = strings.Length;
            IList<IList<string>> result = new List<IList<string>>();

            int[] counter = new int[26];

            Dictionary<string,List<int>> dict = new Dictionary<string, List<int>>();
            StringBuilder sb = new StringBuilder();

            for(int n=0; n<size; n++)
            {
                sb.Clear();
                GetReorderedString(strings[n], sb, counter);
                string key = sb.ToString();
                if (dict.ContainsKey(key))
                {
                    dict[key].Add(n);
                }
                else
                {
                    dict[key] = new List<int> { n};
                }                
            }

            foreach(KeyValuePair<string,List<int>> pair in dict)
            {
                List<string> sl = new List<string>();
                foreach(int i in pair.Value)
                {
                    sl.Add(strings[i]);
                }
                result.Add(sl);
            }

            return result;
        }

        public static void GetReorderedString(string s, StringBuilder sb, int[] counter)
        {
            for (int i = 0; i < 26; i++) counter[i] = 0;

            foreach (char c in s)
            {
                counter[c - 97]++;
            }

            for(int i=0; i<26; i++)
            {
                for(int j=0; j < counter[i]; j++)
                {
                    sb.Append((char)(i+97));
                }
            }
        }

        public static int RottingOranges_Simple(int[][] orgs)
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

            Utility.QuickSort2D(npoints,2, 0, npoints.Length-1);

            for(int i = 0; i < k; i++)
            {
                result[i] = new int[] { npoints[i][0], npoints[i][1]};
            }

            return result;
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
