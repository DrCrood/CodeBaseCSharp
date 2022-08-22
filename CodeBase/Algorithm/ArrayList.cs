using CodeBase.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public class ArrayList
        {
        /// <summary>
        /// Merge input list of intervals if there are any overlaps.
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns>Merged interval list</returns>
        public static int[][] MergeOverlapIntervals(int[][] intervals)
        {
            List<int[]> mergedList = new List<int[]>();
            int size = intervals.Length;
            Utility.QuickSort2D(intervals, 0, 0, size-1);

            for(int i = 0; i < size; i++)
            {
                int k = 1;
                int end = intervals[i][1];
                while(i+k< size && end >= intervals[i+k][0])
                {
                    end = end > intervals[i + k][1] ? end : intervals[i + k][1];
                    k++;
                }

                mergedList.Add(new int[] { intervals[i][0], end });

                i += k-1;

            }

            int fsize = mergedList.Count;

            int[][] result = new int[fsize][];
            for(int i= 0; i<fsize; i++)
            {
                result[i] = new int[] { mergedList[i][0], mergedList[i][1] };
            }

            return result;

        }

        /// <summary>
        /// Calculate the sum of all subarrays strength.
        /// The array strenght = [array sum]*[smallest item in the array]
        /// </summary>
        /// <param name="strength"></param>
        /// <returns></returns>
        public int SumOfAllSubArrayStrength(int[] strength)
        {

           throw new NotImplementedException();
        }

        public static ListNode MergeKSortedLists(ListNode[] lists)
        {
            int k = lists.Length;
            ListNode[] heap = new ListNode[k];
            int[] listIndex = new int[k];
            for (int i = 0; i < k; i++) listIndex[i] = -1;
            int heapSize = 0;
            for (int i = 0; i < k; i++)
            {
                if (lists[i] != null)
                {
                    listIndex[heapSize] = i;
                    Heap.MinHeapInsert_ObjectIndex(heap, heapSize, lists[i], listIndex);
                    lists[i] = lists[i].next;
                    heapSize++;
                }
            }
            if(heapSize < 1)
            {
                return null;
            }

            int nextIndex = listIndex[0];
            ListNode header = Heap.MinHeapPop_ObjectIndex(heap, heapSize, listIndex);
            heapSize--;

            if (lists[nextIndex] != null)
            {
                listIndex[heapSize] = nextIndex;
                Heap.MinHeapInsert_ObjectIndex(heap, heapSize, lists[nextIndex], listIndex);
                lists[nextIndex] = lists[nextIndex].next;
                heapSize++;
            }
            ListNode tail = header;
            while(heapSize > 0)
            {
                nextIndex = listIndex[0];
                tail.next = Heap.MinHeapPop_ObjectIndex(heap, heapSize, listIndex);
                tail = tail.next;
                heapSize -= 1;
                if (lists[nextIndex] != null)
                {
                    listIndex[heapSize] = nextIndex;
                    Heap.MinHeapInsert_ObjectIndex(heap, heapSize, lists[nextIndex], listIndex);
                    lists[nextIndex] = lists[nextIndex].next;
                    heapSize++;
                }
            }

            return header;
        }

        /// <summary>
        /// Get Kth permutation of input string
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string getKthPermutation(string s, int k)
        {
            int n = s.Length;
            if(n > 20)
            {
                return "Error: Input string too long! Max allowed 20.";
            }
            StringBuilder builder = new StringBuilder();
            List<char> clist = s.ToList();
            GetNextChar(builder, clist, n, k);
            return builder.ToString();
        }

        public static void GetNextChar(StringBuilder builder, List<char> chars, int n, long k)
        {
            long p = Utility.getFactorial(n - 1);
            if (k <= p)
            {
                builder.Append(chars[0].ToString());
                chars.RemoveAt(0);
                if (chars.Count == 1)
                {
                    builder.Append(chars[0].ToString());
                    return;
                }
                GetNextChar(builder, chars, n - 1, k);
            }
            else
            {
                int index = (int)Math.Ceiling(1.0 * k / p) - 1;

                builder.Append(chars[index].ToString());
                chars.RemoveAt(index);
                if (chars.Count == 1)
                {
                    builder.Append(chars[0].ToString());
                    return;
                }
                k = k - index * p;
                n = n - 1;
                GetNextChar(builder, chars, n, k);
            }
        }

        /// <summary>
        /// Find the longest increasing sequence in a number list
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>comman sequence</returns>
        public static List<int> LongestIncreasingSubsequence(List<int> nums)
        {
            int n = nums.Count;
            HashSet<int> unums = new HashSet<int>(nums);

            List<int> ulist = new List<int>(unums);

            ulist.Sort();

            List<int> result = GetSubNumMatch(ulist, nums, 0, 0, ulist.Count - 1, nums.Count - 1);

            return result;
        }

        private static List<int> GetSubNumMatch(List<int> a, List<int> b, int sa, int sb, int ea, int eb)
        {
            List<int> l = new List<int>();
            if (sa > ea || sb > eb)
            {
                return l;
            }

            if (a[sa] == b[sb])
            {
                l.Add(a[sa]);
                l.AddRange(GetSubNumMatch(a, b, sa + 1, sb + 1, ea, eb));
                return l;
            }
            else
            {
                List<int> up = GetSubNumMatch(a, b, sa + 1, sb, ea, eb);
                List<int> down = GetSubNumMatch(a, b, sa, sb + 1, ea, eb);
                return up.Count > down.Count ? up : down;
            }
        }
        /// <summary>
        /// Find the largest permutation by swap max k times
        /// The arr is a array with number from 1 to arr.Count
        /// </summary>
        /// <param name="k"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static List<int> LargestPermutation(int k, List<int> arr)
        {
            int size = arr.Count;
            int[] lo = new int[size + 1];

            for (int i = 0; i < size; i++)
            {
                lo[arr[i]] = i;
            }
            int n = size;
            for (int j = 0; j < size && k > 0; j++)
            {
                if (arr[j] == n) { n--; continue; }

                int jlo = lo[arr[j]];
                int nlo = lo[n];

                int tmp = arr[j];
                arr[j] = n;
                arr[nlo] = tmp;

                lo[n] = jlo;
                lo[tmp] = nlo;
                n--;
                k--;
            }
            return arr;
        }

        public static void StringSort(List<string> list1, List<string> list2)
        {

            //IComparer
            list1.Sort((string a, string b) => a.Length - b.Length);

            //Linq
            list2 = list2.OrderBy(s => s.Length).ToList();

            
        }
    }
}
