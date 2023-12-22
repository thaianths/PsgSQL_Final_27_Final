using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class ModelConfig: dispose
    {
        #region model config
        public int? threadSleepBck { get; set; }
        public int? threadSleepRst { get; set; }
        public string? PassConfig { get; set; }
        public Boolean isDisplayPass { get; set; }
        #endregion

    }
}
