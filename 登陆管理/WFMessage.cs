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

namespace 宿舍管理系统
{
    public partial class WFMessage : Skin_Mac
    {
        private int No { get; set; }//记录管理员的帐号
        private string Notice { get; set; }//记录发布的消息
        public WFMessage(int no)
        {
            this.No = no;
            InitializeComponent();
        }

        private void WFMessage_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("事物表.xml");
            XmlElement Users = doc.DocumentElement;

            XmlNode xnl = Users.SelectSingleNode("/Users/manager[@no='" + No + "']");
            Notice = xnl["notice"].InnerText;
            this.skinWaterTextBox1.Text = Notice;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("事物表.xml");
            XmlElement Users = doc.DocumentElement;

            XmlNode xnl = Users.SelectSingleNode("/Users/manager[@no='" + No + "']");
            Notice = xnl["notice"].InnerText = this.skinWaterTextBox1.Text.Trim();

            doc.Save("事物表.xml");
            MessageBoxEx.Show("发布成功！");
            this.Dispose();
        }
    }
}
