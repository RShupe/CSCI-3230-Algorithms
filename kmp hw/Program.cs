using System;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         program.cs.cs
//	Description:       This is the main part of the program is executed
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University.
//	Created:           Wednesday, Apr 15 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace kmp_hw
{
    internal class Program
    {
        /// <summary>
        /// main - this is where the main program is executed.
        /// </summary>
        ///
        private static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            String string1 = Console.ReadLine(); //input string one
            Console.Write("Enter a pattern: ");
            String string2 = Console.ReadLine(); //input string two
            StringMatcher(string1, string2);
            Console.ReadLine();
        }

        /// <summary>
        /// ComputePrefix - computes the pi array for the KMP string matching process
        /// </summary>
        /// <param>string P</param>>
        ///<return>int[]</return>>
        public static int[] ComputePrefix(string P)
        {
            int[] pi = new int[P.Length]; //create pi array that has the size of the length of the string
            int k = 0; //number of matches
            int i = 1; //index starting at 1
            pi[0] = 0; // pi[0] is always 0

            //calculate pi[] until the legnth of p is hit
            while (i < P.Length)
            {
                if (P[i] == P[k]) //if the value of P{i} is  equal to P{k}
                {
                    k++;
                    pi[i] = k;
                    i++;
                }
                else  //if the value of P{i} is not equal to P{k}
                {
                    if (k == 0)
                    {
                        pi[i] = k;
                        i++;
                    }
                    else
                    {
                        k = pi[k - 1];
                    }
                }
            }
            return pi;
        }

        /// <summary>
        /// String Matcher - this matches the string with the pattern and prints out the shift location it finds it at
        /// </summary>
        /// <param>string T</param>>
        /// <param>string P</param>>

        public static void StringMatcher(string T, string P)
        {
            int[] pi = ComputePrefix(P); //pi array

            for(int o = 0; o < pi.Length; o++)
            {
                Console.Write(pi[o] + " ");
            }
            Console.WriteLine();
            
        }
    }
}