using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm.Utility
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

        public static void QuickSortObject(int[][] points, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(points, start, end);
                QuickSortObject(points, start, pivot - 1);
                QuickSortObject(points, pivot + 1, end);
            }
        }

        public static int Partition(int[][] a, int start, int end)
        {
            int index = start;
            for (int i = start; i < end; i++)
            {
                if (a[i][2] <= a[end][2]) //Sort ascending
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
