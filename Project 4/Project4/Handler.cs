using System;
using System.IO;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Handler.cs
//	Description:       This handles all of the processing involving reading from files and heaps
//                                (CONTAINS MANY HOURS OF PAIN AND SUFFERING)
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
        public int buffer;        //the current line number in the file
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

        private BinaryReader[] readers; //array of readers that have the current files being sorted open at all times until empty to drastically reduce running time

        /// <summary>
        /// MergeFiles - this method combines the files merging K files at a file until getting the result
        /// </summary>
        /// <param name="=numFilesAtATime">< /param>
        /// <param name="=numLinesinFile">< /param>
        public void MergeFiles(int MaxFilesToMergeAtATime, int numLinesinFile)
        {
            int TotalNumFilesFromPrevLevel = totalNumFiles; //intially set the number of files from the prev level to the total of files generated at lvl 1
            int NumFilesBuiltThisLevel;                     //declare variable for the number of files built on the current level
            int NumFilesRemainingToProcThisLevel;           //variable to hold th enumber of files left on the level to generate
            int NumFilesToMergeThisTime;                    //current number of files to merge at a time
            int sortFileNumber = 1;                         //set the output sort file to be number 1 in the level
           
            while (TotalNumFilesFromPrevLevel > 1) //while the number of files from the previous level is greater than 1
            {
                NumFilesBuiltThisLevel = 0;     //reset the number of files built in current level
                NumFilesRemainingToProcThisLevel = TotalNumFilesFromPrevLevel; //update the total files remaining
                currentFile = 1;                //the current file we are at in the level is 1

                while (NumFilesRemainingToProcThisLevel > 0) //while we still have files to process at this level
                {
                    if (NumFilesRemainingToProcThisLevel > MaxFilesToMergeAtATime) //if we can merge K files at a time
                    {
                        NumFilesToMergeThisTime = MaxFilesToMergeAtATime;   //tell the function we can merge K at a time
                    }
                    else
                    {
                        NumFilesToMergeThisTime = NumFilesRemainingToProcThisLevel; //if we have less than K files left, then set the number of merge at a time to the remainding number of files.
                    }

                    if (NumFilesRemainingToProcThisLevel == 1) //if we have 1 file remaining on this level we can bring it down and rename it
                    {
                        // rename the file to current level naming scheme - no need to waste processing time 

                        File.Move(System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (CurrentLevel) + "-" + currentFile + ".bin",
                            System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (CurrentLevel + 1) + "-" + sortFileNumber + ".bin");

                        NumFilesBuiltThisLevel += 1; //increase the number of files built in the level
                    }
                    else //while we can merge > 1 files
                    {
                        readers = new BinaryReader[NumFilesToMergeThisTime]; //set the number of readers to be the number of files we are merging
                        files = new MergeFile[NumFilesToMergeThisTime];      //set the number of files to be the number of files we are merging
                        sortHeap = new ObjectHeap(NumFilesToMergeThisTime);  //set the heap size to be the number of files we are merging


                        for (int i = 0; i < NumFilesToMergeThisTime; i++)    //while we are merging K files
                        {
                            files[i].fileName = System.IO.Directory.GetCurrentDirectory() + "\\~" + CurrentLevel + "-" + (currentFile) + ".bin"; // load the file name into the first file

                            using (FileStream sr = File.OpenRead(files[i].fileName))
                            {
                                using (BinaryReader reader = new BinaryReader(sr)) //read in a binary integer
                                {
                                    files[i].buffer = 0; //set the initial position in the open file to 0, to get the first number
                                    sr.Seek(files[i].buffer, SeekOrigin.Begin); //start reading at the buffer position

                                    files[i].currentNum = reader.ReadInt32(); //first number from the open file stored into the current file
                                }
                                sr.Close(); //close the file current stream
                            }

                            readers[i] = new BinaryReader(File.Open(files[i].fileName, FileMode.Open)); //open the currently loaded files for fast access

                            currentFile++; //increment the current file we are on
                        }

                        NumFilesBuiltThisLevel++; //increase the number of files built in this level of sorting

                        for (int i = 0; i < files.Length; i++)
                        {
                            sortHeap.Insert(files[i]); //insert 1st nums in the heap
                        }

                        using (FileStream fs2 = new FileStream(System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (
                        CurrentLevel + 1) + "-" + (sortFileNumber) + ".bin", FileMode.Create)) //open and create the binary file
                        {
                            using (BinaryWriter r = new BinaryWriter(fs2))
                            {
                                for (int i = 0; i < numLinesinFile * totalNumFiles; i++) //at most this loop will execute the total number of numbers times.
                                {
                                    MergeFile extractedNode; //variable to hold an extracted node
                                    try
                                    {
                                        extractedNode = sortHeap.Extract(); //extract the node on the top which should be the smallest number

                                        r.Write(extractedNode.currentNum);  //write the number to the file

                                        for (int j = 0; j < files.Length; j++) //find which file was just extracted
                                        {
                                            if (files[j].fileName == extractedNode.fileName) //if the file name of the extracted node matches with a loaded file
                                            {
                                                try
                                                {
                                                    files[j].buffer += 4; //increment to next int in the file
                                                    
                                                    readers[j].BaseStream.Seek(files[j].buffer, SeekOrigin.Begin); //start reading at the new int position

                                                    byte[] temp = (readers[j].ReadBytes(4)); //read in 4 bytes
                                                    int number = BitConverter.ToInt32(temp, 0); //convert the 4 bytes into an integer that we can use to compare

                                                    files[j].currentNum = number; //store the new number from the file into the files array

                                                    sortHeap.Insert(files[j]); //insert the new node into the heap
                                                }
                                                catch //if an exception is thrown that means we are at the end of the file.
                                                {
                                                    Console.WriteLine("Reached End of file");   //debug msg
                                                    readers[j].Close(); //close the opened reader
                                                    File.Delete(files[j].fileName); //delete the file we just reached the end of
                                                    
                                                }
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        break; //if exception is thrown the heap is empty
                                    }
                                }
                            }
                        }

                        sortFileNumber++; //increment to the next output sort file number
                    }

                    NumFilesRemainingToProcThisLevel -= MaxFilesToMergeAtATime; //get the remaining number of files to calculate on this level
                    if (NumFilesRemainingToProcThisLevel < 0) //if th enumber is less than zero
                    {
                        readers[0].Close(); //close the first reader
                        break; //end the loop
                        
                    }
                }

                CurrentLevel += 1;//increment to the next level
                currentFile = 1; //reset the current file number to 1
                sortFileNumber = 1; //reset the output sort number to 1
                TotalNumFilesFromPrevLevel = NumFilesBuiltThisLevel; //update the total files from previous level from the ones that were built this level
            }

            for(int i = 0; i < readers.Length; i++)
            {
                readers[i].Close(); //close all of the remaining open readers.
            }

            File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\result.bin"); //delete the result.bin that currently exists if their is one
            File.Move(System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (CurrentLevel) + "-" + (sortFileNumber) + ".bin",
                System.IO.Directory.GetCurrentDirectory() + "\\result.bin"); //rename the last file generated to the result file.

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
                            //Heap1.Sort(); //sort the heap
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
                                       // Heap1.Sort(); //sort the heap
                    fileNum++;

                    PrintHeapToFile(CurrentLevel, fileNum, Heap1); //print the heap to a file
                    Heap1 = new Heap(size); //reset the heap
                }
                catch
                {
                    last = new Heap(temp); //allocate space big enough for the last few numbers

                    for (int i = 1; i <= temp; i++)
                    {
                        last.Insert(Heap1.h[i]); //insert the extra numbers in this new heap
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
            using (FileStream fs2 = new FileStream(System.IO.Directory.GetCurrentDirectory() + "\\" + "~" + (level) + "-" + (fileNum) + ".bin",
                                                    FileMode.Create)) //open and create the binary file
            {
                using (BinaryWriter r = new BinaryWriter(fs2))
                {
                    while (heap.size != 0)
                    {
                        r.Write(heap.Extract()); //while the heap has integers in it, extract and write the smallest number.
                    }
                }
                //fs2.Flush();
                // fs2.Close();
            }
        }
    } // class handler
}