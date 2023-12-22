using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class ModelProduct: dispose
    {
        #region model product to install
        public string? tablename { get; set; }
        public string? type { get; set; }
        #endregion
        #region disposal objects
        public static void DisposeListObject(IEnumerable collection)
        {
            foreach (var obj in collection.OfType<IDisposable>())
            {
                obj.Dispose();
            }
        }
        #endregion
    }
}
