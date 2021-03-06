﻿using System;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         ObjectHeap.cs
//	Description:       Heap for Merge files sort via the current number in the node.
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University.
//	Created:           Friday, Apr 24 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Project4
{
    internal class ObjectHeap
    {
        public int max_size;           //max size of heap, this is included just to explain that size is not maximum size, but is current heap size.
        public int size;               //size of current heap
        public MergeFile[] h;          //array of mergefiles that the heap will use

        /// <summary>
        /// MaxHeap - No arg constructor
        /// </summary>
        ///
        public ObjectHeap()
        {// no arg constructor
        }

        /// <summary>
        /// MaxHeap - constructor that accepts a max-size
        /// </summary>
        ///
        public ObjectHeap(int inSize)
        {
            size = 0;
            max_size = inSize;
            h = new MergeFile[max_size + 1]; //create the array of mergefiles
        }

        /// <summary>
        /// extract - this method takes the root node and swaps it with the last node, decreasing the size
        /// </summary>
        ///
        public MergeFile Extract()
        {
            if (size == 0)
            {
                throw new Exception("The heap is empty."); // if the heap is empty throw an exception
            }

            MergeFile output;   //variable to hold the output node to send back to the handler
            MergeFile lastItem; //variable to hold the last item in the array
            MergeFile root = h[1]; //the main root node string

            output = root; //make the output node the root node to send back to the hander.

            lastItem = h[size]; //string of the last item in the heap
            h[1] = lastItem;

            h[size] = root; //remove the first item and place in the last spot

            size--;

            fixHeap(1); //we need to fix the heap starting with the root node

            return output; //return the extracted node
        }

        /// <summary>
        /// fixHeap - this method fixed the heap so it retains the max heap structure
        /// </summary>
        ///
        public void fixHeap(int i)
        {
            int smallest = i; //current smallest int found
            int l = 2 * i; //get index of the left child
            int r = 2 * i + 1; //get index of the right child

            if (l <= size && (h[l].currentNum < h[smallest].currentNum))//checks to see if the left child is larger than the parent
                smallest = l;

            if (r <= size && (h[r].currentNum < h[smallest].currentNum)) //checks to see if the right child is larger than the parent
                smallest = r;

            if (smallest != i) //if a new largest is found we need to swap them
            {
                MergeFile swap = h[i]; //string to hold for swapping two strings
                h[i] = h[smallest];
                h[smallest] = swap;

                fixHeap(smallest); // call the method again
            }
        }

        /// <summary>
        /// Insert - inserts an item into the heap and keeps the max heap format
        /// </summary>
        ///
        public void Insert(MergeFile item)
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
                MergeFile temp; //temp variable for holding a node to swap with another

                if (h[parentNode].currentNum > h[currentNode].currentNum) //place the new string in the correct spot
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
    }
}