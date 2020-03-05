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
        private static int N = 1000050;

        private static int[] on_Y;
        private static int[] x;
        private static int[] y;
        private static int[] t;
        private static int[] toadd;

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
            String[] output = new String[testCases];                  //space to hold the results that the number of testcases gives
            sw.Start();
            for (int i = 0; i < testCases; i++)
            {
                output[i] = Calculate();
            }
            sw.Stop();

            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }

            //Console.WriteLine("Time used: " + sw.Elapsed.TotalMilliseconds / 1000 + " seconds.");
            //Console.ReadLine();
        }

        private static String Calculate()
        {
            ClearandInitialize();
            List<int>[] ys = new List<int>[N];
            for(int i = 0; i < ys.Length; i++)
            {
                ys[i] = new List<int>();
            }
            List<Point> points = new List<Point>();
            int numLines = int.Parse(Console.ReadLine());

            for (int i = numLines; i > 0; i--)
            {
                String instring = Console.ReadLine();           //create a string to hold the input the user types

                string[] values = instring.Split(' ');          //create a string array and split the input into two seperate numbers

                Point inPoint = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));  //create a point object to store the two numbers.

                points.Add(inPoint);                            //add the point object into the points list.

                x[i] = inPoint.X;
                y[i] = inPoint.Y;

                ys[x[i]].Add(y[i]);
                on_Y[y[i]]++;
            }

            for (int i = 1001; i >= 0; --i)
            {
                on_Y[i] += on_Y[i + 1];
            }

            build(1, 0, 1001);

            int ans = 0;
            for (int i = 0; i <= 1001; i++)
            {
                ans = Math.Max(ans, t[1]);
                for (int j = 0; j < ys[i].Count; j++)
                {
                    int ps = ys[i][j];
                    add(1, 0, 1001, 0, ps, -1);
                    add(1, 0, 1001, ps + 1, 1001, 1);
                }

                ans = (Math.Max(ans, t[1]));
            }

            return ans.ToString();
        }

        private static void build(int v, int tl, int tr)
        {
            toadd[v] = 0;
            if (tl == tr)
            {
                t[v] = on_Y[tl];
                return;
            }
            int tm = tl + tr;
            tm /= 2;
            build(v * 2, tl, tm);
            build(v * 2 + 1, tm + 1, tr);
            t[v] = Math.Min(t[v * 2], t[v * 2 + 1]);
        }

        private static void push(int v, int tl, int tr)
        {
            if (toadd[v] == 0)
            {
                return;
            }
            toadd[v * 2] += toadd[v];
            toadd[v * 2 + 1] += toadd[v];
            t[v * 2] += toadd[v];
            t[v * 2 + 1] += toadd[v];
            toadd[v] = 0;
        }

        private static void add(int v, int tl, int tr, int l, int r, int val)
        {
            if (l > r)
            {
                return;
            }

            if (tl == l && tr == r)
            {
                t[v] += val;
                toadd[v] += val;
                return;
            }

            push(v, tl, tr);
            int tm = tl + tr;
            tm /= 2;
            add(v * 2, tl, tm, l, Math.Min(r, tm), val);
            add(v * 2 + 1, tm + 1, tr, Math.Max(tm + 1, l), r, val);
            t[v] = Math.Min(t[v * 2], t[v * 2 + 1]);
        }

        public static void ClearandInitialize()
        {
            x = new int[N];
            y = new int[N];
            t = new int[N * 4];
            toadd = new int[N * 4];
            on_Y = new int[N];
        }
    }
}