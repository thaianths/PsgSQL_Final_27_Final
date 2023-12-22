namespace WinFormsApp1
{
    partial class PopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupForm));
            txtlogin = new TextBox();
            btnenter = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // txtlogin
            // 
            txtlogin.BackColor = SystemColors.Info;
            txtlogin.Location = new Point(49, 43);
            txtlogin.Name = "txtlogin";
            txtlogin.Size = new Size(273, 31);
            txtlogin.TabIndex = 0;
            txtlogin.UseSystemPasswordChar = true;
            // 
            // btnenter
            // 
            btnenter.Image = (Image)resources.GetObject("btnenter.Image");
            btnenter.ImageAlign = ContentAlignment.MiddleLeft;
            btnenter.Location = new Point(49, 105);
            btnenter.Name = "btnenter";
            btnenter.Size = new Size(129, 34);
            btnenter.TabIndex = 1;
            btnenter.Text = "Enter";
            btnenter.UseVisualStyleBackColor = true;
            btnenter.Click += button1_Click;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(193, 105);
            button2.Name = "button2";
            button2.Size = new Size(129, 34);
            button2.TabIndex = 1;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // PopupForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 186);
            Controls.Add(button2);
            Controls.Add(btnenter);
            Controls.Add(txtlogin);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PopupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += PopupForm_Load;
            ResumeLayout(false);
            PerformLayout();
            create();
        }

        #endregion

        private TextBox txtlogin;
        private Button btnenter;
        private Button button2;
    }
}