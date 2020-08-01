namespace FacebookBackupParser
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
            this.chooseFolderButton = new System.Windows.Forms.Button();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.startButton = new System.Windows.Forms.Button();
            this.backup = new System.Windows.Forms.CheckBox();
            this.progressBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chooseFolderButton
            // 
            this.chooseFolderButton.Location = new System.Drawing.Point(12, 12);
            this.chooseFolderButton.Name = "chooseFolderButton";
            this.chooseFolderButton.Size = new System.Drawing.Size(75, 23);
            this.chooseFolderButton.TabIndex = 0;
            this.chooseFolderButton.Text = "Chat Folder";
            this.chooseFolderButton.UseVisualStyleBackColor = true;
            this.chooseFolderButton.Click += new System.EventHandler(this.chooseFolderButton_Click);
            // 
            // folderTextBox
            // 
            this.folderTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.folderTextBox.Location = new System.Drawing.Point(125, 14);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(259, 20);
            this.folderTextBox.TabIndex = 1;
            this.folderTextBox.Text = "Select the facebookExport\\messages\\user folder";
            this.folderTextBox.Click += new System.EventHandler(this.folderTextBox_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(309, 108);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // backup
            // 
            this.backup.AutoSize = true;
            this.backup.Checked = true;
            this.backup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.backup.Location = new System.Drawing.Point(32, 54);
            this.backup.Name = "backup";
            this.backup.Size = new System.Drawing.Size(93, 17);
            this.backup.TabIndex = 5;
            this.backup.Text = "Make Backup";
            this.backup.UseVisualStyleBackColor = true;
            // 
            // progressBox
            // 
            this.progressBox.Enabled = false;
            this.progressBox.Location = new System.Drawing.Point(13, 110);
            this.progressBox.Name = "progressBox";
            this.progressBox.ReadOnly = true;
            this.progressBox.Size = new System.Drawing.Size(257, 20);
            this.progressBox.TabIndex = 6;
            this.progressBox.Text = "Press Start";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 143);
            this.Controls.Add(this.progressBox);
            this.Controls.Add(this.backup);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.folderTextBox);
            this.Controls.Add(this.chooseFolderButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseFolderButton;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox backup;
        private System.Windows.Forms.TextBox progressBox;
    }
}

