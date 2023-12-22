using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public interface Ivalidate
    {
        #region interface validation
        public void seterror(TextBox txtBox, CancelEventArgs e);
        public void CheckIP(TextBox txt, CancelEventArgs e);
        public void CheckInteger(TextBox txt,CancelEventArgs e);
        public void CheckSpecialCharacters(TextBox txt,CancelEventArgs e);
        #endregion
    }
}
