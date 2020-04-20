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


       
        public int ProcessBinaryFile(string binaryFileName, int size, int fileNum)
        {
            heap = new MaxHeap(size);
            using (FileStream fs2 = new FileStream(binaryFileName, FileMode.Open))
            {
                using (BinaryReader r = new BinaryReader(fs2))
                {
                    int index = 1;
                    int newMax = heap.max_size;
                    while (r.BaseStream.Position != r.BaseStream.Length)
                    {
                        if (index <= newMax)
                        {
                            heap.Insert(r.ReadInt32());
                            index++;
                        }
                        else
                        {
                            heap.Sort();
                            fileNum++;
                            PrintHeapToFile(fileNum);
                            newMax = heap.max_size + index -1;
                            heap = new MaxHeap(size);
                        }
                    }
                    heap.Sort();
                    fileNum++;
                    PrintHeapToFile(fileNum);
                    return fileNum;
                }
            }

            
            
        } // ProcessBinaryFile()

        public void PrintHeapToFile(int fileNum)
        {
            File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "\\" + (fileNum) + ".txt", heap.printArray());
        }

    } // class binhandler
}
