using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    public class MaxHeap
    {
        public int size;
        private int heapSize;
        private int[] arr;
        public MaxHeap(int size)
        {
            this.size = size;
            arr = new int[size]; 
        }

        private void IncreaseSize()
        {
            int s = this.size;
            this.size *= 2;
            int[] narr = new int[this.size];
            for(int i = 0; i < s; i++)
            {
                narr[i] = arr[i];
            }
            arr = narr;
        }

        public void Push(int n)
        {
            if (heapSize+1 > size)
            {
                this.IncreaseSize();
            }
            arr[heapSize] = n;
            int i = heapSize;
            while (i >= 0 && arr[Parent(i)] < arr[i])
            {
                (arr[Parent(i)], arr[i]) = (arr[i], arr[Parent(i)]);
                i = Parent(i);
            }
            heapSize++;
        }

        public int Pop()
        {
            int max = arr[0];
            arr[0] = arr[heapSize - 1];
            heapSize--;
            MaxHeapify(0);
            return max;
        }

        public int Count()
        {
            return this.heapSize;
        }
        private void MaxHeapify(int index)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int maxIndex = (left < heapSize && arr[left] > arr[index]) ? left : index;
            maxIndex = (right < heapSize && arr[right] > arr[maxIndex]) ? right : maxIndex;

            if (maxIndex != index)
            {
                int tmp = arr[index];
                arr[index] = arr[maxIndex];
                arr[maxIndex] = tmp;
                MaxHeapify(maxIndex);
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
