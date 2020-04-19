using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace homework1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

	    // Choose, open and process the text file
        private void OpenTextFileBtn_Click(object sender, EventArgs e)
        {
            string fileName = "";
            biorecord brec = new biorecord();

            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (DialogResult.Cancel != OpenDlg.ShowDialog())
            {
                fileName = OpenDlg.FileName;
                brec.ProcessTextFile(fileName);
            }
        }

	    // Choose, open, and process the binary file
        private void OpenBinaryFileBtn_Click(object sender, EventArgs e)
        {
            string fileName = "";
            biorecord brec = new biorecord();
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (DialogResult.Cancel != OpenDlg.ShowDialog())
            {
                fileName = OpenDlg.FileName;
                brec.ProcessBinaryFile(fileName);
            }
        }
    }
}
