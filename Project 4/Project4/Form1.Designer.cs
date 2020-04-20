﻿namespace Project4
{
    partial class frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.binBtn = new System.Windows.Forms.Button();
            this.sizebox = new System.Windows.Forms.NumericUpDown();
            this.fileLbl = new System.Windows.Forms.Label();
            this.countlbl = new System.Windows.Forms.Label();
            this.btn_Merge = new System.Windows.Forms.Button();
            this.chkDisplay = new System.Windows.Forms.CheckBox();
            this.displayBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.numberofFilesBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNumFilesGenerated = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sizebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberofFilesBox)).BeginInit();
            this.SuspendLayout();
            // 
            // binBtn
            // 
            this.binBtn.Location = new System.Drawing.Point(12, 37);
            this.binBtn.Name = "binBtn";
            this.binBtn.Size = new System.Drawing.Size(173, 35);
            this.binBtn.TabIndex = 0;
            this.binBtn.Text = "Load a bin file";
            this.binBtn.UseVisualStyleBackColor = true;
            this.binBtn.Click += new System.EventHandler(this.binBtn_Click);
            // 
            // sizebox
            // 
            this.sizebox.Location = new System.Drawing.Point(77, 11);
            this.sizebox.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.sizebox.Name = "sizebox";
            this.sizebox.Size = new System.Drawing.Size(111, 20);
            this.sizebox.TabIndex = 3;
            this.sizebox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // fileLbl
            // 
            this.fileLbl.AutoSize = true;
            this.fileLbl.Location = new System.Drawing.Point(12, 165);
            this.fileLbl.Name = "fileLbl";
            this.fileLbl.Size = new System.Drawing.Size(134, 13);
            this.fileLbl.TabIndex = 4;
            this.fileLbl.Text = "Number of files generated: ";
            // 
            // countlbl
            // 
            this.countlbl.AutoSize = true;
            this.countlbl.Location = new System.Drawing.Point(12, 86);
            this.countlbl.Name = "countlbl";
            this.countlbl.Size = new System.Drawing.Size(0, 13);
            this.countlbl.TabIndex = 5;
            // 
            // btn_Merge
            // 
            this.btn_Merge.Location = new System.Drawing.Point(12, 111);
            this.btn_Merge.Name = "btn_Merge";
            this.btn_Merge.Size = new System.Drawing.Size(170, 23);
            this.btn_Merge.TabIndex = 6;
            this.btn_Merge.Text = "Merge";
            this.btn_Merge.UseVisualStyleBackColor = true;
            this.btn_Merge.Click += new System.EventHandler(this.btn_Merge_Click);
            // 
            // chkDisplay
            // 
            this.chkDisplay.AutoSize = true;
            this.chkDisplay.Checked = true;
            this.chkDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplay.Location = new System.Drawing.Point(12, 140);
            this.chkDisplay.Name = "chkDisplay";
            this.chkDisplay.Size = new System.Drawing.Size(108, 17);
            this.chkDisplay.TabIndex = 7;
            this.chkDisplay.Text = "Display sorted file";
            this.chkDisplay.UseVisualStyleBackColor = true;
            // 
            // displayBox
            // 
            this.displayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayBox.FormattingEnabled = true;
            this.displayBox.Location = new System.Drawing.Point(207, 13);
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(418, 277);
            this.displayBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "East Tennessee State University";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ryan Shupe";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Algorithms - Project 4 ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Heap Size:";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(12, 205);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 12;
            // 
            // numberofFilesBox
            // 
            this.numberofFilesBox.Location = new System.Drawing.Point(136, 182);
            this.numberofFilesBox.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numberofFilesBox.Name = "numberofFilesBox";
            this.numberofFilesBox.Size = new System.Drawing.Size(52, 20);
            this.numberofFilesBox.TabIndex = 14;
            this.numberofFilesBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Numer of files to merge:";
            // 
            // lblNumFilesGenerated
            // 
            this.lblNumFilesGenerated.AutoSize = true;
            this.lblNumFilesGenerated.Location = new System.Drawing.Point(140, 164);
            this.lblNumFilesGenerated.Name = "lblNumFilesGenerated";
            this.lblNumFilesGenerated.Size = new System.Drawing.Size(13, 13);
            this.lblNumFilesGenerated.TabIndex = 15;
            this.lblNumFilesGenerated.Text = "0";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 298);
            this.Controls.Add(this.lblNumFilesGenerated);
            this.Controls.Add(this.numberofFilesBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.displayBox);
            this.Controls.Add(this.chkDisplay);
            this.Controls.Add(this.btn_Merge);
            this.Controls.Add(this.countlbl);
            this.Controls.Add(this.fileLbl);
            this.Controls.Add(this.sizebox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.binBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(520, 316);
            this.Name = "frm_Main";
            this.Text = "Project 4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.sizebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberofFilesBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button binBtn;
        private System.Windows.Forms.NumericUpDown sizebox;
        private System.Windows.Forms.Label fileLbl;
        private System.Windows.Forms.Label countlbl;
        private System.Windows.Forms.Button btn_Merge;
        private System.Windows.Forms.CheckBox chkDisplay;
        private System.Windows.Forms.ListBox displayBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.NumericUpDown numberofFilesBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNumFilesGenerated;
    }
}

