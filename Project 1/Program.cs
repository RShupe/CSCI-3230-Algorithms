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

        static double[,] fillDistanceTable(int x, int y, Point pointA)
        {
            double[,] distanceTable = new double [x, y];    //distance table to create
            double distanceX;                               //record the current distance between X
            double distanceY;                               //recorod the current distance between Y
            double totalDistance;                           //record the current total distance for comparison

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                { 
                    distanceX = pointA.X - i;
                    distanceX *= distanceX;
                    distanceY =  pointA.Y - j;
                    distanceY *= distanceY;

                    totalDistance = distanceX + distanceY;
                    totalDistance = Math.Sqrt(totalDistance);
                    distanceTable[i, j] = totalDistance;
                }
            }

            return distanceTable;
        }

        static double getDistance(double[,] inTable, Point pointToFind)
        {
            double distance = inTable[pointToFind.X, pointToFind.Y];
            return distance;
        }

        static double findShortestRoute(List<Point> inPoints)
        {
            int numberOfPoints = inPoints.Count();
            double[,] distanceTable;                               //creates a table that stores the distance between points
            distanceTable = fillDistanceTable(inPoints[numberOfPoints - 1].X + 1, inPoints[numberOfPoints - 1 ].Y + 1, inPoints[0]);
            double distance = getDistance(distanceTable, inPoints[1]);
            return 0.0;
        }
    }
}
