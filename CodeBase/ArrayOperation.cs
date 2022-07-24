using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace CodeBase
{
    class ArrayOperation
    {

        public int Trap(int[] height)
        {
            //determine the water volumn make by the bars
            int res = 0;
            int n = height.Length;
            int maxheight = 0;
            int[] d = new int[n];

            for (int i = 0; i < n; i++)
            {
                d[i] = 0;
                if (height[i] > maxheight)
                {
                    maxheight = height[i];
                    continue;
                }
                d[i] = maxheight - height[i];
            }

            maxheight = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (height[i] > maxheight)
                {
                    maxheight = height[i];
                }
                if (maxheight - height[i] < d[i])
                {
                    d[i] = maxheight - height[i];
                }
            }
            for (int i = 0; i < n; i++)
            {
                res += d[i];
            }

            return res;
        }

        public int MaxChunksToSorted(int[] arr)
        {
            int res = 0;
            int n = arr.Length;
            int max = -1;
            int maxIndex = 0;
            int maxmin = 0;
            int maxminIndex = 0;
            int endIndex = n;
            while (true)
            {
                max = -1;
                maxmin = 1000000000;
                for (int i = 0; i < endIndex; i++)
                {
                    if (arr[i] >= max)
                    {
                        max = arr[i];
                        maxIndex = i;
                        maxmin = 1000000000;
                    }
                    if (i > maxIndex && maxmin > arr[i])
                    {
                        maxmin = arr[i];
                        maxminIndex = i;
                    }
                }
                bool checkdone = false;
                while (maxIndex < maxminIndex && !checkdone)
                {
                    int tmin = maxmin;
                    int tminIndex = maxminIndex;
                    checkdone = true;
                    for (int m = maxIndex - 1; m >= 0; m--)
                    {
                        if (arr[m] > maxmin)
                        {
                            maxIndex = m;
                            maxmin = tmin;
                            maxminIndex = tminIndex;
                            checkdone = false;
                        }
                        if (arr[m] < tmin)
                        {
                            tmin = arr[m];
                            tminIndex = m;
                        }
                    }
                }

                endIndex = maxIndex;
                Console.WriteLine("cut index = " + endIndex);
                res++;

                if (endIndex < 1)
                {
                    break;
                }
            }

            return res;
        }

        public int LargestRectangleArea(int[] heights)
        {
            int res = 0;
            int n = heights.Length;
            int a = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            if (n < 2)
            {
                return heights[0];
            }
            if (n < 3)
            {
                if (heights[0] < heights[1])
                {
                    return heights[0] * 2 > heights[1] ? heights[0] * 2 : heights[1];
                }
                else
                {
                    return heights[1] * 2 > heights[0] ? heights[1] * 2 : heights[0];
                }
            }

            for (int i = 0; i < n; i++)
            {
                int minh = 100000;
                for (int j = i; j < n; j++)
                {
                    if (heights[j] < minh)
                    {
                        minh = heights[j];
                    }
                    a = minh * (j - i + 1);
                    if (a > res)
                    {
                        res = a;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("time = " + sw.ElapsedMilliseconds + " result = " + res);

            sw.Restart();

            int max = -1 ;

            GetMaxinArray(ref max, heights, 0, n - 1);
            sw.Stop();
            Console.WriteLine("time = " + sw.ElapsedMilliseconds + " result = " + max);

            return max;
        }

        public void GetMaxinArray(ref int max, int[] heights, int start, int end)
        {
            if (end == start)
            {
                max = heights[start] > max ? heights[start] : max;
                return;
            }
            if (end - start == 1)
            {
                if (heights[start] > heights[end])
                {
                    int x = heights[end] * 2 > heights[start] ? heights[end] * 2 : heights[start];
                    max = x > max ? x : max;
                    return;
                }
                else
                {
                    int x = heights[start] * 2 > heights[end] ? heights[start] * 2 : heights[end];
                    max = x > max ? x : max;
                    return;
                }
            }
            int min = 1000000;
            int minIndex = -1;
            for (int i = start; i <= end; i++)
            {
                if (heights[i] < min)
                {
                    min = heights[i];
                    minIndex = i;
                }
            }
            max = min * (end - start + 1) > max ? min * (end - start + 1) : max;

            if (minIndex - start == 0)
            {
                while (heights[start] == heights[start + 1] && start < end - 1)
                {
                    start++;
                }
                GetMaxinArray(ref max, heights, start + 1, end);
            }
            else if (minIndex - start == 1)
            {
                if (heights[start] > max)
                {
                    max = heights[start];
                }
                GetMaxinArray(ref max, heights, start + 2, end);
            }
            else if (end == minIndex)
            {
                GetMaxinArray(ref max, heights, start, end - 1);
            }
            else if (end - minIndex == 1)
            {
                if (heights[end] > max)
                {
                    max = heights[end];
                }
                GetMaxinArray(ref max, heights, start, end - 2);
            }
            else
            {
                GetMaxinArray(ref max, heights, start, minIndex - 1);
                GetMaxinArray(ref max, heights, minIndex + 1, end);
            }
        }

        public String getPermutation(int n, int k)
        {
            StringBuilder builder = new StringBuilder();
            List<int> digits = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                digits.Add(i);
            }

            getNextDigit(builder, digits, n, k);
            return builder.ToString();
        }

        public void getNextDigit(StringBuilder builder, List<int> digits, int n, int k)
        {
            int p = getFactorial(n - 1);
            if (k <= p)
            {
                builder.Append(digits[0].ToString());
                digits.RemoveAt(0);
                if (digits.Count == 1)
                {
                    builder.Append(digits[0].ToString());
                    return;
                }
                getNextDigit(builder, digits, n - 1, k);

            }
            else
            {
                int index = (int)Math.Ceiling((1.0 * k) / p) - 1;

                builder.Append(digits[index].ToString());
                digits.RemoveAt(index);
                if (digits.Count == 1)
                {
                    builder.Append(digits[0].ToString());
                    return;
                }
                k = k - index * p;
                n = n - 1;
                getNextDigit(builder, digits, n, k);
            }
        }

        public int getFactorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            int f = 1;
            for (int i = 2; i <= n; i++)
            {
                f = f * i;
            }
            return f;
        }

        public void Cointoss()
        {
            Random ran = new Random();
            int hh = 0;
            int h = 0;
            int h1 = 0;
            int h2 = 0;
            for (int i = 0; i < 1000000; i++)
            {
                int a = ran.Next(1, 3);
                int b = ran.Next(1, 3);
                int c = ran.Next(1, 3);

                if (a == 1 || b == 1)
                {
                    h1++;
                    if (a == 1 && b == 1)
                    {
                        h2++;
                    }
                }

                if (c == 1)
                {
                    if (a == 1)
                    {
                        h++;
                        if (b == 1)
                        {
                            hh++;
                        }
                    }
                }
                else
                {
                    if (b == 1)
                    {
                        h++;
                        if (a == 1)
                        {
                            hh++;
                        }
                    }
                }
            }
            Console.WriteLine("If we know one of them is head then " + 100 * h2 / h1 + "% chance that another is head too.");
            Console.WriteLine("If random check and found one is head then " + Math.Round(100.0 * hh / h) + "% chance that another is head too.");
        }


        public int activityNotifications(int[] expenditure, int d)
        {
            //using counting sort to quickly find the medium number
            int n = expenditure.Length;
            int notices = 0;
            int[] counts = new int[201];
            for (int k = 0; k < d-1; k++)
            {
                counts[expenditure[k]]++;
            }
            counts[expenditure[0]]++;
            int MSN = d / 2;
            bool even = true;
            if (d % 2 != 0)
            {
                even = false;
                MSN++;
            }

            double medium = UpdateAndgetMedium(counts, MSN, expenditure[0], expenditure[d-1], even);
            if (expenditure[d] >= 2 * medium)
            {
                notices++;
            }


            for (int i = d+1; i < n; i++)
            {
                medium = UpdateAndgetMedium(counts, MSN, expenditure[i - d-1], expenditure[i - 1], even);
                if (expenditure[i] >= 2 * medium)
                {
                    notices++;
                }

            }
            return notices;

        }

        public double UpdateAndgetMedium(int[] exp, int msn, int remove, int update, bool even)
        {
            exp[remove]--;
            exp[update]++;
            int counts = 0;
            for (int k = 0; k < 201; k++)
            {
                if (counts + exp[k] < msn)
                {
                    counts += exp[k];
                    continue;
                }
                if (!even)
                {
                    return k;
                }
                else
                {
                    if (counts + exp[k] > msn)
                    {
                        return k;
                    }
                    else
                    {
                        int r = 0;
                        for (r = k + 1; r < 201; r++)
                        {
                            if (exp[r] > 0)
                            {
                                break;
                            }
                        }

                        return 0.5 * (k + r);
                    }
                }

            }

            return 0;



        }


        public long largestRectangle(int[] h)
        {
            //This function is used to find the larges of rectangle on a continus bar shape graph
            //the idea is to cut the graph into subregions by the minimum value in their parent region.

            return FindMaxSubRegion(h, 0, h.Length - 1);

        }

        public long FindMaxSubRegion(int[] h, int start, int end)
        {
            if (end == start)
            {
                return h[end];
            }

            if (end - start == 1)
            {
                return h[end] > h[start] ? 2 * h[start] : 2 * h[end];
            }

            long max = 0;
            int min = int.MaxValue;

            List<int> minIndex = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (h[i] < min)
                {
                    min = h[i];
                    minIndex.Clear();
                }
                if (h[i] == min)
                {
                    minIndex.Add(i);
                }
            }

            max = (end - start + 1) * min;

            int s = start;
            int e = end;
            int size = minIndex.Count;
            for (int i = 0; i < size; i++)
            {
                if (size == 1)
                {
                    s = start;
                    e = minIndex[0] - 1;
                    long m = FindMaxSubRegion(h, s, e);
                    max = m > max ? m : max;

                    s = minIndex[0] + 1;
                    e = end;
                    m = FindMaxSubRegion(h, s, e);
                    max = m > max ? m : max;
                    break;
                }

                if (i == 0)
                {
                    s = start;
                    e = minIndex[0] - 1;
                    long m = FindMaxSubRegion(h, s, e);
                    max = m > max ? m : max;
                    continue;
                }

                if (i > 0 && i != size - 1)
                {
                    s = minIndex[i - 1] + 1;
                    e = minIndex[i] - 1;
                    long m = FindMaxSubRegion(h, s, e);
                    max = m > max ? m : max;
                    continue;
                }

                if (i == size - 1)
                {
                    s = minIndex[i - 1] + 1;
                    e = minIndex[i] - 1;
                    long m = FindMaxSubRegion(h, s, e);
                    max = m > max ? m : max;

                    s = minIndex[i] + 1;
                    e = end;
                    m = FindMaxSubRegion(h, s, e);
                    max = m > max ? m : max;
                    break;
                }

            }

            return max;
        }


        public long triplets(int[] a, int[] b, int[] c)
        {
            //This function find the number of unique combinations in three arrays a, b and c such that
            // each combination is : {a[i], b[i], c[i]} where a[i] and c[i] are not greater than b[i].

            HashSet<int> aset = new HashSet<int>(a);
            HashSet<int> bset = new HashSet<int>(b);
            HashSet<int> cset = new HashSet<int>(c);

            a = aset.ToArray();
            b = bset.ToArray();
            c = cset.ToArray();

            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);

            int na = a.Length;
            int nb = b.Length;
            int nc = c.Length;

            long res = 0;
            int[] astartIndex = new int[1] { na - 1 };
            int[] cstartIndex = new int[1] { nc - 1 };

            for (int i = nb - 1; i >= 0; i--)
            {
                long A = findNumbersLessThan(b[i], a, astartIndex);
                long B = findNumbersLessThan(b[i], c, cstartIndex);

                res += A * B;
            }

            return res;

        }

        public int findNumbersLessThan(int n, int[] a, int[] index)
        {
            int sindex = index[0];
            int i = 0;
            for (i = sindex; i >= 0; i--)
            {
                if (a[i] <= n)
                {
                    break;
                }
            }
            index[0] = i;
            return i + 1;
        }

    }
}
