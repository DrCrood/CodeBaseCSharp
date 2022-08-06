using System;
using System.Collections.Generic;

namespace CodeBase.Algorithm
{
    /// <summary>
    /// Min heap with extra track of the data index so it can be removed from heap later on.
    /// </summary>
    public class MinHeapFW
    {
        private readonly int size;
        private int heapSize;
        private int[] arr;
        private Dictionary<int, int> array2HeapMap;
        private Dictionary<int,int> heap2ArrayMap;
        public MinHeapFW(int size)
        {
            this.size = size;
            arr = new int[size];
            array2HeapMap = new Dictionary<int,int>();
            heap2ArrayMap = new Dictionary<int,int>();
        }

        /// <summary>
        /// Push a number and its index to the Heap. The index is used for remove the num from the Heap.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="index"></param>
        public void Push(int index, int num)
        {
            arr[heapSize] = num;
            array2HeapMap[index] = heapSize;
            heap2ArrayMap[heapSize] = index;
            int i = heapSize;
            while (i >= 0 && arr[Parent(i)] > arr[i])
            {
                int j = Parent(i);
                (arr[j], arr[i]) = (arr[i], arr[j]);
                UpdateIndexMap(i ,j);
                i = j;
            }
            heapSize++;
        }

        public (int, int) Pop()
        {
            int min = arr[0];
            int index = heap2ArrayMap[0];
            arr[0] = arr[heapSize - 1];
            array2HeapMap.Remove(index);
            heap2ArrayMap.Remove(0);

            if(heapSize == 1)
            {
                heapSize--;
                return (index, min);
            }

            int k = heap2ArrayMap[heapSize - 1];
            array2HeapMap[k] = 0;
            heap2ArrayMap[0] = k;
            heap2ArrayMap.Remove(heapSize - 1);
            heapSize--;
            MinHeapify(0);
            return (index, min);
        }

        private void UpdateIndexMap(int i, int j)
        {
            int indexi = heap2ArrayMap[i];
            int indexj = heap2ArrayMap[j];
            (heap2ArrayMap[j], heap2ArrayMap[i]) = (heap2ArrayMap[i], heap2ArrayMap[j]);
            (array2HeapMap[indexi], array2HeapMap[indexj]) = (array2HeapMap[indexj], array2HeapMap[indexi]);
        }

        public void Remove(int index)
        {
            int i = array2HeapMap[index];
            array2HeapMap.Remove(index);

            arr[i] = arr[heapSize - 1];
            int j = heap2ArrayMap[heapSize - 1];
            heap2ArrayMap[i] = j;
            array2HeapMap[j] = i;
            heap2ArrayMap.Remove(heapSize - 1);

            heapSize--;
            MinHeapify(i);
        }

        public int Count()
        {
            return this.heapSize;
        }

        public bool ContainsIndex(int i)
        {
            return array2HeapMap.ContainsKey(i);
        }

        private void MinHeapify(int index)
        {
            //push the bigger node down the chain
            int left = 2 * index;
            int right = 2 * index + 1;
            int minIndex = (left < heapSize && arr[left] < arr[index]) ? left : index;
            minIndex = (right < heapSize && arr[right] < arr[minIndex]) ? right : minIndex;

            if (minIndex != index)
            {
                (arr[minIndex], arr[index]) = (arr[index], arr[minIndex]);
                UpdateIndexMap(minIndex, index);
                MinHeapify(minIndex);
            }
        }

        private int Parent(int i)
        {
            double k = i / 2;
            return (int)Math.Floor(k);
        }

        public int Peek()
        {
            return arr[0];
        }

    }
}
