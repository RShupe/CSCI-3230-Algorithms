using System;
using System.IO;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Handler.cs
//	Description:       This handles all of the processing involving reading from files and heaps
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University.
//	Created:           Wednesday, Apr 22 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Project4
{
    internal struct MergeFile
    {
        public int currentNum;
        public String fileName;
    }

    internal class Handler
    {
        public int numberOfFiles;
        private MaxHeap maxHeap;
        private MinHeap minHeap;

        public void MergeFiles(int numFilesAtATime)
        {
            int currentFileNum = 0;
            for (int i = 0; i < numberOfFiles; i++)
            {
                for (int j = 0; j < numFilesAtATime; j++)
                {
                }
            }
        }

        public int ProcessBinaryFile(string binaryFileName, int size, int fileNum)
        {
            MaxHeap last;
            maxHeap = new MaxHeap(size);
            using (FileStream fs2 = new FileStream(binaryFileName, FileMode.Open))
            {
                using (BinaryReader r = new BinaryReader(fs2))
                {
                    int index = 1;
                    int newMax = maxHeap.max_size;
                    while (r.BaseStream.Position != r.BaseStream.Length)
                    {
                        if (index <= newMax)
                        {
                            maxHeap.Insert(r.ReadInt32());
                            index++;
                        }
                        else
                        {
                            maxHeap.Sort();
                            fileNum++;
                            PrintHeapToFile(fileNum);
                            newMax = maxHeap.max_size + index - 1;
                            maxHeap = new MaxHeap(size);
                        }
                    }
                }

                try
                {
                    maxHeap.Sort();
                    fileNum++;
                    PrintHeapToFile(fileNum);
                }
                catch
                {
                    last = new MaxHeap(fileNum);

                    for (int i = 1; i <= fileNum; i++)
                    {
                        last.Insert(maxHeap.h[i]);
                    }

                    last.Sort();
                    fileNum++;
                    File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "\\" + (fileNum) + ".txt", last.printArray());
                }

                this.numberOfFiles = fileNum;
                return fileNum;
            }
        } // ProcessBinaryFile()

        public void PrintHeapToFile(int fileNum)
        {
            File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "\\" + (fileNum) + ".txt", maxHeap.printArray());
        }
    } // class binhandler
}