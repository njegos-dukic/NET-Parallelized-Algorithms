using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parallelator
{
    public class ParallelPIAproximation
    {
        static int numberOfCores = Environment.ProcessorCount;
        static int iterations = 1_000_000_000 * numberOfCores;

        public static void MonteCarloPiApproximationParallellForSimulation(ref double aprox)
        {
            double piApproximation = 0;
            int inCircle = 0;
            double x, y = 0;

            Parallel.For(0, numberOfCores, new ParallelOptions { MaxDegreeOfParallelism = numberOfCores }, i =>
            {

                int localCounterInside = 0;

                Random rnd = new Random();

                for (int j = 0; j < iterations / numberOfCores; j++)
                {
                    x = rnd.NextDouble();
                    y = rnd.NextDouble();
                    if (Math.Sqrt(x * x + y * y) <= 1.0)
                        localCounterInside++;
                }

                Interlocked.Add(ref inCircle, localCounterInside);

            });

            piApproximation = 4 * ((double)inCircle / (double)iterations);

            aprox = piApproximation;
        }

        private static void MonteCarloPiApproximationSerialSimulation()
        {
            double piApproximation = 0;
            int total = 0;
            int inCircle = 0;
            double x, y = 0;
            Random rnd = new Random();

            while (total < iterations)
            {
                x = rnd.NextDouble();
                y = rnd.NextDouble();

                if ((Math.Sqrt(x * x + y * y) <= 1.0))
                    inCircle++;

                total++;
                piApproximation = 4 * ((double)inCircle / (double)total);
            } 


            Console.WriteLine();
            Console.WriteLine("Approximated Pi = {0}", piApproximation.ToString("F8"));

        }
    }
}
