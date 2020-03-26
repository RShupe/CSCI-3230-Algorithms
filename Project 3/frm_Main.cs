﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project_3
{
    public partial class frm_Main : Form
    {
        private List<String[]> entries = new List<String[]>(); //variable to hold the rsid's that is found in the file
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
                    entries.Clear();
                    outputBox.Items.Clear();
                    outputBox.Refresh();

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
                        entries.Add(ent);
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
            loadingLabel.Text = "Report is generating...";
            loadingLabel.Refresh();


            outputBox.Items.Clear();
            outputBox.Refresh();

            if (fileIn)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    String output = ""; //build a string to put in the list
                    String[] currentEntry = new String[5]; //get the current line from the file and format it into a readable string array

                    currentEntry = entries[i];

                    #region Popular Items

                    //this is where all of the popular items are kept (it works its just really slow)
                    if (currentEntry[0] == "rs53576")
                    {
                        output += "RS53576\t\t\t";
                        output += "Description: social behavior/personality\t";

                        if (((currentEntry[3] == "A") && (currentEntry[4] == "A")) || ((currentEntry[3] == "A") && (currentEntry[4] == "G")))
                        {
                            output += "Bad\t";
                            output += "Lack of empathy?";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "G")))
                        {
                            output += "Good\t";
                            output += "Optimistic and empathetic; handle stress well";
                            outputBox.Items.Add(output);
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs1815739")
                    {
                        output += "RS1815739\t\t";
                        output += "Description:  muscle performance\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "Good\t";
                            output += "Better performing muscles. Likely sprinter.";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Good\t";
                            output += "Impaired muscle performance. Likely endurance athlete.";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "C") && (currentEntry[4] == "T")))
                        {
                            output += "Neutral\t";
                            output += "Mix of muscle types. Likely sprinter.";
                            outputBox.Items.Add(output);
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs429358" || currentEntry[0] == "rs7412")
                    {
                        output += "RS429358 or RS7412\t";
                        output += "Description:  raise risk of Alzheimer's\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "Bad\t";
                            output += "one of 2 snps relevant to classifying APOE genotype";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += ">3x increased risk for Alzheimer's; 1.4x increased risk for heart disease";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "C") && (currentEntry[4] == "T")))
                        {
                            output += "Good\t";
                            output += "Common";
                            outputBox.Items.Add(output);
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs6152")
                    {
                        output += "RS6152\t\t";
                        output += "Description: baldness\t\t\t";

                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "Good";
                            output += "won't go bald";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "A") && (currentEntry[4] == "G")))
                        {
                            output += "Neutral";
                            output += "	Increased risk of baldness";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "G")))
                        {
                            output += "Neutral\t";
                            output += "able to go bald";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if ((currentEntry[3] == "A"))
                        {
                            output += "Neutral\t";
                            outputBox.Items.Add(output);
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs6152")
                    {
                        output += "RS333\t\t";
                        output += "Description: HIV Resistance\t";
                        output += "Good\t";
                        outputBox.Items.Add(output);
                    }
                    else if (currentEntry[0] == "rs1800497")
                    {
                        output += "RS1800497\t\t";
                        output += "Description: May influence the sense of pleasure\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "Good\t";
                            output += "Normal";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "C") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += "A1/A2: Bad at avoidance of errors. 0.5x lower OCD risk, 0.87x lower Tardive Diskinesia risk, " +
                                "higher ADHD risk. More Alcohol Dependence. Lower risk of Postoperative Nausea. Increased obesity. Bupropion is not effective for smoking cessation.";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += "A1/A1: Bad at avoidance of errors. 0.25x lower OCD; 0.56x lower Tardive Diskinesia; higher ADHD; " +
                                "1.4x Alcohol Dependence; lower Postoperative Nausea; Increased obesity; less pleasure response; Bupropion ineffective for smoking cessation.;" +
                                " 2.4x risk for adenoma recurrence.";
                            outputBox.Items.Add(output);
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs1805007")
                    {
                        output += "RS1805007\t\t";
                        output += "Description: sensitivity to anesthetics\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "Good\t";
                            output += "Normal";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "C") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += "Carrier of a red hair associated variant; higher risk of melanoma";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += "Increased response to anesthetics; 13-20x higher likelihood of red hair; increased risk of melanoma";
                            outputBox.Items.Add(output);
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs9939609")
                    {
                        output += "RS9939609\t\t";
                        output += "Description: Obesity related. Raises T2D risk through obesity.\t";

                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "Bad\t";
                            output += "obesity risk and 1.6x risk for T2D";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "A") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += "1.3x risk for T2D; obesity risk";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Good\t";
                            output += "lower risk of obesity and Type-2 diabetes";
                            outputBox.Items.Add(output);
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs662799")
                    {
                        output += "RS662799\t\t";
                        output += "Description: Prevents weight gain from high fat diets\t";

                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "Good\t";
                            output += "Normal";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "A") && (currentEntry[4] == "G")))
                        {
                            output += "Bad\t";
                            output += "1.4x higher early heart attack risk; less weight gain on high fat diets";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "G")))
                        {
                            output += "Bad\t";
                            output += "2x higher early heart attack risk; less weight gain on high fat diets";
                            outputBox.Items.Add(output);
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs7495174")
                    {
                        output += "RS7495174\t\t";
                        output += "Description:  green eye color\t\t";

                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "Neutral\t";
                            output += "blue/gray eyes more likely";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "A") && (currentEntry[4] == "G")))
                        {
                            output += "Neutral\t";
                            output += "blue/gray eyes more likely";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "G")))
                        {
                            output += "Neutral\t";
                            output += "blue/gray eyes more likely";
                            outputBox.Items.Add(output);
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs12913832")
                    {
                        output += "RS12913832\t\t";
                        output += "Description:  blue/brown eye color\t";

                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "Neutral\t";
                            output += "brown eye color, 80% of the time";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "A") && (currentEntry[4] == "G")))
                        {
                            output += "Neutral\t";
                            output += "brown eye color";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "G")))
                        {
                            output += "Neutral\t";
                            output += "blue eye color, 99% of the time";
                            outputBox.Items.Add(output);
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs7903146")
                    {
                        output += "RS79031462\t\t";
                        output += "Description:  Associated with T2D.\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "Good\t";
                            output += "Normal (lower) risk of Type 2 Diabetes and Gestational Diabetes.";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "C") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += "1.4x increased risk for diabetes (and perhaps colon cancer).";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += "2x increased risk for Type-2 diabetes";
                            outputBox.Items.Add(output);
                            outputBox.Refresh();
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs12255372")
                    {
                        output += "RS12255372\t\t";
                        output += "Description: risks for T2D, breast and prostate cancers.\t";

                        if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "Good\t";
                            output += "Normal";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += "	1.3x increased type-2 diabetes risk";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += "	slight increases (~1.5x) in risk for type-2 diabetes and possibly breast cancer and aggressive prostate cancer";
                            outputBox.Items.Add(output);
                            outputBox.Refresh();
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs1799971")
                    {
                        output += "RS1799971\t\t";
                        output += "Description:  alcohol cravings\t\t";

                        if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "Good\t";
                            output += "Normal";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "A") && (currentEntry[4] == "G")))
                        {
                            output += "Bad\t";
                            output += " stronger cravings for alcohol. if alcoholic, naltrexone treatment 2x more successful";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "G")))
                        {
                            output += "Bad\t";
                            output += " more pain";
                            outputBox.Items.Add(output);
                            outputBox.Refresh();
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs17822931")
                    {
                        output += "RS17822931\t\t";
                        output += "Description:  earwax, body odor\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "Neutral\t";
                            output += "Wet earwax. Normal body odour. Normal colostrum.";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "A") && (currentEntry[4] == "G")))
                        {
                            output += "Good\t";
                            output += " Wet earwax. Slightly better body odour.";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "G")))
                        {
                            output += "Good\t";
                            output += " Dry earwax. No body odour. Likely Asian ancestry. Reduced colostrum.";
                            outputBox.Items.Add(output);
                            outputBox.Refresh();
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs4680")
                    {
                        output += "RS4680\t\t\t";
                        output += "Description:  warrior vs worrier\t\t";

                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "Good\t";
                            output += "(worrier) advantage in memory and attention tasks";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "A") && (currentEntry[4] == "G")))
                        {
                            output += "Neutral\t";
                            output += " Intermediate dopamine levels, other effects";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "G")))
                        {
                            output += "Good\t";
                            output += " (warrior) multiple associations, see details";
                            outputBox.Items.Add(output);
                            outputBox.Refresh();
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs1333049")
                    {
                        output += "RS1333049\t\t";
                        output += "Description: " +
                            "risk for coronary artery disease\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "Bad\t";
                            output += "1.9x increased risk for coronary artery disease";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "C") && (currentEntry[4] == "G")))
                        {
                            output += "Bad\t";
                            output += " 1.5x increased risk for CAD";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "G") && (currentEntry[4] == "G")))
                        {
                            output += "Good\t";
                            output += "Normal";
                            outputBox.Items.Add(output);
                            outputBox.Refresh();
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs1801133")
                    {
                        output += "RS1801133\t\t";
                        output += "Description:  Folic acid processing; homocysteine levels\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "Good\t";
                            output += "	Common genotype: normal homocysteine levels";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "C") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += " 1 copy of C677T allele of MTHFR = 65% efficiency in processing folic acid";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += "Homozygous for C677T of MTHFR = 10-20% efficiency in processing folic acid = high homocysteine, low B12 and folate levels";
                            outputBox.Items.Add(output);
                            outputBox.Refresh();
                            continue;
                        }
                    }
                    else if ((currentEntry[0] == "rs1051730") || (currentEntry[0] == "rs3750344"))
                    {
                        output += "RS1051730 or RS3750344\t";
                        output += "Description:  smoking and drinking\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "Good\t";
                            output += "	Smokes normal (lower) number of cigarettes if a smoker.";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "C") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += " 1.3x increased risk of lung cancer";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Bad\t";
                            output += "1.8x increased risk of lung cancer; reduced response to alcohol, therefore possibly increased risk of alcohol abuse";
                            outputBox.Items.Add(output);
                            outputBox.Refresh();
                            continue;
                        }
                    }
                    else if (currentEntry[0] == "rs4988235")
                    {
                        output += "RS4988235\t\t";
                        output += "Description:   lactose intolerance\t";

                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "Bad\t";
                            output += "	likely to be lactose intolerant as an adult";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "C") && (currentEntry[4] == "T")))
                        {
                            output += "Good\t";
                            output += " likely to be able to digest milk as an adult";
                            outputBox.Items.Add(output);
                            continue;
                        }
                        else if (((currentEntry[3] == "T") && (currentEntry[4] == "T")))
                        {
                            output += "Good\t";
                            output += "can digest milk";
                            outputBox.Items.Add(output);
                            outputBox.Refresh();
                            continue;
                        }
                    }

                    #endregion Popular Items

                }
            }
            else
            {
                outputBox.Items.Clear();
                outputBox.Items.Add("No file loaded!");
            }

            loadingLabel.Text = "";
            loadingLabel.Refresh();
        }

        private void btn_Detox_Click(object sender, EventArgs e)
        {
            loadingLabel.Text = "Report is generating...";
            loadingLabel.Refresh();


            outputBox.Items.Clear();
            outputBox.Refresh();

            if (fileIn)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    String output = ""; //build a string to put in the list
                    String[] currentEntry = new String[5]; //get the current line from the file and format it into a readable string array

                    currentEntry = entries[i];

                    #region Detox Items
                    if(currentEntry[0] == "rs1048943")
                    {
                        output += "CYP1A1*2C A4889G\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        output += "-/-";
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1800440")
                    {
                        output += "CYP1B1 N453S\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "T") && (currentEntry[4] == "C"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "T") && (currentEntry[4] == "T"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs6413419")
                    {
                        output += "CYP2E1*4 4768G>A\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";

                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "+/+";
                        }
                        else if((currentEntry[3]  == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }

                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs4986910")
                    {
                        output += "CYP3A4*3 M445T\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";

                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "+/+";
                        }

                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1695")
                    {
                        output += "GSTP1 I105V\t\t";
                        output += currentEntry[0] + "\t\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs4880")
                    {
                        output += "SOD2 A16V\t\t";
                        output += currentEntry[0] + "\t\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1805158")
                    {
                        output += "NAT1 R64W\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "T"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "T") && (currentEntry[4] == "T"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1801280")
                    {
                        output += "NAT2 I114T\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "T"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "T") && (currentEntry[4] == "T"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1799930")
                    {
                        output += "NAT2 R197Q\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1799931")
                    {
                        output += "NAT2 G286E\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1801279")
                    {
                        output += "NAT2 R64Q\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs4986883")
                    {
                        output += "CYP1A1 m3 T3205C\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1799814")
                    {
                        output += "CYP1A1 C2453A\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "T"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "T") && (currentEntry[4] == "T"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs762551")
                    {
                        output += "CYP1A2 164A>C\t\t";
                        output += currentEntry[0] + "\t\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1056836")
                    {
                        output += "CYP1B1 L432V\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs10012")
                    {
                        output += "CYP1B1 R48G\t\t";
                        output += currentEntry[0] + "\t\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "T") && (currentEntry[4] == "T"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "T"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1801272")
                    {
                        output += "CYP2A6*2 1799T>A\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "T") && (currentEntry[4] == "T"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "T"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs568811809")
                    {
                        output += "CYP2A6*20\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "T") && (currentEntry[4] == "T"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "T"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1799853")
                    {
                        output += "CYP2C9*2 C430T\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "T") && (currentEntry[4] == "T"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "T"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1057910")
                    {
                        output += "CYP2C9*3 A1075C\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "C"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs12248560")
                    {
                        output += "CYP2C19*17\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "T"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "T") && (currentEntry[4] == "T"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1135840")
                    {
                        output += "CYP2D6 S486T\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1135840")
                    {
                        output += "CYP2D6 S486T\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1065852")
                    {
                        output += "CYP2D6 100C>T\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "T") && (currentEntry[4] == "T"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "T"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs16947")
                    {
                        output += "CYP2D6 2850C>T\t\t";
                        output += currentEntry[0] + "\t\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs2070676")
                    {
                        output += "CYP2E1*1B 9896C>G\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs55897648")
                    {
                        output += "CYP2E1*1B 10023G>A\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs2740574")
                    {
                        output += "CYP3A4*1B\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs55785340")
                    {
                        output += "CYP3A4*2 S222P\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs12721627")
                    {
                        output += "CYP3A4*16 T185S\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1138272")
                    {
                        output += "GSTP1 A114V\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "C") && (currentEntry[4] == "C"))
                        {
                            output += "-/-";
                        }
                        else if ((currentEntry[3] == "C") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "+/+";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs4986782")
                    {
                        output += "NAT1 R187Q\t\t";
                        output += currentEntry[0] + "\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }
                    else if (currentEntry[0] == "rs1208")
                    {
                        output += "NAT2 K268R\t\t";
                        output += currentEntry[0] + "\t\t";
                        output += currentEntry[3] + currentEntry[4] + "\t";
                        if ((currentEntry[3] == "A") && (currentEntry[4] == "A"))
                        {
                            output += "+/+";
                        }
                        else if ((currentEntry[3] == "A") && (currentEntry[4] == "G"))
                        {
                            output += "+/-";
                        }
                        else if ((currentEntry[3] == "G") && (currentEntry[4] == "G"))
                        {
                            output += "-/-";
                        }
                        outputBox.Items.Add(output);
                        continue;
                    }



                    #endregion Detox Items
                }
            }
            else
            {
                outputBox.Items.Clear();
                outputBox.Items.Add("No file loaded!");
            }

            loadingLabel.Text = "";
            loadingLabel.Refresh();
        }
        private void btn_Methylation_Click(object sender, EventArgs e)
        {
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            outputBox.Items.Clear();
            outputBox.Refresh();
        }
    }
    
}