using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4
{
    public partial class frm_Main : Form
    {
        Handler handler = new Handler();
        int fileNum = 0;
        bool fileLoaded = false;
        int size;
        List<string> fileNames = new List<String>();
        public frm_Main()
        {
            InitializeComponent();
        }

        private void binBtn_Click(object sender, EventArgs e)
        {
            handler.DeleteTempFiles();
            displayBox.Text = "";
            errorLabel.Text = "";
             size = Convert.ToInt32(sizebox.Value);
            string fileName = "";
            
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (DialogResult.Cancel != OpenDlg.ShowDialog())
            {
                fileName = OpenDlg.FileName;
                lblNumFilesGenerated.Text = ((handler.ProcessBinaryFile(fileName, size, fileNum)).ToString());
                numberofFilesBox.Value = Convert.ToInt32(lblNumFilesGenerated.Text);
                fileLoaded = true;
                countlbl.Text = "File is loaded!";
            }
            
        }

        private void btn_Merge_Click(object sender, EventArgs e)
        {
            if(fileLoaded == false)
            {
                errorLabel.Text = "Error! No file loaded!";
            }
            else
            {
                Stopwatch time = new Stopwatch();
                errorLabel.Text = "";
                int numSortFiles = Convert.ToInt32(numberofFilesBox.Value);


                if (chkDisplay.Checked)
                {
                    time.Start();
                    displayBox.Text = handler.MergeFiles(numSortFiles, size);
                    time.Stop();

                    lblTime.Text = "Seconds: " + time.Elapsed.TotalMilliseconds / 1000;

                }
                else
                {
                    time.Start();
                    handler.MergeFiles(numSortFiles, size);
                    time.Stop();

                    lblTime.Text = "Seconds: " + time.Elapsed.TotalMilliseconds / 1000;
                }
                errorLabel.Text = "Saved as output.bin!";


            }
            
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            handler.DeleteTempFiles();
        }

        private void sizebox_ValueChanged(object sender, EventArgs e)
        {
            displayBox.Text = "";
            errorLabel.Text = "";
        }

        private void numberofFilesBox_ValueChanged(object sender, EventArgs e)
        {
            displayBox.Text = "";
            errorLabel.Text = "";
        }
    }
}
