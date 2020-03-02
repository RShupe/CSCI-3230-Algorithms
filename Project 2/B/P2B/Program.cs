using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace P2B
{
    internal class Program
    {
        /// <summary>
        /// Main - The method that drives the program.
        /// </summary>
        /// <param name="string[] args"></param>
        ///
        public static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());//record the number of test cases
            double[] outArray = new double[testCases];

            for (int i= 0; i < testCases; i++)
            {
                outArray[i] = Cookies();
            }

            for (int i = 0; i < outArray.Length; i++)
            {
                Console.WriteLine(outArray[i]);
            }
            Console.ReadLine();
        }


        public static double Cookies()
        {
            List<Point> points = new List<Point>();             //a list containing point objects
            int num = Convert.ToInt32(Console.ReadLine());      //the number of points to store
            for (int i = num; i > 0; i--)
            {
                String instring = Console.ReadLine();			//create a string to hold the input the user types

                string[] values = instring.Split(' ');			//create a string array and split the input into two seperate numbers

                Point inPoint = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));	//create a point object to store the two numbers.

                points.Add(inPoint);           					//add the point object into the points list.
            }

            return CalculateCookies(points);
        }

        public static double CalculateCookies(List<Point> inPoints)
        {
            inPoints = inPoints.OrderByDescending(p => p.X).ToList();

            double ALine = inPoints[ inPoints.Count() / 2].X;

            double PlusAline = ALine + 0.5;

            double NegAline = ALine - 0.5;

            int APlusCookies = 0;

            int ANegCookies = 0;

            for (int i = 0; i < inPoints.Count -1; i++)

            {
                if (inPoints[i].X > PlusAline)

                {
                    APlusCookies++;
                }

                if (inPoints[i].X > NegAline)

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

            return findBCookies(inPoints, ALine, APlusCookies);

        }

        public static double findBCookies(List<Point> inPoints, double ALine, double APlusCookies)
        {
            double BLine = 0.5;

            double tempBLine = 0;

            int BTempMax = 0;

            int BMax = 0;

            inPoints = inPoints.OrderByDescending(p => p.Y).ToList();

            while (BLine < inPoints[inPoints.Count()-1].Y)

            {
                for (int i = 0; i < inPoints.Count-1; i++)

                {
                    if (inPoints[i].Y < BLine && inPoints[i].X > ALine || inPoints[i].Y > BLine && inPoints[i].X < ALine) //Checking for B's Cookies

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
           

            return APlusCookies;
        }
    }
}