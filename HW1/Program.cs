using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            List<int> x = new List<int>();                      //a int list containing the x values
            List<int> y = new List<int>();                      //a int list containing the y values 
            Stopwatch sw = new Stopwatch();                     //creates stopwatch

            for (int i = Convert.ToInt32(Console.ReadLine()); i > 0; i--)
            {
                String instring = Console.ReadLine();

                string[] values = instring.Split(' ');

                x.Add(Convert.ToInt32(values[0]));
                y.Add(Convert.ToInt32(values[1]));
            }

            sw.Start();
            //write code here
            Console.WriteLine(":)");
            sw.Stop();
            Console.WriteLine("Time used: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
        }
    }
}
