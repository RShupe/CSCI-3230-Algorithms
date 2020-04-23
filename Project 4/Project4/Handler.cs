using System;
using System.IO;
using System.Linq;

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
        public string fileName;
    }

    internal class Handler
    {
        public int totalNumFiles;
        private Heap Heap1;
        private Heap Heap2;
        private MergeFile[] files;

        public string MergeFiles(int numFilesAtATime, int numLinesinFile)
        {
            string output = "";
            int currentFileNum = 1;
            int currentNumberLine = 0;
            int filesLeft = totalNumFiles;

            Heap2 = new Heap(totalNumFiles * numLinesinFile);
            while (currentFileNum <= totalNumFiles)
            {
                if (numFilesAtATime > filesLeft)
                {
                    currentNumberLine = 0;
                    files = new MergeFile[filesLeft];
                    for (int j = 0; j < filesLeft; j++)
                    {
                        numFilesAtATime = filesLeft;
                        files[j].fileName = (System.IO.Directory.GetCurrentDirectory() + "\\" + (currentFileNum) + ".txt".ToString());
                        files[j].currentNum = Convert.ToInt32(File.ReadLines(files[j].fileName).Skip(0).First());
                        currentFileNum++;
                        //filesLeft--;
                    }
                }
                else
                {
                    currentNumberLine = 0;
                    files = new MergeFile[numFilesAtATime];
                    for (int j = 0; j < numFilesAtATime; j++)
                    {
                        files[j].fileName = (System.IO.Directory.GetCurrentDirectory() + "\\" + (currentFileNum) + ".txt".ToString());
                        files[j].currentNum = Convert.ToInt32(File.ReadLines(files[j].fileName).Skip(0).First());
                        filesLeft--;
                        currentFileNum++;
                    }
                }

                for (int i = 0; i < numLinesinFile; i++)
                {
                    for (int j = 0; j < numFilesAtATime; j++)
                    {
                        try
                        {
                            files[j].currentNum = Convert.ToInt32(File.ReadLines(files[j].fileName).Skip(currentNumberLine).First());
                            Heap2.Insert(files[j].currentNum);
                        }
                        catch
                        {
                            break;
                        }
                    }
                    currentNumberLine++;
                }
            }
            int temp2 = Heap2.size;
            Heap2.max_size = Heap2.size;
            Heap2.Sort();

            for(int i = 1; i < 10; i++)
            {
                try
                {
                    if (Heap2.h[i] > Heap2.h[i + 1])
                    {
                        int temp = Heap2.h[i];
                        Heap2.h[i] = Heap2.h[i + 1];
                        Heap2.h[i + 1] = temp;
                    }
                }
                catch
                {

                }

            }

            WriteToBin(Heap2, temp2);

            return output = Heap2.printArray();
        }

        public void WriteToBin(Heap heap, int temp2)
        {
            using (BinaryWriter binWriter =
                   new BinaryWriter(File.Open(System.IO.Directory.GetCurrentDirectory() + "\\" + "output.bin", FileMode.Create)))
            {
                for (int i = 1; i <= temp2; i++)
                {
                    binWriter.Write(heap.h[i]);
                }
                binWriter.Flush();
                binWriter.Close();
            }

        }

        public void DeleteTempFiles()
        {
            string path;
            for (int i = 0; i <= totalNumFiles; i++)
            {
                path = System.IO.Directory.GetCurrentDirectory() + "\\" + i + ".txt";
                File.Delete(path);
            }
        }

        public int ProcessBinaryFile(string binaryFileName, int size, int fileNum)
        {
            Heap last;
            Heap1 = new Heap(size);
            using (FileStream fs2 = new FileStream(binaryFileName, FileMode.Open))
            {
                using (BinaryReader r = new BinaryReader(fs2))
                {
                    int index = 1;
                    int newMax = Heap1.max_size;
                    while (r.BaseStream.Position != r.BaseStream.Length)
                    {
                        if (index <= newMax)
                        {
                            Heap1.Insert(r.ReadInt32());
                            index++;
                        }
                        else
                        {
                            Heap1.Sort();
                            fileNum++;
                            PrintHeapToFile(fileNum);
                            newMax = Heap1.max_size + index - 1;
                            Heap1 = new Heap(size);
                        }
                    }
                }

                try
                {
                    Heap1.Sort();
                    fileNum++;
                    PrintHeapToFile(fileNum);
                }
                catch
                {
                    last = new Heap(fileNum);

                    for (int i = 1; i <= fileNum; i++)
                    {
                        last.Insert(Heap1.h[i]);
                    }

                    last.Sort();
                    fileNum++;
                    File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "\\" + (fileNum) + ".txt", last.printArray());
                }

                this.totalNumFiles = fileNum;
                return fileNum;
            }
        } // ProcessBinaryFile()

        public void PrintHeapToFile(int fileNum)
        {
            File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "\\" + (fileNum) + ".txt", Heap1.printArray());
        }
    } // class binhandler
}