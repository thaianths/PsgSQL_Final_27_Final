namespace WinFormsApp1
{
    partial class LogFile
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
            rstLogFile = new RichTextBox();
            SuspendLayout();
            // 
            // rstLogFile
            // 
            rstLogFile.Location = new Point(12, 12);
            rstLogFile.Name = "rstLogFile";
            rstLogFile.Size = new Size(795, 500);
            rstLogFile.TabIndex = 0;
            rstLogFile.Text = "";
            // 
            // LogFile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 524);
            Controls.Add(rstLogFile);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LogFile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogFile";
            Load += LogFile_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rstLogFile;
    }
}