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

namespace 宿舍管理系统
{
    public partial class WFFix : Skin_Mac
    {
        private DataSet dataset;
        public WFFix()
        {
            InitializeComponent();
        }

        private void WFFix_Load(object sender, EventArgs e)
        {
            dataset = DBHelper.Select("select * from DormSum where isfix='已提交'");
            ReLoad();
        }

        private void ReLoad()
        {
            DataSet ds = DBHelper.Select("select dormitoryno,fixItem,things from DormSum where isfix='已提交'");
            skinDataGridView1.DataSource = ds.Tables[0].DefaultView;

            this.skinDataGridView1.Columns[0].HeaderText = "宿舍号";
            this.skinDataGridView1.Columns[1].HeaderText = "需要修理项";
            this.skinDataGridView1.Columns[2].HeaderText = "其他问题";

            this.skinDataGridView1.Columns[0].Width = 68;
            this.skinDataGridView1.Columns[1].Width = 300;
            this.skinDataGridView1.Columns[2].Width = 300;
        }

        private void 已通知维修ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (skinDataGridView1.SelectedRows.Count == 0)
            {
                MessageBoxEx.Show("请选择要通知的项！");
                return;
            }
            int dormitoryno = Convert.ToInt32(skinDataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            if (DBHelper.Update("update DormSum set isfix='维修中' where dormitoryno='" + dormitoryno + "'"))
            {
                MessageBoxEx.Show("已通知！");
                ReLoad();
            }
            else
            {
                MessageBoxEx.Show("通知异常！");
            }
        }

    
       
    }
}
