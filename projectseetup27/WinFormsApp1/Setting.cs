using Devart.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.SqlServer.Management.Assessment.Checks;
using Microsoft.SqlServer.Management.HadrData;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using Microsoft.SqlServer.Management.Smo.Wmi;
using Microsoft.VisualBasic;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static Devart.Common.Utils;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static WinFormsApp1.Setting;
using Button = System.Windows.Forms.Button;

namespace WinFormsApp1
{
    //presentation layer
    public partial class Setting : Form, Icreate, Ivalidate
    {
        #region common declare
        //Working directory
        //C:\Users\SW24\source\repos\projectseetup26\WinFormsApp1\bin\Debug\net6.0-windows\PgSql
        //Dir Backup directory
        //Logfile for track log stored Backup && Restore Working directory \ Logfile
        //logError for Track log stored at Working directory \ Logerror
        string? _dir = dispose._dir;
        string? _WorkingDirectory = dispose._WorkingDirectory;
        DataTable dt;
        string databaseName = string.Empty;
        int selectedTables = 0;
        int threadSleepBck;
        int threadSleepRst;
        string passConfig = string.Empty;
        Boolean isDisplayPass;
        List<string> list = new List<string>();
        DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
        DataGridViewCheckBoxColumn dgvData = new DataGridViewCheckBoxColumn();
        #endregion
        public Setting()
        {
            try
            {
                #region  register
                InitializeComponent();
                create(null);
                runProcess();
                track();
                save();
                delete();
                HoverButton();
                #endregion
                btntrack.Enabled = false;
                //create checkbox
                //create schema checkBox
                dgvCmb.ValueType = typeof(bool);
                dgvCmb.Name = "ChkSchema";
                dgvCmb.HeaderText = "Schema";
                //create Data checkBox
                dgvData.ValueType = typeof(bool);
                dgvData.Name = "ChkData";
                dgvData.HeaderText = "Data";

                drgViewTables.ReadOnly = ModelSetting.drGridviewReadonly;
                chkAll.Enabled = !ModelSetting.drGridviewReadonly;
                chkAll_Data.Enabled = !ModelSetting.drGridviewReadonly;

                //chkAll.Enabled = false;
                rdChema.Checked = true;
                //State of Buttons
                DisplayDisabledFunction();
                //set value for connection string
                setModelConnect(ipcustomer.Text,
                                portcustomer.Text,
                                idcustomer.Text,
                                passwordcustomer.Text,
                                ipcnn.Text,
                                portcnn.Text,
                                idcnn.Text,
                                passwordcnn.Text,
                                dbcnn.Text);
                //get customer server information 
                ipcustomer.Text = GetConfigServer<ModelConnect>(_WorkingDirectory + @"\serverConfig.xml").ip_cnn_customer_Serialize.ToString();
                portcustomer.Text = GetConfigServer<ModelConnect>(_WorkingDirectory + @"\serverConfig.xml").Port_cnn_customer_Serialize.ToString();
                idcustomer.Text = GetConfigServer<ModelConnect>(_WorkingDirectory + @"\serverConfig.xml").Id_cnn_customer_Serialize.ToString();
                passwordcustomer.Text = GetConfigServer<ModelConnect>(_WorkingDirectory + @"\serverConfig.xml").Password_cnn_customer_Serialize.ToString();
                dbcnn.Text = GetConfigServer<ModelConnect>(_WorkingDirectory + @"\serverConfig.xml").Database_cnn_Serialize.ToString();
                //get smartway server information 
                ipcnn.Text = GetConfigServer<ModelConnect>(_WorkingDirectory + @"\serverConfig.xml").ip_cnn_Serialize.ToString();
                portcnn.Text = GetConfigServer<ModelConnect>(_WorkingDirectory + @"\serverConfig.xml").Port_cnn_Serialize.ToString();
                idcnn.Text = GetConfigServer<ModelConnect>(_WorkingDirectory + @"\serverConfig.xml").Id_cnn_Serialize.ToString();
                passwordcnn.Text = GetConfigServer<ModelConnect>(_WorkingDirectory + @"\serverConfig.xml").Password_cnn_Serialize.ToString();
                //set sleep thread
                threadSleepRst = int.Parse(GetConfigServer<ModelConfig>(_WorkingDirectory + @"\savefile.xml").threadSleepRst.ToString());
                threadSleepBck = int.Parse(GetConfigServer<ModelConfig>(_WorkingDirectory + @"\savefile.xml").threadSleepBck.ToString());
                //set PassConfig
                isDisplayPass = Boolean.Parse(GetConfigServer<ModelConfig>(_WorkingDirectory + @"\savefile.xml").isDisplayPass.ToString());
                passConfig = GetConfigServer<ModelConfig>(_WorkingDirectory + @"\savefile.xml").PassConfig.ToString();
                rdChema.BackColor = System.Drawing.Color.Transparent;
                getListProduct(comboBox1);

            }
            catch (Exception ex)
            {
                using (Helper _hp = new Helper())
                {
                    _hp.writeLogFile(_WorkingDirectory + @"\logError.txt",
                     string.Format("Error {0} : {1}",
                     DateTime.Now.ToString(), ex.ToString()));
                }
                MessageBox.Show("Error");
            }
        }
        //get configuration of server
        public T GetConfigServer<T>(string path)
        {
            using (Helper _hp = new Helper())
            {
                return _hp.GetConfigServer<T>(path);
            }
        }
        //save config of server
        public void SaveConfigServerToFile<T>(T state, string _name)
        {
            using (Helper _hp = new Helper())
            {
                _hp.SaveConfigServerToFile<T>(state, _name, _WorkingDirectory + "\\" + _name);
            }
        }
        //set
        public void setModelConnect(string ip_cnn_customer,
                                    string Port_cnn_customer,
                                    string Id_cnn_customer,
                                    string Password_cnn_customer,
                                    string ip_cnn,
                                    string Port_cnn,
                                    string Id_cnn,
                                    string Password_cnn,
                                    string database_cnn)
        {
            using (Service sv = new Service())
            {
                sv.setModelConnect(ip_cnn_customer,
                                    Port_cnn_customer,
                                    Id_cnn_customer,
                                    Password_cnn_customer,
                                    ip_cnn,
                                    Port_cnn,
                                    Id_cnn,
                                    Password_cnn,
                                    database_cnn);
            }
        }
        public void HoverButton()
        {
            this.btnCreateDB.MouseHover += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Red);
                }
            };
            this.btnCreateDB.MouseLeave += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Black);
                }
            };
            //create List
            this.btnCreate.MouseHover += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Red);
                }
            };
            this.btnCreate.MouseLeave += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Black);
                }
            };

            //backup
            this.btnbacup.MouseHover += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Red);
                }
            };
            this.btnbacup.MouseLeave += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Black);
                }
            };
            //restore
            this.btnRestore.MouseHover += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Red);
                }
            };
            this.btnRestore.MouseLeave += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Black);
                }
            };

            this.btntrack.MouseHover += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Red);
                }
            };
            this.btntrack.MouseLeave += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Black);
                }
            };
            //logfile
            this.btndelete.MouseHover += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Red);
                }
            };
            this.btndelete.MouseLeave += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Black);
                }
            };
            //exit
            this.btnExit.MouseHover += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Red);
                }
            };
            this.btnExit.MouseLeave += (s, e) =>
            {
                using (Helper _hp = new Helper())
                {
                    _hp.ChangeColor((Button)s, Color.Black);
                }
            };
        }
        //Backup && Restore
        //btnbacup_Click_3
        //Backup
        //btnRestore_Click_3
        //Restore
        public void runProcess()
        {
            Task.Factory.StartNew(() =>
            {
                Process ps = new Process();
                ps.StartInfo = new ProcessStartInfo("cmd.exe")
                {
                    WorkingDirectory = _WorkingDirectory,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                ps.Start();
                this.btnbacup.Click += (s, e) =>
                {
                    using (Helper _hp = new Helper())
                    {
                        false.DisplayActiveFunction(this, btnbacup);
                        //reset connect
                        //Set config
                        setModelConnect(ipcustomer.Text,
                                           portcustomer.Text,
                                           idcustomer.Text,
                                           passwordcustomer.Text,
                                           ipcnn.Text,
                                           portcnn.Text,
                                           idcnn.Text,
                                           passwordcnn.Text,
                                           dbcnn.Text);
                        drgViewTables.ClearSelection();
                        //Process To handle backup and restore
                        //btnbacup_Click_3
                        //backup && restore
                        CreateProcess(ps, true, rdChema, e,
                        ipcustomer.Text,
                        portcustomer.Text,
                        idcustomer.Text,
                        passwordcustomer.Text,
                        ipcnn.Text,
                        portcnn.Text,
                        idcnn.Text,
                        passwordcnn.Text);
                    }
                };
                this.btnRestore.Click += (s, e) =>
                {
                    CreateProcess(ps, false, rdChema, e,
                    ipcustomer.Text,
                    portcustomer.Text,
                    idcustomer.Text,
                    passwordcustomer.Text,
                    ipcnn.Text,
                    portcnn.Text,
                    idcnn.Text,
                    passwordcnn.Text);
                };
                ps.BeginErrorReadLine();
                ps.BeginOutputReadLine();
                ps.WaitForExit();
            });
        }
        //btnbacup_Click_3
        //backup
        //btnRestore_Click_3
        //Restore
        public async void CreateProcess(Process ps,
                                       Boolean backup,
                                       RadioButton btn,
                                       EventArgs e,
                                       string ip_cnn_customer,
                                       string Port_cnn_customer,
                                       string Id_cnn_customer,
                                       string Password_cnn_customer,
                                       string ip_cnn,
                                       string Port_cnn,
                                       string Id_cnn,
                                       string Password_cnn)
        {
            using (Service sv = new Service())
            {
                sv.CreateProcess(ps,
                                 backup,
                                 btn,
                                 e,
                                 ip_cnn_customer,
                                 Port_cnn_customer,
                                 Id_cnn_customer,
                                 Password_cnn_customer,
                                 ip_cnn,
                                 Port_cnn,
                                 Id_cnn,
                                 Password_cnn,
                                 this.drgViewTables,
                                 prgBar,
                                 selectedTables,
                                 txtcustomer1,
                                 txtcustomer2,
                                 CheckDatabaseExists(ReturnDbName(btn)),
                                 threadSleepBck,
                                 dbcnn,
                                 _dir,
                                 threadSleepRst,
                                 lblset,
                                 toolStripStatusLabel1,
                                 btnbacup,
                                 btnRestore,
                                 btntrack,
                                 _WorkingDirectory + @"\logError.txt");
            }
        }
        //determine checkbox checked
        public string ReturnDbName(RadioButton btn)
        {
            using (Helper _hp = new Helper())
            {
                return _hp.ReturnDbName(btn, txtcustomer1, txtcustomer2);
            }
        }
        public DataTable returnDataTableCheckedBox(DataGridView dr)
        {
            using (Service sv = new Service())
            {
                return sv.returnDataTableCheckedBox(dr);
            }
        }
        //this function is used to identify name of functions
        public string nameofFunction(string type,
                                     string data)
        {
            return type.nameofunction(data);
        }
        public void execute_stored_procedure_function_trigger(string? sql, string? db)
        {
            try
            {
                using (Helper _hp = new Helper())
                {
                    _hp.execNonquery(sql, db);
                }
            }
            catch (Exception ex)
            {
                using (Helper _hp = new Helper())
                {
                    _hp.writeLogFile(_WorkingDirectory + @"\logError.txt",
                    string.Format("Error {0} : {1}",
                    DateTime.Now.ToString(), ex.ToString()));
                }
            }
        }
        public List<ModelProduct> _GetList(DataTableCollection ds,
                                           ListTable lst)
        {
            using (Service sv = new Service())
            {
                return sv._GetList(ds, lst);
            }
        }
        //draw background for table..
        public void drawRowGridview(DataGridView dr)
        {
            false.drawRowGridview(dr);
        }
        //check database exists
        private bool CheckDatabaseExists(string databaseName)
        {
            using (Helper _hp = new Helper())
            {
                return _hp.CheckDatabaseExists(@"SELECT 1 FROM 
                pg_database WHERE 
                datname = '" +
                databaseName.Trim().ToString() + "'",
                ModelConnect.cnn_customer());
            }
        }
        public void CreateDatabase(string dbName)
        {
            try
            {
                using (Helper _hp = new Helper())
                {
                    _hp.CreateDatabase(@"
                CREATE DATABASE " + dbName +
                    @" WITH
                OWNER = postgres
                ENCODING = 'UTF8'
                TABLESPACE = pg_default
                CONNECTION LIMIT = -1
                IS_TEMPLATE = False;",
                    ModelConnect.cnn_customer());
                }
                MessageBox.Show("Finish");
            }
            catch (Exception ex)
            {
                using (Helper _hp = new Helper())
                {
                    _hp.writeLogFile(_WorkingDirectory + @"\logError.txt",
                    string.Format("Error {0} : {1}",
                    DateTime.Now.ToString(), ex.ToString()));
                }
                MessageBox.Show(string.Format("Database {0} Existed", dbName));
            }
        }
        private void btnbacup_Click(object sender, EventArgs e)
        {
            drgViewTables.ClearSelection();
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            drgViewTables.ClearSelection();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdChema.Checked)
                {
                    DeleteDB(txtcustomer1.Text);
                }
                else
                {
                    DeleteDB(txtcustomer2.Text);
                }
            }
            catch { }
        }
        public void DeleteDB(string db)
        {
            try
            {
                using (Helper _hp = new Helper())
                {
                    _hp.DeleteDB(@"DROP DATABASE " + db, ModelConnect.cnn_customer());
                }
                MessageBox.Show("Finish");
            }
            catch
            {
                MessageBox.Show("Close and Reset PgAdmin");
            }
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {



        }
        public void CheckUncheckAll(DataGridView drg,
                                    Boolean bl,
                                    int count, string Chk)
        {
            bl.CheckUncheckAll(drg, count, Chk);
        }
        private void button1_Click_2(object sender, EventArgs e)
        {

        }
        private void btn_Click(object sender, EventArgs e)
        {
        }

        private void ipcustomer_Validating(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
            CheckIP((System.Windows.Forms.TextBox)sender, e);
        }

        private void portcustomer_Validating(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
            CheckInteger((System.Windows.Forms.TextBox)sender, e);

        }
        private void idcustomer_Validating(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
        }
        private void passwordcustomer_Validating(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
        }

        private void txtcustomer1_Validating(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
        }

        private void txtcustomer2_Validating(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
        }
        private void ipcnn_Validating(object sender, CancelEventArgs e)
        {

        }
        private void portcnn_Validating(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
            CheckInteger((System.Windows.Forms.TextBox)sender, e);
        }
        private void idcnn_Validating(object sender, CancelEventArgs e)
        {
            seterror(idcnn, e);
        }
        public void seterror(System.Windows.Forms.TextBox txt,
                             CancelEventArgs e)
        {
            using (Helper _hp = new Helper())
            {
                _hp.seterror(txt, e, errorProvider1);
            }
        }
        public void CheckInteger(System.Windows.Forms.TextBox txt,
                                 CancelEventArgs e)
        {
            using (Helper _hp = new Helper())
            {
                _hp.CheckInteger(txt, e, errorProvider1);
            }
        }
        public void CheckSpecialCharacters(System.Windows.Forms.TextBox txt,
                                  CancelEventArgs e)
        {
            using (Helper _hp = new Helper())
            {
                _hp.CheckSpecialCharacters(txt, e, errorProvider1);
            }
        }
        private void passwordcnn_Validating(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
        }
        private void dbcnn_Validating(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
        }
        private void ipcnn_TextChanged(object sender, EventArgs e)
        {

        }
        private void ipcnn_Validating_1(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
            CheckIP((System.Windows.Forms.TextBox)sender, e);
        }
        private void txtcustomer1_TextChanged(object sender, EventArgs e)
        {
            txtcustomer1.Text = txtcustomer1.Text.ToLower();
        }
        private void txtcustomer2_TextChanged(object sender, EventArgs e)
        {
            txtcustomer2.Text = txtcustomer2.Text.ToLower();

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCreateDB_Click(object sender, EventArgs e)
        {

        }
        private void btnCreate_Click_1(object sender, EventArgs e)
        {

        }
        //backup
        private void btnbacup_Click_1(object sender, EventArgs e)
        {

        }
        private void btnRestore_Click_1(object sender, EventArgs e)
        {

        }
        public dynamic getTableToTrack(DataGridView dr, string _type)
        {
            using (Service _hp = new Service())
            {
                return _hp.getTableToTrack(dr, _type);
            }
        }
        private async void btn_Click_1(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)
        {

        }
        private void ipcnn_Validating_2(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
            CheckIP((System.Windows.Forms.TextBox)sender, e);
        }

        private void portcnn_Validating_1(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
            CheckInteger((System.Windows.Forms.TextBox)sender, e);
        }
        private void idcnn_Validating_1(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);

        }
        private void passwordcnn_Validating_1(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
        }
        private void dbcnn_Validating_1(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
        }
        private void ipcustomer_Validating_1(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
            CheckIP((System.Windows.Forms.TextBox)sender, e);
        }
        private void portcustomer_Validating_1(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
            CheckInteger((System.Windows.Forms.TextBox)sender, e);
        }
        private void idcustomer_Validating_1(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
        }
        private void passwordcustomer_Validating_1(object sender, CancelEventArgs e)
        {
            seterror((System.Windows.Forms.TextBox)sender, e);
        }
        private void txtcustomer1_Validating_1(object sender, CancelEventArgs e)
        {
            CheckSpecialCharacters((System.Windows.Forms.TextBox)sender, e);
            seterror((System.Windows.Forms.TextBox)sender, e);
        }
        private void txtcustomer2_Validating_1(object sender, CancelEventArgs e)
        {
            CheckSpecialCharacters((System.Windows.Forms.TextBox)sender, e);
            seterror((System.Windows.Forms.TextBox)sender, e);
        }
        private void txtcustomer1_TextChanged_1(object sender, EventArgs e)
        {
     
        }
        private void txtcustomer2_TextChanged_1(object sender, EventArgs e)
        {

        }
        public void selectDatabase(RadioButton bt)
        {
            bt.selectDatabase(txtcustomer1,
                              txtcustomer2,
                              databaseName);

        }
        private void rdChema_CheckedChanged(object sender, EventArgs e)
        {
            selectDatabase((RadioButton)sender);
        }
        private void rdData_CheckedChanged(object sender, EventArgs e)
        {
            selectDatabase(rdChema);
        }

        public void DisplayDisabledFunction()
        {
            false.DisplayDisabledFunction(this);
        }

        public List<ModelProduct> GetSelectedItemListProduct(DataTable dt)
        {
            using (Helper _hp = new Helper())
            {
                return _hp.GetSelectedItemListProduct(dt);
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {

        }
        private void btnsave_MouseHover(object sender, EventArgs e)
        {
            using (Helper _hp = new Helper())
            {
                _hp.ChangeColor((Button)sender, Color.Red);
            }
        }
        private void btnsave_MouseLeave(object sender, EventArgs e)
        {
            using (Helper _hp = new Helper())
            {
                _hp.ChangeColor((Button)sender, Color.Black);
            }
        }
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.Run(new Setting());
        }

        private void drgViewTables_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void button1_Click_3(object sender, EventArgs e)
        {
        }
        private void btnsetting_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click_4(object sender, EventArgs e)
        {
            MessageBox.Show(drgViewTables.ReadOnly.ToString());
        }
        //setting
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (PopupForm popup = new PopupForm(this.passConfig,
                                                    isDisplayPass,
                                                    this))
            {
                popup.ShowDialog();
                drgViewTables.ReadOnly = ModelSetting.drGridviewReadonly;
                chkAll.Enabled = !ModelSetting.drGridviewReadonly;
                chkAll_Data.Enabled = !ModelSetting.drGridviewReadonly;
                btnsave.Enabled = !ModelSetting.drGridviewReadonly;
                btnadd.Enabled = !ModelSetting.drGridviewReadonly;
                btnsubtract.Enabled = !ModelSetting.drGridviewReadonly;
                btndelete.Enabled = !ModelSetting.drGridviewReadonly;
                chkAll.Refresh();
            }
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LogFile logFile = new LogFile(_WorkingDirectory + @"\logfile.txt");
            logFile.ShowDialog();
            logFile.Dispose();
        }
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;

        }
        //btnCreate_Click_2
        //Create List CheckBox
        public void create()
        {
            try
            {
                using (Service sv = new Service())
                {
                    if (drgViewTables.Columns.Count < 3)
                    {
                        drgViewTables.Columns.Add(dgvCmb);
                        drgViewTables.Columns.Add(dgvData);
                    }
                    //wait
                    Cursor = Cursors.WaitCursor;
                    //display active
                    using (Helper _hp = new Helper())
                    {
                        false.DisplayActiveFunction(this, btnCreate);
                        //set config
                        setModelConnect(ipcustomer.Text,
                                        portcustomer.Text,
                                        idcustomer.Text,
                                        passwordcustomer.Text,
                                        ipcnn.Text,
                                        portcnn.Text,
                                        idcnn.Text,
                                        passwordcnn.Text,
                                        dbcnn.Text);
                        //Create List
                        sv.create(drgViewTables, new Helper(), ModelConnect.cnn() + dbcnn.Text);
                        drawRowGridview(this.drgViewTables);
                        lblTables.Text = drgViewTables.Rows.Count.ToString() + " Objects";
                        drgViewTables.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Arrow;
                using (Helper _hp = new Helper())
                {
                    _hp.writeLogFile(_WorkingDirectory + @"\logError.txt",
                    string.Format("Error {0} : {1}",
                    DateTime.Now.ToString(), ex.ToString()));
                }
                MessageBox.Show("Check connection or server information!");
            }
        }
        //Create Database
        //btnCreateDB_Click_2
        public void create(string param)
        {
            btnCreateDB.Click += (s, e) =>
            {
                try
                {
                    using (Service checkConnect = new Service())
                    {
                        //Check connection
                        if (false.CheckInternet("8.8.8.8", 1000) ||
                           ipcustomer.Text == "127.0.0.1")
                        {
                            using (Helper _hp = new Helper())
                            {
                                if (_hp._dialog("Confirm create!!",
                                    string.Format("Are you sure to create database {0} ?",
                                    databaseName)) == DialogResult.Yes)
                                {
                                    false.DisplayActiveFunction(this, btnCreateDB);
                                    //set config
                                    setModelConnect(ipcustomer.Text,
                                               portcustomer.Text,
                                               idcustomer.Text,
                                               passwordcustomer.Text,
                                               ipcnn.Text,
                                               portcnn.Text,
                                               idcnn.Text,
                                               passwordcnn.Text,
                                               dbcnn.Text);
                                    if (rdChema.Checked)
                                    {
                                        //database only accept lower
                                        CreateDatabase(txtcustomer1.Text.ToLower());
                                    }
                                    else
                                    {
                                        CreateDatabase(txtcustomer2.Text.ToLower());
                                    }
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.Cancel;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Check connection!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    using (Helper _hp = new Helper())
                    {
                        _hp.writeLogFile(_WorkingDirectory + @"\logError.txt",
                        string.Format("Error {0} : {1}",
                        DateTime.Now.ToString(), ex.ToString()));
                    }
                    MessageBox.Show("server information!");
                }
            };
        }
        private void btnCreateDB_Click_1(object sender, EventArgs e)
        {

        }
        private void btnbacup_Click_2(object sender, EventArgs e)
        {

        }

        private void btnRestore_Click_2(object sender, EventArgs e)
        {
            using (Helper _hp = new Helper())
            {
                false.DisplayActiveFunction(this, btnRestore);
                //reset connect
                setModelConnect(ipcustomer.Text,
                                   portcustomer.Text,
                                   idcustomer.Text,
                                   passwordcustomer.Text,
                                   ipcnn.Text,
                                   portcnn.Text,
                                   idcnn.Text,
                                   passwordcnn.Text,
                                   dbcnn.Text);
                drgViewTables.ClearSelection();
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {

        }
        //btnsave_Click
        //Save config
        public void save()
        {
            this.btnsave.Click += (o, e) =>
            {
                try
                {
                    using (Helper _hp = new Helper())
                    {
                        setModelConnect(ipcustomer.Text,
                                       portcustomer.Text,
                                       idcustomer.Text,
                                       passwordcustomer.Text,
                                       ipcnn.Text,
                                       portcnn.Text,
                                       idcnn.Text,
                                       passwordcnn.Text,
                                       dbcnn.Text);
                        if (_hp._dialog("Confirm create!!",
                            "Do you want to save?") == DialogResult.Yes)
                        {
                            SaveConfigServerToFile<ModelConnect>(ModelConnect.myInstance(), @"\serverConfig.xml");
                            saveProduct(GetSelectedItemListProduct(returnDataTableCheckedBox(this.drgViewTables)));
                            SaveConfigServerToFile<List<string>>(comboBox1.Items.Cast<object>().Select(x => x.ToString()).ToList(), @"\ListProduct.xml");
                            ModelConnect.DisposeInstance();
                            MessageBox.Show("Finish");
                        }
                    }
                }
                catch (Exception ex)
                {
                    using (Helper _hp = new Helper())
                    {
                        _hp.writeLogFile(_WorkingDirectory + @"\logError.txt",
                        string.Format("Error {0} : {1}",
                        DateTime.Now.ToString(), ex.ToString()));
                    }
                    MessageBox.Show("error");
                }
            };
        }
        private void Btnsave_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        string Icreate.createReturn(string param)
        {
            throw new NotImplementedException();
        }
        //btndelete_Click
        //Delete button
        public void delete()
        {
            this.btndelete.Click += (o, e) =>
            {
                try
                {
                    using (Helper _hp = new Helper())
                    {
                        setModelConnect(ipcustomer.Text,
                                       portcustomer.Text,
                                       idcustomer.Text,
                                       passwordcustomer.Text,
                                       ipcnn.Text,
                                       portcnn.Text,
                                       idcnn.Text,
                                       passwordcnn.Text,
                                       dbcnn.Text);
                        if (_hp._dialog("Confirm Delete!!",
                            string.Format("Are you sure to delete database {0} ?",
                            databaseName)) == DialogResult.Yes)
                        {
                            if (rdChema.Checked)
                            {
                                DeleteDB(txtcustomer1.Text);
                            }
                            else
                            {
                                DeleteDB(txtcustomer2.Text);
                            }
                        }
                        else
                        {
                            this.DialogResult = DialogResult.Cancel;
                        }
                    }
                }
                catch (Exception ex)
                {
                    using (Helper _hp = new Helper())
                    {
                        _hp.writeLogFile(_WorkingDirectory + @"\logError.txt",
                        string.Format("Error {0} : {1}",
                        DateTime.Now.ToString(), ex.ToString()));
                    }
                    MessageBox.Show("Error");
                }
            };
        }
        //btntrack_Click
        //Track backup && Restore
        public async void track()
        {
            //btntrack.Click += (s, e) =>
            //{
            //    using (Service sv = new Service())
            //    {
            //        sv.track_logfile(btnbacup,
            //                        btntrack,
            //                        _WorkingDirectory + @"\logfile.txt",
            //                        this,
            //                        this.drgViewTables,
            //                        ReturnDbName(rdChema),
            //                        ipcustomer.Text,
            //                        portcustomer.Text,
            //                        idcustomer.Text,
            //                        passwordcustomer.Text,
            //                        ipcnn.Text,
            //                        portcnn.Text,
            //                        idcnn.Text,
            //                        passwordcnn.Text,
            //                        dbcnn.Text);
            //    }
            //};
        }
        private async void btntrack_Click(object sender, EventArgs e)
        {
        }
        //combo product
        private void button1_Click_5(object sender, EventArgs e)
        {
            if (comboBox1.Text != string.Empty)
            {
                if (comboBox1.Items.Cast<object>().Select(x => x.ToString()).ToList().All(x => x.Equals(comboBox1.Text) == false))
                {
                    comboBox1.Items.Add(comboBox1.Text);
                }
            }
        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            comboBox1.Items.Remove(comboBox1.Text);
        }
        private void button3_Click(object sender, EventArgs e)
        {

            SaveConfigServerToFile<List<string>>(comboBox1.Items.Cast<object>().Select(x => x.ToString()).ToList(), @"\ListProduct.xml");
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
        public void getListProduct(System.Windows.Forms.ComboBox cb)
        {
            GetConfigServer<List<string>>(_WorkingDirectory + @"\ListProduct.xml").ForEach(item =>
            {
                cb.Items.Add(item);
            });
        }
        public void SaveListProduct(List<string> lst)
        {
            lst.ForEach(item =>
            {
                comboBox1.Items.Add(item.ToString());
            });
        }
        public void saveProduct(List<ModelProduct> lstproduct)
        {
            string fileName = comboBox1.Text;
            SaveConfigServerToFile<List<ModelProduct>>(lstproduct, fileName + ".xml");
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string fileName = comboBox1.Text;
                false.CheckUncheckAllMix(this.drgViewTables, this.drgViewTables.Rows.Count, "ChkSchema", "ChkData");
                foreach (var lst in GetConfigServer<List<ModelProduct>>(_WorkingDirectory + "\\" + fileName + ".xml"))
                {
                    foreach (DataGridViewRow row in drgViewTables.Rows)
                    {
                        if (lst.tablename.ToString().Substring(0, lst.tablename.ToString().Length - 2).Equals(row.Cells["tablename"].Value.ToString()))
                        {
                            if (lst.tablename.ToString().Contains("_T"))
                            {
                                row.Cells["ChkData"].Value = true;
                            }
                            else if(lst.tablename.ToString().Contains("_F"))
                            {
                                row.Cells["ChkSchema"].Value = true;

                            }
                        }
                    }
                }
                drgViewTables.ClearSelection();
            }
            catch (Exception ex)
            {
                using (Helper _hp = new Helper())
                {
                    _hp.writeLogFile(_WorkingDirectory + @"\logError.txt",
                    string.Format("Error {0} : {1}",
                    DateTime.Now.ToString(), ex.ToString()));
                    //MessageBox.Show("error");
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void btnCreate_Click_2(object sender, EventArgs e)
        {
            try
            {
                //Create List
                create();
                //Move Column
                //Schema 
                //Data
                drgViewTables.Columns[0].DisplayIndex = 2;
                drgViewTables.Columns[1].DisplayIndex = 3;
                drgViewTables.Columns[0].Width = 80;
                drgViewTables.Columns[1].Width = 80;
                drgViewTables.Columns[2].Width = 700;
                drgViewTables.Columns[2].DisplayIndex = 0;
                drgViewTables.Columns[3].DisplayIndex = 1;
                if (e != null)
                    chkAll.Checked = false;
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex) { }
        }
        private void lblsetting_Click(object sender, EventArgs e)
        {

        }
        private void btnadd_MouseHover(object sender, EventArgs e)
        {
            using (Helper _hp = new Helper())
            {
                _hp.ChangeColor((Button)sender, Color.Red);
            }
        }

        private void btnadd_MouseLeave(object sender, EventArgs e)
        {
            using (Helper _hp = new Helper())
            {
                _hp.ChangeColor((Button)sender, Color.White);
            }
        }
        private void btnsubtract_MouseHover(object sender, EventArgs e)
        {
            using (Helper _hp = new Helper())
            {
                _hp.ChangeColor((Button)sender, Color.Red);
            }
        }
        private void btnsubtract_MouseLeave(object sender, EventArgs e)
        {
            using (Helper _hp = new Helper())
            {
                _hp.ChangeColor((Button)sender, Color.White);
            }
        }
        // btnCreateDB.Click
        private void btnCreateDB_Click_2(object sender, EventArgs e)
        {
            txtcustomer1.Text = txtcustomer1.Text.ToLower();
        }
        private void drgViewTables_Click(object sender, EventArgs e)
        {

        }
        private void chkAll_Click(object sender, EventArgs e)
        {
            btnCreate_Click_2(null, null);
            if (chkAll.Checked)
            {
                true.CheckUncheckAll(this.drgViewTables, this.drgViewTables.Rows.Count, "ChkSchema");
            }
            else
            {

                false.CheckUncheckAll(this.drgViewTables, this.drgViewTables.Rows.Count, "ChkSchema");
            }
            chkAll_Data.Checked = false;

        }

        private void drgViewTables_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {


        }

        private void button1_Click_6(object sender, EventArgs e)
        {

        }
        private void drgViewTables_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        public void CheckIP(System.Windows.Forms.TextBox txt, CancelEventArgs e)
        {
            using (Helper _hp = new Helper())
            {
                _hp.CheckIP(txt, e, errorProvider1);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click_7(object sender, EventArgs e)
        {
        }

        private void button1_Click_8(object sender, EventArgs e)
        {


        }

        private void button2_Click_3(object sender, EventArgs e)
        {

        }

        private void btnbacup_Click_3(object sender, EventArgs e)
        {
            txtcustomer1.Text = txtcustomer1.Text.ToLower();
        }

        private void btnRestore_Click_3(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }
        private void Setting_Load(object sender, EventArgs e)
        {

        }
        static void TestFunc(dynamic dvar)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void chkAll_Data_Click(object sender, EventArgs e)
        {
            btnCreate_Click_2(null, null);
            if (chkAll_Data.Checked)
            {
                true.CheckUncheckAll(this.drgViewTables, this.drgViewTables.Rows.Count, "ChkData");
            }
            else
            {

                false.CheckUncheckAll(this.drgViewTables, this.drgViewTables.Rows.Count, "ChkData");

            }
            chkAll.Checked = false;

        }

        private void portcustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_9(object sender, EventArgs e)
        {
        }

        private void button1_Click_10(object sender, EventArgs e)
        {

            using (Helper _hp = new Helper())
            {
                setModelConnect(ipcustomer.Text,
                               portcustomer.Text,
                               idcustomer.Text,
                               passwordcustomer.Text,
                               ipcnn.Text,
                               portcnn.Text,
                               idcnn.Text,
                               passwordcnn.Text,
                               dbcnn.Text);
                if (_hp._dialog("Confirm create!!",
                    "Do you want to save?") == DialogResult.Yes)
                {

                    SaveConfigServerToFile<ModelConnect>(ModelConnect.myInstance(), @"\serverConfig.xml");
                    saveProduct(GetSelectedItemListProduct(returnDataTableCheckedBox(this.drgViewTables)));
                    SaveConfigServerToFile<List<string>>(comboBox1.Items.Cast<object>().Select(x => x.ToString()).ToList(), @"\ListProduct.xml");
                    ModelConnect.DisposeInstance();
                    MessageBox.Show("Finish");
                }
            }


        }
    }
}
