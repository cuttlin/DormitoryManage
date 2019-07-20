using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using Tools;

namespace 宿舍管理系统
{
    public partial class WFDormSch : Skin_Mac
    {
        public int Dormitory { get; set; }
        public WFDormSch(int dormitoryno)
        {
            this.Dormitory = dormitoryno;
            InitializeComponent();
        }

        private void ReLoad()
        {
            DataSet ds = DBHelper.Select("select dormitoryno,isfix from DormSum where dormitoryno='" + Dormitory + "'");
            skinDataGridView1.DataSource = ds.Tables[0].DefaultView;

            skinDataGridView1.Columns[0].HeaderText = "宿舍号";
            skinDataGridView1.Columns[1].HeaderText = "修理状态";
            if (skinDataGridView1.Rows[0].Cells[1].Value.ToString() != "维修中")
            {
                btnSuc.Enabled = false;
            }
        }

        private void WFDormSch_Load(object sender, EventArgs e)
        {
            ReLoad();
        }

        private void skinDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            skinDataGridView1.ClearSelection();
        }

        private void btnSuc_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("确定已维修？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (DBHelper.Update("update DormSum set isfix='无修理项' where dormitoryno='" + Dormitory + "'"))
                {
                    MessageBoxEx.Show("提交成功！");
                    ReLoad();
                }
            }
        }
    }
}
