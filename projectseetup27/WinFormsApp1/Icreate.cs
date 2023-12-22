using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public interface Icreate
    {
        #region interface Crud
        public void create();
        public void create(string param);
        public string createReturn(string param);
        public void save();
        public void delete();
        #endregion

    }
}
