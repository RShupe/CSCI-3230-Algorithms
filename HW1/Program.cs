﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Program.cs
//	Description:       This is the Homework 1 main cs file. Intake different points, convert them, and find the
//                      shortest distance between the set points and display them. 
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University
//	Created:           Friday, Jan 24 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///
namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();             //a list containing point objects
            Stopwatch sw = new Stopwatch();                     //creates stopwatch

            for (int i = Convert.ToInt32(Console.ReadLine()); i > 0; i--)
            {
                String instring = Console.ReadLine();

                string[] values = instring.Split(' ');

                Point inPoint = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));

                points.Add(inPoint);           
            }

            sw.Start();
            Console.WriteLine(findClosestPointsDistance(points));
            sw.Stop();

            Console.WriteLine("Time used: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
        }

        static double findClosestPointsDistance(List<Point> inPoints)
        {
            inPoints = inPoints.OrderBy(p => p.X).ToList(); //order the points so the compution processes faster
            double distanceX;                               //record the current distance between X
            double distanceY;                               //recorod the current distance between Y
            double totalDistance;                           //record the current total distance for comparison
            double shortestDistance = double.MaxValue;      //initially set the shortest distance to the max double value so it will be set on the first pass

            for (int i = 0; i < inPoints.Count() - 2; i++)
            {
                for(int j = (i + 1); j < inPoints.Count() - 1; j++)
                {
                    distanceX = (inPoints[i].X - inPoints[j].X);
                    distanceX *= distanceX;
                    distanceY = (inPoints[i].Y - inPoints[j].Y);
                    distanceY *= distanceY;

                    totalDistance = distanceX + distanceY;
                    totalDistance = Math.Sqrt(totalDistance);
                    if (shortestDistance > totalDistance)
                    {
                        shortestDistance = totalDistance;
                    }
                }
            }
                return shortestDistance;
        }
    }
}
