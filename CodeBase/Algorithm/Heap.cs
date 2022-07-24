using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algoriths
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

        public static void MinHeapInsert(int[] a, int HeapSize, int key)
        {
            a[HeapSize] = Int32.MinValue;
            HeapDecreaseKey(a, HeapSize, key);
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
    }
}
