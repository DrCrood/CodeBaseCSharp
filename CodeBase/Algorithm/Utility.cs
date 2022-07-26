using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    public static class Utility
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

        public static double Sqrt(double n)
        {
            double error = 1e-12;
            double root = 0.1 * n;
            double rootSqrt = root * root;
            while (rootSqrt - n > error || rootSqrt - n < -error)
            {
                root = 0.5 * (root + n / root);
                rootSqrt = root * root;
            }

            return root;
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

        public static void QuickSort2D(int[][] points, int innerIndex, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition2D(points, innerIndex, start, end);
                QuickSort2D(points, innerIndex, start, pivot - 1);
                QuickSort2D(points, innerIndex, pivot + 1, end);
            }
        }

        public static int Partition2D(int[][] a, int innerIndex, int start, int end)
        {
            int index = start;
            for (int i = start; i < end; i++)
            {
                if (a[i][innerIndex] <= a[end][innerIndex]) //Sort ascending
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

        public static void MergeSort(int[] a, int s, int e)
        {
            if (s < e)
            {
                int q = (s + e) / 2;
                MergeSort(a, s, q);
                MergeSort(a, q + 1, e);
                Merge(a, s, q, e);
            }
        }

        private static void Merge(int[] a, int s, int m, int e)
        {
            int nleft = m - s + 1;
            int nright = e - m;
            int[] left = new int[nleft + 1];
            int[] right = new int[nright + 1];

            int i = 0;
            int j = 0;
            for (i = 0; i < nleft; i++)
            {
                left[i] = a[s + i];
            }
            for (j = 0; j < nright; j++)
            {
                right[j] = a[m + 1 + j];
            }

            left[nleft] = int.MaxValue;
            right[nright] = int.MaxValue;

            i = 0;
            j = 0;
            for (int n = s; n <= e; n++)
            {
                if (left[i] > right[j])
                {
                    a[n] = right[j];
                    j++;
                }
                else
                {
                    a[n] = left[i];
                    i++;
                }
            }
        }
    }
}
