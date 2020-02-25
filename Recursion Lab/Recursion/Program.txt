using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static int steps = 0;
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();                     //creates stopwatch

            sw.Start();
            Console.WriteLine(pow(1, 1000));
            sw.Stop();
            Console.WriteLine("Time used: {0} seconds", sw.Elapsed.TotalMilliseconds / 1000);
            Console.WriteLine(steps);
            Console.ReadLine();     //pause
        }

        public static ulong Fib(ulong n)
        {
            if ((n == 0) || (n == 1))
            {
                return n;
            }
            else
                return Fib(n - 1) + Fib(n - 2);
        }

        public static double pow(double n, int powerRaised)
        {
            steps++;
            if (powerRaised != 0)
            {
                return (n * pow(n, powerRaised - 1));
            }
            else
            {
                return 1;
            }
        }

        public static double powFix(double n, int powerRaised)
        {
            steps++;
            if (powerRaised != 1)
            {
                double temp = powFix(n, powerRaised / 2);
                return (temp * temp);
            }
            else
            {
                return n;
            }
        }

        public static double powFix2(double n, int powerRaised)
        {
            steps++;
           if (powerRaised != 1)
            {
                double temp = powFix2(n, powerRaised / 2);
                if (n % 2 == 0)
                {
                    return temp * temp;
                }
                else
                {
                    return temp * temp * n;
                }
            }
            else
            {
                return n;
            }

            
        }
    }
}
