using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    #region static helper for services, presentations
    public static class staticHelper
    {
        public static string nameofunction(this string type, string data)
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
        public static Boolean CheckUncheckAll(this Boolean bl,
                                              DataGridView drg,
                                              int count,
                                              string Chk)
        {
          
            foreach (DataGridViewRow row in drg.Rows)
            {
                row.Cells[Chk].Value = bl;
            }
            return bl;
        }
        public static Boolean CheckUncheckAllMix(this Boolean bl,
                                             DataGridView drg,
                                             int count,
                                             string Chk,
                                             string _ChkData)
        {

            foreach (DataGridViewRow row in drg.Rows)
            {
                row.Cells[Chk].Value = bl;
                row.Cells[_ChkData].Value = bl;
            }

            return bl;
        }
        public static Boolean drawRowGridview(this Boolean rs,
                                               DataGridView dr)
        {
            try
            {
                foreach (DataGridViewRow row in dr.Rows)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    switch (row.Cells["type"].Value.ToString())
                    {
                        case "table":
                            row.DefaultCellStyle.BackColor = Color.Snow;
                            row.DefaultCellStyle.ForeColor = Color.Blue;
                            break;
                        case "view":
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            row.DefaultCellStyle.BackColor = Color.LightCyan;
                            break;
                        case "procedure":
                            row.DefaultCellStyle.ForeColor = Color.Chocolate;
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "function":
                            row.DefaultCellStyle.ForeColor = Color.Blue;
                            row.DefaultCellStyle.BackColor = Color.Wheat;
                            break;
                        case "trigger":
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Boolean DisplayDisabledFunction(this Boolean bl,
                                                      Form frm)
        {
            try
            {
                foreach (Control control in frm.Controls)
                {
                    if (control.GetType() == typeof(Panel))
                    {
                        var panel = control as Panel;
                        foreach (var pan in panel.Controls)
                        {
                            if (pan.GetType() == typeof(Button))
                            {
                                var button = pan as Button;
                                button.BackColor = Color.LightGray;
                            }
                        }

                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Boolean DisplayActiveFunction(this Boolean bl, 
                                                    Form frm,
                                                    Button bt)
        {
            try
            {
                foreach (Control control in frm.Controls)
                {
                    if (control.GetType() == typeof(Panel))
                    {
                        var panel = control as Panel;
                        foreach (var pan in panel.Controls)
                        {
                            if (pan.GetType() == typeof(Button))
                            {
                                var button = pan as Button;
                                if (button.Name == bt.Name)
                                {
                                    button.BackColor = Color.LightYellow;
                                    button.ForeColor = Color.Red;
                                }
                                else
                                {
                                    button.BackColor = Color.LightGray;

                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Boolean CheckInternet(this Boolean bl,
                                            string ip,
                                            int timeout)
        {
            Ping myPing = new Ping();
            Predicate<PingReply> _replay = delegate (PingReply reply)
            {
            return (reply.Status == IPStatus.Success);
            };
            return _replay(myPing.Send(ip, timeout));
        }
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
            {
            yield return enumerator.Current;
            }
        }
        public static void selectDatabase(this RadioButton chk,
                                             System.Windows.Forms.TextBox txtcustomer1,
                                             System.Windows.Forms.TextBox txtcustomer2,
                                             String databaseName)
        {
                if (chk.Checked)
                {
                    txtcustomer1.BackColor = Color.LightYellow;
                    txtcustomer2.BackColor = Color.White;
                    databaseName = txtcustomer1.Text;
                }
                else
                {
                    databaseName = txtcustomer2.Text;
                    txtcustomer2.BackColor = Color.LightYellow;
                    txtcustomer1.BackColor = Color.White;
                }
        }
    }
    #endregion
}


