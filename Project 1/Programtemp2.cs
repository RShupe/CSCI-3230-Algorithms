/*using System;
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
        static double[,] distanceTable;
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
            distanceTable = fillDistanceTable(points.Count, points);
            Console.WriteLine(findShortestRoute(points));
            sw.Stop();

            Console.WriteLine("Time used: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
        }

        /// fillDistanceTable - This method takes in number of points and points and generates distances between the points
        /// </summary>
        /// <returns name="distanceTable"></returns>
        ///
        private static double[,] fillDistanceTable(int NumPoints, List<Point> inPoints)
        {
            double[,] distanceTable = new double[NumPoints, NumPoints];    //distance table to create and fill
            double distanceX;                               //record the current distance between X
            double distanceY;                               //record the current distance between Y
            double totalDistance;                           //record distance between the points

            for (int i = 0; i < NumPoints; i++)
            {
                for (int j = i; j < NumPoints; j++)							// make sure you use 'j = i' to save calc time (below)
                {
                    distanceX = inPoints[j].X - inPoints[i].X;
                    distanceX *= distanceX;
                    distanceY = inPoints[j].Y - inPoints[i].Y;
                    distanceY *= distanceY;

                    totalDistance = distanceX + distanceY;
                    totalDistance = Math.Sqrt(totalDistance);
                    distanceTable[i, j] = totalDistance;
                    if (i != j)
                    {
                        // saves time from recalc distance between same 2 points
                        distanceTable[j, i] = totalDistance;
                    }
                }
            }

            return distanceTable;
        }

        /// <summary>
        /// getDistance - returns the distance between the current point and pointB by looking at the distance table.
        /// </summary>
        /// <param name="double[,] intable"></param>
        /// <param name="pointToFind"></param>
        /// <returns name="distance"></returns>
        ///
        private static double getDistance(double[,] inTable, Point pointToFind)
        {
            double distance = inTable[pointToFind.X, pointToFind.Y];    //a double to store the value at [x,y]
            return distance;
        }

        /// <summary>
        /// finds the shortest route and returns a string containing the distance and the optimal route
        /// </summary>
        /// <param name="List<Point> inPoints"></param>
        /// <returns name="outputString"></returns>
        ///
        private static String findShortestRoute(List<Point> inPoints)
        {
            int[] Path = new int[inPoints.Count];       //creates an array with 2 extra spots for 0
            Path[0] = 0;   // (Point(0) "index 0")

            int LastPoint = 0;
            int NextPoint = 0;
            int NumPointsTraversed = 0;
            double TotalDistanceTraversed = 0;


            int i = LastPoint;


            while (NumPointsTraversed < inPoints.Count - 2)
            {
                double ShortestDist = Double.MaxValue;

                for (int j = 0; j < inPoints.Count - 1; j++)
                {
                    if (distanceTable[i, j] != 0)
                    {
                        if (distanceTable[i, j] < ShortestDist)
                        {
                            ShortestDist = distanceTable[i, j];
                            NextPoint = j;
                        }
                    }
                }

                LastPoint = i;
                i = NextPoint;
                Path[NumPointsTraversed + 1] = NextPoint;
                TotalDistanceTraversed += ShortestDist;
                NumPointsTraversed += 1;

                for (int h = 0; h < inPoints.Count; h++)
                {     // remove last point from future consideration
                    distanceTable[h, LastPoint] = 0;
                }
            }

            TotalDistanceTraversed += distanceTable[Path[0], NextPoint];  // get distance back to start							
            Path[NumPointsTraversed + 1] = Path[0];        // add destination point as originating point							

            TotalDistanceTraversed = Math.Truncate(TotalDistanceTraversed * 100) / 100;

            String output = "";
            for (int z = 0; z < Path.Length; z++)
            {
                output += Path[z] + " ";
            }


            return "The total distance is: " + TotalDistanceTraversed + "\n The optimal route is: " + output;
        }
    }
}*/