using System;
using System.Diagnostics;

namespace com.dnene.josephus
{
    class Program
    {
        private static readonly decimal ITER = 10000m;
        private static Chain[] chains = new Chain[(int)ITER];
        private static Chain[] target = new Chain[(int)ITER];

        public static void Main(String[] args)
        {
            var sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < ITER; i++)
            {
                Chain chain = new Chain(40);
                chain.Kill(3);
                chains[i] = chain;
            }

            // Ensure JIT doesn't optimize out the first loop
            for (int i = 0; i < ITER; ++i)
            {
                target[i] = chains[i];
            }

            sw.Stop();
            //double end = sw.ElapsedMilliseconds;

            Console.WriteLine($" Last Chain {GetLastChain()}");
            decimal frequency = Convert.ToDecimal(Stopwatch.Frequency);
            Console.WriteLine($"  Timer frequency in ticks per second = {frequency}");
            Console.WriteLine($"  Total Elapsed Ticks = {sw.ElapsedTicks}");
            decimal ticksPerIteration = sw.ElapsedTicks / ITER;
            Console.WriteLine($"  Total Elapsed Ticks Per Second Per Iteration = {ticksPerIteration}");
            decimal secondsPerIteration = ticksPerIteration / frequency;
            Console.WriteLine($"Total Seconds per Iteration = {secondsPerIteration}");
        }

        private static Chain GetLastChain()
        {
            return target[(int)ITER - 1];
        }
    }
}
