using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    public class Scheduling
    {
        /// <summary>
        /// Find the required rooms for all meetings. Meetings are listed with start_time and end_time.
        /// </summary>
        /// <param name="meetings"></param>
        /// <returns>Minimum number of rooms required.</returns>
        public static int MiniMumMeetingRooms_Simple(int[][] meetings)
        {
            int MAX_timespan = 1000;
            int[] time = new int[MAX_timespan+1];

            foreach (int[] m in meetings)
            {
                for (int i = m[0]; i <= m[1]; i++)
                {
                    time[i]++;
                }
            }

            int max = 0;
            foreach (int x in time)
            {
                if (x > max)
                    max = x;
            }
            return max;
        }

        /// <summary>
        /// General solution for finding required rooms for list of meetings.
        /// </summary>
        /// <param name="meetings"></param>
        /// <returns>The minimum number of required meeting rooms</returns>
        public int MinMeetingRooms(int[][] meetings)
        {
            int n = meetings.Length;
            int[] endTimes = new int[n];
            QuickSortObject(meetings, 0, n - 1);

            for (int i = 0; i < n; i++)
            {
                MinHeapInsert(endTimes, i, meetings[i][1]);
            }
            int rooms = 0;
            int maxrooms = 0;
            int hs = n;
            for (int i = 0; i < n;)
            {
                if (meetings[i][0] < MinHeapCheck(endTimes))
                {
                    rooms++;
                    i++;
                    if (rooms > maxrooms)
                    {
                        maxrooms = rooms;
                    }
                }
                else
                {
                    MinHeapPop(endTimes, hs--);
                    rooms--;
                }
            }

            return maxrooms;
        }

        private static int Parent(int i)
        {
            double k = i / 2;
            return (int)Math.Floor(k);
        }

        private static int MinHeapPop(int[] a, int heapSize)
        {
            int min = a[0];
            a[0] = a[heapSize - 1];
            heapSize--;
            MinHeapify(a, 0, heapSize);
            return min;
        }

        private static void MinHeapInsert(int[] a, int HeapSize, int key)
        {
            a[HeapSize] = Int32.MinValue;
            HeapDecreaseKey(a, HeapSize, key);
        }

        private static void HeapDecreaseKey(int[] a, int i, int key)
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
        private static void MinHeapify(int[] array, int index, int heapSize)
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

        public static int MinHeapCheck(int[] a)
        {
            return a[0];
        }

        private static void QuickSortObject(int[][] points, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(points, start, end);
                QuickSortObject(points, start, pivot - 1);
                QuickSortObject(points, pivot + 1, end);
            }
        }

        private static int Partition(int[][] a, int start, int end)
        {
            int index = start;

            for (int i = start; i < end; i++)
            {
                if (a[i][0] <= a[end][0]) //Sort ascending
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
