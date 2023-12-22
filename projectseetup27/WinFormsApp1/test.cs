using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct,
                       AllowMultiple = true)]
    public class testAttribute : System.Attribute
    {
        string _Name;
        public double Version;
        public testAttribute(string name)
        {
            _Name = name;

            // Default value.
            Version = 1.0;
        }

        public string GetName() => _Name;
    }
}
