using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Program.cs
//	Description:       This executes program, reading in a file and sorting, displaying output
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University.
//	Created:           Wednesday, Mar 25 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Heap_Insert
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int strings = Convert.ToInt32(Console.ReadLine()); //read in number of strings
            MaxHeap heap = new MaxHeap(strings);

            for (int i = 0; i < strings; i++)
            {
                heap.Insert(Console.ReadLine()); //insert them into the heap
            }

            heap.Sort(); //sort and display
            Console.WriteLine(heap.printArray());
            Console.ReadLine();
        }
    }
}