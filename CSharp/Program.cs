using System;

namespace com.dnene.josephus
{
    class Program
    {
        public static void Main(String[] args)
        {
            var sw = new System.Diagnostics.Stopwatch();

            int ITER = 100000;

            sw.Start();
            var start = DateTime.Now;
            for (int i = 0; i < ITER; i++)
            {
                Chain chain = new Chain(40);
                chain.Kill(3);
            }
            //var stop = DateTime.Now;
            //var end = (stop - start).TotalMilliseconds;
            double end = sw.ElapsedMilliseconds;

            Console.WriteLine($"Total time = {end} milliseconds");
            Console.WriteLine($"Time per iteration = {end / ITER}  milliseconds.");
        }
    }
}
