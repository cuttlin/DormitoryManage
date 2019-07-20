using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CCWin;
using System.Xml;
using System.Collections;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace 宿舍管理系统
{
    public partial class UpdataPwd : Skin_Mac
    {
        string Pwd;
        int Sno;
        public string Type { get; set; }
        public UpdataPwd(int sno,string pwd,string type)
        {
            this.Sno = sno;
            this.Pwd = pwd;
            this.Type = type;
            InitializeComponent();
        }

        

        private void BtnEbdPwd_Click(object sender, EventArgs e)
        {
            MD5 md5 = MD5.Create();
            byte[] buf2 = Encoding.Default.GetBytes(TextOldPwd.Text.Trim());
            byte[] newBuf2 = md5.ComputeHash(buf2);
            StringBuilder sb2 = new StringBuilder();
            for (int j = 0; j < newBuf2.Length; j++)
            {
                sb2.Append(newBuf2[j].ToString("x2"));
            }
            this.Pwd = sb2.ToString();
            XmlDocument doc = new XmlDocument();
            doc.Load("用户登录表.xml");
            XmlElement Users = doc.DocumentElement;
            ////获得根节点
            //XmlElement books = doc.DocumentElement;

            //////获得子节点 返回节点的集合
            //XmlNodeList xnl = books.ChildNodes;

            //foreach (XmlNode item in xnl)
            //{
            //    Console.WriteLine(item["no"].InnerText);
            //}
            //Console.ReadKey();

            XmlNode xn;
            bool flag = (Type == "student") ? true : false;
            if (flag)
            {
                xn = Users.SelectSingleNode("/Users/student[no='" + Sno + "']");
            }
            else
            {
                xn = Users.SelectSingleNode("/Users/manager[no='" + Sno + "']");
            }
            
            byte[] buf = Encoding.Default.GetBytes(TextOldPwd.Text.Trim());
            byte[] newBuf = md5.ComputeHash(buf);
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < newBuf.Length; j++)
            {
                sb.Append(newBuf[j].ToString("x2"));
            }
            string md5Pwd = sb.ToString();
             if (md5Pwd == xn["psw"].InnerText)
            {
                if(TextNewPwd.Text==" ")
                {
                    LblNewpwd.Text = "*请输入有效字符为密码";
                    TextNewPwd.Text = "";
                    return;
                }
                else
                {
                    if (TextNewPwd.Text.ToString().IndexOf(" ") >= 0)
                    {
                        LblNewpwd.Text = "*请输入有效字符为密码";
                        TextNewPwd.Text = "";
                        TextEbdPwd.Text = "";
                        LblOldpwd.Text = "";
                        LblEbdpwd.Text = "";
                        return;
                    }
                    else if (TextNewPwd.Text.Trim() == TextEbdPwd.Text.Trim())
                    {
                        byte[] buf1 = Encoding.Default.GetBytes(TextEbdPwd.Text.Trim());
                        byte[] newBuf1 = md5.ComputeHash(buf1);
                        StringBuilder sb1 = new StringBuilder();
                        for (int j = 0; j < newBuf1.Length; j++)
                        {
                            sb1.Append(newBuf1[j].ToString("x2"));
                        }
                        string md5Pwd1 = sb1.ToString();
                        xn["psw"].InnerText = md5Pwd1;
                        doc.Save("用户登录表.xml");
                        MessageBoxEx.Show("修改成功");
                        this.Dispose();
                    }
                    else
                    {
                        LblEbdpwd.Text = "*两次密码不相同，请重新输入";
                        TextEbdPwd.Text = "";
                        LblOldpwd.Text = "";
                        LblNewpwd.Text = "";
                        
                        return;
                    }
                }
                
            }
             else
            {
                LblOldpwd.Text = "*密码输入错误，请重新输入";
                TextOldPwd.Text = "";
                LblNewpwd.Text = "";
                LblEbdpwd.Text = "";
                return;
            }
            
        }

        private void UpdataPwd_Load(object sender, EventArgs e)
        {
            this.LblUser.Text = Sno + "";
        }

        

        
    }
}
