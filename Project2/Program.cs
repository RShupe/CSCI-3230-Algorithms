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
        public static void Main(string[] args)
        {
            List<Point> points = new List<Point>();             //a list containing point objects
            Stopwatch sw = new Stopwatch();                     //creates stopwatch

            for (int i = Convert.ToInt32(Console.ReadLine()); i > 0; i--)
            {
                String instring = Console.ReadLine();			//create a string to hold the input the user types

                string[] values = instring.Split(' ');			//create a string array and split the input into two seperate numbers

                Point inPoint = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));	//create a point object to store the two numbers.

                points.Add(inPoint);           					//add the point object into the points list.
            }

            sw.Start();
            Console.WriteLine(findClosestPointsDistanceDQ(points));
            sw.Stop();

            Console.WriteLine("Time used: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
            Console.ReadLine();
        }

        public static double findClosestPointsDistanceDQ(List<Point> inPoints)
        {
            double shortestDistance = 0.0;

            inPoints = inPoints.OrderBy(p => p.X).ToList(); //order the points so the compution processes faster

            //----------------DIVIDE---------------
            int middle = inPoints.Count / 2;                //find the middle index of the list
            List<Point> A = new List<Point>();              //A point list to contain the first half of the points.

            for (int i = 0; i < middle; i++)
            {
                A.Add(inPoints.ElementAt(i));
            }

            List<Point> B = new List<Point>();              //B point list to contain the rest of the points

            for (int i = middle; i < inPoints.Count; i++)
            {
                B.Add(inPoints.ElementAt(i));
            }

            //-------------CONQUER-----------------
           

            return shortestDistance;
        }

       

        public static double Calculate(Point A, Point B)
        {
            double distanceX;                               //record the current distance between X
            double distanceY;                               //record the current distance between Y
            double totalDistance;                           //record the current total distance for comparison

            distanceX = (A.X - B.X);
            distanceX *= distanceX;
            distanceY = (A.Y - B.Y);
            distanceY *= distanceY;

            totalDistance = distanceX + distanceY;
            totalDistance = Math.Sqrt(totalDistance);

            return totalDistance;
        }
    }
}