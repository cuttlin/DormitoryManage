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
    public partial class WFHld : Skin_Mac
    {
        private List<HolidayInfo> list = new List<HolidayInfo>();
        public int Sno { get; set; }
        public WFHld(int sno)
        {
            this.Sno = sno;
            InitializeComponent();
        }

        private void WFHld_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("事物表.xml");
            XmlElement Users = doc.DocumentElement;

            XmlNode xnl = Users.SelectSingleNode("/Users/student[sno='" + Sno + "']");

           
            list.Add(new HolidayInfo(Convert.ToInt32(xnl["sno"].InnerText), Convert.ToDateTime(xnl["leavetime"].InnerText),
                  Convert.ToDateTime(xnl["arrivetime"].InnerText), xnl["state"].InnerText));
            
            this.skinDataGridView1.DataSource = list;
            this.skinDataGridView1.Columns[0].HeaderText = "学号";
            this.skinDataGridView1.Columns[1].HeaderText = "离宿日期";
            this.skinDataGridView1.Columns[2].HeaderText = "回宿日期";
            this.skinDataGridView1.Columns[3].HeaderText = "状态";
            this.skinDataGridView1.Columns[0].Width = 78;
            this.skinDataGridView1.Columns[1].Width = 78;
            this.skinDataGridView1.Columns[2].Width = 78;
            this.skinDataGridView1.Columns[3].Width = 78;
        }

        private void btnSuc_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("事物表.xml");
            XmlElement Users = doc.DocumentElement;

            XmlNode xnl = Users.SelectSingleNode("/Users/student[sno='" + Sno + "']");
            xnl["state"].InnerText = "已销假";
            doc.Save("事物表.xml");
            MessageBoxEx.Show("提交成功!");
            this.Dispose();
        }
    }
}
