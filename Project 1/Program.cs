using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

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
    class Program
    {

        /// <summary>
        /// Main - The method that drives the program.
        /// </summary>
        /// <param name="string[] args"></param>
        /// 
        static void Main(string[] args)
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
        }

        /// <summary>
        /// fillDistanceTable - This method takes in a point and a size for the arrray and generates multiple distances at every possible point.
        /// </summary>
        /// <param name="point pointA"></param>
        /// <param name="int x"></param>
        /// <param name="int y"></param>
        /// <returns name="distanceTable"></returns>
        /// 
        static double[,] fillDistanceTable(int x, int y, Point pointA)
        {
            double[,] distanceTable = new double[x, y];    //distance table to create and fill
            double distanceX;                               //record the current distance between X
            double distanceY;                               //recorod the current distance between Y
            double totalDistance;                           //record distance between the points

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    distanceX = pointA.X - i;
                    distanceX *= distanceX;
                    distanceY = pointA.Y - j;
                    distanceY *= distanceY;

                    totalDistance = distanceX + distanceY;
                    totalDistance = Math.Sqrt(totalDistance);
                    distanceTable[i, j] = totalDistance;
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
        static double getDistance(double[,] inTable, Point pointToFind)
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

        static String findShortestRoute(List<Point> inPoints)
        {

            int numberOfPoints = inPoints.Count();                 //number of points in the array
            double totalDistance = 0;                                  //double to store the total distance 
            double distance;                                       //get the distance from a point
            double smallestDistance = Double.MaxValue;             //hold the smallest distance between any two points
            double[,] distanceTable;                               //creates a table that stores the distance between points
            Point zero = new Point(0, 0);                           //create a zero point so we can use it at the beginning and end
            Point nextPoint = new Point();


            inPoints = inPoints.OrderBy(p => p.X).ToList();
            int XPoint = inPoints[numberOfPoints - 1].X + 1;       //record the highest X value to fill the table
            inPoints = inPoints.OrderBy(p => p.Y).ToList();
            int YPoint = inPoints[numberOfPoints - 1].Y + 1;       //record the highest Y value to fill the table
            int nextPointPos = 0;

            //start at zero
            distanceTable = fillDistanceTable(XPoint, YPoint, zero);

            //loop to find the shortest distance initial
            for (int i = 0; i < numberOfPoints; i++)
            {
                distance = getDistance(distanceTable, inPoints[i]);
                if (i == 0)
                {
                    smallestDistance = distance;
                }
                else
                {
                    if (smallestDistance > distance)
                    {
                        smallestDistance = distance;
                        totalDistance += smallestDistance;
                        nextPointPos = i;
                    }
                }
            }

            //totalDistance = smallestDistance;
            //while there is still points left to traverse
            while (numberOfPoints != 1)
            {

                smallestDistance = Double.MaxValue;
                distanceTable = fillDistanceTable(XPoint, YPoint, nextPoint); //next point is the current point right here
                inPoints.RemoveAt(nextPointPos);                              //remove the current point from the list
                numberOfPoints--;

                for (int i = 0; i < numberOfPoints; i++)
                {
                    distance = getDistance(distanceTable, inPoints[i]);
                    if (smallestDistance > distance)
                    {
                        smallestDistance = distance;
                        totalDistance += smallestDistance;
                        nextPointPos = i;                       //set the next point to remove

                    }
                }

                nextPoint = inPoints[nextPointPos];
            }

            //last point back to 0,0
            //nextPoint = inPoints[nextPointPos];
            distanceTable = fillDistanceTable(XPoint, YPoint, nextPoint);
            distance = getDistance(distanceTable, zero);
            totalDistance += distance;


            totalDistance = Math.Truncate(totalDistance * 100) / 100;

            return "The total distance is: " + totalDistance + "\n The optimal route is: ";
        }
    }
}