using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    public class MedianStreamFW
    {
        private readonly int size;
        private int count = 0;
        private int index = 0;
        private double median;
        private readonly MinHeapFW minHeap;
        private readonly MaxHeapFW maxHeap;
        private int[] arr;

        public MedianStreamFW(int size)
        {
            this.size = size;
            arr = new int[size];
            minHeap = new MinHeapFW(size/2 + 1);
            maxHeap = new MaxHeapFW(size/2 + 1);
            for(int i = 0; i < size; i++)
            {
                arr[i] = int.MinValue;
            }
        }

        public void Add(int n)
        {
            if(index < size)
            {
                Remove(index, arr[index]);
            }
            else
            {
                Remove(0, arr[0]);
                index = 0;
            }

            arr[index] = n;
            if(n >= median)
            {
                minHeap.Push(index, n);
            }
            else
            {
                maxHeap.Push(index, n);
                (int i, int num) = maxHeap.Pop();
                minHeap.Push(i, num);
            }

            if(minHeap.Count() > maxHeap.Count())
            {
                (int index, int num) = minHeap.Pop();
                maxHeap.Push(index, num);
            }
           
            if(count < size) { count++; }
            if (count % 2 == 0)
            {
                this.median = (minHeap.Peek() + maxHeap.Peek()) / 2.0;
            }
            else
            {
                this.median = maxHeap.Peek();
            }
            index++;
        }

        private void Remove(int i, int value)
        {
            if(value == Int32.MinValue)
            {
                return;  //nothing to remove from the data stream
            }

            if(minHeap.ContainsIndex(i))
            {
                minHeap.Remove(i);
            }
            else
            {
                maxHeap.Remove(i);
            }

            if (minHeap.Count() > maxHeap.Count())
            {
                (int index, int num) = minHeap.Pop();
                maxHeap.Push(index, num);
            }
            count--;
            if (count % 2 == 0)
            {
                this.median = (minHeap.Peek() + maxHeap.Peek()) / 2.0;
            }
            else
            {
                this.median = maxHeap.Peek();
            }

        }

        public double Get()
        {
            return this.median;
        }

    }
}
