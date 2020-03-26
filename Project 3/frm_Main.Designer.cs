namespace Project_3
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
            this.btn_Upload = new System.Windows.Forms.Button();
            this.btn_Popular = new System.Windows.Forms.Button();
            this.btn_Methylation = new System.Windows.Forms.Button();
            this.btn_Detox = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_file = new System.Windows.Forms.Label();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.outputBox = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Upload
            // 
            this.btn_Upload.Location = new System.Drawing.Point(12, 12);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(103, 23);
            this.btn_Upload.TabIndex = 0;
            this.btn_Upload.Text = "Upload File";
            this.btn_Upload.UseVisualStyleBackColor = true;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // btn_Popular
            // 
            this.btn_Popular.Location = new System.Drawing.Point(121, 14);
            this.btn_Popular.Name = "btn_Popular";
            this.btn_Popular.Size = new System.Drawing.Size(123, 37);
            this.btn_Popular.TabIndex = 1;
            this.btn_Popular.Text = "Result from Popular Snpedia Items";
            this.btn_Popular.UseVisualStyleBackColor = true;
            this.btn_Popular.Click += new System.EventHandler(this.btn_Popular_Click);
            // 
            // btn_Methylation
            // 
            this.btn_Methylation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Methylation.Location = new System.Drawing.Point(486, 16);
            this.btn_Methylation.Name = "btn_Methylation";
            this.btn_Methylation.Size = new System.Drawing.Size(123, 35);
            this.btn_Methylation.TabIndex = 2;
            this.btn_Methylation.Text = "Generate Methylation Analysis";
            this.btn_Methylation.UseVisualStyleBackColor = true;
            this.btn_Methylation.Click += new System.EventHandler(this.btn_Methylation_Click);
            // 
            // btn_Detox
            // 
            this.btn_Detox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Detox.Location = new System.Drawing.Point(250, 14);
            this.btn_Detox.Name = "btn_Detox";
            this.btn_Detox.Size = new System.Drawing.Size(230, 37);
            this.btn_Detox.TabIndex = 3;
            this.btn_Detox.Text = "Generate Detox Profile";
            this.btn_Detox.UseVisualStyleBackColor = true;
            this.btn_Detox.Click += new System.EventHandler(this.btn_Detox_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(615, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Algorithms - Project 3 ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(615, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ryan Shupe";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(615, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "East Tennessee State University";
            // 
            // label_file
            // 
            this.label_file.AutoSize = true;
            this.label_file.Location = new System.Drawing.Point(12, 38);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(75, 13);
            this.label_file.TabIndex = 8;
            this.label_file.Text = "No file loaded!";
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.Location = new System.Drawing.Point(244, 335);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(0, 33);
            this.loadingLabel.TabIndex = 9;
            // 
            // outputBox
            // 
            this.outputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputBox.FormattingEnabled = true;
            this.outputBox.Location = new System.Drawing.Point(15, 55);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(764, 277);
            this.outputBox.TabIndex = 10;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(12, 344);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear Box";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frm_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(791, 377);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Detox);
            this.Controls.Add(this.btn_Methylation);
            this.Controls.Add(this.btn_Popular);
            this.Controls.Add(this.btn_Upload);
            this.MinimumSize = new System.Drawing.Size(700, 386);
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algorithms - Project 3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Upload;
        private System.Windows.Forms.Button btn_Popular;
        private System.Windows.Forms.Button btn_Methylation;
        private System.Windows.Forms.Button btn_Detox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.ListBox outputBox;
        private System.Windows.Forms.Button btnClear;
    }
}

