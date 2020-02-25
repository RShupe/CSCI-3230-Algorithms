using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Program.cs
//	Description:       This is the project file for Part A, Project 2
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University
//	Created:           Sunday, Feb 16 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///
namespace Project2
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
            List<Point> points = new List<Point>();             //a list containing point objects
            Stopwatch sw = new Stopwatch();                     //creates stopwatch
            int num = Convert.ToInt32(Console.ReadLine());      //the number of points to store
            for (int i = num; i > 0; i--)
            {
                String instring = Console.ReadLine();			//create a string to hold the input the user types

                string[] values = instring.Split(' ');			//create a string array and split the input into two seperate numbers

                Point inPoint = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));	//create a point object to store the two numbers.

                points.Add(inPoint);           					//add the point object into the points list.
            }

            sw.Start();
            Console.WriteLine(ClosestPointDQ(points));
            sw.Stop();

            Console.WriteLine("Time used: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
            Console.ReadLine();
        }

        /// <summary>
        /// ClosestPointDQ - method that executes the divide and conquer and returns the shortest distance
        /// </summary>
        /// <param name="inPoints"></param>
        /// <return name="shortest"></return>
        ///
        private static double ClosestPointDQ(List<Point> inPoints)
        {
            inPoints = inPoints.OrderByDescending(p => p.X).ToList();
            return CPP(inPoints);
        }

        /// <summary>
        /// bruteForce - method solves the problem using brute force if the number of points in less than 3.
        /// </summary>
        /// <param name="inPoints"></param>
        /// <return name="shortestDistance"></return>
        ///
        public static double bruteForce(List<Point> inPoints)
        {
            double totalDistance;                           //record the current total distance for comparison
            double shortestDistance = double.MaxValue;      //initially set the shortest distance to the max double value so it will be set on the first pass

            for (int i = 0; i < inPoints.Count() - 2; i++)
            {
                for (int j = (i + 1); j < inPoints.Count() - 1; j++)
                {
                    totalDistance = Distance(inPoints[i], inPoints[j]); //calculate the distance between the two points.

                    if (shortestDistance > totalDistance)
                    {
                        shortestDistance = totalDistance;       //set the new shortest if there is a new one calculated
                    }
                }
            }
            return shortestDistance;
        }

        /// <summary>
        /// CPP - recursive method that calculates the closest distance between two points including in between the line.
        /// </summary>
        /// <param name="inPoints"></param>
        /// <return name="shortest"></return>
        ///
        private static double CPP(List<Point> inPoints)
        {
            if (inPoints.Count <= 3) //if the number of points in less than 3, then brute force is faster
            {
                return bruteForce(inPoints);
            }

            double smallestDistance = Math.Min(CPP(inPoints.Take(inPoints.Count / 2).ToList()), CPP(inPoints.Skip(inPoints.Count / 2).ToList())); //save the current shortest distance by calculating the min of the two halves shortest distance.
            List<Point> middleStripPoints = new List<Point>();      //create a seperate list that will contain all of the points within D distance away

            for (int i = 0; i < inPoints.Count; i++)
            {
                if (Math.Abs(inPoints[i].X - inPoints[inPoints.Count / 2].X) < smallestDistance)
                {
                    middleStripPoints.Add(inPoints[i]); //add the point to the array if it is within a certain distance away
                }
            }
            return Math.Min(smallestDistance, findStripClosestPoint(middleStripPoints, smallestDistance)); //return the minimum of the two distances calculated
        }

        /// <summary>
        /// findStripClosestPoint - method that finds the closest distance between two points within the current distance
        /// </summary>
        /// <param name="inPoints"></param>
        /// <return name="stripPointsDistance"></return>
        ///
        public static double findStripClosestPoint(List<Point> inPoints, double currentMin)
        {
            double stripPointsDistance = currentMin; //create the copy of the current minimum distance
            inPoints = inPoints.OrderByDescending(p => p.Y).ToList(); //sort the list by y value

            //AT MOST THIS LOOP WILL EXECUTE 6 TIMES
            for (int i = 0; i < inPoints.Count; i++)
            {
                for (int j = i + 1; j < inPoints.Count && (inPoints[j].Y - inPoints[j].Y) < stripPointsDistance; j++)
                {
                    double temp = Distance(inPoints[i], inPoints[j]); //holds the calculated distance that the distance method returns
                    if (temp < stripPointsDistance)
                    {
                        stripPointsDistance = temp;
                    }
                }
            }
            return stripPointsDistance;
        }

        /// <summary>
        ///  Distance - calculates the distance between two points and returns the double value
        /// </summary>
        /// <param name="Point A"></param>
        /// <param name="Point B"></param>
        /// <return name="totalDistance"></return>
        ///
        public static double Distance(Point A, Point B)
        {
            double distanceX;                               //record the current distance between X
            double distanceY;                               //record the current distance between Y
            double totalDistance;                           //record the current total distance for comparison

            //sqrt((x2 - x1)^2 + (y2 - y1)^2)
            distanceX = (A.X - B.X);
            distanceX *= distanceX;
            distanceY = (A.Y - B.Y);
            distanceY *= distanceY;
            totalDistance = distanceX + distanceY;
            return Math.Sqrt(totalDistance); ;
        }
    }
}