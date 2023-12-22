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
    public partial class LogFile : Form, Icreate
    {
        string path;
        public LogFile(string path)
        {
            this.path = path;
            InitializeComponent();
        }
        private void LogFile_Load(object sender, EventArgs e)
        {
            create();
        }
        public void create()
        {
            rstLogFile.Text = createReturn(path);
        }

        public void create(string param)
        {
            throw new NotImplementedException();
        }

        public string createReturn(string path)
        {
            using (Service sv = new Service())
            {
                return sv.createReturn(path);
            }
        }
        public void save()
        {
            throw new NotImplementedException();
        }

        public void delete()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {



        }
    }
}
