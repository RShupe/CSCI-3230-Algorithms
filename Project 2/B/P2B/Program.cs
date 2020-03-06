﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Program.cs
//	Description:       This is the project file for Part B, Project 2
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University.
//	Created:           Wednesday, Mar 04 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace P2B
{
    internal class Program
    {
        private static int[] onvl;
        private static int[] SegTree;
        private static int[] toAdd;

        /// <summary>
        /// Main - The method that drives the program.
        /// </summary>
        /// <param name="string[] args"></param>
        ///
        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();                           //creates stopwatch
            int testCases = Convert.ToInt32(Console.ReadLine());      //the number of test cases
            Console.WriteLine();
            String[] output = new String[testCases];                  //space to hold the results that the number of testcases give
            sw.Start();						      //start the stopwatch
            for (int i = 0; i < testCases; i++)
            {
                output[i] = Calculate();
            }
            sw.Stop();						      //stop the stopwatch

            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }

            Console.WriteLine("Time used: " + sw.Elapsed.TotalMilliseconds / 1000 + " seconds.");
            Console.ReadLine();
        }

        /// <summary>
        /// Calculate - This method calculates the answer and returns the int string of the number of cookies.
        /// </summary>
        /// <return name="output"></param>
        ///
        private static String Calculate()
        {
            int N = 1000000;		//max possible number of cookies

            int output = 0; //the output number of cookies
            List<Point> points = new List<Point>(); //the list of points taken in from input

            int numLines = int.Parse(Console.ReadLine());       //get number of coord points input by user
            SegTree = new int[N * 4];
            toAdd = new int[N * 4];
            onvl = new int[N];

            for (int i = numLines; i > 0; i--)
            {
                String instring = Console.ReadLine();           //create a string to hold the user input

                string[] values = instring.Split(' ');          //create a string array and split the input into two seperate numbers

                Point inPoint = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));  //create a point object to store the two coords

                points.Add(inPoint);                   //list of Y points for each X
                onvl[inPoint.Y] += 1;                              //number of Y points on vertical line
            }

            for (int i = 0; i < numLines - 1; i++)
            {
                onvl[i] += onvl[i + 1];                            //get total number of Y points into onvl[0]
            }

            BuildSegTree(1, 0, 1001);

            for (int i = 0; i < points.Count; i++)
            {
                output = Math.Max(output, SegTree[1]);

                Add(1, 0, 1001, 0, points[i].Y, -1);
                Add(1, 0, 1001, points[i].Y + 1, 1001, 1);

                output = (Math.Max(output, SegTree[1]));
            }

            return output.ToString();
        }

        /// <summary>
        /// BuildSegTree -  this method...
        /// </summary>
        /// <param name="index"></param>
        /// <param name="treeLeft"></param>
        /// <param name="treeRight"></param>
        ///
        private static void BuildSegTree(int index, int TreeLft, int TreeRgt)
        {
            toAdd[index] = 0;
            if (TreeLft == TreeRgt)
            {
                SegTree[index] = onvl[TreeLft];
                return;
            }
            else
            {
                int TreeMid = (TreeLft + TreeRgt) / 2;                        //find the middle of the tree to consider

                BuildSegTree(index * 2, TreeLft, TreeMid);                   //analyze the left half of the tree
                BuildSegTree(index * 2 + 1, TreeMid + 1, TreeRgt);               //analyze the right half of the tree
                SegTree[index] = Math.Min(SegTree[index * 2], SegTree[index * 2 + 1]);  //find minimum of ..
            }
        }

        /// <summary>
        /// Push -  this method...
        /// </summary>
        /// <param name="index"></param>
        ///
        private static void Push(int index)
        {
            if (toAdd[index] == 0)
            {
                return;
            }
            else
            {
                toAdd[index * 2] += toAdd[index];
                toAdd[index * 2 + 1] += toAdd[index];
                SegTree[index * 2] += toAdd[index];
                SegTree[index * 2 + 1] += toAdd[index];

                toAdd[index] = 0;
            }
        }

        /// <summary>
        /// Add -  this method...
        /// </summary>
        /// <param name="index"></param>
        /// <param name="treeLeft"></param>
        /// <param name="treeRight"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="vlv"></param>
        ///
        private static void Add(int index, int treeLeft, int treeRight, int left, int right, int vlv)
        {
            if (left > right)                            //make sure there are vertical lines left to analyze
            {
                return;
            }
            else if (treeLeft == left && treeRight == right)
            {
                SegTree[index] += vlv;
                toAdd[index] += vlv;
                return;
            }
            else
            {
                Push(index);
                int TreeMid = (treeLeft + treeRight) / 2;                        //find the middle of the tree to consider
                Add(index * 2, treeLeft, TreeMid, left, Math.Min(right, TreeMid), vlv);
                Add(index * 2 + 1, TreeMid + 1, treeRight, Math.Max(TreeMid + 1, left), right, vlv);
                SegTree[index] = Math.Min(SegTree[index * 2], SegTree[index * 2 + 1]);
            }
        }
    }
}