namespace GitBisectGUI
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.b_searchRepo = new System.Windows.Forms.Button();
            this.b_start = new System.Windows.Forms.Button();
            this.tb_ondisk = new System.Windows.Forms.TextBox();
            this.tb_incloud = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fbd_repoOnDisk = new System.Windows.Forms.FolderBrowserDialog();
            this.output = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bcheckSettings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_from = new System.Windows.Forms.ComboBox();
            this.cb_to = new System.Windows.Forms.ComboBox();
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
            this.b_start.Location = new System.Drawing.Point(366, 11);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(139, 25);
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
            this.tb_ondisk.Leave += new System.EventHandler(this.tb_ondisk_Leave);
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
            this.output.Size = new System.Drawing.Size(690, 44);
            this.output.TabIndex = 6;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 71);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(693, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 7;
            // 
            // bcheckSettings
            // 
            this.bcheckSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bcheckSettings.Location = new System.Drawing.Point(366, 38);
            this.bcheckSettings.Name = "bcheckSettings";
            this.bcheckSettings.Size = new System.Drawing.Size(139, 23);
            this.bcheckSettings.TabIndex = 8;
            this.bcheckSettings.Text = "Check setup";
            this.bcheckSettings.UseVisualStyleBackColor = true;
            this.bcheckSettings.Click += new System.EventHandler(this.bcheckSettings_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(512, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(512, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "To:";
            // 
            // cb_from
            // 
            this.cb_from.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_from.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_from.DropDownWidth = 250;
            this.cb_from.FormattingEnabled = true;
            this.cb_from.Location = new System.Drawing.Point(551, 11);
            this.cb_from.Name = "cb_from";
            this.cb_from.Size = new System.Drawing.Size(144, 21);
            this.cb_from.TabIndex = 11;
            this.cb_from.SelectedIndexChanged += new System.EventHandler(this.cb_from_SelectedIndexChanged);
            // 
            // cb_to
            // 
            this.cb_to.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_to.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_to.DropDownWidth = 250;
            this.cb_to.FormattingEnabled = true;
            this.cb_to.Location = new System.Drawing.Point(551, 38);
            this.cb_to.Name = "cb_to";
            this.cb_to.Size = new System.Drawing.Size(144, 21);
            this.cb_to.TabIndex = 12;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 156);
            this.Controls.Add(this.cb_to);
            this.Controls.Add(this.cb_from);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bcheckSettings);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_incloud);
            this.Controls.Add(this.tb_ondisk);
            this.Controls.Add(this.b_start);
            this.Controls.Add(this.b_searchRepo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BiBi GUI - Binary search in git-repos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.saveSettings);
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
        private System.Windows.Forms.Button bcheckSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_from;
        private System.Windows.Forms.ComboBox cb_to;
    }
}

