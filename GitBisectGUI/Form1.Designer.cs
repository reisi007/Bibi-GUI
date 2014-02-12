namespace GitBisectGUI
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
            this.b_searchRepo = new System.Windows.Forms.Button();
            this.b_start = new System.Windows.Forms.Button();
            this.tb_ondisk = new System.Windows.Forms.TextBox();
            this.tb_incloud = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fbd_repoOnDisk = new System.Windows.Forms.FolderBrowserDialog();
            this.output = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // b_searchRepo
            // 
            this.b_searchRepo.Location = new System.Drawing.Point(12, 14);
            this.b_searchRepo.Name = "b_searchRepo";
            this.b_searchRepo.Size = new System.Drawing.Size(133, 23);
            this.b_searchRepo.TabIndex = 0;
            this.b_searchRepo.Text = "Repo folder on disk";
            this.b_searchRepo.UseVisualStyleBackColor = true;
            this.b_searchRepo.Click += new System.EventHandler(this.b_searchRepo_Click);
            // 
            // b_start
            // 
            this.b_start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_start.Location = new System.Drawing.Point(366, 12);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(139, 52);
            this.b_start.TabIndex = 1;
            this.b_start.Text = "Start";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // tb_ondisk
            // 
            this.tb_ondisk.Location = new System.Drawing.Point(152, 14);
            this.tb_ondisk.Name = "tb_ondisk";
            this.tb_ondisk.Size = new System.Drawing.Size(208, 20);
            this.tb_ondisk.TabIndex = 2;
            // 
            // tb_incloud
            // 
            this.tb_incloud.Location = new System.Drawing.Point(152, 40);
            this.tb_incloud.Name = "tb_incloud";
            this.tb_incloud.Size = new System.Drawing.Size(208, 20);
            this.tb_incloud.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Repo online";
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(15, 100);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(500, 44);
            this.output.TabIndex = 6;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 71);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(503, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 156);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_incloud);
            this.Controls.Add(this.tb_ondisk);
            this.Controls.Add(this.b_start);
            this.Controls.Add(this.b_searchRepo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.saveSettings);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_searchRepo;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.TextBox tb_ondisk;
        private System.Windows.Forms.TextBox tb_incloud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbd_repoOnDisk;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

