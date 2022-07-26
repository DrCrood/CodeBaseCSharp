using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algoriths
{
    public class Search
    {
        private struct Stock
        {
            public int present;
            public int future;
            public int profit;
            public double profitR;
            public Stock(int pre, int fu, int pro)
            {
                present = pre;
                future = fu;
                profit = pro;
                profitR = (fu - pre) / (1.0 * pre);
            }
        }

        public static List<string> grid = new List<string>() { "7283455864", "6731158619", "8988242643", "3830589324", "2229505813", "5633845374", "6473530293", "7053106601", "0834282956", "4607924137" };
        public static List<string> pattern = new List<string>() { "9505", "3845", "3530" };
        public static List<string> pattern2 = new List<string>() { "7283", "6731", "8988" };
        public static List<string> pattern3 = new List<string>() { "6601", "2956", "4137" };
        public static (int, int) SearchPatternInGrid(List<string> Grid, List<string> Pattern)
        {
            int gs = Grid.Count;
            int ps = Pattern.Count;
            int pl = Pattern[0].Length;
            int row = -1;
            int col = -1;
            bool found = true;
            for (row = 0; row <= gs - ps; row++)
            {
                int index = 0;
                while (true)
                {
                    index = Grid[row].IndexOf(Pattern[0], index);
                    found = true;
                    if (index < 0)
                    {
                        found = false;
                        break;
                    }
                    for (int i = 1; i < ps; i++)
                    {
                        int k = Grid[row + i].IndexOf(Pattern[i], index);
                        if (k != index)
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        return (row,index);
                    }
                    index++;
                }
            }

            return (-1,-1);
        }



        public static void separateNumbers(string s)
        {
            int size = s.Length;
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(s.Substring(i, 1));
            }

            int maxlength = size / 2;
            bool beautiful = false;
            long min = 0;
            long start = 0;
            for (int l = 1; l <= maxlength; l++)
            {
                beautiful = true;
                start = 0;
                for (int i = 0; i < l; i++)
                {
                    start = start * 10 + arr[i];
                }
                int startindex = l;
                while (true)
                {
                    int endindex = FindNextMatch(startindex, l, size, start + 1, arr);
                    if (endindex < 0)
                    {
                        beautiful = false;
                        break;
                    }

                    if (endindex == size - 1)
                    {
                        break;
                    }

                    startindex = endindex + 1;
                    start++;
                }

                if (beautiful)
                {
                    for (int k = 0; k < l; k++)
                    {
                        min = min * 10 + arr[k];
                    }

                    break;
                }

            }

            if (beautiful)
            {
                Console.WriteLine($"YES {min}");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        public static int FindNextMatch(int index, int length, int size, long number, int[] arr)
        {
            Console.WriteLine($"index={index}, length={length}, number={number}");
            if (arr[index] == 0)
            {
                return -1;
            }
            long next = 0;
            int endindex = Math.Min(index + length - 1, size - 1);
            for (int k = index; k <= endindex; k++)
            {
                next = next * 10 + arr[k];
            }

            if (next == number)
            {
                return endindex;
            }

            if (endindex == size - 1)
            {
                return -1;
            }

            next = 0;
            for (int k = index; k <= endindex + 1; k++)
            {
                next = next * 10 + arr[k];
            }
            if (next == number)
            {
                return endindex + 1;
            }

            return -1;
        }


        public static int[] FindMinmumLoss(List<int> prices)
        {
            Hashtable ht = new Hashtable();

            int size = prices.Count;
            for (int i = 0; i < size; i++)
            {
                ht.Add(prices[i], i);
            }

            prices.Sort();

            int min = 1000000;
            int s = 0;
            int e = 1;
            int mins = 0;
            int mine = 0;
            while (true)
            {
                while ((int)ht[prices[e]] > (int)ht[prices[s]])
                {
                    Console.WriteLine(ht[prices[e]] + " " + ht[prices[s]]);
                    e++;
                    if (e == size)
                    {
                        break;
                    }
                }

                if (e < size && prices[e] - prices[s] < min)
                {
                    min = prices[e] - prices[s];
                    mins = s;
                    mine = e;
                }

                s++;
                e = s + 1;
                if (e == size)
                {
                    break;
                }

            }


            return new int[3] { min, prices[mins],prices[mine] };
        }

        public static IList<string> SearchWordsInGrid(char[][] board, string[] words)
        {
            List<string> result = new List<string>();

            foreach (string word in words)
            {
                if(WordExistsInGrid(board,word))
                {
                    result.Add(word);
                }
            }

            return result;
        }

        public static bool WordExistsInGrid(char[][] board, string word)
        {
            int row = board.Length;
            int col = board[0].Length;

            List<(int, int)> startp = new List<(int, int)>();
            int[,] count = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (board[i][j] == word[0])
                    {
                        startp.Add((i, j));
                    }
                }
            }

            foreach ((int i, int j) in startp)
            {
                if (FindTheNextCharInTheWord(i, j, row, col, 1, board, word, count))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool FindTheNextCharInTheWord(int i, int j, int row, int col, int index, char[][] board, string word, int[,] count)
        {
            if (index == word.Length)
            {
                return true;
            }
            count[i,j] = 1;
            if (i != 0 && count[i-1,j] < 1 && board[i - 1][j] == word[index])
            {
                if (FindTheNextCharInTheWord(i - 1, j, row, col, index + 1, board, word, count))
                {
                    return true;
                }
            }
            if (j != 0 && count[i, j-1] < 1 && board[i][j - 1] == word[index])
            {
                if (FindTheNextCharInTheWord(i, j - 1, row, col, index + 1, board, word, count))
                {
                    return true;
                }
            }
            if (i != row - 1 && count[i+1, j] < 1 && board[i + 1][j] == word[index])
            {
                if (FindTheNextCharInTheWord(i + 1, j, row, col, index + 1, board, word, count))
                {
                    return true;
                }
            }
            if (j != col - 1 && count[i, j+1] < 1 && board[i][j + 1] == word[index])
            {
                if (FindTheNextCharInTheWord(i, j + 1, row, col, index + 1, board, word, count))
                {
                    return true;
                }
            }
            count[i, j] = 0;
            return false;
        }

        public static void FindTheBestStockCombinationUnderBudget()
        {
            int[] present = new int[35] { 24, 34, 55, 67, 123, 200, 18, 25, 30, 35, 40, 45, 150, 188, 65, 79, 42, 33, 90, 129, 66, 80, 96, 8, 12, 5, 10, 15, 20, 25, 10, 20, 30, 40, 50 };
            int[] future = new int[35] { 29, 30, 50, 69, 130, 202, 28, 35, 38, 25, 39, 59, 200, 200, 68, 85, 50, 30, 99, 138, 70, 85, 120, 28, 25, 9, 14, 22, 33, 44, 15, 26, 37, 48, 59 };

            int budget = 150;
            List<Stock> stocks = new List<Stock>();
            int n = present.Length;
            for (int i = 0; i < n; i++)
            {
                if (future[i] - present[i] > 0)
                {
                    stocks.Add(new Stock(present[i], future[i], future[i] - present[i]));
                }
            }
        }

        public static void FindDivisions()
        {
            int[] a = new int[] { 4, 15 };
            a = new int[] { 4, 4, 4, 4 };
            a = new int[] { 2, 2, 3 };
            a = new int[] { 2, 2, 1, 2, 3, 5 };
            a = new int[] { 1, 2, 3, 1, 1, 1 };
            a = new int[] { 4, 17, 18, 3, 2, 10, 9, 5, 5, 5, 1, 5, 10, 1, 10 };
            a = new int[] { 1, 1, 1, 1, 1, 1, 3, 3, 3, 5, 5, 4, 1, 6, 8, 1, 1, 2, 5, 4, 3, 11, 1, 3, 3, 8, 4, 5, 6, 3, 1, 4, 8, 1, 2, 4, 4, 3, 3, 1 };
            int max = -1;
            int min = 1000000;
            foreach (int i in a)
            {
                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
            }

            if (max == min)
            {
                Console.WriteLine("[{0}]", string.Join(", ", a));
                return;
            }

            int groupSize = max;
            int index = 0;
            int ops = 0;
            int groupSum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                groupSum = 0;
                while (groupSum < groupSize)
                {
                    groupSum += a[i];
                    i++;
                    if (i == a.Length)
                    {
                        break;
                    }
                    ops++;
                }

                if (groupSum == groupSize)
                {
                    if (i == a.Length)
                    {
                        Console.WriteLine(groupSize);
                    }
                    i--;
                    continue;
                }

                if (i == a.Length && groupSum < groupSize)
                {
                    groupSize += groupSum;
                }
                else
                {
                    groupSize = groupSum;
                }
                i = -1;
            }
        }
    }
}
