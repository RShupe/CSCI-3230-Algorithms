using System;
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
        private static int[] onY;
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
            SegTree = new int[N * 4];
            toAdd = new int[N * 4];
            onY = new int[N];
            int output = 0;
            List<int>[] Ys = new List<int>[N];
            for (int i = 0; i < Ys.Length; i++)
            {
                Ys[i] = new List<int>();                        //build list of lists of Y coords
            }

            int numLines = int.Parse(Console.ReadLine());       //get number of X,Y coord points input by user

            for (int i = numLines; i > 0; i--)
            {
                String instring = Console.ReadLine();           //create a string to hold the user input

                string[] values = instring.Split(' ');          //create a string array and split the input into two seperate numbers

                Point inPoint = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));  //create a point object to store the two coords

                Ys[inPoint.X].Add(inPoint.Y);                   //list of Y points for each X
                onY[inPoint.Y]++;                               //number of Y points on vertical line
            }

            for (int i = 1001; i >= 0; i--)
            {
                onY[i] += onY[i + 1];                             //get total number of Y points into onY[0]
            }

            BuildSegTree(1, 0, 1001);


            for (int i = 0; i <= 1001; i++)
            {
                output = Math.Max(output, SegTree[1]);
                for (int j = 0; j < Ys[i].Count; j++)
                {
                    int ps = Ys[i][j];
                    Add(1, 0, 1001, 0, ps, -1);
                    Add(1, 0, 1001, ps + 1, 1001, 1);
                }

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
        private static void BuildSegTree(int index, int treeLeft, int treeRight)
        {
            toAdd[index] = 0;
            if (treeLeft == treeRight)
            {
                SegTree[index] = onY[treeLeft];
                return;
            }

            int TreeMid = treeLeft + treeRight;                       //find the middle of the tree to consider
            TreeMid /= 2;
            BuildSegTree(index * 2, treeLeft, TreeMid);                   //analyze the left half of the tree
            BuildSegTree(index * 2 + 1, TreeMid + 1, treeRight);               //analyze the right half of the tree
            SegTree[index] = Math.Min(SegTree[index * 2], SegTree[index * 2 + 1]);   //find minimum of ..
        }


        /// <summary>
        /// Push -  this method...
        /// </summary>
        /// <param name="vl"></param>
        ///
        private static void Push(int vl)
        {
            if (toAdd[vl] == 0)
            {
                return;
            }

            toAdd[vl * 2] += toAdd[vl];
            toAdd[vl * 2 + 1] += toAdd[vl];
            SegTree[vl * 2] += toAdd[vl];
            SegTree[vl * 2 + 1] += toAdd[vl];
            toAdd[vl] = 0;
        }
        /// <summary>
        /// Add -  this method...
        /// </summary>
        /// <param name="vl"></param>
        /// <param name="treeLeft"></param>
        /// <param name="treeRight"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="vlv"></param>
        ///
        private static void Add(int vl, int treeLeft, int treeRight, int left, int right, int vlv)
        {
            if (left > right)                            //make sure there are vertical lines left to analyze
            {
                return;
            }

            if (treeLeft == left && treeRight == right)
            {
                SegTree[vl] += vlv;
                toAdd[vl] += vlv;
                return;
            }

            Push(vl);
            int treeMid = treeLeft + treeRight;
            treeMid /= 2;
            Add(vl * 2, treeLeft, treeMid, left, Math.Min(right, treeMid), vlv);
            Add(vl * 2 + 1, treeMid + 1, treeRight, Math.Max(treeMid + 1, left), right, vlv);
            SegTree[vl] = Math.Min(SegTree[vl * 2], SegTree[vl * 2 + 1]);
        }
    }
}