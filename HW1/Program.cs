using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;

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
            inPoints = inPoints.OrderBy(p => p.X).ToList();
            double distanceX;
            double distanceY;
            double totalDistance;
            double shortestDistance = double.MaxValue;
            for (int i = 0; i < inPoints.Count() - 1; i++)
            {

                distanceX = (inPoints[i + 1].X - inPoints[i].X);
                distanceX *= distanceX;
                distanceY = (inPoints[i + 1].Y - inPoints[i].Y);
                distanceY *= distanceY;

                totalDistance = distanceX + distanceY;
                totalDistance = Math.Sqrt(totalDistance);
                if (shortestDistance > totalDistance)
                {
                    shortestDistance = totalDistance;
                }
            }

            return shortestDistance;
        }
    }
}
