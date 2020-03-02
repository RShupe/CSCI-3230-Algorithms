using System;
using System.Collections.Generic;
using System.Diagnostics;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Program.cs
//	Description:       This is the project file for Part C, Project 2
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University.
//	Created:           Sunday, Feb 29 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///
namespace P2C
{
    internal class Program
    {
        /// <summary>
        /// Main - The method that drives the program.
        /// </summary>
        /// <param name="string[] args"></param>
        ///
        private static void Main(string[] args)
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

        /// <summary>
        /// Calculate - This method converts the input into 2 2d arrays and then calls the number of times function.
        /// </summary>
        /// <return name="number of times"></return>
        ///
        public static String Calculate()
        {
            int numLines = Convert.ToInt32(Console.ReadLine()); //record the number of lines to store
            int[,] firstHalf = new int[numLines, 2];            //hold the first half of the input
            int[,] secondHalf = new int[numLines, 2];           //creates the second half of the input
            int sum = Convert.ToInt32(Console.ReadLine());      //the sum to add up to

            for (int i = 0; i < numLines; i++)
            {
                String instring = Console.ReadLine();           //create a string to hold the input the user types

                string[] values = instring.Split(' ');			//create a string array and split the input into two seperate numbers

                for (int j = 0; j < values.Length; j++)         //fill the row with the current values.
                {
                    if (j >= 2)
                    {
                        secondHalf[i, j - 2] = Convert.ToInt32(values[j]);
                    }
                    else
                    {
                        firstHalf[i, j] = Convert.ToInt32(values[j]);
                    }
                }
            }
            return numberOfTimes(sum, firstHalf, secondHalf, numLines).ToString(); //return the number of times the numbers add up to the target value
        }

        /// <summary>
        /// numberOfTimes - This method creates sorted lists of ints and then counts the number of times the arrays add up to the target value.
        /// </summary>
        /// <param name="int sum"></param>
        /// <param name="int[,] firstHalf"></param>
        /// <param name="int[,] secondHalf"></param>
        /// <param name="int numLines"></param>
        /// <return name="number of times"></return>
        ///
        public static int numberOfTimes(int sum, int[,] firstHalf, int[,] secondHalf, int numLines)
        {
            int numTimesFound = 0;      //record the number of times found that the sum is correct

            List<int> firstHalfVals = new List<int>(addArray(firstHalf, numLines)); //hold the possible numbers for the first 2 cols
            List<int> secondHalfVals = new List<int>(addArray(secondHalf, numLines));//hold the possible numbers for the last 2 cols
            firstHalfVals.Sort();
            secondHalfVals.Sort();

            int firstHalfCount = firstHalfVals.Count;       //store the count value so that it doesnt get called as much
            int secondHalfCount = secondHalfVals.Count;     //store the count value so that it doesnt get called as much

            Dictionary<int, int> checkForSum = new Dictionary<int, int>(); //dictionary for fast access and lookup to eliminate the n^2 way of looking for the target

            for (int i = 0; i < firstHalfCount; i++)
            {
                checkForSum[firstHalfVals[i]] = 0;
            }

            for (int j = 0; j < secondHalfCount; j++)
            {
                if (checkForSum.ContainsKey(sum - secondHalfVals[j]))
                {
                    numTimesFound += 1;
                }
            }

            return numTimesFound;
        }

        /// <summary>
        /// addArray - This method takes in a 2d array and generates a list containing all the possible sums.
        /// </summary>
        /// <param name="int[,] inArray"></param>
        /// <param name="int numLines"></param>
        /// <return name="outArray"></return>
        ///
        public static List<int> addArray(int[,] inArray, int numLines)
        {
            List<int> outArray = new List<int>(); //the list that is going to be givin back

            for (int i = 0; i < numLines; i++)
            {
                int val1 = inArray[i, 0];   //temp variable to hold the value at a specific point

                for (int j = 0; j < numLines; j++)
                {
                    outArray.Add(val1 + inArray[j, 1]);
                }
            }
            return outArray;
        }
    }
}