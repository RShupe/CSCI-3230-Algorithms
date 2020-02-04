using System;
using System.Diagnostics;
using System.Globalization;
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
                //ulong input = Convert.ToUInt64(Console.ReadLine());
                //String input = Console.ReadLine();
                //BigInteger nice = BigInteger.Parse(input);          
                // int input = Convert.ToInt32(Console.ReadLine());


                int input = Convert.ToInt32(Console.ReadLine());

                sw.Start();
                twoPow(input);
                sw.Stop();

                Console.WriteLine("n = " + input);
                Console.WriteLine("Time used: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
            }
        }

        public static double twoPow(int n)
        {
            if (n == 0)
            {
                return 1.0;
            }
            else
            {
                return 2.0 * twoPow(n - 1);
            }
                
        }

        private static void ngrowth(ulong n)
        {
            ulong sum = 0;
            for (ulong i = 0; i < n; i++)
            {
                sum++;
            }
            Console.WriteLine(sum);
        }

        private static void nsquaredgrowth(BigInteger n)
        {
            BigInteger sum = 0;
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
            BigInteger x = n;
            while (x != 1)
            {
                x /= 2;
            }
        }

        private static void nFactorial(uint n)
        {
            BigInteger output = n;

            for (uint i = 1; i < n; i++)
            {
                output *= i;
            }

            // Console.WriteLine(output);
        }
    }
}
