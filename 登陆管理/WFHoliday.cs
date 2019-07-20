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
    public partial class WFHoliday : Skin_Mac
    {
        private List<HolidayInfo> list = new List<HolidayInfo>();

        public WFHoliday()
        {
            InitializeComponent();
        }

        //重新加载数据表
        private void ReLoad()
        {
            List<HolidayInfo> li = new List<HolidayInfo>();
            XmlDocument doc = new XmlDocument();
            doc.Load("事物表.xml");
            XmlElement Users = doc.DocumentElement;

            XmlNodeList xnl = Users.SelectNodes("/Users/student");

            foreach (XmlNode item in xnl)
            {
                li.Add(new HolidayInfo(Convert.ToInt32(item["sno"].InnerText), Convert.ToDateTime(item["leavetime"].InnerText),
                  Convert.ToDateTime(item["arrivetime"].InnerText), item["state"].InnerText));
            }
            this.skinDataGridView1.DataSource = li;
            this.skinDataGridView1.Columns[0].HeaderText = "学号";
            this.skinDataGridView1.Columns[1].HeaderText = "离宿日期";
            this.skinDataGridView1.Columns[2].HeaderText = "回宿日期";
            this.skinDataGridView1.Columns[3].HeaderText = "状态";
        }


        private void WFHoliday_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("事物表.xml");
            XmlElement Users = doc.DocumentElement;

            XmlNodeList xnl = Users.SelectNodes("/Users/student");
            
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

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (skinDataGridView1.SelectedRows.Count == 0)
            {
                MessageBoxEx.Show("请选择您要删除的项！");
                return;
            }
            else if (skinDataGridView1.SelectedRows[0].Cells[3].Value.ToString() != "已销假")
            {
                MessageBoxEx.Show("学生还没有销假！");
                return;
            }
           
            
            int sno = Convert.ToInt32(skinDataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            XmlDocument doc = new XmlDocument();
            doc.Load("事物表.xml");
            XmlElement Users = doc.DocumentElement;


            XmlNode xn = Users.SelectSingleNode("/Users/student[sno='" + sno + "']");
            XmlNode log = Users.SelectSingleNode("/Users/log");
            log.AppendChild(xn);
            

            doc.Save("事物表.xml");
            

            MessageBoxEx.Show("删除成功！");
            ReLoad();
        }
    }
}
