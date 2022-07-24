using CodeBase.Algorithm;
using System;
using System.Diagnostics;

namespace CodeBase
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayOperation arrop = new ArrayOperation();

            int[] array = new int[] {10,20,30,40,50 };

            Stopwatch watch = new Stopwatch();
            watch.Start();
            watch.Stop();

            Sorting.FindDivisions();
        }
    }
}
