﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.DataStructure
{
    public class MedianStream
    {
        private readonly int size;
        private int count = 0;
        private double median;
        private readonly MinHeap minHeap;
        private readonly MaxHeap maxHeap;

        public MedianStream()
        {
            size = 20;
            minHeap = new MinHeap(size / 2);
            maxHeap = new MaxHeap(size / 2);
        }

        public MedianStream(int size)
        {
            this.size = size;
            minHeap = new MinHeap(size / 2);
            maxHeap = new MaxHeap(size / 2);
        }

        public void Add(int n)
        {
            if (n >= median)
            {
                minHeap.Push(n);
            }
            else
            {
                maxHeap.Push(n);
                minHeap.Push(maxHeap.Pop());
            }

            if (minHeap.Count() > maxHeap.Count())
            {
                maxHeap.Push(minHeap.Pop());
            }
            count++;
            if (count % 2 == 0)
            {
                median = (minHeap.Peek() + maxHeap.Peek()) / 2.0;
            }
            else
            {
                median = maxHeap.Peek();
            }
        }

        public double Get()
        {
            return median;
        }

    }
}
