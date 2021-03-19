using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallelator
{
    class ParallelIntegration
    {
        public double ParTrapezoidalRuleWithCorrection(double a, double b, int n, Func<double, double> f, Func<double, double> fp)
        // a and b are the endpoints
        // n is the number of steps
        // f is f(x) and fp is the derivative of f f'(x)
        {
            double h = (b - a) / (n + 1);
            double sum = 0.5 * (f(a) + f(b));
            double[] innerSum = new double[n + 1];

            Parallel.For(1, n + 1, i =>
            {
                innerSum[i] = f(a + i * h);
            });

            for (int j = 1; j <= n; j++)
                sum += innerSum[j];

            return h * (sum + h * (fp(a) - fp(b)) / 12.0);
        }
    }
}
