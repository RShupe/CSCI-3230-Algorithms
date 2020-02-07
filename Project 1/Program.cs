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
        static double shortestDistance = Double.MaxValue;   //global variable to store the shortestDistance
        static string output;                               //global string variable to hold the output permutation
        static int[] shortestPerm = new int[20];            //integer array to store the shortest permutation
        static double[,] distanceTable = new double[20, 20];//distance table to generate all the distances between points

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
            Console.WriteLine(FindShortestRoute(points));
            sw.Stop();

            Console.WriteLine("\t\t     Time used: {0} seconds", sw.Elapsed.TotalMilliseconds / 1000);
            Console.ReadLine();     //pause
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
            Point zero = new Point(0, 0);
            AllPoints.Add(zero);                            // Add starting point to list
            for (int i = 0; i < PCount; i++)
            {
                AllPoints.Add(inPoints[i]);         // Add all user input points to list
            }

            PCount++;

            // Number of points in AllPoints since (0,0) was added
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

        /// <summary>
        /// FindShortestRoute - This method utilizes the other methods in the program to calculate
        ///  the shortest distance and the permutaion
        /// </summary>
        /// <param name="List<Point> inpoints"></param>
        ///<return name= "output String"></return>
        public static String FindShortestRoute(List<Point> inPoints)
        {
            int[] permPath = new int[inPoints.Count];           //holds the initial permutation

            for (int i = 0; i < permPath.Length; i++)
            {
                permPath[i] = 1 + i;                            //fills the array with the corresponding point number
            }

            FillDistanceTable(inPoints);                        //create the distance table
            CalculatePerm(permPath, inPoints.Count, inPoints);  //calculate the shortest permutation and distance

            output = "";
            output += "0 ";
            for (int i = 0; i < inPoints.Count; i++)
            {
                output += shortestPerm[i] + " ";
            }
            output += "0";

            shortestDistance = Math.Truncate(shortestDistance * 100) / 100;

            return "The total shortest distance is: " + shortestDistance + "\n \t  The optimal route is: " + output;
        }

        /// <summary>
        /// calculatePerm - This method creates a permutation and calls another method to see if it is a shortest distance
        /// </summary>
        /// <param name="int[] currentPerm"></param>
        /// <param name="int permSize"></param>
        /// <param name="List<Point> inPoints"></param>

        private static void CalculatePerm(int[] currentPerm, int permSize, List<Point> inPoints )
        {
            // if size becomes 1 then it creates a path of points corresponding to the permutation calculated
            if (permSize == 1)
            {
                if (currentPerm[0] < currentPerm[permSize] )
                {
                    CalculateDistance(currentPerm);
                }
            }

            if (permSize != 1)
            {
                for (int i = 0; i < permSize; i++)
                {
                    CalculatePerm(currentPerm, permSize - 1, inPoints);

                    if (permSize % 2 == 1)
                    {
                        int num = currentPerm[0];       //save the first point in the current permutation
                        currentPerm[0] = currentPerm[permSize - 1];
                        currentPerm[permSize - 1] = num;
                    }
                    else
                    {
                        int num = currentPerm[i];       //save point i in the current permutation
                        currentPerm[i] = currentPerm[permSize - 1];
                        currentPerm[permSize - 1] = num;
                    }
                }
            }

        }

        /// <summary>
        ///  calculateDistance - This method pulls from the distance table accordingly, adds up the distances and 
        ///     checks to see if the distance is the shortest. If it is the number and permutation is saved
        /// </summary>
        /// <param name="int[] Permutation"></param>

        private static void CalculateDistance(int[] Permutation)
        {
            int PCount = Permutation.Length;                 // Number of points in user input
            double stepDistance;                             // record the current distance between points
            double overallDistance = 0;                      // record the current overall distance

            stepDistance = distanceTable[0, Permutation[0]]; // get distance from 0,0 to first point
            overallDistance += stepDistance;

            for (int i = 0; i < PCount - 1; i++)
            {
                stepDistance = distanceTable[Permutation[i], Permutation[i + 1]];  // get distance from point to point for user input
                overallDistance += stepDistance;
            }

            stepDistance = distanceTable[Permutation[PCount - 1], 0];   // get distance from last point to 0,0
            overallDistance += stepDistance;

            // save permutation and distance if there is a new one.
            if (overallDistance < shortestDistance)
            {
                shortestDistance = overallDistance;

                for (int i = 0; i < Permutation.Length; i++)
                {
                    shortestPerm[i] = Permutation[i];
                }
            }
        }
    }
}