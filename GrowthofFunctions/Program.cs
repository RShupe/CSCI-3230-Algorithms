using System;
using System.Diagnostics;
using System.Numerics;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {


            while (1 == 1)
            {
                Stopwatch sw = new Stopwatch();
                Console.WriteLine("Enter a number: ");
                ulong input = Convert.ToUInt64(Console.ReadLine());


                sw.Start();
                nFactorial(input);
                sw.Stop();

                Console.WriteLine("n = " + input);
                Console.WriteLine("Time used: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
            }
        }

        private static void nsquaredgrowth(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum = sum + 1;
                }
            }
        }

        private static void ncubedgrowth(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        sum = sum + 1;
                    }
                }
            }
        }

        private static void nquadgrowth(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        for (int l = 0; l < n; l++)
                        {
                            sum = sum + 1;
                        }
                    }
                }
            }
        }

        private static void lgngrowth(BigInteger n)
        {
            while (n != 1)
            {
                n = n / 2;
            }
        }

        private static void nFactorial(ulong n)
        {
            ulong output = n;
            for(ulong i = n - 1; i >= 1; i--)
            {
                output *= i;
            }
            Console.WriteLine(output);
        }
    }
}
