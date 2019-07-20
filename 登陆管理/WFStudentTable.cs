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
    public partial class WFStudentTable : Skin_Mac
    {
        public WFStudentTable()
        {
            InitializeComponent();
        }

        private void WFStudentTable_Load(object sender, EventArgs e)
        {
            DataSet ds = DBHelper.Select("select sno,sname,sgender,bednum,checktime from StudentInfo");
            skinDataGridView1.DataSource = ds.Tables[0].DefaultView;

            skinDataGridView1.Columns[0].HeaderText = "学号";
            skinDataGridView1.Columns[1].HeaderText = "姓名";
            skinDataGridView1.Columns[2].HeaderText = "性别";
            skinDataGridView1.Columns[3].HeaderText = "床号";
            skinDataGridView1.Columns[4].HeaderText = "入学时间";

        }

        private void skinDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(skinDataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
            DataSet ds = DBHelper.Select("select * from StudentInfo where sno='" + no + "'");
            DataTable dt = ds.Tables[0];
            int dormitoryno = Convert.ToInt32(dt.Rows[0][0].ToString());

            new WFDetailedInfo(dormitoryno, skinDataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim()).ShowDialog();
        }


    }
}
