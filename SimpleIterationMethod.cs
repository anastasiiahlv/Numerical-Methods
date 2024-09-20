using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_Methods
{
    internal class SimpleIterationMethod
    {
        public static void Method(double epsilon, double x0)
        {
            double x_n;
            double x_n_next = x0;
            double result = 0;
            int iterationCount = 0;
            bool is_result = false;

            Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-20}", "Iteration", "x_n", "|x_n - x_n-1|", "f(x_n)");

            for (int i = 1; i <= 200; i++)
            {
                x_n = x_n_next;
                x_n_next = FuncIter(x_n);

                Console.WriteLine("{0,-15} {1,-20:F15} {2,-20:F15} {3,-20:E15}",
                    i,
                    x_n_next,
                    Math.Abs(x_n_next - x_n),
                    Func(x_n_next));

                if (Math.Abs(x_n_next - x_n) <= epsilon && !is_result)
                {
                    iterationCount = i;
                    is_result = true;
                    result = x_n_next;
                    break;
                }
            }

            if (is_result)
            {
                Console.WriteLine("n(E) = " + N_E(x0, epsilon));
                Console.WriteLine("Result is found during " + iterationCount + " iteration(s)");
                Console.WriteLine("x = " + result + " f(x) = " + Func(result));
            }
            else
            {
                Console.WriteLine("Solution is not found within 100 iterations.");
                Console.WriteLine("n(E) = " + N_E(x0, epsilon));
            }
        }

        public static double Func(double x)
        {
            return 3 * x * x - Math.Pow(Math.Cos(Math.PI * x), 2);
        }

        public static double FuncIter(double x)
        {
            return x - 0.05*x*(3*x*x - Math.Pow(Math.Cos(Math.PI * x), 2));
        }

        public static Boolean Check(double x)
        {
            double q = 0.93;
            double z = 0.1;
            return Math.Abs(FuncIter(x) - x) <= (1 - q) * z;
        }
        public static double N_E(double x, double e)
        {
            double q = 0.93;
            double z = Math.Abs(FuncIter(x) - x); // |φ(x0) - x0|

            return (Math.Log(z / ((1 - q) * e)) / Math.Log(1 / q)) + 1;
        }
    }
}
