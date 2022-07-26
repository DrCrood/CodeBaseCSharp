using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace CodeBase.Algorithm
{
    class Sorting
    {
        public static int[] array = new int[] { 3, 6, 9, 99, 6, 44, 23, 1, 23, 25, 36, 4, 5, 88, 44, 23, 45, 17, 12, 4, 9, 12, 23, 45, 49, 7, 11, 56, 77, 10, 81, 64 };
        public static double[] darray = new double[] { 0.3, 0.6, 0.9, 0.99, 0.6, 0.44, 0.23, 0.1, 0.24, 0.25, 0.36, 0.4, 0.5, 0.88, 0.42, 0.23, 0.45, 0.17, 0.72, 0.54, 0.89, 0.12, 0.53, 0.45, 0.49, 0.7, 0.11, 0.06, 0.77, 0.19, 0.81, 0.64 };

        public static void InsertSort(int[] a)
        {
            int n = a.Length;
            for (int i = 1; i < n; i++)
            {
                int temp = a[i];
                int k = i - 1;
                while (temp < a[k] && k >= 0)
                {
                    a[k + 1] = a[k];
                    k--;
                }
                a[k + 1] = temp;
            }
            Console.WriteLine("[{0}]", string.Join(", ", a));
        }

        public static void HeapSort(int[] a)
        {
            //A binary heap map tructure is like binary tree with each two children are not greater than their parent
            //steps for heap sort: 1, build a heap map from array 2, loop the elements to maintain the order
            int size = a.Length;
            BuildMaxHeap(a, size);
            for (int i = a.Length - 1; i >= 0; i--)
            {
                //each loop put the largest to the back
                int tmp = a[0];
                a[0] = a[i];
                a[i] = tmp;
                size--;
                Heap.MaxHeapify(a, 0, size);
            }
        }

        public static void BuildMaxHeap(int[] a, int size)
        {
            for (int i = size / 2 - 1; i >= 0; i--)
            {
                Heap.MaxHeapify(a, i, size);
            }
        }

        public static void CountingSort(int[] a)
        {
            int n = a.Length;
            int[] bu = new int[100];

            foreach (int i in a)
            {
                bu[i]++;
            }

            int index = 0;
            for (int j = 0; j < 100; j++)
            {
                if (bu[j] > 0)
                {
                    for (int m = 0; m < bu[j]; m++)
                    {
                        a[index] = j;
                        index++;
                    }
                }

            }
            Console.WriteLine("[{0}]", string.Join(", ", a));
        }

    }
}
