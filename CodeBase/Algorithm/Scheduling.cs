using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeBase.DataStructure;

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
            Utility.QuickSort2D(meetings,0, 0, n - 1);

            for (int i = 0; i < n; i++)
            {
                Heap.MinHeapInsert(endTimes, i, meetings[i][1]);
            }
            int rooms = 0;
            int maxrooms = 0;
            int hs = n;
            for (int i = 0; i < n;)
            {
                if (meetings[i][0] < Heap.MinHeapCheck(endTimes))
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
                    Heap.MinHeapPop(endTimes, hs--);
                    rooms--;
                }
            }

            return maxrooms;
        }

   
        /// <summary>
        /// Find the finishing order of tasks with pre-task requirement.
        /// Each task will have another task required to complete before it can be done.
        /// Topological sorting algorithm in Graph. 
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public static int[] TaskScheduleWithPreRequirements(int numCourses, int[][] prerequisites)
        {
            Job[] jobs = new Job[numCourses];
            List<int> results = new List<int>();
            for(int i = 0; i < numCourses; i++)
            {
                jobs[i] = new Job()
                {
                    Color = -1,
                    Id = i,
                };
            }

            foreach (int[] req in prerequisites)
            {
                jobs[req[0]].PreRequirements.Add(jobs[req[1]]);
            }

            int order = 0 ;
            foreach(Job job in jobs)
            {
                if(job.Color < 0)
                {
                    if(DFS(jobs, job, ref order, results) < 0)
                    {
                        return Array.Empty<int>();
                    }
                }
            }

            return results.ToArray();
        }

        public static int DFS(Job[] jobs, Job job, ref int order, List<int> result)
        {
            order++;
            job.StartOrder = order;
            job.Color = 0;
            foreach(Job j in job.PreRequirements)
            {
                if(j.Color == 0)
                {
                    return -1;
                }
                if(j.Color < 0)
                {
                   if( DFS(jobs, j, ref order, result) < 0)
                    {
                        return -1;
                    }
                }
            }
            job.Color = 1;
            order++;
            job.EndOrder = order;
            result.Add(job.Id);
            return 0;
        }

    }

    public class Job
    {
        public int Id { get; set; }
        public int StartOrder { get; set; }
        public int EndOrder { get; set; }
        public int Color { get; set; }
        public int Parent { get; set; }
        public List<Job> PreRequirements { get; set; } = new List<Job>();

    }
}
