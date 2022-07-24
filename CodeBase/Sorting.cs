using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace CodeBase
{
    public struct Stock
    {
        public int present;
        public int future;
        public int profit;
        public double profitR;
        public Stock(int pre, int fu, int pro)
        {
            this.present = pre;
            this.future = fu;
            this.profit = pro;
            this.profitR = (fu - pre) / (1.0 * pre);
        }
    }

    class Sorting
    {
        public static int[] array = new int[] { 3,6,9,99,6,44,23,1,23,25,36,4,5,88,44,23,45,17,12,4,9,12,23,45,49,7,11,56,77,10,81,64 };
        public static double[] darray = new double[] { 0.3, 0.6, 0.9, 0.99, 0.6, 0.44, 0.23, 0.1, 0.24, 0.25, 0.36, 0.4, 0.5, 0.88, 0.42, 0.23, 0.45, 0.17, 0.72, 0.54, 0.89, 0.12, 0.53, 0.45, 0.49, 0.7, 0.11, 0.06, 0.77, 0.19, 0.81, 0.64 };

        public static void QuickSort(int[] a, int start, int end)
        {
            if(start < end)
            {
                int pivot = Partition(a, start, end);
                QuickSort(a, start, pivot - 1);
                QuickSort(a, pivot + 1, end);
            }
        }

        public static int Partition(int[] a, int start, int end)
        {
            int index = start;

            for(int i=start; i<end; i++)
            {
                if(a[i] <= a[end]) //Sort ascending
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

        public static void MergeSort(int[] a, int s, int e)
        {
            if(s < e)
            {
                int q = (s + e) / 2;
                MergeSort(a, s, q);
                MergeSort(a, q + 1, e);
                Merge(a, s, q, e);
            }
            Console.WriteLine("[{0}]", string.Join(", ", a));
        }

        public static void Merge(int[] a, int s, int m, int e)
        {
            int nleft = m - s + 1;
            int nright = e - m;
            int[] left = new int[nleft + 1];
            int[] right = new int[nright + 1];

            int i = 0;
            int j = 0;
            for (i=0; i<nleft; i++)
            {
                left[i] = a[s + i];
            }
            for(j=0; j<nright; j++)
            {
                right[j] = a[m+1+j];
            }

            left[nleft] = Int32.MaxValue;
            right[nright] = Int32.MaxValue;

            i = 0;
            j = 0;
            for(int n = s; n <=e; n++)
            {
                if(left[i] > right[j])
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

        public static void InsertSort(int[] a)
        {
            int n = a.Length;
            for(int i=1; i<n; i++)
            {
                int temp = a[i];
                int k = i - 1;
                while(temp < a[k] && k >=0)
                {
                    a[k + 1] = a[k];
                    k--;
                }
                a[k+1] = temp;
            }
            Console.WriteLine("[{0}]", string.Join(", ", a));
        }

        public static void HeapSort(int[] a)
        {
            //A binary heap map tructure is like binary tree with each two children are not greater than their parent
            //steps for heap sort: 1, build a heap map from array 2, loop the elements to maintain the order
            int size = a.Length;
            BuildMaxHeap(a, size);
            for(int i = a.Length-1; i>=0; i--)
            {
                //each loop put the largest to the back
                int tmp = a[0];
                a[0] = a[i];
                a[i] = tmp;
                size--;
                MaxHeapify(a, 0, size);
            }
        }

        public static void BuildMaxHeap(int[] a, int size)
        {
           for(int i=size/2 - 1; i>=0; i--)
            {
                MaxHeapify(a, i, size);
            }
        }

        public static void MaxHeapify(int[] array, int index, int size)
        {
            //push the smaller parent down the chain
            int left = 2 * index;
            int right = 2 * index + 1;
            int maxIndex = (left < size && array[left] > array[index]) ? left : index;
            maxIndex = (right < size && array[right] > array[maxIndex]) ? right : maxIndex;

            if(maxIndex != index)
            {
                int tmp = array[index];
                array[index] = array[maxIndex];
                array[maxIndex] = tmp;
                MaxHeapify(array, maxIndex, size);
            }
        }

        public static void CountingSort(int[] a)
        {
            int n = a.Length;
            int[] bu = new int[100];

            foreach(int i in a)
            {
                bu[i]++;
            }

            int index = 0;
            for(int j=0; j<100; j++)
            {
                if(bu[j] > 0)
                {
                    for(int m=0; m < bu[j]; m++)
                    {
                        a[index] = j;
                        index++;
                    }
                }
                
            }
            Console.WriteLine("[{0}]", string.Join(", ", a));
        }

        public static void FindTheBestStockCombination()
        {
            int[] present = new int[35] { 24,34,55,67,123,200,18,25,30,35,40,45,150,188,65,79,42,33,90,129,66,80,96,8,12,5,10,15,20,25,10,20,30,40,50 };
            int[] future = new int[35] { 29,30,50,69,130,202,28,35,38,25,39,59,200,200,68,85,50,30,99,138,70,85,120,28,25,9,14,22,33,44,15,26,37,48,59};

            int budget = 150;
            List<Stock> stocks = new List<Stock>();
            int n = present.Length;
            for(int i=0; i < n; i++)
            {
                if(future[i] - present[i] > 0)
                {
                    stocks.Add(new Stock(present[i], future[i], future[i] - present[i]));
                }                
            }

        }

        public static void FindDivisions()
        {
            int[] a = new int[] { 4, 15};
            a = new int[] { 4, 4, 4, 4 };
            a = new int[] { 2, 2, 3 };
            a = new int[] { 2, 2, 1, 2, 3, 5 };
            a = new int[] { 1, 2, 3, 1, 1, 1 };
            a = new int[] { 4, 17, 18, 3, 2, 10, 9, 5, 5, 5, 1, 5, 10, 1, 10 };
            a = new int[] { 1,1,1,1,1,1,3,3,3,5,5,4,1,6,8,1,1,2,5,4,3,11,1,3,3,8,4,5,6,3,1,4,8,1,2,4,4,3,3,1 };
            int max = -1;
            int min = 1000000;
            foreach(int i in a)
            {
                if(i < min)
                {
                    min = i;
                }
                if(i > max)
                {
                    max = i;
                }
            }

            if(max == min)
            {
                Console.WriteLine("[{0}]", string.Join(", ", a));
                return;
            }

            int groupSize = max;
            int index = 0;
            int ops = 0;    
            int groupSum = 0;
            for(int i = 0; i < a.Length; i++)
            {
                groupSum = 0;
                while(groupSum < groupSize)
                {
                    groupSum += a[i];
                    i++;
                    if (i == a.Length)
                    {
                        break;
                    }
                    ops++;
                }

                if(groupSum == groupSize)
                {
                    if(i == a.Length)
                    {
                        Console.WriteLine(groupSize);
                    }
                    i--;
                    continue;
                }

                if(i==a.Length && groupSum < groupSize)
                {
                    groupSize += groupSum;
                }
                else
                {
                    groupSize = groupSum;
                }
                i = -1;

            }


        }


    }
}
