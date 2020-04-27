using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Form1.cs
//	Description:       This is where the user spends all of their time. This file  interacts with the hander to read
//                       in a binary file, and sorts it with
//                       a given heap size and sort k files at a time
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University.
//	Created:           Friday Apr 24, 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Project4
{
    public partial class frm_Main : Form
    {
        private Handler handler = new Handler(); //initialize the hander object
        private int fileNum = 0;                 // the number of files generated
        private bool fileLoaded = false;         // flag that is set if a file is loaded into the system or not
        private int size;                        // int to store the heap size.

        /// <summary>
        /// frm_Main - Constructor for the form
        /// </summary>
        ///
        public frm_Main()
        {
            InitializeComponent(); //initialize the frame
        }

        /// <summary>
        /// binBtn_Click - this executes when the user clicks the load bin file button
        /// </summary>
        /// <param name="=sender">< /param>
        /// <param name="=e">< /param>
        private void binBtn_Click(object sender, EventArgs e)
        {
            handler.DeleteTempFiles(); //make sure all temp files are deleted before doing a calculation
            outputBox.Items.Clear();
            errorLabel.Text = "";
            lblTime.Text = "Seconds: "; //clear out the time label

            size = Convert.ToInt32(sizebox.Value); //get the heap size to split the files.
            OpenFileDialog OpenDlg = new OpenFileDialog(); //new dialog box so the user can select a file
            string fileName = "";

            if (DialogResult.Cancel != OpenDlg.ShowDialog()) //if the user selects a file
            {
                fileName = OpenDlg.FileName; // string to hold the file name
                fileLoaded = true; //set the loaded flag so the user can continue using the program
            }

            if (fileLoaded == false)
            {
                errorLabel.Text = "Error! No file loaded!"; // if no file is loaded display error
            }
            else
            {
                Stopwatch time = new Stopwatch(); //stopwatch to record the time
                errorLabel.Text = ""; // no error - clear label
                int numSortFiles = Convert.ToInt32(numberofFilesBox.Value); //get the number of files generated

                if (chkDisplay.Checked) //check to see if the user wants to display the result or not
                {
                    time.Start(); //start timer

                    handler.ProcessBinaryFile(fileName, size, fileNum); //call the handler to process the binary file

                    handler.MergeFiles(Convert.ToInt32(numberofFilesBox.Value), Convert.ToInt32(sizebox.Value)); //merge files
                    time.Stop();

                    using (FileStream fs2 = new FileStream(System.IO.Directory.GetCurrentDirectory() + "\\result.bin", FileMode.Open)) //open the binary file
                    {
                        using (BinaryReader r = new BinaryReader(fs2))
                        {
                            while (r.BaseStream.Position != r.BaseStream.Length) //while they're are lines left to read
                            {
                                outputBox.Items.Add(r.ReadInt32()); //add the items from the result file to the list
                            }
                        }
                    }

                    // displayBox.Text = File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "\\result.txt"); //update the textbox to read from the output file
                    lblTime.Text = "Seconds: " + time.Elapsed.TotalMilliseconds / 1000; //display time
                }
                else
                {
                    outputBox.Items.Clear();

                    time.Start();
                    handler.ProcessBinaryFile(fileName, size, fileNum); //call the handler to process the binary file
                    handler.MergeFiles(numSortFiles, size); //merge files
                    time.Stop();

                    lblTime.Text = "Seconds: " + time.Elapsed.TotalMilliseconds / 1000; //display time
                }
                errorLabel.Text = "Saved as result.bin!";
            }
            }

        /// <summary>
        /// frm_Main_FormClosing - this makes sure all temp files are deleted when the user closes the program
        /// </summary>
        /// <param name="=sender">< /param>
        /// <param name="=e">< /param>
        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            handler.DeleteTempFiles(); //delete any extra files that might not havegotten deleted
        }

        /// <summary>
        /// sizebox_ValueChanged - If the user changes this, the data in the box wont be acurate, so delete the text
        /// </summary>
        /// <param name="=sender">< /param>
        /// <param name="=e">< /param>
        private void Sizebox_ValueChanged(object sender, EventArgs e)
        {
            outputBox.Items.Clear();
            errorLabel.Text = "";
        }

        /// <summary>
        /// numberofFilesBox_ValueChanged - If the user changes this, the data in the box wont be acurate, so delete the text
        /// </summary>
        /// <param name="=sender">< /param>
        /// <param name="=e">< /param>
        private void NumberofFilesBox_ValueChanged(object sender, EventArgs e)
        {
            outputBox.Items.Clear();
            errorLabel.Text = "";
        }
    }
}