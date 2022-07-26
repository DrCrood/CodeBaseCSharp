﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CodeBase.DataStructure
{
    public class Alpha
    {
        public Alpha() : this(10)
        {

        }

        public Alpha(int size)
        {

        }

        [Flags]
        public enum direction
        {
            left = 1,
            right = 2,
            up = 4,
            down = 8,
            leftright = left | right,
            updown = up | down,
            all = leftright | updown
        }

        public void testenum()
        {
            direction good = direction.left | direction.up;
            Console.WriteLine(direction.all.ToString());
            Console.WriteLine(good.ToString());

            Func<int, string> testdelegate = (x) => { return x * x + " times"; };

            Console.WriteLine(testdelegate(9));
        }


        public void TestEnumerable()
        {
            List<int> IntList = new List<int>();

            for (int i = 3; i < 9; i++)
            {
                IntList.Add(i * i);
            }

            IEnumerator<int> enu = IntList.GetEnumerator();

            enu.MoveNext();
            Console.WriteLine(enu.Current);
            enu.MoveNext();
            Console.WriteLine(enu.Current);
        }


        public delegate (int, string) GetAgeName(string ssn);
        delegate int GetDouble(int n);


        public (int, string) InfoService(string ssn)
        {
            Console.WriteLine("InfoService!");
            return (20, "Lee");
        }

        public (int, string) InfoService2(string ssn)
        {
            Console.WriteLine("InfoService2!");
            return (30, "Chen");
        }

        public int Double(int n)
        {
            return n + n;
        }

        public void Test()
        {
            GetDouble gd = new GetDouble(Double);
            Console.WriteLine(gd(909));

            TestDelegate(InfoService);
            TestDelegate2(InfoService);
        }

        public void TestDelegate(GetAgeName ag)
        {
            ag += InfoService2;

            (int age, string name) = ag("12345");

        }

        public (int, string) TestDelegate2(Func<string, (int, string)> ag)
        {
            ag += InfoService2;

            (int age, string name) = ag("12345");

            return (age, name);
        }

        public void evenodd()
        {
            int n = 20;
            Random ran = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = ran.Next(1, 100);
            }
            int even = 0;
            int loop = 0;
            int odd = a.Length - 1;
            while (even < odd)
            {
                loop++;
                if (a[even] % 2 == 0)
                {
                    even++;
                }
                else
                {
                    int tmp = a[odd];
                    a[odd] = a[even];
                    a[even] = tmp;
                    odd--;
                }
            }
            Console.WriteLine($"loop times = {loop}");
            Console.WriteLine("[{0}]", string.Join(", ", a));
        }

        public void printSpiral(int n)
        {
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = -1;
                }
            }

            int R = 0;
            int C = 0;
            int index = 1;
            int direction = 1;
            while (index <= n * n)
            {
                if (a[R, C] < 0)
                {
                    a[R, C] = index;
                    index++;
                }

                if (direction == 1)
                {
                    C++;
                    if (C == n || a[R, C] > 0)
                    {
                        C--;
                        R++;
                        direction = 2;
                        continue;
                    }
                    continue;
                }
                if (direction == 2)
                {
                    R++;
                    if (R == n || a[R, C] > 0)
                    {
                        R--;
                        C--;
                        direction = 3;
                        continue;
                    }
                    continue;
                }
                if (direction == 3)
                {
                    C--;
                    if (C == -1 || a[R, C] > 0)
                    {
                        C++;
                        R--;
                        direction = 4;
                        continue;
                    }
                    continue;
                }
                if (direction == 4)
                {
                    R--;
                    if (R == -1 || a[R, C] > 0)
                    {
                        R++;
                        C++;
                        direction = 1;
                        continue;
                    }
                    continue;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void AverageOrder(int n)
        {
            int[] a = new int[n];
            Random ran = new Random();
            int av = 0;
            int i = 0;
            for (i = 0; i < n; i++)
            {
                int v = ran.Next(1, 100);
                a[i] = v;
                av += v;
            }
            av /= n;
            i = 0;
            int k = n - 1;
            while (i < k)
            {
                if (a[i] < av)
                {
                    i++;
                }
                else
                {
                    int tmp = a[i];
                    a[i] = a[k];
                    a[k] = tmp;
                    k--;
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", a));
        }


        public void MaxProfitWithDayRange(int days)
        {
            int[] a = new int[60];
            Random ran = new Random();
            for (int i = 0; i < 60; i++)
            {
                a[i] = ran.Next(100, 200);
                while (i > 0 && Math.Abs(a[i] - a[i - 1]) > 20)
                {
                    a[i] = ran.Next(100, 200);
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", a));
            int curMin = 1000000;
            int curIndex = 0;
            int[] min = new int[60];
            int[] minIndex = new int[60];
            for (int i = 0; i < 60; i++)
            {
                if (i - curIndex > days)
                {
                    curMin = 100000;
                    for (int d = 0; d < days; d++)
                    {
                        if (a[i - d] < curMin)
                        {
                            min[i] = a[i - d];
                            minIndex[i] = i - d;
                            curMin = a[i - d];
                            curIndex = i - d;
                        }
                    }
                    continue;
                }

                if (a[i] < curMin)
                {
                    min[i] = a[i];
                    minIndex[i] = i;
                    curMin = a[i];
                    curIndex = i;
                }
                else
                {
                    min[i] = curMin;
                    minIndex[i] = curIndex;
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", min));
            Console.WriteLine("[{0}]", string.Join(", ", minIndex));
            int sell = 0;
            int buy = 0;
            int[] pro = new int[60];
            int profit = 0;
            for (int j = 0; j < 60; j++)
            {
                pro[j] = a[j] - min[j] > 0 ? a[j] - min[j] : 0;
                if (a[j] - min[j] > profit)
                {
                    profit = a[j] - min[j];
                    sell = j;
                    buy = minIndex[j];
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", pro));
            Console.WriteLine("buy = " + buy + " sell = " + sell + "  Profit = " + profit);
        }

        public void randomSample(int n)
        {
            //get random n samples from a pool
            int[] a = new int[50];
            Random ran = new Random();
            for (int i = 0; i < 50; i++)
            {
                a[i] = i;
            }

            for (int j = 0; j < n; j++)
            {
                int r = ran.Next(j, 50);
                int tmp = a[r];
                a[r] = a[j];
                a[j] = tmp;
            }
            int[] sample = new int[n];
            for (int k = 0; k < n; k++)
            {
                sample[k] = a[k];
            }
            Console.WriteLine("[{0}]", string.Join(", ", a));
            Console.WriteLine("[{0}]", string.Join(", ", sample));
        }

        public void converter(string sinput = "", int iinput = 0)
        {
            if (sinput.Length < 1)
            {
                if (iinput == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    bool neg = iinput < 0;
                    if (neg) iinput *= -1;
                    StringBuilder builder = new StringBuilder();
                    while (iinput != 0)
                    {
                        builder.Append((char)('0' + iinput % 10));
                        iinput /= 10;
                    }
                    if (neg) builder.Append('-');
                    char[] c = builder.ToString().ToCharArray();
                    Array.Reverse(c);
                    Console.WriteLine("String = " + new string(c));

                }
            }
            else
            {
                bool neg = sinput[0] == '-';
                int result = 0;
                for (int k = neg ? 1 : 0; k < sinput.Length; k++)
                {
                    int d = sinput[k] - '0';
                    result = result * 10 + d;
                }
                if (neg) result *= -1;
                Console.WriteLine("Integer = " + result);
            }

        }

        public double WinningProbability(int previousWon, int previousLoss, int gameLeft, int MustWin)
        {
            double p;
            double sumpro = 0.0;
            double weight = 0.0;
            for (int i = 0; i <= 100000; i++)
            {
                //find the most probable winning chance of single game
                p = i * 0.00001;
                sumpro += p * Math.Pow(p, previousWon) * Math.Pow(1 - p, previousLoss);
                weight += Math.Pow(p, previousWon) * Math.Pow(1 - p, previousLoss);
            }
            p = sumpro / weight;
            double wp = 0.0;
            sumpro = 0.0;
            for (int w = MustWin; w <= gameLeft; w++)
            {
                //sum of probabilitied that winning w games or more
                sumpro += Math.Pow(p, w) * Math.Pow(1 - p, gameLeft - w) * permu(gameLeft, w);
            }

            return sumpro;
        }

        public int permu(int t, int p)
        {
            int q = t - p;
            long pt = 1;
            long pq = 1;
            long pp = 1;
            for (int i = 1; i <= t; i++)
            {
                pt = pt * i;
            }
            for (int j = 1; j <= p; j++)
            {
                pp = pp * j;
            }
            for (int k = 1; k <= q; k++)
            {
                pq = pq * k;
            }
            return (int)(pt / (pp * pq));
        }


        public void lookandsay(string input, int num)
        {
            StringBuilder builer = new StringBuilder();
            Console.WriteLine(input);
            while (num > 0)
            {
                char s = input[0];
                int N = 1;
                for (int i = 1; i <= input.Length; i++)
                {
                    if (i == input.Length)
                    {
                        builer.Append(N);
                        builer.Append(input[i - 1]);
                        break;
                    }
                    if (input[i] != s)
                    {
                        builer.Append(N);
                        builer.Append(input[i - 1]);
                        s = input[i];
                        N = 1;
                    }
                    else
                    {
                        N++;
                    }

                }
                Console.WriteLine(builer.ToString());
                input = builer.ToString();
                builer.Clear();
                num--;
            }
        }

        public void substringSearch(string sstring, string sub)
        {
            int value = 0;
            int len = sub.Length;

            for (int i = 0; i < len; i++)
            {
                value += sub[i];
                //value += (i+1) * sub[i]; //this requires the recalculation of whole substring tvalue in string for loop but reduce false match like 'ABC' and 'ACB'.
            }

            int tvalue = 0;
            for (int k = 0; k < len - 1; k++)
            {
                tvalue += sstring[k];
            }
            int last = 0;

            for (int j = 0; j <= sstring.Length - len; j++)
            {
                tvalue += sstring[j + len - 1] - last;
                last = sstring[j];
                if (tvalue == value)
                {
                    bool match = true;
                    for (int m = 0; m < len; m++)
                    {
                        if (sub[m] != sstring[j + m])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match)
                        Console.WriteLine(j + " : " + sstring.Substring(j, len));
                }
            }
        }

    }
}
