using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections;

namespace SettingPsql
{
    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }

    class ClassC : IClassC
    {
        public ClassC() => MessageBox.Show("ClassC is created");
        public void ActionC() => MessageBox.Show("Action in ClassC");
    }

    class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC classc)
        {
            c_dependency = classc;
            MessageBox.Show("ClassB is created");
        }
        public void ActionB()
        {
            MessageBox.Show("Action in ClassB");
            c_dependency.ActionC();
        }
    }


    class ClassA
    {
        IClassB b_dependency;
        public ClassA(IClassB classb)
        {
            b_dependency = classb;
            MessageBox.Show("ClassA is created");
        }
        public void ActionA()
        {
            MessageBox.Show("Action in ClassA");
            b_dependency.ActionB();
        }
    }
    public class MyServiceOptions
    {
        public string data1 { get; set; }
        public int data2 { get; set; }
    }
    public class MyService
    {
        public string data1 { get; set; }
        public int data2 { get; set; }

        // Tham số khởi tạo là IOptions, các tham số khởi tạo khác nếu có khai báo như bình thường
        public MyService(IOptions<MyServiceOptions> options)
        {
            // Đọc được MyServiceOptions từ IOptions
            MyServiceOptions opts = options.Value;
            data1 = opts.data1;
            data2 = opts.data2;
        }
        public void PrintData()=>MessageBox.Show($"{data1} / {data2}");
    }
    public partial class Form1 : Form
    {
        private object services;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> lst = new List<int>()
            {
                1,2,3,4
            };
            lst.Add(5);
            lst.Insert(0, 11);
            lst.InsertRange(0, new List<int>() { 12, 13, 14, 15, 16 });
            lst.AddRange(new List<int>() { 6, 7, 8, 9, 10 });
            lst.Reverse();
            foreach(int item in lst)
            {
                MessageBox.Show(item.ToString());
            }

            //ClassC objectC = new ClassC();
            //ClassB objectB = new ClassB(objectC);
            //ClassA objectA = new ClassA(objectB);
            //ServiceCollection services = new ServiceCollection();
            //ServiceCollection ser = new ServiceCollection();
            //ser.AddSingleton<IClassB, ClassB>();
            //ser.AddTransient<IClassC, ClassC>();
            //ser.AddScoped<IClassB, ClassB>();
            //var scope = ser.BuildServiceProvider();
            //var scp = scope.CreateScope();
            //using(var sc = scope.CreateScope())
            //{
            //    for(int i=0;i<services.Count; i++)
            //    {
            //        var _s = sc.ServiceProvider.GetService<IClassB>();
            //    }
            //}
            //services.AddSingleton<IClassC, ClassC>();
            //var provider = ser.BuildServiceProvider();
            //var objservice = provider.GetService<IClassC>();
            //MessageBox.Show(objservice.GetHashCode().ToString());
            ////var provider = services.BuildServiceProvider();

            //for (int i = 0; i < 5; i++) 
            //{
            //    var service = provider.GetService<IClassC>();
            //    MessageBox.Show(service.GetHashCode().ToString());
            //}
            ServiceCollection _ser = new ServiceCollection();
            _ser.AddSingleton<MyService, MyService>();
            _ser.Configure<MyServiceOptions>(
            option =>
            {
                option.data1 = "xinc hao ban fvfefvbqefbeq";
                option.data2 = 2011;
                
            });
            var pro = _ser.BuildServiceProvider();
            var myser = pro.GetService<MyService>();
            myser.PrintData();
            //services.Configure<MyServiceOptions>(
            //options => {
            //options.data1 = "Xin chao cac ban";
            //options.data2 = 2021;
            //}
            //);

            //services.AddSingleton<MyService>();
            //var provider = services.BuildServiceProvider();

            //var myservice = provider.GetService<MyService>();
            //myservice.PrintData();
            Dictionary<string, int> dic = new Dictionary<string, int>()
            {
                ["key1"] = 1,
                ["key2"] = 2

            };
            dic["key3"] = 3;
            var keys = dic.Keys;
            foreach(var k in keys)
            {
                MessageBox.Show(k.ToString());
            }
            foreach(KeyValuePair<string, int> kvp in dic)
            {
                MessageBox.Show(kvp.Key.ToString());
                MessageBox.Show(kvp.Value.ToString());
            }
            HashSet<int> list = new HashSet<int>()
          {
              1, 2, 3,  4, 5, 6
          };
            foreach(var k in list)
            {
                MessageBox.Show(k.ToString());

            }
            Hashtable ht = new Hashtable(); 
            ht.Add("key1", 1);
            ht.Add("key2", 2);

            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}