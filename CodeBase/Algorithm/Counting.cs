using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algoriths
{
    internal class Counting
    {
        /// <summary>
        /// Count how many times the new values if exceeding the double of previous [d] days medium value.
        /// </summary>
        /// <param name="expenditure"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int activityNotificationsBySort(List<int> expenditure, int d)
        {
            int s = expenditure.Count;
            int[] arr = new int[d];

            for (int i = 0; i < d; i++)
            {
                arr[i] = expenditure[i];
            }

            QuickSort(arr, 0, d - 1);

            int mlow = (int)(Math.Ceiling((double)d / 2)) - 1;
            int mup = (int)(Math.Floor((double)d / 2));

            int[] medium = new int[2];
            int notices = 0;
            int curexp = 0;
            int preexp = 0;
            for (int k = d; k < s; k++)
            {
                medium[0] = arr[mlow];
                medium[1] = arr[mup];
                curexp = expenditure[k];
                preexp = expenditure[k - d];

                if (curexp >= medium[0] + medium[1])
                {
                    notices++;
                }

                int l = -1;
                int low = 0;
                int high = d - 1;
                if (preexp > medium[0])
                {
                    low = d / 2;
                }
                else
                {
                    high = d / 2;
                }

                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    if (preexp == arr[mid])
                    {
                        l = mid;
                        break;
                    }
                    else if (preexp > arr[mid])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }

                arr[l] = curexp;

                if (curexp > preexp)
                {
                    int m = l + 1;
                    while (m < d && curexp > arr[m])
                    {
                        arr[m - 1] = arr[m];
                        m++;
                    }
                    arr[m - 1] = curexp;
                }
                if (curexp < preexp)
                {
                    int m = l - 1;
                    while (m >= 0 && curexp < arr[m])
                    {
                        arr[m + 1] = arr[m];
                        m--;
                    }
                    arr[m + 1] = curexp;
                }
            }

            return notices;
        }

        public static void QuickSort(int[] a, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(a, start, end);
                QuickSort(a, start, pivot - 1);
                QuickSort(a, pivot + 1, end);
            }
        }

        public static int Partition(int[] a, int start, int end)
        {
            int index = start;

            for (int i = start; i < end; i++)
            {
                if (a[i] <= a[end]) //Sort ascending
                {
                    int tmp = a[i];
                    a[i] = a[index];
                    a[index] = tmp;
                    index++;
                }
            }

            int t = a[index];
            a[index] = a[end];
            a[end] = t;

            return index;
        }

        //This method works only of the input list has a fixed number range
        //current example assume the numbers in the input list is between 0-200
        public static int activityNotificationsByCounting(List<int> expenditure, int d)
        {
            int s = expenditure.Count;
            int[] arr = new int[201];

            for (int k = 0; k < d; k++)
            {
                arr[expenditure[k]]++;
            }

            int mlow = (int)(Math.Ceiling((double)d / 2)) - 1;
            int mup = (int)(Math.Floor((double)d / 2));

            int[] medium = new int[2];
            int notices = 0;
            int curexp = 0;
            int preexp = 0;
            int count = -1;

            int i = 0;
            bool reachedlow = false;
            while (true)
            {
                //reachedlow = false;
                count += arr[i];
                if (count >= mlow && !reachedlow)
                {
                    medium[0] = i;
                    reachedlow = true;
                }
                if (count >= mup)
                {
                    medium[1] = i;
                    break;
                }
                i++;
            }

            //Console.WriteLine($"medium[0]={medium[0]}, medium[1]={medium[1]}, mlow={mlow}, mup={mup}");
            for (int k = d; k < s; k++)
            {
                curexp = expenditure[k];
                preexp = expenditure[k - d];

                if (curexp >= medium[0] + medium[1])
                {
                    notices++;
                }

                //Console.WriteLine($"medium[0]={medium[0]}, medium[1]={medium[1]}, curexp={curexp}");

                arr[preexp]--;
                arr[curexp]++;
                i = 0;
                count = -1;
                reachedlow = false;
                while (true)
                {
                    count += arr[i];
                    if (count >= mlow && !reachedlow)
                    {
                        medium[0] = i;
                        reachedlow = true;
                    }
                    if (count >= mup)
                    {
                        medium[1] = i;
                        break;
                    }
                    i++;
                }

            }

            return notices;
        }

        //Count numbers of pair numbers in the array with difference k
        public static int  CountPairsInList(int k, int[] arr)
        {
            int size = arr.Length;
            QuickSort(arr, 0, size - 1);

            int i = 0;
            int j = 0;

            int re = 0;
            for (i = 0; i < size - 1; i++)
            {
                while (arr[j] - arr[i] < k)
                {
                    j++;
                    if (j == size)
                    {
                        return re;
                    }
                }
                if (arr[j] - arr[i] == k)
                {
                    re++;
                }

            }

            return re;
        }

        //Find the maximum common child string of two string with same length
        public static int MaxCommonChild(string s1, string s2)
        {
            int size = s1.Length;
            int[,] count = new int[size + 2, size + 2];
            for (int i = 0; i < size + 2; i++)
            {
                for (int j = 0; j < size + 2; j++)
                {
                    count[i, j] = -1;
                }
            }

            return MaxCommon(s1, s2, 0, 0, size, count);
        }

        public static int MaxCommon(string s1, string s2, int i, int j, int size, int[,] count)
        {
            if (i >= size || j >= size)
            {
                return 0;
            }

            if (count[i, j] >= 0)
            {
                return count[i, j];
            }

            if (s1[i] == s2[j])
            {
                count[i + 1, j + 1] = MaxCommon(s1, s2, i + 1, j + 1, size, count);
                count[i, j] = 1 + count[i + 1, j + 1];
                return count[i, j];
            }

            count[i, j+1] = MaxCommon(s1, s2, i, j + 1, size, count);
            count[i+1, j] = MaxCommon(s1, s2, i + 1, j, size, count);

            count[i, j] = Math.Max(count[i, j+1], count[i+1, j]);

            return count[i, j];

        }

        public static int MaxLengthWithPositionProduct(int[] nums)
        {
            int size = nums.Length;
            int start = 0;
            int end = 0;
            int product = 1;
            int max = 0;
            for(int i=0; i<size; i++)
            {
                if(nums[i] == 0)
                {
                    start = i+1;
                    end = i+1;
                    continue;
                }

                if(nums[i] < 0)
                {
                    product *= -1;
                }

                if(product > 0)
                {
                    end = i;
                    if (end - start + 1 > max)
                    {
                        max = end - start + 1;
                    }
                }

            }
            return max;
        }

    }
}
