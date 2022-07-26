using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    public class ArrayList
    {
        /// <summary>
        /// Merge input list of intervals if there are any overlaps.
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns>Merged interval list</returns>
        public static int[][] MergeOverlapIntervals(int[][] intervals)
        {
            List<int[]> mergedList = new List<int[]>();
            int size = intervals.Length;
            Utility.QuickSort2D(intervals, 0, 0, size-1);

            for(int i = 0; i < size; i++)
            {
                int k = 1;
                int end = intervals[i][1];
                while(i+k< size && end >= intervals[i+k][0])
                {
                    end = end > intervals[i + k][1] ? end : intervals[i + k][1];
                    k++;
                }

                mergedList.Add(new int[] { intervals[i][0], end });

                i += k-1;

            }

            int fsize = mergedList.Count;

            int[][] result = new int[fsize][];
            for(int i= 0; i<fsize; i++)
            {
                result[i] = new int[] { mergedList[i][0], mergedList[i][1] };
            }

            return result;

        }

        /// <summary>
        /// Calculate the sum of all subarrays strength.
        /// The array strenght = [array sum]*[smallest item in the array]
        /// </summary>
        /// <param name="strength"></param>
        /// <returns></returns>
        public int SumOfAllSubArrayStrength(int[] strength)
        {

            return 0;
        }

    }
}
