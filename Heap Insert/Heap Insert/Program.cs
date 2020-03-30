using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Insert
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of Strings you wish to store in the heap: ");
            int strings = Convert.ToInt32(Console.ReadLine());
            MaxHeap heap = new MaxHeap(strings);

            for (int i = 0; i < strings; i++)
            {
                heap.Insert(Console.ReadLine());
            }

            heap.Sort();
            Console.WriteLine(heap.printArray());
            Console.ReadLine();
        }
    }
}