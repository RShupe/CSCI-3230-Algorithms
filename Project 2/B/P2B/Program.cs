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
        private static int[] on_Y;
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

            Console.WriteLine("Time used: " + sw.Elapsed.TotalMilliseconds / 1000 + " seconds.");
            Console.ReadLine();
        }

        private static String Calculate()
        {
            int N = 1000000;
            ClearandInitialize(N);
            int output = 0;
            List<int>[] ys = new List<int>[N];
            for (int i = 0; i < ys.Length; i++)
            {
                ys[i] = new List<int>();
            }

            int numLines = int.Parse(Console.ReadLine());

            for (int i = numLines; i > 0; i--)
            {
                String instring = Console.ReadLine();           //create a string to hold the input the user types

                string[] values = instring.Split(' ');          //create a string array and split the input into two seperate numbers

                Point inPoint = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));  //create a point object to store the two numbers.

                ys[inPoint.X].Add(inPoint.Y);
                on_Y[inPoint.Y]++;
            }

            for (int i = 1001; i >= 0; i--)
            {
                on_Y[i] += on_Y[i + 1];
            }

            Build(1, 0, 1001);


            for (int i = 0; i <= 1001; i++)
            {
                output = Math.Max(output, t[1]);
                for (int j = 0; j < ys[i].Count; j++)
                {
                    int ps = ys[i][j];
                    Add(1, 0, 1001, 0, ps, -1);
                    Add(1, 0, 1001, ps + 1, 1001, 1);
                }

                output = (Math.Max(output, t[1]));
            }

            return output.ToString();
        }

        private static void Build(int v, int tl, int tr)
        {
            toadd[v] = 0;
            if (tl == tr)
            {
                t[v] = on_Y[tl];
                return;
            }

            int tm = tl + tr;
            tm /= 2;
            Build(v * 2, tl, tm);
            Build(v * 2 + 1, tm + 1, tr);
            t[v] = Math.Min(t[v * 2], t[v * 2 + 1]);
        }

        private static void Push(int v)
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

        private static void Add(int v, int tl, int tr, int l, int r, int val)
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

            Push(v);
            int tm = tl + tr;
            tm /= 2;
            Add(v * 2, tl, tm, l, Math.Min(r, tm), val);
            Add(v * 2 + 1, tm + 1, tr, Math.Max(tm + 1, l), r, val);
            t[v] = Math.Min(t[v * 2], t[v * 2 + 1]);
        }

        public static void ClearandInitialize(int N)
        {
            t = new int[N * 4];
            toadd = new int[N * 4];
            on_Y = new int[N];
        }
    }
}