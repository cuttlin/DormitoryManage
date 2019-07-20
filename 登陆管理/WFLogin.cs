using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Xml;
using Tools;
using System.Threading;
using System.Runtime.InteropServices;

namespace 宿舍管理系统
{

    public partial class WFLogin : Skin_Mac
    {

        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果 
        //旧的多线程代码
        public static void popStart()
        {
            Application.Run(new WFPop());
        }
        public static ThreadStart pop = new ThreadStart(popStart);
        Thread popThread = new Thread(pop);
        private List<User> list = new List<User>();
        public WFLogin()
        {
            InitializeComponent();
        }
        public void ReLogin()
        {
            list.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"用户登录表.xml");
            XmlElement Users = doc.DocumentElement;
            XmlNodeList xnl = Users.ChildNodes;
            foreach (XmlNode item in xnl)
            {
                if (item.Name == "student")
                {
                    list.Add(new User(Convert.ToInt32(item["no"].InnerText), item["psw"].InnerText, "student"));
                }
                else if (item.Name == "manager")
                {
                    list.Add(new User(Convert.ToInt32(item["no"].InnerText), item["psw"].InnerText, "manager"));

                }
            }
        }

        private void WFLogin_Load(object sender, EventArgs e)
        {
            //淡入淡出效果
            AnimateWindow(this.Handle, 1000, AW_ACTIVE);
            this.FormClosing += (a, b) => { AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE); };
            //用户登录
            XmlDocument doc = new XmlDocument();
            doc.Load(@"用户登录表.xml");
            XmlElement Users = doc.DocumentElement;
            XmlNodeList xnl = Users.ChildNodes;
            foreach (XmlNode item in xnl)
            {
                if (item.Name == "student")
                {
                    list.Add(new User(Convert.ToInt32(item["no"].InnerText), item["psw"].InnerText, "student"));
                }
                else if (item.Name == "manager")
                {
                    list.Add(new User(Convert.ToInt32(item["no"].InnerText), item["psw"].InnerText, "manager"));

                }
            }
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {

            //判断用户登录时输入空的情况
            if (TextSno.Text.Trim() == "" || TextPwd.Text.Trim() == "")
            {
                MessageBoxEx.Show("登录失败");
                return;
            }
            else if (TextSno.Text.Trim() == "" && TextPwd.Text.Trim() == "")
            {
                MessageBoxEx.Show("登录失败");
                return;
            }
            string password = MyMD5.myMD5(TextPwd.Text.Trim());

            if (RdoStudent.Checked)
            {
                List<User> listStu = list.FindAll(u => u.Type.Equals("student"));
                for (int i = 0; i < listStu.Count; i++)
                {
                    if (listStu[i].Sno.ToString() == TextSno.Text.Trim() && listStu[i].Pwd == password)
                    {
                        Thread popThread = new Thread(pop);
                        
                        new StudentManager(this, listStu[i].Sno.ToString(), password).Show();
                        this.Hide();
                        popThread.Start();
                        //new WFPop().Show();
                        return;
                    }
                    else if (i == listStu.Count - 1)
                    {
                        MessageBoxEx.Show("登录失败");
                        return;
                    }
                }
            }
            else
            {
                List<User> listMag = list.FindAll(u => u.Type.Equals("manager"));

                for (int i = 0; i < listMag.Count; i++)
                {
                    if (listMag[i].Sno.ToString() == TextSno.Text.Trim() && listMag[i].Pwd == password)
                    {
                        Thread popThread = new Thread(pop);
                        new WFManager(this, listMag[i].Sno.ToString(), password).Show();
                        this.Hide();
                        popThread.Start();
                        //new WFPop().Show();
                        return;
                    }
                    else if (i == listMag.Count - 1)
                    {
                        MessageBoxEx.Show("登录失败");
                        return;
                    }
                }
            } 
        }
    }
}
