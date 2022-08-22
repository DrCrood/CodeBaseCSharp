using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.DataStructure
{
    public class MinHeap
    {
        public int size;
        private int heapSize;
        private int[] arr;
        public MinHeap(int size)
        {
            this.size = size;
            arr = new int[size];
        }

        private void IncreaseSize()
        {
            int s = size;
            size *= 2;
            int[] narr = new int[size];
            for (int i = 0; i < s; i++)
            {
                narr[i] = arr[i];
            }
            arr = narr;
        }

        public void Push(int n)
        {
            if (heapSize + 1 > size)
            {
                IncreaseSize();
            }
            arr[heapSize] = n;
            int i = heapSize;
            while (i >= 0 && arr[Parent(i)] > arr[i])
            {
                int tmp = arr[i];
                arr[i] = arr[Parent(i)];
                arr[Parent(i)] = tmp;
                i = Parent(i);
            }
            heapSize++;
        }

        public int Pop()
        {
            int min = arr[0];
            arr[0] = arr[heapSize - 1];
            heapSize--;
            MinHeapify(0);
            return min;
        }

        public int Count()
        {
            return heapSize;
        }

        private void MinHeapify(int index)
        {
            //push the bigger node down the chain
            int left = 2 * index;
            int right = 2 * index + 1;
            int minIndex = left < heapSize && arr[left] < arr[index] ? left : index;
            minIndex = right < heapSize && arr[right] < arr[minIndex] ? right : minIndex;

            if (minIndex != index)
            {
                int tmp = arr[index];
                arr[index] = arr[minIndex];
                arr[minIndex] = tmp;
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
