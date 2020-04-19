namespace Project4
{
    partial class Form1
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
            this.binBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sizebox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.sizebox)).BeginInit();
            this.SuspendLayout();
            // 
            // binBtn
            // 
            this.binBtn.Location = new System.Drawing.Point(12, 12);
            this.binBtn.Name = "binBtn";
            this.binBtn.Size = new System.Drawing.Size(173, 35);
            this.binBtn.TabIndex = 0;
            this.binBtn.Text = "Open Bin file to sort";
            this.binBtn.UseVisualStyleBackColor = true;
            this.binBtn.Click += new System.EventHandler(this.binBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Heap Size:";
            // 
            // sizebox
            // 
            this.sizebox.Location = new System.Drawing.Point(65, 65);
            this.sizebox.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.sizebox.Name = "sizebox";
            this.sizebox.Size = new System.Drawing.Size(120, 20);
            this.sizebox.TabIndex = 3;
            this.sizebox.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 99);
            this.Controls.Add(this.sizebox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.binBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.sizebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button binBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown sizebox;
    }
}

