using System;
using System.Linq;

namespace P2B
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int totalNums = Convert.ToInt32(input);

            int[] x = new int[totalNums];

            int[] y = new int[totalNums];

            for (int i = 0; i < totalNums; i++)     //Get the text file split into the arrays

            {
                input = Console.ReadLine();

                string[] values = input.Split(' ');

                Int32.TryParse(values[0], out x[i]);

                Int32.TryParse(values[1], out y[i]);
            }
            Array.Sort(x, y);

            double ALine = Convert.ToInt64(x[x.Length / 2]);

            double PlusAline = ALine + 0.5;

            double NegAline = ALine - 0.5;

            int APlusCookies = 0;

            int ANegCookies = 0;

            for (int i = 0; i < totalNums; i++)

            {
                if (x[i] > PlusAline)

                {
                    APlusCookies++;
                }

                if (x[i] > NegAline)

                {
                    ANegCookies++;
                }
            }

            if (APlusCookies > ANegCookies)

            {
                ALine = PlusAline;
            }
            else

            {
                ALine = NegAline;
            }

            double BLine = 0.5;

            double tempBLine = 0;

            int BTempMax = 0;

            int BMax = 0;

            while (BLine < y[y.Count() - 1])

            {
                for (int i = 0; i < totalNums; i++)

                {
                    if (y[i] < BLine && x[i] > ALine || y[i] > BLine && x[i] < ALine) //Checking for B's Cookies

                    {
                        BTempMax++;
                    }
                }

                if (BTempMax > BMax)

                {
                    BMax = BTempMax;

                    tempBLine = BLine;
                }

                BLine++;

                BLine++;

                BTempMax = 0;
            }

            APlusCookies = totalNums - BMax;

            Console.WriteLine(APlusCookies.ToString());

            Console.ReadLine();
        }
    }
}