using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Numerical_Methods
{
    internal class NewtonMethod
    {
        public static void Method(double epsilon, double x0)
        {
            double x_n;
            double x_n_next = x0;
            double result = 0;
            int iterationCount = 0;
            bool is_result = false;

            Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-20}", "Iteration", "x_n", "|x_n - x_n-1|", "|f(x_n)|");

            for (int i = 1; i <= 20; i++)
            {
                x_n = x_n_next;
                x_n_next = x_n - Func(x_n) / FuncDerivative(x_n);

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
                Console.WriteLine("n(E) = " + N_E(epsilon));
                Console.WriteLine("Result is found during " + iterationCount + " iteration(s)");
                Console.WriteLine("x = " + result + " f(x) = " + Func(result));
            }
            else
            {
                Console.WriteLine("Solution is not found within 20 iterations.");
            }
        }

        public static double Func(double x)
        {
            return 3 * x * x - Math.Pow(Math.Cos(Math.PI*x), 2);
        }

        public static double FuncDerivative(double x)
        {
            return 6 * x + Math.PI * Math.Sin(2*Math.PI*x);
        }

        public static double SecondFuncDeravative(double x)
        {
            return 6 + 2 * Math.PI * Math.PI * Math.Cos(2 * Math.PI * x);
        }

        public static Boolean CheckInitialApproximation(double x)
        {
            return Func(x) * SecondFuncDeravative(x) > 0;
        }

        public static Boolean CheckConvergence()
        {
            double m1 = 4.25;
            double M2 = 9.97;
            double z = 0.1;

            return (M2 * z) / (2 * m1) < 1;
        }

        public static double N_E(double e)
        {
            double m1 = 4.25;
            double M2 = 9.97;
            double z = 0.1;
            double q = (M2 * z) / (2 * m1);

            return Math.Log((Math.Log(z / e) / Math.Log(1 / q)) + 1) / Math.Log(2) + 1;
        }
    }
}
