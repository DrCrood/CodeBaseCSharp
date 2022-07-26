﻿using System;
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
    }
}
