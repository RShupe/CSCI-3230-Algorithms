using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project_3
{
    public partial class frm_Main : Form
    {
        private List<String[]> entrys = new List<String[]>(); //variable to hold the rsid's that is found in the file
        private static bool fileIn = false;
        public frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            StreamReader rdr = null;
            OpenFileDialog OpenDlg = new OpenFileDialog();

            OpenDlg.Filter = "text files|*.txt;*.text";
            OpenDlg.InitialDirectory = Application.StartupPath;
            OpenDlg.Title = "Select a text file to insert into the list";

            if (DialogResult.Cancel != OpenDlg.ShowDialog())
            {
                try
                {
                    rdr = new StreamReader(OpenDlg.FileName);

                    for (int i = 0; i < 17; i++)
                    {
                        rdr.ReadLine();
                    }

                    while (!rdr.EndOfStream)
                    {
                        String sep = "\t";
                        String[] ent = new String[5];

                        ent = rdr.ReadLine().Split(sep.ToCharArray());
                        entrys.Add(ent);
                    }
                }
                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                        fileIn = true;
                        label_file.Text = "File is Loaded!";
                    }
                }

                string fileName = OpenDlg.FileName;
            }
        }

        private void btn_Popular_Click(object sender, EventArgs e)
        {
            if (fileIn)
            {
                outputBox.Items.Clear();

                for(int i = 0; i < entrys.Count; i++)
                {
                    String output = "";
                    String[] currentEntry = new String[5];

                    currentEntry = entrys[i];

                    //this is where all of the popular items are kept (it works its just really slow)
                    if(currentEntry[0] == "rs53576")
                    {
                        output += "RS53576\t\t";
                        output += "Description: influences social behavior and personality\t";

                        if (((currentEntry[3] == "A") && (currentEntry[4] == "A")) || ((currentEntry[3] == "A") && (currentEntry[4] == "G")))
                        {
                            output += "Magnitude: 2.8\t";
                            output += "Lack of empathy?";
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "G")))
                        {
                            output += "Magnitude: 2.5\t";
                            output += "Optimistic and empathetic; handle stress well";
                        }
                    }

                    if (currentEntry[0] == "rs1815739")
                    {
                        output += "RS1815739\t\t";
                        output += "Description: muscle performance\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C")) 
                        {
                            output += "Magnitude: 2.2\t";
                            output += "Better performing muscles. Likely sprinter.";
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Magnitude: 2.2\t";
                            output += "Impaired muscle performance. Likely endurance athlete.";
                        }
                        else if (((currentEntry[3] == "C") && (currentEntry[4] == "T")))
                        {
                            output += "Magnitude: 2.1\t";
                            output += "Mix of muscle types. Likely sprinter.";
                        }
                    }

                    if (currentEntry[0] == "rs429358" || currentEntry[0] == "rs7412")
                    {
                        output += "RS429358 or RS7412\t\t";
                        output += "Description: raise risk of Alzheimer's\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "Magnitude: 1.2\t";
                            output += "one of 2 snps relevant to classifying APOE genotype";
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Magnitude: null\t";
                            output += ">3x increased risk for Alzheimer's; 1.4x increased risk for heart disease";
                        }
                        else if (((currentEntry[3] == "C") && (currentEntry[4] == "T")))
                        {
                            output += "Magnitude: 0\t";
                            output += "Common";
                        }
                    }

                    if (currentEntry[0] == "rs6152")
                    {
                        output += "RS6152\t\t";
                        output += "Description: baldness\t";

                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "Magnitude: 4\t";
                            output += "won't go bald";
                        }
                        else if (((currentEntry[3] == "A") && (currentEntry[4] == "G")))
                        {
                            output += "Magnitude: 2\t";
                            output += "	Increased risk of baldness";
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "G")))
                        {
                            output += "Magnitude: 0.5\t";
                            output += "able to go bald";
                        }
                        else if ((currentEntry[3] == "A"))
                        {
                            output += "Magnitude: 3\t";
                            output += "";
                        }
                    }


                    output += "\n\n";
                    outputBox.Items.Add(output);
                }
            }
            else
            {
                outputBox.Items.Clear();
                outputBox.Items.Add("No file loaded!");
            }
        }

        private void btn_Detox_Click(object sender, EventArgs e)
        {
        }

        private void btn_Methylation_Click(object sender, EventArgs e)
        {
        }


    }
}