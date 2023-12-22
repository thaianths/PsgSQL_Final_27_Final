using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class dispose:IDisposable
    {
        #region common properties for all services, presentations
        //Directory backup
        public static string?_dir = AppDomain.CurrentDomain.BaseDirectory + "backup\\";
        //PostgeSQL directory
        public static string? _WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "PgSql";
        #endregion
        public void Dispose()
        {
            GC.Collect();
            //GC.SuppressFinalize(this);
        }
    }
}
