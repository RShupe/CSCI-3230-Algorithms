using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Project4
{
    // Class biorecord
    // Manages the binary records and file access
    class Handler
    {
        
        MaxHeap heap;

        public void ProcessTextFile(string textFileName)
        {
  
        } // ProcessTextFile()


       
        public void ProcessBinaryFile(string binaryFileName, int size, int fileNum)
        {
            heap = new MaxHeap(size);
            using (FileStream fs2 = new FileStream(binaryFileName, FileMode.Open))
            {
                using (BinaryReader r = new BinaryReader(fs2))
                {
                    int index = 1;
                    while (r.BaseStream.Position != r.BaseStream.Length)
                    {
                        if (index <= heap.max_size)
                        {
                            heap.Insert(r.ReadInt32());
                            index++;
                        }
                        else
                        {
                            break;
                        }
                    }   
                }
            }

            heap.Sort();
            
            PrintHeapToFile(fileNum);
            
        } // ProcessBinaryFile()

        public void PrintHeapToFile(int fileNum)
        {
            File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "\\temp" + (fileNum) + ".txt", heap.printArray());
        }

    } // class binhandler
}
