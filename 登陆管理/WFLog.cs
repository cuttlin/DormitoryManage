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
    public partial class WFLog : Skin_Mac
    {
        List<HolidayInfo> list = new List<HolidayInfo>();//用于加载数据
        public WFLog()
        {
            InitializeComponent();
        }

        private void WFLog_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"事物表.xml");
            XmlElement Users = doc.DocumentElement;

            XmlNodeList xnl = Users.SelectNodes("/Users/log/student");

            foreach (XmlNode item in xnl)
            {
                list.Add(new HolidayInfo(Convert.ToInt32(item["sno"].InnerText), Convert.ToDateTime(item["leavetime"].InnerText),
                  Convert.ToDateTime(item["arrivetime"].InnerText), item["state"].InnerText));
            }

            this.skinDataGridView1.DataSource = list;
            this.skinDataGridView1.Columns[0].HeaderText = "学号";
            this.skinDataGridView1.Columns[1].HeaderText = "离宿日期";
            this.skinDataGridView1.Columns[2].HeaderText = "回宿日期";
            this.skinDataGridView1.Columns[3].HeaderText = "状态";
        }
    }
}
