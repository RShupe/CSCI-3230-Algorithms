using System;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Heap.cs
//	Description:       This controls the heap of ints, used for intially reading in the file.
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University.
//	Created:           Wednesday, Mar 25 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Project4
{
    internal class Heap
    {
        public int max_size;           //max size of heap, this is included just to explain that size is not maximum size, but is current heap size.
        public int size;               //size of current heap
        public int[] h;             //array of strings that the heap will use

        /// <summary>
        /// MaxHeap - No arg constructor
        /// </summary>
        ///
        public Heap()
        {
        }

        /// <summary>
        /// MaxHeap - constructor that accepts a max-size
        /// </summary>
        ///
        public Heap(int inSize)
        {
            size = 0;
            max_size = inSize;
            h = new int[max_size + 1];
        }

        /// <summary>
        /// extract - this method takes the root node and swaps it with the last node, decreasing the size
        /// </summary>
        ///
        public void Extract()
        {
            int lastItem;
            int root = h[1]; //the main root node string
            try
            {
                lastItem = h[size]; //string of the last item in the heap
                h[1] = lastItem;
            }
            catch
            {
                throw new Exception("size is too largo");
            }

            h[size] = root; //remove the first item and place in the last spot

            size--;



            fixHeap(1); //we need to fix the heap starting with the root node
            return;
        }

        /// <summary>
        /// fixHeap - this method fixed the heap so it retains the max heap structure
        /// </summary>
        ///
        public void fixHeap(int i)
        {
            int largest = i; //current largest int found
            int l = 2 * i; //get index of the left child
            int r = 2 * i + 1; //get index of the right child

            if (l <= size && (h[l] > h[largest]))//checks to see if the left child is larger than the parent
                largest = l;

            if (r <= size && (h[r] > h[largest])) //checks to see if the right child is larger than the parent
                largest = r;

            if (largest != i) //if a new largest is found we need to swap them
            {
                int swap = h[i]; //string to hold for swapping two strings
                h[i] = h[largest];
                h[largest] = swap;
                
                fixHeap(largest); // call the method again
            }
        }

        /// <summary>
        /// Insert - inserts an item into the heap and keeps the max heap format
        /// </summary>
        ///
        public void Insert(int item)
        {
            h[size + 1] = item;
            size++; //insert the item and increase the size by 1

            int fixsize = size;
            do
            {
                if (size == 1)
                {
                    break; //if the size is 1, then we dont have to execute this loop
                }
                int currentNode = fixsize; //index of the current node we are at
                int parentNode = fixsize / 2; //index of the current node's parent node
                fixsize /= 2;
                int temp; //temp variable for holding a string to swap with another

                if (h[parentNode] < h[currentNode]) //place the new string in the correct spot
                {
                    temp = h[parentNode];
                    h[parentNode] = h[currentNode];
                    h[currentNode] = temp;//swap
                }
                else
                {
                    break;
                }
            } while (fixsize != 1);
        }

        /// <summary>
        /// Sort - calls extract until the size is 0, heap should be sorted at this point
        /// </summary>
        ///
        public void Sort()
        {
            for (int x = 0; x < max_size; x++)
            {
                Extract();
            }

            return;
        }

        /// <summary>
        /// Print - returns a string containing the heap contents
        /// </summary>
        ///
        public string print()
        {
            string output = ""; //string formatted for output
            for (int i = 0; i < size; i++)
            {
                output += h[i + 1] + " "; //fill with items in heap
            }
            return output;//return the formatted string
        }

        /// <summary>
        /// PrintArray - returns a string containing the sorted array from the heap
        /// </summary>
        ///
        public string printArray()
        {
            string output = ""; //string formatted for output
            for (int i = 1; i <= max_size; i++)
            {
                if (i == max_size)
                {
                    output += h[i]; //end with no new line
                }
                else
                {
                    output += h[i] + "\n"; //fill with items in heap
                }

            }
            return output;//return the formatted string
        }
    }
}