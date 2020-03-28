using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Insert
{
    internal class MaxHeap
    {
        private int max_size;           //max size of heap, this is included just to explain that size is not maximum size, but is current heap size.
        private int size;               //size of current heap
        private string[] h;             //array of strings that the heap will use

        public MaxHeap()
        {
        }

        public MaxHeap(int inSize)
        {
            size = 0;
            max_size = inSize;
            h = new string[max_size + 1];
        }

        public void Insert(String item)
        {
            h[size + 1] = item;
            size++;

            int fixsize = size;
            do
            {
                if (size == 1)
                {
                    break;
                }
                int currentNode = fixsize;
                int parentNode = fixsize / 2;
                fixsize /= 2;
                string temp;
                if (String.CompareOrdinal(h[parentNode], h[currentNode]) < 0)
                {
                    temp = h[parentNode];
                    h[parentNode] = h[currentNode];
                    h[currentNode] = temp;
                }
                else
                {
                    break;
                }
            } while (fixsize != 1);
        }

        public string print()
        {
            string output = "";
            for (int i = 0; i < size; i++)
            {
                output += h[i + 1] + " ";
            }
            return output;
        }
    }
}