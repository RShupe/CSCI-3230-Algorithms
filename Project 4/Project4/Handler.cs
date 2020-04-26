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
        private int CurrentLevel = 1;   //the current level we are at
        private int currentFile = 1;    //the current file number we are at

        private ObjectHeap sortHeap;    //heap that is compatible for mergiles
        private Heap Heap1;             //heap to hold the inital numbers when the file was being broken down
        private MergeFile[] files;      //array of mergefiles so we can keep track of the currently selected files

        /// <summary>
        /// MergeFiles - this method combines the files merging K files at a file until getting the result
        /// </summary>
        /// <param name="=numFilesAtATime">< /param>
        /// <param name="=numLinesinFile">< /param>
        public void MergeFiles(int MaxFilesToMergeAtATime, int numLinesinFile)
        {
            int TotalNumFilesFromPrevLevel = totalNumFiles;
            int NumFilesBuiltThisLevel;
            int NumFilesRemainingToProcThisLevel;
            int NumFilesToMergeThisTime;
            int sortFileNumber = 1;
            

            while (TotalNumFilesFromPrevLevel > 1) 
            {
                NumFilesBuiltThisLevel = 0;
                NumFilesRemainingToProcThisLevel = TotalNumFilesFromPrevLevel;
                currentFile = 1;

                while (NumFilesRemainingToProcThisLevel > 0)
                {
                    if(NumFilesRemainingToProcThisLevel > MaxFilesToMergeAtATime)
                    {
                        NumFilesToMergeThisTime = MaxFilesToMergeAtATime; 
                    }
                    else 
                    { 
                        NumFilesToMergeThisTime = NumFilesRemainingToProcThisLevel; 
                    }

                    if(NumFilesRemainingToProcThisLevel == 1) 
                    {
                        /* rename the file to current level naming scheme - no need to waste processing time */

                        File.Move(System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (CurrentLevel) + "-" + currentFile + ".txt",
                            System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (CurrentLevel+1) + "-" + sortFileNumber + ".txt");
                        NumFilesBuiltThisLevel += 1;
                    }
                    else
                    {
                        /* merge NumFilesToMergeThisTime */
                        files = new MergeFile[NumFilesToMergeThisTime];
                        sortHeap = new ObjectHeap(NumFilesToMergeThisTime);

                        for (int i = 0; i < NumFilesToMergeThisTime; i++)
                        {
                            files[i].fileName = System.IO.Directory.GetCurrentDirectory() + "\\~" + CurrentLevel + "-" + (currentFile) + ".txt";
                            files[i].lineNum = 0;
                            files[i].currentNum = Convert.ToInt32(File.ReadLines(files[i].fileName).Skip(0).First()); //first line
                            currentFile++;
                        }

                        NumFilesBuiltThisLevel ++;

                    }
                    
                    NumFilesRemainingToProcThisLevel -= MaxFilesToMergeAtATime;

                    for (int i = 0; i < files.Length; i++)
                    {
                        sortHeap.Insert(files[i]); //insert 1st nums in the heap
                    }

                    using (StreamWriter sw = File.AppendText(System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (
                        CurrentLevel + 1) + "-" + (sortFileNumber) + ".txt"))
                    {
                        for (int i = 0; i < numLinesinFile * totalNumFiles; i++)
                        {
                            MergeFile extractedNode;
                            try
                            {
                                extractedNode = sortHeap.Extract();

                                sw.WriteLine(extractedNode.currentNum);

                                for (int j = 0; j < files.Length; j++)
                                {
                                    if (files[j].fileName == extractedNode.fileName)
                                    {
                                        try
                                        {
                                            files[j].lineNum += 1;
                                            files[j].currentNum = Convert.ToInt32(File.ReadLines(files[j].fileName).Skip(files[j].lineNum).First());

                                            sortHeap.Insert(files[j]);
                                        }
                                        catch
                                        {
                                            //sortHeap.fixHeap(1);
                                            Console.WriteLine("Reached End of file");
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }
                    }

                    sortFileNumber++;
                }
                CurrentLevel += 1;
                currentFile = 1;
                sortFileNumber = 1;
                TotalNumFilesFromPrevLevel = NumFilesBuiltThisLevel;
            }

            File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\result.txt");
            File.Move(System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (CurrentLevel) + "-" + (sortFileNumber) + ".txt", System.IO.Directory.GetCurrentDirectory() + "\\result.txt");
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
            CurrentLevel = 1;       // we are currently at level 1
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

                            PrintHeapToFile(CurrentLevel, fileNum, Heap1); //print the heap to a file
                            newMax = Heap1.max_size + index - 1; //increase the max size to keep track of what numbers we are reading in
                            Heap1 = new Heap(size); //reset the heap
                        }
                    }
                }

                try
                {
                    Heap1.fixHeap(1);
                    temp = Heap1.size; //make a temp variable with the current heap size
                    Heap1.Sort(); //sort the heap
                    fileNum++;

                    PrintHeapToFile(CurrentLevel, fileNum, Heap1); //print the heap to a file
                    Heap1 = new Heap(size); //reset the heap
                }
                catch
                {
                    last = new Heap(temp); //allocate space big enough for the last few numbers

                    if (Heap1.h[0] > Heap1.h[1])
                    {
                        int temp2 = Heap1.h[0];
                        Heap1.h[0] = Heap1.h[1];
                        Heap1.h[1] = temp2;
                    }
                    for (int i = 1; i <= temp; i++)
                    {
                        last.Insert(Heap1.h[i]); //insert the extra numbers in this new heap
                    }

                    last.Sort(); //sort
                    if (last.h[0] > last.h[1])
                    {
                        int temp2 = last.h[0];
                        last.h[0] = last.h[1];
                        last.h[1] = temp2;
                    }
                    fileNum++;
                    PrintHeapToFile(CurrentLevel, fileNum, last); //output the remaining numbers to a file
                    Heap1 = new Heap(size); //reset the heap
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