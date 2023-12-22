namespace WinFormsApp1
{
    partial class Setting
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            drgViewTables = new DataGridView();
            rdChema = new RadioButton();
            rdData = new RadioButton();
            lblTables = new Label();
            chkAll = new CheckBox();
            prgBar = new ProgressBar();
            lblset = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1 = new Panel();
            lbldb = new Label();
            lblpassword = new Label();
            lblid = new Label();
            lblport = new Label();
            lblip = new Label();
            dbcnn = new TextBox();
            passwordcnn = new TextBox();
            idcnn = new TextBox();
            portcnn = new TextBox();
            ipcnn = new TextBox();
            panel2 = new Panel();
            btnsave = new Button();
            label2 = new Label();
            label1 = new Label();
            lblpasscustomer = new Label();
            lblidcustomer = new Label();
            lblportcustomer = new Label();
            lblipcustomer = new Label();
            txtcustomer2 = new TextBox();
            txtcustomer1 = new TextBox();
            passwordcustomer = new TextBox();
            idcustomer = new TextBox();
            portcustomer = new TextBox();
            ipcustomer = new TextBox();
            label3 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            btntrack = new Button();
            btndelete = new Button();
            btnExit = new Button();
            btnRestore = new Button();
            btnbacup = new Button();
            btnCreateDB = new Button();
            btnCreate = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            lblsetting = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            stbarProgress = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblprogress = new Label();
            pictureBox3 = new PictureBox();
            label5 = new Label();
            comboBox1 = new ComboBox();
            btnadd = new Button();
            btnsubtract = new Button();
            chkAll_Data = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)drgViewTables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            stbarProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // drgViewTables
            // 
            drgViewTables.AllowUserToAddRows = false;
            drgViewTables.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            drgViewTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            drgViewTables.Location = new Point(31, 81);
            drgViewTables.Name = "drgViewTables";
            drgViewTables.RowHeadersWidth = 62;
            drgViewTables.RowTemplate.Height = 33;
            drgViewTables.Size = new Size(1105, 585);
            drgViewTables.TabIndex = 0;
            drgViewTables.ColumnHeaderMouseClick += drgViewTables_ColumnHeaderMouseClick;
            // 
            // rdChema
            // 
            rdChema.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rdChema.AutoSize = true;
            rdChema.ForeColor = Color.Red;
            rdChema.Location = new Point(27, 729);
            rdChema.Name = "rdChema";
            rdChema.Size = new Size(97, 29);
            rdChema.TabIndex = 5;
            rdChema.TabStop = true;
            rdChema.Text = "schema";
            rdChema.UseVisualStyleBackColor = true;
            rdChema.Visible = false;
            rdChema.CheckedChanged += rdChema_CheckedChanged;
            // 
            // rdData
            // 
            rdData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rdData.AutoSize = true;
            rdData.ForeColor = Color.Red;
            rdData.Location = new Point(217, 729);
            rdData.Name = "rdData";
            rdData.Size = new Size(77, 29);
            rdData.TabIndex = 6;
            rdData.TabStop = true;
            rdData.Text = " data";
            rdData.UseVisualStyleBackColor = true;
            rdData.Visible = false;
            rdData.CheckedChanged += rdData_CheckedChanged;
            // 
            // lblTables
            // 
            lblTables.AutoSize = true;
            lblTables.ForeColor = Color.Firebrick;
            lblTables.Location = new Point(1037, 35);
            lblTables.Name = "lblTables";
            lblTables.Size = new Size(0, 25);
            lblTables.TabIndex = 9;
            // 
            // chkAll
            // 
            chkAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chkAll.AutoSize = true;
            chkAll.ForeColor = Color.Red;
            chkAll.Location = new Point(861, 725);
            chkAll.Name = "chkAll";
            chkAll.Size = new Size(100, 29);
            chkAll.TabIndex = 10;
            chkAll.Text = "Schema";
            chkAll.UseVisualStyleBackColor = true;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            chkAll.Click += chkAll_Click;
            // 
            // prgBar
            // 
            prgBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            prgBar.Location = new Point(29, 672);
            prgBar.Name = "prgBar";
            prgBar.Size = new Size(1111, 15);
            prgBar.TabIndex = 11;
            // 
            // lblset
            // 
            lblset.AutoSize = true;
            lblset.BackColor = Color.Gainsboro;
            lblset.ForeColor = Color.IndianRed;
            lblset.Location = new Point(31, 697);
            lblset.Name = "lblset";
            lblset.Size = new Size(0, 25);
            lblset.TabIndex = 12;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lbldb);
            panel1.Controls.Add(lblpassword);
            panel1.Controls.Add(lblid);
            panel1.Controls.Add(lblport);
            panel1.Controls.Add(lblip);
            panel1.Controls.Add(dbcnn);
            panel1.Controls.Add(passwordcnn);
            panel1.Controls.Add(idcnn);
            panel1.Controls.Add(portcnn);
            panel1.Controls.Add(ipcnn);
            panel1.Location = new Point(1159, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(356, 291);
            panel1.TabIndex = 16;
            panel1.Paint += panel1_Paint;
            // 
            // lbldb
            // 
            lbldb.AutoSize = true;
            lbldb.Location = new Point(28, 235);
            lbldb.Name = "lbldb";
            lbldb.Size = new Size(86, 25);
            lbldb.TabIndex = 21;
            lbldb.Text = "Database";
            // 
            // lblpassword
            // 
            lblpassword.AutoSize = true;
            lblpassword.Location = new Point(29, 185);
            lblpassword.Name = "lblpassword";
            lblpassword.Size = new Size(87, 25);
            lblpassword.TabIndex = 22;
            lblpassword.Text = "Password";
            // 
            // lblid
            // 
            lblid.AutoSize = true;
            lblid.Location = new Point(85, 128);
            lblid.Name = "lblid";
            lblid.Size = new Size(30, 25);
            lblid.TabIndex = 23;
            lblid.Text = "ID";
            // 
            // lblport
            // 
            lblport.AutoSize = true;
            lblport.Location = new Point(67, 69);
            lblport.Name = "lblport";
            lblport.Size = new Size(44, 25);
            lblport.TabIndex = 24;
            lblport.Text = "Port";
            // 
            // lblip
            // 
            lblip.AutoSize = true;
            lblip.Location = new Point(85, 18);
            lblip.Name = "lblip";
            lblip.Size = new Size(27, 25);
            lblip.TabIndex = 25;
            lblip.Text = "IP";
            // 
            // dbcnn
            // 
            dbcnn.Location = new Point(123, 233);
            dbcnn.Name = "dbcnn";
            dbcnn.Size = new Size(194, 31);
            dbcnn.TabIndex = 16;
            dbcnn.Validating += dbcnn_Validating_1;
            // 
            // passwordcnn
            // 
            passwordcnn.Location = new Point(123, 179);
            passwordcnn.Name = "passwordcnn";
            passwordcnn.Size = new Size(194, 31);
            passwordcnn.TabIndex = 17;
            passwordcnn.UseSystemPasswordChar = true;
            passwordcnn.Validating += passwordcnn_Validating_1;
            // 
            // idcnn
            // 
            idcnn.Location = new Point(123, 122);
            idcnn.Name = "idcnn";
            idcnn.Size = new Size(194, 31);
            idcnn.TabIndex = 18;
            idcnn.Validating += idcnn_Validating_1;
            // 
            // portcnn
            // 
            portcnn.Location = new Point(123, 66);
            portcnn.Name = "portcnn";
            portcnn.Size = new Size(194, 31);
            portcnn.TabIndex = 19;
            portcnn.Validating += portcnn_Validating_1;
            // 
            // ipcnn
            // 
            ipcnn.Location = new Point(123, 15);
            ipcnn.Name = "ipcnn";
            ipcnn.Size = new Size(194, 31);
            ipcnn.TabIndex = 20;
            ipcnn.Validating += ipcnn_Validating_2;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnsave);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lblpasscustomer);
            panel2.Controls.Add(lblidcustomer);
            panel2.Controls.Add(lblportcustomer);
            panel2.Controls.Add(lblipcustomer);
            panel2.Controls.Add(txtcustomer2);
            panel2.Controls.Add(txtcustomer1);
            panel2.Controls.Add(passwordcustomer);
            panel2.Controls.Add(idcustomer);
            panel2.Controls.Add(portcustomer);
            panel2.Controls.Add(ipcustomer);
            panel2.Location = new Point(1163, 415);
            panel2.Name = "panel2";
            panel2.Size = new Size(352, 434);
            panel2.TabIndex = 17;
            panel2.Paint += panel2_Paint;
            // 
            // btnsave
            // 
            btnsave.Enabled = false;
            btnsave.Image = (Image)resources.GetObject("btnsave.Image");
            btnsave.ImageAlign = ContentAlignment.MiddleLeft;
            btnsave.Location = new Point(125, 362);
            btnsave.Name = "btnsave";
            btnsave.Size = new Size(194, 52);
            btnsave.TabIndex = 28;
            btnsave.Text = "Save";
            btnsave.UseVisualStyleBackColor = true;
            btnsave.Click += btnsave_Click;
            btnsave.MouseLeave += btnsave_MouseLeave;
            btnsave.MouseHover += btnsave_MouseHover;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 312);
            label2.Name = "label2";
            label2.Size = new Size(47, 25);
            label2.TabIndex = 22;
            label2.Text = "data";
            label2.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 254);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 23;
            label1.Text = " schema";
            // 
            // lblpasscustomer
            // 
            lblpasscustomer.AutoSize = true;
            lblpasscustomer.Location = new Point(29, 199);
            lblpasscustomer.Name = "lblpasscustomer";
            lblpasscustomer.Size = new Size(87, 25);
            lblpasscustomer.TabIndex = 24;
            lblpasscustomer.Text = "Password";
            // 
            // lblidcustomer
            // 
            lblidcustomer.AutoSize = true;
            lblidcustomer.Location = new Point(85, 142);
            lblidcustomer.Name = "lblidcustomer";
            lblidcustomer.Size = new Size(30, 25);
            lblidcustomer.TabIndex = 25;
            lblidcustomer.Text = "ID";
            // 
            // lblportcustomer
            // 
            lblportcustomer.AutoSize = true;
            lblportcustomer.Location = new Point(67, 83);
            lblportcustomer.Name = "lblportcustomer";
            lblportcustomer.Size = new Size(44, 25);
            lblportcustomer.TabIndex = 26;
            lblportcustomer.Text = "Port";
            // 
            // lblipcustomer
            // 
            lblipcustomer.AutoSize = true;
            lblipcustomer.Location = new Point(85, 32);
            lblipcustomer.Name = "lblipcustomer";
            lblipcustomer.Size = new Size(27, 25);
            lblipcustomer.TabIndex = 27;
            lblipcustomer.Text = "IP";
            // 
            // txtcustomer2
            // 
            txtcustomer2.Location = new Point(123, 306);
            txtcustomer2.Name = "txtcustomer2";
            txtcustomer2.Size = new Size(194, 31);
            txtcustomer2.TabIndex = 16;
            txtcustomer2.Text = "client_data";
            txtcustomer2.Visible = false;
            txtcustomer2.TextChanged += txtcustomer2_TextChanged_1;
            txtcustomer2.Validating += txtcustomer2_Validating_1;
            // 
            // txtcustomer1
            // 
            txtcustomer1.Location = new Point(123, 248);
            txtcustomer1.Name = "txtcustomer1";
            txtcustomer1.Size = new Size(194, 31);
            txtcustomer1.TabIndex = 17;
            txtcustomer1.Text = "client_schema";
            txtcustomer1.TextChanged += txtcustomer1_TextChanged_1;
            txtcustomer1.Validating += txtcustomer1_Validating_1;
            // 
            // passwordcustomer
            // 
            passwordcustomer.Location = new Point(123, 193);
            passwordcustomer.Name = "passwordcustomer";
            passwordcustomer.Size = new Size(194, 31);
            passwordcustomer.TabIndex = 18;
            passwordcustomer.UseSystemPasswordChar = true;
            passwordcustomer.Validating += passwordcustomer_Validating_1;
            // 
            // idcustomer
            // 
            idcustomer.Location = new Point(123, 136);
            idcustomer.Name = "idcustomer";
            idcustomer.Size = new Size(194, 31);
            idcustomer.TabIndex = 19;
            idcustomer.Validating += idcustomer_Validating_1;
            // 
            // portcustomer
            // 
            portcustomer.Location = new Point(123, 80);
            portcustomer.Name = "portcustomer";
            portcustomer.Size = new Size(194, 31);
            portcustomer.TabIndex = 20;
            portcustomer.TextChanged += portcustomer_TextChanged;
            portcustomer.Validating += portcustomer_Validating_1;
            // 
            // ipcustomer
            // 
            ipcustomer.Location = new Point(123, 29);
            ipcustomer.Name = "ipcustomer";
            ipcustomer.Size = new Size(194, 31);
            ipcustomer.TabIndex = 21;
            ipcustomer.Validating += ipcustomer_Validating_1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(1155, 35);
            label3.Name = "label3";
            label3.Size = new Size(144, 25);
            label3.TabIndex = 18;
            label3.Text = "Server Smartway";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(1163, 379);
            label4.Name = "label4";
            label4.Size = new Size(115, 25);
            label4.TabIndex = 18;
            label4.Text = "Server  Client";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btntrack);
            panel3.Controls.Add(btndelete);
            panel3.Controls.Add(btnExit);
            panel3.Controls.Add(btnRestore);
            panel3.Controls.Add(btnbacup);
            panel3.Controls.Add(btnCreateDB);
            panel3.Controls.Add(btnCreate);
            panel3.Location = new Point(26, 771);
            panel3.Name = "panel3";
            panel3.Size = new Size(1118, 77);
            panel3.TabIndex = 19;
            // 
            // btntrack
            // 
            btntrack.Image = (Image)resources.GetObject("btntrack.Image");
            btntrack.ImageAlign = ContentAlignment.MiddleLeft;
            btntrack.Location = new Point(677, 15);
            btntrack.Name = "btntrack";
            btntrack.Size = new Size(126, 46);
            btntrack.TabIndex = 27;
            btntrack.Text = "&More";
            btntrack.UseVisualStyleBackColor = true;
            btntrack.Click += btntrack_Click;
            // 
            // btndelete
            // 
            btndelete.BackColor = Color.Gainsboro;
            btndelete.Enabled = false;
            btndelete.Image = (Image)resources.GetObject("btndelete.Image");
            btndelete.ImageAlign = ContentAlignment.MiddleLeft;
            btndelete.Location = new Point(834, 15);
            btndelete.Name = "btndelete";
            btndelete.Size = new Size(119, 44);
            btndelete.TabIndex = 26;
            btndelete.Text = "Delete";
            btndelete.UseVisualStyleBackColor = false;
            btndelete.Click += btndelete_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = SystemColors.Control;
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageAlign = ContentAlignment.MiddleLeft;
            btnExit.Location = new Point(973, 15);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(127, 44);
            btnExit.TabIndex = 25;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnRestore
            // 
            btnRestore.BackColor = SystemColors.ButtonFace;
            btnRestore.Enabled = false;
            btnRestore.Image = (Image)resources.GetObject("btnRestore.Image");
            btnRestore.ImageAlign = ContentAlignment.MiddleLeft;
            btnRestore.Location = new Point(507, 15);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(136, 46);
            btnRestore.TabIndex = 24;
            btnRestore.Text = "Restore";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestore_Click_3;
            // 
            // btnbacup
            // 
            btnbacup.Image = (Image)resources.GetObject("btnbacup.Image");
            btnbacup.ImageAlign = ContentAlignment.MiddleLeft;
            btnbacup.Location = new Point(362, 15);
            btnbacup.Name = "btnbacup";
            btnbacup.Size = new Size(123, 46);
            btnbacup.TabIndex = 23;
            btnbacup.Text = "Backup";
            btnbacup.UseVisualStyleBackColor = true;
            btnbacup.Click += btnbacup_Click_3;
            // 
            // btnCreateDB
            // 
            btnCreateDB.BackColor = SystemColors.Control;
            btnCreateDB.Image = (Image)resources.GetObject("btnCreateDB.Image");
            btnCreateDB.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreateDB.Location = new Point(25, 15);
            btnCreateDB.Name = "btnCreateDB";
            btnCreateDB.Size = new Size(152, 46);
            btnCreateDB.TabIndex = 22;
            btnCreateDB.Text = "Create DB";
            btnCreateDB.UseVisualStyleBackColor = false;
            btnCreateDB.Click += btnCreateDB_Click_2;
            // 
            // btnCreate
            // 
            btnCreate.Image = (Image)resources.GetObject("btnCreate.Image");
            btnCreate.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreate.Location = new Point(192, 15);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(149, 46);
            btnCreate.TabIndex = 21;
            btnCreate.Text = "Table List";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click_2;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1367, -7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(143, 113);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(702, 724);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(33, 38);
            pictureBox2.TabIndex = 26;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            pictureBox2.MouseLeave += pictureBox2_MouseLeave;
            pictureBox2.MouseHover += pictureBox2_MouseHover;
            // 
            // lblsetting
            // 
            lblsetting.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblsetting.AutoSize = true;
            lblsetting.ForeColor = Color.Red;
            lblsetting.Location = new Point(738, 727);
            lblsetting.Name = "lblsetting";
            lblsetting.Size = new Size(68, 25);
            lblsetting.TabIndex = 27;
            lblsetting.Text = "Setting";
            lblsetting.Click += lblsetting_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // stbarProgress
            // 
            stbarProgress.AutoSize = false;
            stbarProgress.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            stbarProgress.ImageScalingSize = new Size(24, 24);
            stbarProgress.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            stbarProgress.Location = new Point(0, 862);
            stbarProgress.Name = "stbarProgress";
            stbarProgress.Size = new Size(1543, 32);
            stbarProgress.TabIndex = 28;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BackColor = Color.WhiteSmoke;
            toolStripStatusLabel1.ImageAlign = ContentAlignment.MiddleRight;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 25);
            // 
            // lblprogress
            // 
            lblprogress.AutoSize = true;
            lblprogress.Location = new Point(336, 730);
            lblprogress.Name = "lblprogress";
            lblprogress.Size = new Size(0, 25);
            lblprogress.TabIndex = 29;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(534, 722);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(33, 38);
            pictureBox3.TabIndex = 26;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            pictureBox3.MouseLeave += pictureBox3_MouseLeave;
            pictureBox3.MouseHover += pictureBox3_MouseHover;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(573, 728);
            label5.Name = "label5";
            label5.Size = new Size(42, 25);
            label5.TabIndex = 27;
            label5.Text = "Log";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(97, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(282, 33);
            comboBox1.TabIndex = 30;
            comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged;
            // 
            // btnadd
            // 
            btnadd.BackColor = Color.DeepSkyBlue;
            btnadd.Enabled = false;
            btnadd.ForeColor = SystemColors.ButtonHighlight;
            btnadd.Location = new Point(389, 25);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(60, 36);
            btnadd.TabIndex = 31;
            btnadd.Text = "+";
            btnadd.UseVisualStyleBackColor = false;
            btnadd.Click += button1_Click_5;
            btnadd.MouseLeave += btnadd_MouseLeave;
            btnadd.MouseHover += btnadd_MouseHover;
            // 
            // btnsubtract
            // 
            btnsubtract.BackColor = Color.Red;
            btnsubtract.Enabled = false;
            btnsubtract.ForeColor = SystemColors.ButtonFace;
            btnsubtract.Location = new Point(32, 25);
            btnsubtract.Name = "btnsubtract";
            btnsubtract.Size = new Size(57, 36);
            btnsubtract.TabIndex = 31;
            btnsubtract.Text = "-";
            btnsubtract.UseVisualStyleBackColor = false;
            btnsubtract.Click += button2_Click_2;
            btnsubtract.MouseLeave += btnsubtract_MouseLeave;
            btnsubtract.MouseHover += btnsubtract_MouseHover;
            // 
            // chkAll_Data
            // 
            chkAll_Data.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chkAll_Data.AutoSize = true;
            chkAll_Data.ForeColor = Color.Red;
            chkAll_Data.Location = new Point(1000, 724);
            chkAll_Data.Name = "chkAll_Data";
            chkAll_Data.Size = new Size(75, 29);
            chkAll_Data.TabIndex = 32;
            chkAll_Data.Text = "Data";
            chkAll_Data.UseVisualStyleBackColor = true;
            chkAll_Data.Click += chkAll_Data_Click;
            // 
            // Setting
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1543, 894);
            Controls.Add(chkAll_Data);
            Controls.Add(btnsubtract);
            Controls.Add(btnadd);
            Controls.Add(comboBox1);
            Controls.Add(lblprogress);
            Controls.Add(stbarProgress);
            Controls.Add(label5);
            Controls.Add(lblsetting);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(panel3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(lblset);
            Controls.Add(prgBar);
            Controls.Add(chkAll);
            Controls.Add(lblTables);
            Controls.Add(rdData);
            Controls.Add(rdChema);
            Controls.Add(drgViewTables);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Setting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PgSQL";
            Load += Setting_Load;
            ((System.ComponentModel.ISupportInitialize)drgViewTables).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            stbarProgress.ResumeLayout(false);
            stbarProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView drgViewTables;
        private RadioButton rdChema;
        private RadioButton rdData;
        private Label lblTables;
        private CheckBox chkAll;
        private ProgressBar prgBar;
        private Label lblset;
        private ErrorProvider errorProvider1;
        private Panel panel1;
        private Label lbldb;
        private Label lblpassword;
        private Label lblid;
        private Label lblport;
        private Label lblip;
        private TextBox dbcnn;
        private TextBox passwordcnn;
        private TextBox idcnn;
        private TextBox portcnn;
        private TextBox ipcnn;
        private Panel panel3;
        private Button btntrack;
        private Button btndelete;
        private Button btnExit;
        private Button btnRestore;
        private Button btnbacup;
        private Button btnCreateDB;
        private Button btnCreate;
        private Label label4;
        private Label label3;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Label lblpasscustomer;
        private Label lblidcustomer;
        private Label lblportcustomer;
        private Label lblipcustomer;
        private TextBox txtcustomer2;
        private TextBox txtcustomer1;
        private TextBox passwordcustomer;
        private TextBox idcustomer;
        private TextBox portcustomer;
        private TextBox ipcustomer;
        private Button btnsave;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label lblsetting;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private StatusStrip stbarProgress;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label lblprogress;
        private Label label5;
        private PictureBox pictureBox3;
        private ComboBox comboBox1;
        private Button btnsubtract;
        private Button btnadd;
        private CheckBox chkAll_Data;
    }
}