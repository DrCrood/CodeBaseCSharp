using CodeBase.Algorithm;
using System;
using System.Diagnostics;

namespace CodeBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int count = 0;
            for (long i = 146783789682978; i < 146783789682999; i++)
            {
                if(Utility.IsPrime(i))
                {
                    count++;
                    Console.WriteLine(i.ToString());
                }
            }
            watch.Stop();
            Console.WriteLine( count + " primes in " + watch.ElapsedMilliseconds + " ms");
        }
    }
}
