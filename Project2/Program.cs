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
        private static double[,] distanceTable;             //distance table to generate all the distances between points
        public static void Main(string[] args)
        {
            List<Point> points = new List<Point>();             //a list containing point objects
            Stopwatch sw = new Stopwatch();                     //creates stopwatch
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = num; i > 0; i--)
            {
                String instring = Console.ReadLine();			//create a string to hold the input the user types

                string[] values = instring.Split(' ');			//create a string array and split the input into two seperate numbers

                Point inPoint = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));	//create a point object to store the two numbers.

                points.Add(inPoint);           					//add the point object into the points list.
            }
            distanceTable = new double[num, num];
            sw.Start();
            FillDistanceTable(points);
           Console.WriteLine(closest(points));
            sw.Stop();

            Console.WriteLine("Time used: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
            Console.ReadLine();
        }

        private static double closest(List<Point> inPoints)
        {
            double[] output = new double[distanceTable.Length-1];
            int index = 0;
            for (int i = 0; i < inPoints.Count; i++)
            {
                for(int j = 0; j < inPoints.Count; j++)
                {
                    output[index] = distanceTable[i, j];
                    if(index < distanceTable.Length - 2)
                    {
                        index++;
                    }
                    
                } 
            }

            output = MergeSort(output);

            double shortest = 0;
            int ind = 0;
            while(shortest == 0)
            {
                if(output[ind] != 0)
                {
                    shortest = output[ind];
                }
                ind++;
            }
            return shortest;

        }

        static double[] MergeSort(double[] C)
        {
            return C.Length == 1 ? C :

                Merge(MergeSort(C.Take(C.Length / 2).ToArray()),
                MergeSort(C.Skip(C.Length / 2).ToArray()));
        }

        private static double[] Merge(double[] A, double[] B)
        {
            double[] outputArray = new double[A.Length + B.Length];
            int AIndex = 0;
            int BIndex = 0;
            int outputIndex = 0;

            while (AIndex < A.Length && BIndex < B.Length)
            {
                if (A[AIndex] < B[BIndex])
                {
                    outputArray[outputIndex] = A[AIndex];
                    outputIndex++;
                    AIndex++;
                }
                else
                {
                    outputArray[outputIndex] = B[BIndex];
                    outputIndex++;
                    BIndex++;
                }
            }

            while (AIndex < A.Length)
            {
                outputArray[outputIndex] = A[AIndex];
                outputIndex++;
                AIndex++;
            }

            while (BIndex < B.Length)
            {
                outputArray[outputIndex] = B[BIndex];
                outputIndex++;
                BIndex++;
            }

            return outputArray;
        }
        /// <summary>
        /// fillDistanceTable - The method generates a distance table and fills in values from point A to B
        /// </summary>
        /// <param name="List<Point> inpoints"></param>
        ///
        private static void FillDistanceTable(List<Point> inPoints)
        {
            List<Point> AllPoints = new List<Point>();      // List of all points from start thru user input

            int PCount = inPoints.Count;                    // Number of points
            Point FromPnt;                                  // From Point
            Point ToPnt;                                    // To Point
            double distanceX;                               // record the distance between Xs
            double distanceY;                               // record the distance between Ys
            double totalDistance;                           // record the total distance

            for (int i = 0; i < PCount; i++)
            {
                AllPoints.Add(inPoints[i]);         // Add all user input points to list
            }

            for (int i = 0; i < PCount; i++)
            {
                FromPnt = AllPoints[i];                 // Set From Point for calculation
                for (int j = i; j < PCount; j++)
                {
                    ToPnt = AllPoints[j];               // Set To Point for calculation

                    // d = sqrt((x2 - x1)^2 + (y2 - y1)^2)
                    distanceX = (ToPnt.X - FromPnt.X);
                    distanceX *= distanceX;
                    distanceY = (ToPnt.Y - FromPnt.Y);
                    distanceY *= distanceY;
                    totalDistance = distanceX + distanceY;
                    totalDistance = Math.Sqrt(totalDistance);

                    distanceTable[i, j] = totalDistance;
                    if (i != j)
                    {            // saves time from recalc distance between same 2 points
                        distanceTable[j, i] = totalDistance;
                    }
                }
            }
        }
    }
}