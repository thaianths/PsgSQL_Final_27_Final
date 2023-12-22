using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinFormsApp1
{
    //common helper for all services
    public class Helper : dispose
    {
        public DialogResult _dialog(string title,
                                    string message)
        {
            DialogResult confirmResult = MessageBox.Show(message,
                                                         title,
                                         MessageBoxButtons.YesNo);
            return confirmResult;
        }
        public DataTable _GetDataTable(string connect,
                                       string sqlList)
        {
            DataTable _dt = new DataTable();
            using (NpgsqlConnection Connection = new NpgsqlConnection(connect))
            {
                Connection.Open();
                using (NpgsqlCommand objcmd = new NpgsqlCommand(sqlList, Connection))
                {
                    NpgsqlDataAdapter adp = new NpgsqlDataAdapter(objcmd);
                    adp.Fill(_dt);
                }
                Connection.Close();
            }
            return _dt;
        }
        //==================================
        public void execNonquery(string sql, string? db)
        {
            try
            {
                using (NpgsqlConnection connect = new NpgsqlConnection(ModelConnect.cnn_customer() + db))
                {
                    connect.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }
            } catch (Exception ex) { }
        }
        public bool CheckDatabaseExists(string sql,
                                        string connect)
        {
            string sqlCreateDBQuery;
            bool result = false;
            var tmpConn = new NpgsqlConnection(connect);
            sqlCreateDBQuery = sql;
            using (tmpConn)
            {
                using (NpgsqlCommand sqlCmd = new NpgsqlCommand(sqlCreateDBQuery, tmpConn))
                {
                    tmpConn.Open();
                    object? resultObj = sqlCmd.ExecuteScalar();
                    int databaseID = 0;
                    if (resultObj != null)
                    {
                        int.TryParse(resultObj.ToString(), out databaseID);
                    }
                    tmpConn.Close();
                    result = (databaseID > 0);
                }
            }
            return result;
        }
        public void CreateDatabase(string sql, string connect)
        {
            var m_conn = new NpgsqlConnection(connect);
            var m_createdb_cmd = new NpgsqlCommand(sql, m_conn);
            m_conn.Open();
            m_createdb_cmd.ExecuteNonQuery();
            m_conn.Close();
        }
        public void DeleteDB(string sql, string connect)
        {

            var m_conn = new NpgsqlConnection(connect);
            var m_createdb_cmd = new NpgsqlCommand(sql, m_conn);
            m_conn.Open();
            m_createdb_cmd.ExecuteNonQuery();
            m_conn.Close();
        }
        public void seterror(System.Windows.Forms.TextBox txt,
                        CancelEventArgs e,
                        ErrorProvider err)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                err.SetError(txt, "required!");
                e.Cancel = true;
            }
            else
            {
                err.SetError(txt, null);
                e.Cancel = false;
            }
        }
        public void CheckIP(System.Windows.Forms.TextBox txt,
                            CancelEventArgs e,
                            ErrorProvider err)
        {
            Boolean rs = false;
            rs = Regex.IsMatch(txt.Text, "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            if (!rs)
            {
                err.SetError(txt, "Invalid IP!");
                e.Cancel = true;
            }
            else
            {
                err.SetError(txt, null);
                e.Cancel = false;
            }
        }
        public void CheckInteger(System.Windows.Forms.TextBox txt,
                                 CancelEventArgs e,
                                 ErrorProvider err)
        {

            if (!int.TryParse(txt.Text, out int value))
            {
                err.SetError(txt, "Invalid value!");
                e.Cancel = true;
            }
            else
            {
                err.SetError(txt, null);
                e.Cancel = false;
            }
        }
        public void CheckSpecialCharacters(System.Windows.Forms.TextBox txt,
                                           CancelEventArgs e, ErrorProvider err)
        {
            if (txt.Text.Contains(".") ||
               (txt.Text.Contains("-")))
            {
                err.SetError(txt, "invalid value!");
                e.Cancel = true;
            }
            else
            {
                err.SetError(txt, null);
                e.Cancel = false;
            }
        }
        public List<ModelProduct> GetSelectedItemListProduct(DataTable dt)
        {
            try
            {
                List<ModelProduct> lst = new List<ModelProduct>();
                foreach(DataRow r in dt.Rows)
                {
                    lst.Add(new ModelProduct()
                    {
                        tablename = Boolean.Parse(r["btnRadio"].ToString())?r["tablename"].ToString() + "_T" : r["tablename"].ToString() + "_F",
                        type = r["type"].ToString()
                    });
                }
                return lst;
            }
            catch
            {
                return null;
            }
        }
        public void writeLogFile(string path, string content)
        {
            // If file does not exists
            if (!System.IO.File.Exists(path))
            {
                System.IO.File.Create(path).Close();
                using (StreamWriter sw = System.IO.File.AppendText(path))
                {
                    sw.WriteLine(content);
                }
            }
            else // If file already exists
            {
                using (StreamWriter sw = System.IO.File.AppendText(path))
                {
                    sw.WriteLine(content);
                }
            }
        }
        public void SaveConfigServerToFile<T>(T state,
                                              string _name,
                                              string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writeFileStream = new StreamWriter(path))
            {
             serializer.Serialize(writeFileStream, state);
            }
        }
        public T GetConfigServer<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using ( FileStream readFileStream = new FileStream(path,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read))
            {
            return (T)serializer.Deserialize(readFileStream);
            }
        }
        public void ChangeColor(Button button,
                                 System.Drawing.Color color)
        {
            button.ForeColor = color;
        }
        public string ReturnDbName(RadioButton btn,
                                   TextBox txtcustomer1,
                                   TextBox txtcustomer2)
        {
         return (btn.Checked? txtcustomer1.Text.ToLower():
                              txtcustomer2.Text.ToLower());
        }
    }
    public class ListTable : List<ModelProduct>,IDisposable
    {
        public new void Add(ModelProduct item)
        {
            base.Add(item);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

}
