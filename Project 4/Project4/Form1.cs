using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        List<string> fileNames = new List<String>();
        public frm_Main()
        {
            InitializeComponent();
        }

        private void binBtn_Click(object sender, EventArgs e)
        {
            
            int size = Convert.ToInt32(sizebox.Value);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            int numOfFiles = Convert.ToInt32(numberofFilesBox.Value);
            string path;
            for(int i = 0; i <= numOfFiles; i++)
            {
                path = System.IO.Directory.GetCurrentDirectory() + "\\" + i + ".txt";
                File.Delete(path);
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
                errorLabel.Text = "";
                int numSortFiles = Convert.ToInt32(numberofFilesBox.Value);
                handler.MergeFiles(numSortFiles);

                if (chkDisplay.Checked)
                {
                    displayBox.Text = "insert output file text here";
                }
 
            }
            
        }
    }
}
