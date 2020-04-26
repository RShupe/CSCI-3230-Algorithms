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
        public int lineNum;       //the current line number in the file
        public int currentNum;    //the current number selected in the file
        public string fileName;   //string holding the file path
    }

    internal class Handler
    {
        public int totalNumFiles;       //the total number of files
        private int level = 1;          //the current level we are at
        private int currentFile = 1;    //the current file number we are at

        private ObjectHeap sortHeap;    //heap that is compatible for mergiles
        private Heap Heap1;             //heap to hold the inital numbers when the file was being broken down
        private MergeFile[] files;      //array of mergefiles so we can keep track of the currently selected files

        /// <summary>
        /// MergeFiles - this method combines the files merging K files at a file until getting the result
        /// </summary>
        /// <param name="=numFilesAtATime">< /param>
        /// <param name="=numLinesinFile">< /param>
        public void MergeFiles(int numFilesAtATime, int numLinesinFile)
        {
            currentFile = 1;
            int sortFileNumber = 1;



            files = new MergeFile[numFilesAtATime];

            for (int i = 0; i < numFilesAtATime; i++)
            {
                files[i].fileName = System.IO.Directory.GetCurrentDirectory() + "\\~1-" + (currentFile) + ".txt";
                files[i].lineNum = 0;
                files[i].currentNum = Convert.ToInt32(File.ReadLines(files[i].fileName).Skip(0).First()); //first line
                currentFile++;
            }

            sortHeap = new ObjectHeap(numFilesAtATime);

            for (int i = 0; i < numFilesAtATime; i++)
            {
                sortHeap.Insert(files[i]); //insert 1st nums in the heap
            }


            sortHeap.fixHeap(1);
            for (int i = 0; i < numLinesinFile * totalNumFiles * level; i++)
            {
                using (StreamWriter sw = File.AppendText(System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (level + 1) + "-" + (sortFileNumber) + ".txt"))
                {
                    MergeFile extractedNode;
                    try
                    {
                        sortHeap.fixHeap(1);
                        extractedNode = sortHeap.Extract();

                        sw.WriteLine(extractedNode.currentNum);

                        for (int j = 0; j < files.Length; j++)
                        {
                            if (files[j].fileName == extractedNode.fileName)
                            {
                                try
                                {
                                    files[j].lineNum += 1;
                                    files[j].currentNum = Convert.ToInt32(File.ReadLines(files[j].fileName).Skip(files[j].lineNum).First()) ;

                                    sortHeap.Insert(files[j]);
                                }
                                catch
                                {
                                    Console.WriteLine("Reached End of file");
                                }
                            }
                        }
                    }
                    catch
                    {

                    }


                }
            }

            sortFileNumber++;

            //File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\result.txt");
            //File.Move(System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (level+1) + "-" + (sortFileNumber-1) + ".txt", System.IO.Directory.GetCurrentDirectory() + "\\result.txt");
            return;
        }

        /// <summary>
        /// DeleteTempFiles - This method deletes all of the temp files created.
        /// </summary>
        /// <param name="=numFilesAtATime">< /param>
        /// <param name="=numLinesinFile">< /param>
        public void DeleteTempFiles()
        {
            string[] dirs = (Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), "~*")); //all the files in the path starting with ~
            for (int i = 0; i < dirs.Length; i++)
            {
                File.Delete(dirs[i]); //find all of the files in the directory starting with ~ and delete them
            }
        }

        /// <summary>
        /// ProcessBinaryFile - reads in a binary file, outputs multiple split up files from the given heap size.
        /// </summary>
        /// <param name="=binaryFileName">< /param>
        /// <param name="=size">< /param>
        /// <param name="=fileNum">< /param>
        public int ProcessBinaryFile(string binaryFileName, int size, int fileNum)
        {
            level = 1;              // we are currently at level 1
            currentFile = 1;        //start with file 1-1
            int temp = 0;           //allocate a temp variable.
            Heap last;              //make a heap to hold the extra numbers that dont divide up as nice
            Heap1 = new Heap(size); //make aheap the size of the user defined size

            using (FileStream fs2 = new FileStream(binaryFileName, FileMode.Open)) //open the binary file
            {
                using (BinaryReader r = new BinaryReader(fs2))
                {
                    int index = 1; //start at index 1
                    int newMax = Heap1.max_size; // initallize the current max size of the Heap1

                    while (r.BaseStream.Position != r.BaseStream.Length) //while they're are lines left to read
                    {
                        if (index <= newMax) //if we have not hit the max size
                        {
                            Heap1.Insert(r.ReadInt32()); //insert the number at the current index
                            index++; //increment to the next position
                        }
                        else
                        {
                            Heap1.Sort(); //sort the heap
                            fileNum++; //increase the file number
                            /*for (int i = 0; i < 10; i++)
                            {
                                if (Heap1.h[i] > Heap1.h[i + 1])
                                {
                                    int temp2 = Heap1.h[i];
                                    Heap1.h[i] = Heap1.h[i + 1];
                                    Heap1.h[i + 1] = temp2;
                                }
                            }
                            for (int i = 10; i < 0; i--)
                            {
                                if (Heap1.h[i] < Heap1.h[i - 1])
                                {
                                    int temp2 = Heap1.h[i];
                                    Heap1.h[i] = Heap1.h[i - 1];
                                    Heap1.h[i - 1] = temp2;
                                }
                            }*/

                            PrintHeapToFile(level, fileNum, Heap1); //print the heap to a file
                            newMax = Heap1.max_size + index - 1; //increase the max size to keep track of what numbers we are reading in
                            Heap1 = new Heap(size); //reset the heap
                        }
                    }
                }

                try
                {
                    temp = Heap1.size; //make a temp variable with the current heap size
                    Heap1.Sort(); //sort the heap
                    /*
                    for (int i = 0; i < 10; i++)
                    {
                        if (Heap1.h[i] > Heap1.h[i + 1])
                        {
                            int temp2 = Heap1.h[i];
                            Heap1.h[i] = Heap1.h[i + 1];
                            Heap1.h[i + 1] = temp2;
                        }
                    }
                    for (int i = 10; i < 0; i--)
                    {
                        if (Heap1.h[i] < Heap1.h[i - 1])
                        {
                            int temp2 = Heap1.h[i];
                            Heap1.h[i] = Heap1.h[i - 1];
                            Heap1.h[i - 1] = temp2;
                        }
                    }*/
                    fileNum++;
                    PrintHeapToFile(level, fileNum, Heap1); //print the heap to a file
                }
                catch
                {
                    last = new Heap(temp); //allocate space big enough for the last few numbers

                    for (int i = 1; i <= temp; i++)
                    {
                        last.Insert(Heap1.h[i]); //insert the extra numbers in this new heap
                    }

                    last.Sort(); //sort
                    fileNum++;
                    PrintHeapToFile(level, fileNum, last); //output the remaining numbers to a file
                }

                totalNumFiles = fileNum; //record the number of files for later

                return fileNum; //return the total number of files generated
            }
        } // ProcessBinaryFile()

        /// <summary>
        /// PrintHeapToFile - prints the current heap to a file
        /// </summary>
        /// <param name="=level">< /param>
        /// <param name="=fileNum">< /param>
        /// <param name="=heap">< /param>
        public void PrintHeapToFile(int level, int fileNum, Heap heap)
        {
            File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (level) + "-" + (fileNum) + ".txt", heap.printArray()); //print all of the text that the print array method gives back to a file
        }
    } // class handler
}