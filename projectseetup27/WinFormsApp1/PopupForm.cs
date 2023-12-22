using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class PopupForm : Form, Icreate
    {
        string passConfig;
        Boolean isDisplayPass;
        Form frm;
        public PopupForm(string passConfig,
                        Boolean isDisplayPass,
                        Form frm)
        {
            this.passConfig = passConfig;
            //Display password
            this.isDisplayPass = isDisplayPass;
            InitializeComponent();
            //Pass parameter to display password
            txtlogin.Text = (this.isDisplayPass ? this.passConfig : string.Empty);
            this.frm = frm;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void PopupForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //button1_Click
        //Create button
        public void create()
        {
            this.btnenter.Click += (o, e) =>
            {
                using(Service sv = new Service ())
                {
                    sv.create(txtlogin, passConfig, this);
                }
            };
        }

        public void create(string param)
        {
            throw new NotImplementedException();
        }

        public string createReturn(string param)
        {
            throw new NotImplementedException();
        }
        public void save()
        {
            throw new NotImplementedException();
        }
        public void delete()
        {
            throw new NotImplementedException();
        }
    }
}
