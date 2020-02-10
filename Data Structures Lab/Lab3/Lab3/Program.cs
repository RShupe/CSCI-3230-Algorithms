﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    static class Program
    {
        static void Main(string[] args)
        {
            #region Array
            /* STRING ARRAY
            int size = Convert.ToInt32(Console.ReadLine());
            String[] stringArray = new String[size];
            Stopwatch sw = new Stopwatch();                     //creates stopwatch

            for (int i = 0; i < size; i++)
            {
                String instring = Console.ReadLine();			
                stringArray[i] = instring;           			
            }

            sw.Start();
            Array.Sort(stringArray);
            stringArray = stringArray.Distinct().ToArray();
            sw.Stop();

            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.WriteLine(stringArray[i]);
            }

            Console.WriteLine("Time used to sort: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
            Console.WriteLine("The total number of strings without duplicates: " + stringArray.Length);

            Console.ReadLine();
            */
            #endregion Array
            #region Hashset
            //HASTSET/*
            /*int numOfLines = 0; //number of items in file
            String line = ""; //holds each line from input file

            Stopwatch sw = Stopwatch.StartNew(); //creates sw and starts stopwatch
                                                 //read in first line of file and set 'numOfLines'
                                                 //(first line of file states how many inputs are in the file)
            if ((line = Console.ReadLine()) != null)
                Int32.TryParse(line, out numOfLines);
            //holds input and output lines
            HashSet<string> inString = new HashSet<string>(StringComparer.Ordinal);
            //read file into HashSet line by line
            while ((line = Console.ReadLine()) != null)
            {
                inString.Add(line);
            }

            //sort data
            inString = new HashSet<string>(inString.OrderBy(i => i, StringComparer.Ordinal));
            sw.Stop(); // stops stopwatch

            //display each line in the output HashSet
            //foreach (string s in inString)
            //{
            //    Console.WriteLine(s);
            //}

            Console.WriteLine("Time used to sort: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
            Console.WriteLine("The total number of strings without duplicates: " + inString.Count);*/
            #endregion Hashset
            #region LinkedList
            /*int numOfLines = 0; //number of items in file
            String line = ""; //holds each line from input file

            Stopwatch sw = Stopwatch.StartNew(); //creates sw and starts stopwatch
                                                 //read in first line of file and set 'numOfLines'
                                                 //(first line of file states how many inputs are in the file)
            if ((line = Console.ReadLine()) != null)
                Int32.TryParse(line, out numOfLines);
            //holds input and output lines
            LinkedList<string> inString = new LinkedList<string>();
            //read file into HashSet line by line
            while ((line = Console.ReadLine()) != null)
            {
                inString.AddLast(line);
            }

            
            sw.Stop(); // stops stopwatch

            //display each line in the output HashSet
             foreach (string s in inString)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Time used to sort: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
            Console.WriteLine("The total number of strings without duplicates: " + inString.Count);*/
            #endregion LinkedList
            #region List
            /*int size = Convert.ToInt32(Console.ReadLine());
            List<String> stringArray = new List<String>();
            Stopwatch sw = new Stopwatch();                     //creates stopwatch

            for (int i = 0; i < size; i++)
            {
                String instring = Console.ReadLine();
                stringArray.Add(instring);
            }

            sw.Start();
            stringArray.Sort();
            sw.Stop();

            for(int i = 0; i < stringArray.Count; i++)
            {
                if(stringArray[i] == stringArray[i + 1])
                {
                    stringArray.RemoveAt(i);
                }
            }

            for (int i = 0; i < stringArray.Count(); i++)
            {
                Console.WriteLine(stringArray[i]);
            }

            Console.WriteLine("Time used to sort: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
            Console.WriteLine("The total number of strings without duplicates: " + stringArray.Count);

            Console.ReadLine();*/
            #endregion List
            #region Sorted Set
            /*int size = Convert.ToInt32(Console.ReadLine());
            SortedSet<String> stringArray = new SortedSet<String>(Comparer<String>.Create((a1, a2) => a1.CompareTo(a2)));
            Stopwatch sw = new Stopwatch();                     //creates stopwatch
            sw.Start();
            for (int i = 0; i < size; i++)
            {
                String instring = Console.ReadLine();
                stringArray.Add(instring);
            }

            sw.Stop();

            for (int i = 0; i < stringArray.Count; i++)
            {
                if (stringArray.ElementAt(i) == stringArray.ElementAt(i + 1))
                {
                    stringArray.Remove(stringArray.ElementAt(i));
                }
            }

            for (int i = 0; i < stringArray.Count(); i++)
             {
                Console.WriteLine(stringArray[i]);
            }

            Console.WriteLine("Time used to sort: {0} seconds.", sw.Elapsed.TotalMilliseconds / 1000);
            Console.WriteLine("The total number of strings without duplicates: " + stringArray.Count);

            Console.ReadLine();*/
            #endregion Sorted Set
            #region Dictionary
            int size = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < size; i++)
            {
                String instring = Console.ReadLine();
                dict.Add(instring, i);
            }

            Console.WriteLine("The total number of strings without duplicates: " + dict.Count);
            Console.ReadLine();
            #endregion Dictionary


        }
        public static T KeyByValue<T, W>(this Dictionary<T, W> dict, W val)
        {
            T key = default;
            foreach (KeyValuePair<T, W> pair in dict)
            {
                if (EqualityComparer<W>.Default.Equals(pair.Value, val))
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }


    }

}
