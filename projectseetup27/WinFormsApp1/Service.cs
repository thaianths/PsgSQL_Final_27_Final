using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace WinFormsApp1
{
      //common controller layer
    internal class Service : dispose
    {
        //btnCreate_Click_2
        #region setting
        public void create(DataGridView dr,
                           Helper _hp,
                           string connect)
        {

            DataSet ds = new DataSet();
            ListTable modelList = new ListTable();
            String sqlUnion = @"SELECT tablename,'table' AS type FROM pg_catalog.pg_tables where schemaname = 'public'
                               UNION ALL
                               SELECT table_name AS tablename, 'view' as type
                               FROM information_schema.views
                               WHERE  table_schema = 'public'";
            String sqlFunction = @"SELECT pg_get_functiondef(f.oid) AS tablename,'procedure_function_trigger' AS type
                               FROM pg_catalog.pg_proc f
                               INNER JOIN pg_catalog.pg_namespace n ON (f.pronamespace = n.oid)
                               WHERE n.nspname = 'public'";
            ds.Tables.Add(_hp._GetDataTable(connect, sqlUnion));
            ds.Tables.Add(_hp._GetDataTable(connect, sqlFunction));
            _GetList(ds.Tables, modelList);
            //display grid
            dr.DataSource = modelList.OrderByDescending(x => x.type == "table").ToList();
            dr.Columns[1].Width = 515;
            dr.Columns[2].Width = 350;
            dr.ClearSelection();
            ModelProduct.DisposeListObject(modelList);
        }
        public ListTable _GetList(DataTableCollection ds,
                                  ListTable lst)
        {
            foreach (DataTable dt in ds)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    lst.Add(new ModelProduct()
                    {
                        tablename = dtRow["tablename"].ToString(),
                        type = (dtRow["type"].ToString() == "procedure_function_trigger" ?
                        nameofFunction("procedure_function_trigger",
                        dtRow["tablename"].ToString()) : dtRow["type"].ToString())
                    });
                }
            }
            return lst;
        }
        public string nameofFunction(string type,
                                    string data)
        {
            string rs = string.Empty;
            if (type == "procedure_function_trigger")
            {
                if (data.Contains("procedure"))
                {
                    rs = "procedure";
                }
                else if (data.Contains("trigger"))
                {
                    rs = "trigger";
                }
                else
                {
                    rs = "function";
                }
            }
            return rs;
        }
        public dynamic getTableToTrack(DataGridView dr,
                                       string _type)
        {
            DataTable _dt = new DataTable();
            _dt.Columns.Add("tablename", typeof(string));
            _dt.Columns.Add("type", typeof(string));
            DataRow _dr;
            for (int i = 0; i < dr.Rows.Count; i++)
            {
                   if (dr.Rows[i].Cells["ChkSchema"].Value != null ||
                       dr.Rows[i].Cells["ChkData"].Value != null)
                    {
                        if (dr.Rows[i].Cells["type"] != null)
                        {
                            if (dr.Rows[i].Cells["type"].Value.ToString().Contains(_type))
                            {
                                _dr = _dt.NewRow();
                                _dr["tablename"] = dr.Rows[i].Cells["tablename"].Value.ToString();
                                _dr["type"] = dr.Rows[i].Cells["type"].Value.ToString();
                                _dt.Rows.Add(_dr);
                            }
                        }
                    }
            }
            return _dt;
        }
        //Edit
        public DataTable returnDataTableCheckedBox(DataGridView dr)
        {
            DataTable _dt = new DataTable();
            _dt.Columns.Add("tablename", typeof(string));
            _dt.Columns.Add("type", typeof(string));
            _dt.Columns.Add("btnRadio", typeof(string));
            DataRow _dr;
            for (int i = 0; i < dr.Rows.Count; i++)
            {
                if (dr.Rows[i].Cells["ChkData"].Value!= null &&
                   (bool)dr.Rows[i].Cells["ChkData"].Value)
                {
                            _dr = _dt.NewRow();
                            _dr["tablename"] = dr.Rows[i].Cells["tablename"].Value.ToString();
                            _dr["type"] = dr.Rows[i].Cells["type"].Value.ToString();
                            _dr["btnRadio"] = true;
                            _dt.Rows.Add(_dr);
                }
                else if (dr.Rows[i].Cells["ChkSchema"].Value != null && 
                    (bool)dr.Rows[i].Cells["ChkSchema"].Value)
                {
                            _dr = _dt.NewRow();
                            _dr["tablename"] = dr.Rows[i].Cells["tablename"].Value.ToString();
                            _dr["type"] = dr.Rows[i].Cells["type"].Value.ToString();
                            _dr["btnRadio"] = false;
                            _dt.Rows.Add(_dr);
                }
            }
            return _dt;
        }
        //table used for log
        public DataTable GetDataTable(string connect,
                                      string sqlList,
                                      string path)
        {
            try
            {
                using (Helper _hp = new Helper())
                {
                    return _hp._GetDataTable(connect, sqlList);

                }
            }
            catch (Exception ex)
            {
                using (Helper _hp = new Helper())
                {
                    _hp.writeLogFile(path,
                    string.Format("Error {0} : {1}",
                    DateTime.Now.ToString(), ex.ToString()));
                }
                return null;
            }
        }

        public DataTable NotrestoredTables(DataTable source,
                                          string sql,
                                          string obj,
                                          string path,
                                          string ReturnDbName)
        {
            try
            {
                //Create datatable to raise warning
                DataTable dtb = new DataTable();
                dtb.Columns.Add("tablename", typeof(string));
                dtb.Columns.Add("type", typeof(string));
                string rs = string.Empty;
                if (source != null)
                {
                    foreach (DataRow r in source.Rows)
                    {
                      DataRowCollection? _row = GetDataTable(ModelConnect.cnn_customer() + ReturnDbName, sql, path).Rows;
                        Boolean t = false;
                        if (_row!=null)
                        {
                            foreach (DataRow _r in _row)
                            {
                                if (_r["tablename"].ToString() == r["tablename"].ToString() &&
                                     r["type"].ToString() == obj)
                                {
                                    t = true;
                                }
                            }
                        }
                        if (t == false)
                        {
                            DataRow row = dtb.NewRow();
                            row["tablename"] = r["tablename"].ToString();
                            row["type"] = r["type"].ToString();
                            dtb.Rows.Add(row);
                        }
                    }
                }
                return dtb;
            }
            catch { return null; }
        }

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
            ModelConnect.ip_cnn_customer = ip_cnn_customer;
            ModelConnect.Port_cnn_customer = Port_cnn_customer;
            ModelConnect.Id_cnn_customer = Id_cnn_customer;
            ModelConnect.Password_cnn_customer = Password_cnn_customer;
            ModelConnect.ip_cnn = ip_cnn;
            ModelConnect.Port_cnn = Port_cnn;
            ModelConnect.Id_cnn = Id_cnn;
            ModelConnect.Password_cnn = Password_cnn;
            ModelConnect.Database_cnn = database_cnn;
        }
        internal void comboBox1_SelectedValueChanged(System.Windows.Forms.ComboBox cb,
                                                   DataGridView dr,
                                                   List<ModelProduct> lst,
                                                   string path)
        {
            try
            {
                string fileName = cb.Text;
                dr.ClearSelection();
                for (int i = 0; i < dr.Rows.Count; i++)
                {
                    foreach (var item in lst)
                    {
                        if (dr.Rows[i].Cells["tablename"].Value.ToString().Equals(item.tablename.ToString()) &&
                            dr.Rows[i].Cells["type"].Value.ToString().Equals(item.type.ToString()))
                        {
                            dr.Rows[i].Cells["ChkSchema"].Value = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (Helper _hp = new Helper())
                {
                    _hp.writeLogFile(path,
                    string.Format("Error {0} : {1}",
                    DateTime.Now.ToString(), ex.ToString()));
                }
                MessageBox.Show("error");
            }
        }
        //btnbacup_Click_3
        //Backup
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
                                        string Password_cnn,
                                        DataGridView dr,
                                        System.Windows.Forms.ProgressBar pb,
                                        int selectedTables,
                                        System.Windows.Forms.TextBox txtcustomer1,
                                        System.Windows.Forms.TextBox txtcustomer2,
                                        bool CheckDatabaseExists,
                                        int threadSleepBck,
                                        System.Windows.Forms.TextBox dbcnn,
                                        string _dir,
                                        int threadSleepRst,
                                        Label lblset,
                                        ToolStripStatusLabel toolStripStatusLabel1,
                                        System.Windows.Forms.Button btnbacup,
                                        System.Windows.Forms.Button btnRestore,
                                        System.Windows.Forms.Button btntrack,
                                        string path)
        {
            int count = 0;
            pb.Minimum = 0;
            selectedTables = returnDataTableCheckedBox(dr).Rows.Count;
           
            pb.Maximum = selectedTables;
            
            try
            {
                using (Helper _hp = new Helper())
                {
                    //check database exist
                    if (CheckDatabaseExists)
                    {
                        //check checkbox of table checked
                        if (returnDataTableCheckedBox(dr).Rows.Count > 0)
                        {
                            
                            foreach (DataRow row in returnDataTableCheckedBox(dr).Rows)
                            {
                                await Task.Run(() =>
                                {
                                    //Backup
                                    if (backup)
                                    {
                                        ps.StandardInput.WriteLine(@"set PGPASSWORD=" + Password_cnn);
                                        if (row["type"].ToString() == "table" ||
                                            row["type"].ToString() == "view")
                                        {
                                            //schema only
                                            if (!Boolean.Parse(row["btnRadio"].ToString()))
                                            {
                                                ps.StandardInput.WriteLine("pg_dump -h " + ip_cnn + " -p " + Port_cnn + " -U " + Id_cnn + " --schema-only --format=c -d " + dbcnn.Text + " -t " + "public." + row["tablename"].ToString() + " > " + _dir + "public." + row["tablename"].ToString() + ".sql");
                                            }
                                            else //data
                                            {
                                                ps.StandardInput.WriteLine("pg_dump -h " + ip_cnn + " -p " + Port_cnn + " -U " + Id_cnn + " --format=c -d " + dbcnn.Text + " -t " + "public." + row["tablename"].ToString() + " > " + _dir + row["tablename"].ToString() + ".sql");
                                            }
                                        }
                                        ps.StandardInput.Flush();
                                        Thread.Sleep(threadSleepBck);
                                    }
                                    else
                                    {
                                        ps.StandardInput.WriteLine(@"set PGPASSWORD=" + Password_cnn_customer);
                                        //Restore
                                        //stored procedure  
                                        //schema
                                        if (!Boolean.Parse(row["btnRadio"].ToString()))
                                        {
                                            if ((row["type"].ToString() == "procedure") ||
                                                (row["type"].ToString() == "function") ||
                                                (row["type"].ToString() == "trigger"))
                                            {
                                                using (Helper _hp = new Helper())
                                                {
                                                    _hp.execNonquery(row["tableName"].ToString(), txtcustomer1.Text.ToLower());
                                                }
                                                //execute_stored_procedure_function_trigger(row["tableName"].ToString(), txtcustomer1.Text.ToLower());
                                            }
                                            else
                                            {
                                                ps.StandardInput.WriteLine("pg_restore  -h " + ip_cnn_customer + " -p  " + Port_cnn_customer + " -U " + Id_cnn_customer + " -v -d " + txtcustomer1.Text + " " + _dir + "public." + row["tablename"].ToString() + ".sql");
                                            }
                                        }
                                        else
                                        {
                                            if ((row["type"].ToString() == "procedure") ||
                                                (row["type"].ToString() == "function") ||
                                                (row["type"].ToString() == "trigger"))
                                            {
                                                using (Helper _hp = new Helper())
                                                {
                                                    _hp.execNonquery(row["tableName"].ToString(), txtcustomer1.Text.ToLower());
                                                }
                                                //==============================================CHECK===========================
                                            }
                                            else
                                            {
                                                ps.StandardInput.WriteLine("pg_restore  -h " + ip_cnn_customer + "  -p  " + Port_cnn_customer + " -U " + Id_cnn_customer + " -v -d " + txtcustomer1.Text + " " + _dir + row["tablename"].ToString() + ".sql");
                                            }
                                        }
                                        ps.StandardInput.Flush();
                                        Thread.Sleep(threadSleepRst);
                                    }
                                });
                                count += 1;
                                toolStripStatusLabel1.Text = row["tableName"].ToString();
                                pb.Value = count;
                                lblset.Text = ((count * 100) / selectedTables).ToString() + " %";
                            }
                            if (btnbacup.Enabled)
                            {
                                btnbacup.Enabled = false;
                                btnRestore.Enabled = true;
                            }
                            else
                            {
                                btnbacup.Enabled = true;
                                btnRestore.Enabled = false;
                                btntrack.Enabled = true;
                            }
                            MessageBox.Show(string.Format("Finish {0} objects",
                            count.ToString()));
                            toolStripStatusLabel1.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Select Objects");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Database not exist");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                using (Helper _hp = new Helper())
                {
                    _hp.writeLogFile(path,
                    string.Format("Error {0} : {1}",
                    DateTime.Now.ToString(), ex.ToString()));
                }
                MessageBox.Show("Error");
            }
        }
        //btntrack_Click
        //Track backup && Restore
        internal async void track_logfile(System.Windows.Forms.Button btnbacup,
        System.Windows.Forms.Button btntrack,
        string path,
        Form frm,
        DataGridView dr,
        string ReturnDbName,
        string ipcustomer,
        string portcustomer,
        string idcustomer,
        string passwordcustomer,
        string ipcnn,
        string portcnn,
        string idcnn,
        string passwordcnn,
        string dbcnn)
        {
            try
            {
                string _infor = string.Empty;
                btnbacup.Enabled = true;
                btntrack.Enabled = false;
                using (Helper _hp = new Helper())
                {
                //_hp.DisplayActiveFunction(btntrack, frm, path);
                false.DisplayActiveFunction(new Setting(), btntrack);
                setModelConnect(ipcustomer,
                                portcustomer,
                                idcustomer,
                                passwordcustomer,
                                ipcnn,
                                portcnn,
                                idcnn,
                                passwordcnn,
                                dbcnn);
                    DataTable dtTrack = new DataTable();
                    //Track table
                    dtTrack = NotrestoredTables(getTableToTrack(dr, "table"),
                                                                @"SELECT tablename,
                                                                tableowner FROM pg_catalog.pg_tables
                                                                where schemaname = 'public'", "table",path,ReturnDbName);
                    await Task.Run(() =>
                    {
                        if (dtTrack != null)
                        {
                            if (dtTrack.Rows.Count > 0)
                            {
                                foreach (DataRow r in dtTrack.Rows)
                                {
                                    MessageBox.Show(r["tablename"].ToString() + "." + r["type"].ToString());
                                }
                            }
                            else
                            {
                                _infor = getTableToTrack(dr, "table")
                               .Rows.Count.ToString();
                                _hp.writeLogFile(path,
                                string.Format("Database {0} Time {1} finished {2} {3}",
                                ReturnDbName,
                                DateTime.Now.ToString(),
                                _infor, " tables"));
                                MessageBox.Show("Finish " + _infor + " tables");
                            }
                        }
                    });
                    dtTrack = NotrestoredTables(getTableToTrack(dr, "view"),
                              @"SELECT table_schema AS chema_name, table_name AS tablename
                              FROM information_schema.views
                              WHERE  table_schema = 'public'", "view",path,ReturnDbName);
                    await Task.Run(() =>
                    {
                        if (dtTrack.Rows.Count > 0)
                        {
                            //Track View
                            foreach (DataRow r in dtTrack.Rows)
                            {
                                MessageBox.Show(r["tablename"].ToString() + "." + r["type"].ToString());
                            }
                        }
                        else
                        {
                            _infor = getTableToTrack(dr, "view")
                            .Rows.Count.ToString();
                            using (Helper _hp = new Helper())
                            {
                                _hp.writeLogFile(path,
                                 string.Format("Database {0} Time {1} finished {2} {3}",
                                 ReturnDbName,
                                 DateTime.Now.ToString(), _infor, " Views"));
                            }
                            MessageBox.Show("Finish " + _infor
                            + " Views");
                        }
                    });
                    string sql_proce_func_trig = @"SELECT pg_get_functiondef(f.oid) AS tablename
                                 FROM pg_catalog.pg_proc f
                                 INNER JOIN pg_catalog.pg_namespace n ON (f.pronamespace = n.oid)
                                 WHERE n.nspname = 'public'";
                    dtTrack = NotrestoredTables(getTableToTrack(dr, "procedure"),
                                 sql_proce_func_trig, "procedure",path,ReturnDbName);
                    await Task.Run(() =>
                    {
                        if (dtTrack.Rows.Count > 0)
                        {
                            //Track Stored Procedure
                            foreach (DataRow r in dtTrack.Rows)
                            {
                                MessageBox.Show(r["tablename"].ToString() + "." + r["type"].ToString());
                            }
                        }
                        else
                        {
                            _infor = getTableToTrack(dr, "procedure")
                            .Rows.Count.ToString();
                            using (Helper _hp = new Helper())
                            {
                                _hp.writeLogFile(path,
                                string.Format("Database {0} Time {1} finished {2} {3}",
                                ReturnDbName, DateTime.Now.ToString(),
                                _infor, " procedures"));
                            }
                            MessageBox.Show("Finish " + _infor +
                                             " procedures");
                        }
                    });
                    dtTrack = NotrestoredTables(getTableToTrack(dr, "function"),
                             sql_proce_func_trig, "function",path,ReturnDbName);
                    await Task.Run(() =>
                    {
                        if (dtTrack.Rows.Count > 0)
                        {
                            //Track function
                            foreach (DataRow r in dtTrack.Rows)
                            {
                                MessageBox.Show(r["tablename"].ToString() + "." + r["type"].ToString());
                            }
                        }
                        else
                        {
                            _infor = getTableToTrack(dr, "function")
                           .Rows.Count.ToString();
                            using (Helper _hp = new Helper())
                            {
                               _hp.writeLogFile(path,
                               string.Format("Database {0} Time {1} finished {2} {3}",
                               ReturnDbName, DateTime.Now.ToString(), _infor, " functions"));
                            }
                            MessageBox.Show("Finish " + _infor + " functions");
                        }
                    });
                    dtTrack = NotrestoredTables(getTableToTrack(dr, "trigger"),
                              sql_proce_func_trig, "trigger",path,ReturnDbName);
                    await Task.Run(() =>
                    {
                        if (dtTrack.Rows.Count > 0)
                        {
                            //Track trigger
                            foreach (DataRow r in dtTrack.Rows)
                            {
                                MessageBox.Show(r["tablename"].ToString() + "." + r["type"].ToString());
                            }
                        }
                        else
                        {
                            _infor = getTableToTrack(dr, "trigger")
                           .Rows.Count.ToString();
                            using (Helper _hp = new Helper())
                            {
                                _hp.writeLogFile(path,
                                 string.Format("Database {0} Time {1} finished {2} {3}",
                                 ReturnDbName, DateTime.Now.ToString(), _infor, " triggers"));
                            }
                            MessageBox.Show("Finish " + _infor + " triggers");
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                using (Helper _hp = new Helper())
                {
                    _hp.writeLogFile(path,
                    string.Format("Error {0} : {1}",
                    DateTime.Now.ToString(), ex.ToString()));
                }
            }
        }
        #endregion
        #region logfife
        public string createReturn(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            string rs = string.Empty;
            foreach (string line in lines)
            {
                rs += line;
            }
            return rs;
        }
        #endregion
        #region popup
        public void create(System.Windows.Forms.TextBox txtlogin,
        string passConfig,Form frm)
        {
            try
            {
                if (txtlogin.Text == passConfig)
                {
                    ModelSetting.drGridviewReadonly = false;
                    frm.Close();
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
        #endregion
    }
}

