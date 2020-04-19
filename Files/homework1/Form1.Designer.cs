namespace homework1
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
            this.OpenTextFileBtn = new System.Windows.Forms.Button();
            this.OpenBinaryFileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenTextFileBtn
            // 
            this.OpenTextFileBtn.Location = new System.Drawing.Point(11, 11);
            this.OpenTextFileBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenTextFileBtn.Name = "OpenTextFileBtn";
            this.OpenTextFileBtn.Size = new System.Drawing.Size(197, 28);
            this.OpenTextFileBtn.TabIndex = 0;
            this.OpenTextFileBtn.Text = "OpenTextFile";
            this.OpenTextFileBtn.UseVisualStyleBackColor = true;
            this.OpenTextFileBtn.Click += new System.EventHandler(this.OpenTextFileBtn_Click);
            // 
            // OpenBinaryFileBtn
            // 
            this.OpenBinaryFileBtn.Location = new System.Drawing.Point(16, 54);
            this.OpenBinaryFileBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenBinaryFileBtn.Name = "OpenBinaryFileBtn";
            this.OpenBinaryFileBtn.Size = new System.Drawing.Size(192, 32);
            this.OpenBinaryFileBtn.TabIndex = 1;
            this.OpenBinaryFileBtn.Text = "Open Binary File";
            this.OpenBinaryFileBtn.UseVisualStyleBackColor = true;
            this.OpenBinaryFileBtn.Click += new System.EventHandler(this.OpenBinaryFileBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 104);
            this.Controls.Add(this.OpenBinaryFileBtn);
            this.Controls.Add(this.OpenTextFileBtn);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenTextFileBtn;
        private System.Windows.Forms.Button OpenBinaryFileBtn;
    }
}

