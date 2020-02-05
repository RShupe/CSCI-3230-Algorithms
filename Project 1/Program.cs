using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Program.cs
//	Description:       This is the main file for Project 1. UPS Driver has multiple points,
//                      find the optimal route for the UPS Driver to take.
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University
//	Created:           Monday, Jan 27 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///
namespace Project_1
{
    internal class Program
    {
        /// <summary>
        /// Main - The method that drives the program.
        /// </summary>
        /// <param name="string[] args"></param>
        ///
        public static double shortestDistance = Double.MaxValue;
        private static int[] shortestPerm;

        private static void Main(string[] args)
        {
            List<Point> points = new List<Point>();             //a list containing point objects

            Stopwatch sw = new Stopwatch();                     //creates stopwatch

            for (int i = Convert.ToInt32(Console.ReadLine()); i > 0; i--)
            {
                String instring = Console.ReadLine();           //string that contains what the user typed in

                string[] values = instring.Split(' ');          //array string to split into points format

                Point inPoint = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));  //create a point object that contains the first and second value.

                points.Add(inPoint);
            }

            sw.Start();
            Console.WriteLine(findShortestRoute(points));
            sw.Stop();

            Console.WriteLine("Time used: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
            Console.ReadLine();
        }

        public static String findShortestRoute(List<Point> inPoints)
        {
            int[] permPath = new int[inPoints.Count];
            for (int i = 0; i < permPath.Length; i++)
            {
                permPath[i] = 1 + i;
            }

            String output = "";

            calculatePerm(permPath, inPoints.Count, inPoints);
            output += "0 ";
            for (int i = 0; i < inPoints.Count; i++)
            {
                output += shortestPerm[i] + " ";
            }
            output += "0";

            //shortestDistance = Math.Truncate(shortestDistance * 100) / 100;

            return "The total distance is: " + shortestDistance + "\n The optimal route is: " + output;
        }

        //editmore
        private static void calculatePerm(int[] currentPerm, int permSize, List<Point> inPoints)
        {
            List<Point> zeroPath = new List<Point>();
            Point zero = new Point(0, 0);

            // if size becomes 1 then it creates a path of points corresponding to the permutation calculated
            if (permSize == 1)
            {
                zeroPath.Add(zero);
                for (int i = 0; i < inPoints.Count; i++)
                {
                    zeroPath.Add(inPoints[currentPerm[i] - 1]);
                }
                zeroPath.Add(zero);

                calculateDistance(currentPerm, zeroPath);
            }

            for (int i = 0; i < permSize; i++)
            {
                calculatePerm(currentPerm, permSize - 1, inPoints);

                if (permSize % 2 == 1)
                {
                    int num = currentPerm[0];
                    currentPerm[0] = currentPerm[permSize - 1];
                    currentPerm[permSize - 1] = num;
                }
                else
                {
                    int num = currentPerm[i];
                    currentPerm[i] = currentPerm[permSize - 1];
                    currentPerm[permSize - 1] = num;
                }
            }
        }

        private static void calculateDistance(int[] Permutation, List<Point> inPoints)
        {
            double distanceX;                               //record the current distance between X
            double distanceY;                               //recorod the current distance between Y
            double totalDistance;                           //record the current total distance for comparison
            double overallDistance = 0;
            Point currentPoint;
            Point NxtPoint;

            //calculates the distance between all the points.
            for (int i = 0; i < Permutation.Length + 1; i++)
            {
                currentPoint = inPoints[i];
                NxtPoint = inPoints[i + 1];

                distanceX = (currentPoint.X - NxtPoint.X);
                distanceX *= distanceX;
                distanceY = (currentPoint.Y - NxtPoint.Y);
                distanceY *= distanceY;

                totalDistance = distanceX + distanceY;
                totalDistance = Math.Sqrt(totalDistance);
                overallDistance += totalDistance;
            }

            //save permutation and distance if there is a new one.
            if (overallDistance < shortestDistance)
            {
                shortestDistance = overallDistance;
                shortestPerm = Permutation;
            }
        }
    }
}