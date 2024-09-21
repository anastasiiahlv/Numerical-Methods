using System;
using Numerical_Methods;
using static System.Math;
using static Numerical_Methods.NewtonMethod;

public class Program
{
    public static void Main(string[] args)
    {
        int n = -1;

        while (n != 0)
        {
            Console.Write("Enter the precision (e.g., 10e-4): ");
            string? input = Console.ReadLine();
            double epsilon = 0;

            // перевірку на коректність введеної точності 
            if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^[0-9]+(\.[0-9]+)?[eE][+-]?[0-9]+$"))
            {
                epsilon = double.Parse(input);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.WriteLine();
                continue;
            }

            Console.Write("Enter x0, where x0 є [-0,4; -0,3]U[0,3; 0,4]: ");
            input = Console.ReadLine();
            double x0 = 0;

            // перевірка на коректність введення початкового наближення
            if (!double.TryParse(input, out x0) || !(x0 >= -0.4 && x0 <= -0.3 || x0 >= 0.3 && x0 <= 0.4))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();

            Console.WriteLine("Choose the method. Enter 1 or 2.");
            Console.WriteLine("1 - Simple Iteration Method");
            Console.WriteLine("2 - Newton Method");
            Console.Write("Enter: ");

            if (int.TryParse(Console.ReadLine(), out int selectedMethod))
            {
                switch (selectedMethod)
                {
                    case 1:
                        Console.WriteLine(" ------------------------------------ ");
                        // перевірка для початкового наближення
                        if (!SimpleIterationMethod.Check(x0))
                        {
                            Console.WriteLine("|ф(x0) - x0| > (1-q)*z - x0 does not meet the condition.");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine("|ф(x0) - x0| <= (1-q)*z");
                        Console.WriteLine("q < 1 - for x0, Simple Iteration method converges.");
                        SimpleIterationMethod.Method(epsilon, x0);
                        Console.WriteLine(" ------------------------------------ ");
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine(" ------------------------------------ ");
                        // перевірка для початкового наближення
                        if (!NewtonMethod.CheckInitialApproximation(x0))
                        {
                            Console.WriteLine("f(x0)*f''(x0) < 0 - x0 does not meet the condition.");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine("f(x0)*f''(x0) > 0");
                        Console.WriteLine("q < 1 - for x0, Newton's method converges.");
                        NewtonMethod.Method(epsilon, x0);
                        Console.WriteLine(" ------------------------------------ ");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        continue;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number 1 or 2.");
                Console.WriteLine();
                continue;
            }

            Console.Write("Enter 1 to continue, 0 to exit: ");
            if (int.TryParse(Console.ReadLine(), out n))
            {
                continue;
            }
            else
            {
                Console.WriteLine("Invalid input. Exiting.");
                break;
            }
        }
    }
}