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


    }
}
