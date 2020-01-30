using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Program.cs
//	Description:       This is the main file for Project 1. UPS Driver has multiple points, find the optimal route for the UPS Driver to take. 
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
            //Console.WriteLine(findClosestPointsDistance(points));
            sw.Stop();

            Console.WriteLine("Time used: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
        }
    }
}
