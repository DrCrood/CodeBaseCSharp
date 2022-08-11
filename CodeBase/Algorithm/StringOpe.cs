using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    public class StringOpe
    {
        /// <summary>
        /// Get string permutation
        /// </summary>
        /// <param name="s"></param>
        /// <returns>The list of string permutation</returns>
        public IList<string> GetStringPermutationInOrder(string s)
        {
            int size = s.Length;
            List<string> list = new List<string>();
            StringPermutationInOrder(list, s, 0, size);
            
            return list;
        }

        private void StringPermutationInOrder(List<string> list, string s, int index, int end)
        {
            if(index == end-1)
            {
                list.Add(s);
            }
            for(int i=index; i<end; i++)
            {
                string str = swapChar(s, index, i);
                StringPermutationInOrder(list, str, index + 1, end);
            }
        }

        public static List<string> StringPermutation(string s)
        {
            List<string> list = new List<string>();
            List<char> charList = s.ToList();
            int l = s.Length;

            list.Add(s);
            GetPermutation(0, l, list);

            return list;
        }


        private static void GetPermutation(int i, int j, List<string> list)
        {
            while(i < j)
            {
                List<string> nlist = new List<string>();
                foreach(string str in list)
                {
                    for (int k = i + 1; k < j; k++)
                    {
                        string ss = swapChar(str, i, k);
                        nlist.Add(ss);
                    }
                }
                list.AddRange(nlist);
                i++;
            }
        }

        private static string swapChar(string s, int i, int j)
        {
            char[] a = s.ToCharArray();
            (a[j], a[i]) = (a[i], a[j]);
            return new string(a);

        }

        /// <summary>
        /// Find the longest sub string with all chars appear at least K times.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns>string</returns>
        public string LongestSubStringWithKTimes(string s, int k)
        {
            int[] count = new int[26];
            foreach(char c in s)
            {
                count[c-97]++;
            }

            List<char> splitChars = new List<char>();
            int maxc = 0;
            for(int i=0; i<26; i++)
            {
                if(count[i] > maxc) { maxc = count[i]; }
                if(count[i]<k && count[i]>0)
                {
                    splitChars.Add((char)(i + 97));
                }
            }
            if(maxc < k)
            {
                return "";
            }

            if(splitChars.Count == 0)
            {
                return s;
            }
            string[] splitedStrings = s.Split(splitChars.ToArray());

            int max = 0;
            string maxString = "";
            foreach(string str in splitedStrings)
            {
                if(str.Length < k) { continue; }
                string s2 = LongestSubStringWithKTimes(str, k);
                if(s2.Length > max)
                {
                    maxString = s2;
                }
            }
            return maxString;
        }

        /// <summary>
        /// Find how many times the string B occurs in string A, continuous or discontinuous.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns>number of times</returns>
        public int CountStringSequenceinAnotherString(string A, string B)
        {
            int n = A.Length;
            int m = B.Length;
            int[,] counts = new int[n, m];
            for(int i=0; i<n;i++)
            {
                for(int j=0; j<m;j++)
                {
                    counts[i,j] = -1;
                }
            }
            int res = countMatch(A, B,0,0, A.Length, B.Length, counts);
            return res;
        }

        private int countMatch(string a, string b, int ia, int ib, int la, int lb, int[,] counts)
        {
            if(ib == lb)
            {
                return 1;
            }
            if(ia == la)
            {
                return 0;
            }

            if (counts[ia,ib] != -1)
            {
                return counts[ia,ib];
            }

            if (a[ia] == b[ib])
            {
                counts[ia,ib] = countMatch(a,b,ia+1,ib+1,la,lb,counts) + countMatch(a,b,ia+1,ib,la,lb,counts);
                return counts[ia, ib];
            }
            else
            {
                counts[ia, ib] = countMatch(a, b, ia + 1, ib, la, lb, counts);
                return counts[ia, ib];
            }

        }

        /// <summary>
        /// Count the total occurrences of sequence "AB" in the repeated string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns>number of total occurrences</returns>
        public int CountOccurencesIfStringRepeatKTimes(string s, int k)
        {
            int ca = 0;
            int cb = 0;
            int tc = 0;
            foreach(char c in s)
            {
                if(c == 'A') { ca++; }
                if(c == 'B')
                {
                    cb++;
                    tc += ca;
                }
            }

            return k * tc + (k * (k - 1)) * ca * cb / 2;
        }

        /// <summary>
        /// Count the number of times the sub sequence (length=3) occurs in the string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sub"></param>
        /// <returns>number of occurrence</returns>
        public int CountOccurencesOfSubsequenceWithABCPattern(string s, string sub)
        {
            //count how many sub[0] occurs before sub[1] and how many sub[2] occurs after sub[1]!
            // Use DP method if sub length is more than 3.
            if(sub.Length != 3)
            {
                return -1;
            }
            int n = s.Length;
            int[] countR2L = new int[n];
            int[] countL2R = new int[n];
            int total = 0;
            int cA = 0;
            int cC = 0;
            for(int i=0; i<n; i++)
            {
                if(s[i] == sub[0])
                {
                    cA++;
                }
                if(s[i] == sub[1])
                {
                    countL2R[i] = cA;
                }
            }

            for (int i = n-1; i >=0; i--)
            {
                if (s[i] == sub[2])
                {
                    cC++;
                }
                if (s[i] == sub[1])
                {
                    countR2L[i] = cC;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if(countR2L[i] > 0 && countL2R[i] > 0)
                {
                    total += countR2L[i] * countL2R[i];
                }
            }

            return total;
        }

        private int ArrayTimes(int[] counts)
        {
            int count = 1;
            for(int i=0; i<counts.Length-1; i++)
            {
                count *= counts[i];
            }
            return count;
        }

        /// <summary>
        /// Count the total number of distinct sub sequences in the string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>number of distinct sub sequences</returns>
        public int countDistinctSubSequences(string s)
        {
            int n = s.Length;
            int[] counts = new int[n+1];
            int[] laseIndex = new int[26];
            counts[0] = 1;
            for(int i=1; i<=n; i++)
            {
                counts[i] =2*counts[i-1];
                int li = laseIndex[s[i-1]-97];
                if( li > 0)
                {
                    counts[i] -= counts[li - 1];  
                }
                laseIndex[s[i - 1] - 97] = i;
            }

            return counts[n];
        }

        /// <summary>
        /// Find the longest common sequence length in two strings
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>comman sequence length</returns>
        public int longestCommonSequenceLength(string a, string b)
        {
            int n = a.Length;
            int m = b.Length;

            int[,] counts = new int[n, m];

            int result = MatchStrings(a, b, 0, 0, n-1, m-1);
            return result;
        }

        private int MatchStrings(string a, string b, int sa, int sb, int ea, int eb)
        {
            if(sa > ea || sb > eb)
            {
                return 0;
            }

            if (a[sa] == b[sb])
            {
               return 1 + MatchStrings(a,b,sa+1,sb+1,ea, eb);
            }
            else
            {
                return Math.Max(MatchStrings(a, b, sa + 1, sb, ea, eb), MatchStrings(a, b, sa, sb + 1, ea, eb));
            }
        }

        /// <summary>
        /// Find the longest common sequence in two strings
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>comman sequence</returns>
        public string longestCommonSequence(string a, string b)
        {
            int n = a.Length;
            int m = b.Length;

            int[,] counts = new int[n, m];

            string result = GetSubMatch(a, b, 0, 0, n - 1, m - 1);
            return result;
        }

        private string GetSubMatch(string a, string b, int sa, int sb, int ea, int eb)
        {
            string re = "";
            if (sa > ea || sb > eb)
            {
                return "";
            }

            if (a[sa] == b[sb])
            {
                re = String.Concat(a[sa], GetSubMatch(a, b, sa + 1, sb + 1, ea, eb));
                return re;
            }
            else
            {
                string up = GetSubMatch(a, b, sa + 1, sb, ea, eb);
                string down = GetSubMatch(a, b, sa, sb + 1, ea, eb);
                return up.Length > down.Length? up : down;
            }
        }

        /// <summary>
        /// Find all longest common sequences in two strings
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>List of longest common sequences</returns>
        public HashSet<string> AllLongestCommonSequence(string a, string b)
        {
            int n = a.Length;
            int m = b.Length;

            int[,] counts = new int[n, m];

            HashSet<string> result = GetAllLongestSubSeq(a, b, 0, 0, n - 1, m - 1);
            return result;
        }

        private HashSet<string> GetAllLongestSubSeq(string a, string b, int sa, int sb, int ea, int eb)
        {
            HashSet<string> result = new HashSet<string>();
            if (sa > ea || sb > eb)
            {
                result.Add("");
                return result;
            }

            if (a[sa] == b[sb])
            {
                HashSet<string> ne = GetAllLongestSubSeq(a, b, sa + 1, sb + 1, ea, eb);
                foreach (string s in ne)
                {
                    result.Add(String.Concat(a[sa],s ));
                }
                return result;
            }
            else
            {
                HashSet<string> up = GetAllLongestSubSeq(a, b, sa + 1, sb, ea, eb);
                HashSet<string> down = GetAllLongestSubSeq(a, b, sa, sb + 1, ea, eb);

                if (up.ElementAt(0).Length > down.ElementAt(0).Length)
                {
                    return up;
                }
                else if(up.ElementAt(0).Length < down.ElementAt(0).Length)
                {
                    return down;
                }
                else
                {
                    up.UnionWith(down);
                    return up;
                }         
            }
        }



        /// <summary>
        /// Find the largest variance possible among all sunstrings.
        /// The variance is the largest difference between the number of occurrences of any 2 characters present in the string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>largest variance</returns>
        public int LargestVariance(string s)
        {
            int re = 0;
            return re;

            throw new NotImplementedException();
        }
        /// <summary>
        /// Break the input string into a sentence by adding spaces and using words in Dict.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns>List of sentences</returns>
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int minL = 100;
            int maxL = 0;
            foreach (string word in wordDict)
            {
                if(word.Length > maxL) maxL = word.Length;
                if(word.Length < minL) minL = word.Length;
                dict.Add(word, 0);
            }

            List<string> result = new List<string>();
            List<string> list = new List<string>();
            for (int l= minL; l <= maxL; l++)
            {
                list.Clear();
                FindtheNextWord(s, dict,0,l,minL,maxL,list,s.Length, result);
            }

            return list;
        }

        private void FindtheNextWord(string s, Dictionary<string,int> dict, int index, int length,int minL, int maxL, List<string> list, int size, List<string> result)
        {
            string x = s.Substring(index, length);
            if (dict.ContainsKey(x))
            {
                list.Add(x);
                if (index + length == size)
                {
                    list.Add(x);
                    result.Add(string.Join(" ",list));
                    list.Clear();
                    return;
                }
                for (int l = minL; l <= maxL; l++)
                {
                    if (l + index + length > size)
                    {
                        list.Clear();
                        break;
                    }
                    FindtheNextWord(s, dict, length + index, l, minL, maxL, list,size, result);
                }
                list.Clear();
            }
        }

    }
}
