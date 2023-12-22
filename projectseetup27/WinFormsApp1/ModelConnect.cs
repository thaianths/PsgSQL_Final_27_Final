using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    [Serializable]
    public class ModelConnect: dispose
    {
        #region model configuration
        //client
        public static string? ip_cnn_customer { get; set; }
        public static string? Port_cnn_customer { get; set; }
        public static string? Id_cnn_customer { get; set; }
        public static string? Password_cnn_customer { get; set; }
        //smartway
        public static string? ip_cnn { get; set; }
        public static string? Port_cnn { get; set; }
        public static string? Id_cnn { get; set; }
        public static string? Password_cnn { get; set; }
        public static string? Database_cnn { get; set; }
        #endregion
        #region serialize
        //wrap static property
        //client Serialize
        public string ip_cnn_customer_Serialize { get { return ip_cnn_customer; } set { ip_cnn_customer = value; } }
        public string Port_cnn_customer_Serialize { get { return Port_cnn_customer; } set { Port_cnn_customer = value; } }
        public string Id_cnn_customer_Serialize { get { return Id_cnn_customer; } set { Id_cnn_customer = value; } }
        public string Password_cnn_customer_Serialize { get { return Password_cnn_customer; } set { Password_cnn_customer = value; } }
        public string Database_cnn_Serialize { get { return Database_cnn; } set { Database_cnn = value; } }
        //wrap static property
        //client smartway
        public string ip_cnn_Serialize { get { return ip_cnn; } set { ip_cnn = value; } }
        public string Port_cnn_Serialize { get { return Port_cnn; } set { Port_cnn = value; } }
        public string Id_cnn_Serialize { get { return Id_cnn; } set { Id_cnn = value; } }
        public string Password_cnn_Serialize { get { return Password_cnn; } set { Password_cnn = value; } }
        #endregion
        private static ModelConnect _myInstance;
        static ModelConnect()
        {
            _myInstance = new ModelConnect();
        }
        public static string cnn_customer()
        {
            return String.Format(@"Server={0};Port={1};User Id={2};Password={3};Database=", 
                   ip_cnn_customer, 
                   Port_cnn_customer,
                   Id_cnn_customer, 
                   Password_cnn_customer);
        }
        public static string cnn()
        {
            return String.Format(@"Server={0};Port={1};User Id={2};Password={3};Database=",
                   ip_cnn,
                   Port_cnn,
                   Id_cnn,
                   Password_cnn);
        }
        //To get instance this class
        public static ModelConnect myInstance()
        {
            return _myInstance;
        }
        //to destroy 
        public static void DisposeInstance()
        {
            if (_myInstance != null)
            {
                _myInstance.Dispose();
            }
        }
    }
}
