using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    public static class Heap
    {
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
                MaxHeapify(a, 0, size);
            }
        }

        public static void BuildMaxHeap(int[] a, int size)
        {
            for (int i = size / 2 - 1; i >= 0; i--)
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

            if (maxIndex != index)
            {
                int tmp = array[index];
                array[index] = array[maxIndex];
                array[maxIndex] = tmp;
                MaxHeapify(array, maxIndex, size);
            }
        }
        public static void MinHeapify(int[] array, int index, int heapSize)
        {
            //push the bigger node down the chain
            int left = 2 * index;
            int right = 2 * index + 1;
            int minIndex = (left < heapSize && array[left] < array[index]) ? left : index;
            minIndex = (right < heapSize && array[right] < array[minIndex]) ? right : minIndex;

            if (minIndex != index)
            {
                int tmp = array[index];
                array[index] = array[minIndex];
                array[minIndex] = tmp;
                MinHeapify(array, minIndex, heapSize);
            }
        }

        public static void MinHeapify_Object(ListNode[] array, int index, int heapSize)
        {
            //push the bigger node down the chain
            int left = 2 * index;
            int right = 2 * index + 1;
            int minIndex = (left < heapSize && array[left].val < array[index].val) ? left : index;
            minIndex = (right < heapSize && array[right].val < array[minIndex].val) ? right : minIndex;

            if (minIndex != index)
            {
                ListNode tmp = array[index];
                array[index] = array[minIndex];
                array[minIndex] = tmp;
                MinHeapify_Object(array, minIndex, heapSize);
            }
        }

        public static void MinHeapInsert(int[] a, int HeapSize, int key)
        {
            a[HeapSize] = Int32.MinValue;
            HeapDecreaseKey(a, HeapSize, key);
        }

        public static void MinHeapInsert_Object(ListNode[] a, int HeapSize, ListNode node)
        {
            int n = HeapSize;
            a[HeapSize] = node;
            while ( n >= 0 && a[Parent(n)].val > a[n].val)
            {
                ListNode tmp = a[n];
                a[n] = a[Parent(n)];
                a[Parent(n)] = tmp;
                n = Parent(n);
            }
        }

        /// <summary>
        /// When heap item order is changed, use index array to keep track of the original item
        /// </summary>
        /// <param name="a"></param>
        /// <param name="HeapSize"></param>
        /// <param name="node"></param>
        /// <param name="index"></param>
        public static void MinHeapInsert_ObjectIndex(ListNode[] a, int HeapSize, ListNode node, int[] index)
        {
            int n = HeapSize;
            a[HeapSize] = node;
            while (n >= 0 && a[Parent(n)].val > a[n].val)
            {
                (a[Parent(n)], a[n]) = (a[n], a[Parent(n)]);

                (index[Parent(n)], index[n]) = (index[n], index[Parent(n)]);

                n = Parent(n);
            }
        }

        public static void HeapDecreaseKey(int[] a, int i, int key)
        {
            a[i] = key;
            while (i >= 0 && a[Parent(i)] > a[i])
            {
                int tmp = a[i];
                a[i] = a[Parent(i)];
                a[Parent(i)] = tmp;
                i = Parent(i);
            }
        }

        public static int Parent(int i)
        {
            double k = i / 2;
            return (int)Math.Floor(k);
        }

        public static int MinHeapPop(int[] a, int heapSize)
        {
            int min = a[0];
            a[0] = a[heapSize - 1];
            heapSize--;
            MinHeapify(a, 0, heapSize);
            return min;
        }

        /// <summary>
        /// Mini heap pop for working on objects
        /// </summary>
        /// <param name="a"></param>
        /// <param name="heapSize"></param>
        /// <returns></returns>
        public static ListNode MinHeapPop_Object(ListNode[] a, int heapSize)
        {
            ListNode node = a[0];
            a[0] = a[heapSize - 1];
            heapSize--;
            MinHeapify_Object(a, 0, heapSize);
            return node;
        }

        /// <summary>
        /// Mini heap pop for working with object and tracking of original index
        /// </summary>
        /// <param name="a"></param>
        /// <param name="heapSize"></param>
        /// <returns></returns>
        public static ListNode MinHeapPop_ObjectIndex(ListNode[] a, int heapSize, int[] index)
        {
            ListNode node = a[0];
            a[0] = a[heapSize - 1];
            index[0] = index[heapSize - 1];
            index[heapSize - 1] = -1;
            heapSize--;
            MinHeapify_ObjectIndex(a, 0, heapSize, index);
            return node;
        }

        public static void MinHeapify_ObjectIndex(ListNode[] array, int i, int heapSize, int[] index)
        {
            //push the bigger node down the chain
            int left = 2 * i;
            int right = 2 * i + 1;
            int minIndex = (left < heapSize && array[left].val < array[i].val) ? left : i;
            minIndex = (right < heapSize && array[right].val < array[minIndex].val) ? right : minIndex;

            if (minIndex != i)
            {
                ListNode tmp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = tmp;

                (index[i], index[minIndex]) = (index[minIndex], index[i]);
                MinHeapify_ObjectIndex(array, minIndex, heapSize, index);
            }
        }

        public static int MinHeapCheck(int[] a)
        {
            return a[0];
        }
    }
}
