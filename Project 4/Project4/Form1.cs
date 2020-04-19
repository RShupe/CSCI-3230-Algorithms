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
    public partial class Form1 : Form
    {
        int fileNum = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void binBtn_Click(object sender, EventArgs e)
        {
            
            int size = Convert.ToInt32(sizebox.Value);
            string fileName = "";
            Handler handler = new Handler();
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (DialogResult.Cancel != OpenDlg.ShowDialog())
            {
                fileName = OpenDlg.FileName;
                handler.ProcessBinaryFile(fileName, size, fileNum);
                
            }
            fileNum++;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path;
            for(int i = 0; i < fileNum; i++)
            {
                path = System.IO.Directory.GetCurrentDirectory() + "\\temp" + i + ".txt";
                File.Delete(path);
            }
        }
    }
}
