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
    public partial class WFManager : Skin_Mac
    {
        private WFLogin Fm;//登录窗体
        private int No;//学号
        private string Pwd;//密码

        
        public WFManager(WFLogin fm,string no,string pwd)
        {
            this.Fm = fm;
            this.No = Convert.ToInt32(no);
            this.Pwd = pwd;
            InitializeComponent();
        }

        private void WFManager_Load(object sender, EventArgs e)
        {
            //设置默认选择项为第一项
            this.cbbFirst.SelectedIndex = 0;
            this.cbbSecond.SelectedIndex = 0;

            SelectAll("select floor,dormitoryno,gender,checknum,isfix from DormSum");
        }

        //查询总表
        private void SelectAll(string str)
        {
            DataSet ds = DBHelper.Select(str);
            this.skinDataGridView1.DataSource = ds.Tables[0].DefaultView;

            this.skinDataGridView1.Columns[0].HeaderText = "楼层";
            this.skinDataGridView1.Columns[1].HeaderText = "宿舍号";
            this.skinDataGridView1.Columns[2].HeaderText = "性别";
            this.skinDataGridView1.Columns[3].HeaderText = "入住人数";
            this.skinDataGridView1.Columns[4].HeaderText = "修理状态";
        }

        //上方的按钮查询
        private void btnEbd_Click(object sender, EventArgs e)
        {
            #region 一坨筛选代码
            if (cbbFirst.SelectedIndex == 0 && cbbSecond.SelectedIndex == 0)//全部全部
            {
                SelectAll("select floor,dormitoryno,gender,checknum,isfix from DormSum");
            }
            else if (cbbFirst.SelectedIndex == 1 && cbbSecond.SelectedIndex == 0)//男 全部
            {
                SelectAll("select floor,dormitoryno,gender,checknum,isfix from DormSum where gender='男'");
            }
            else if (cbbFirst.SelectedIndex == 2 && cbbSecond.SelectedIndex == 0)//女 全部
            {
                SelectAll("select floor,dormitoryno,gender,checknum,isfix from DormSum where gender='女'");
            }
            else if (cbbFirst.SelectedIndex == 1 && cbbSecond.SelectedIndex == 1)//男 一层
            {
                SelectAll("select floor,dormitoryno,gender,checknum,isfix from DormSum where floor=1 and gender='男'");
            }
            else if (cbbFirst.SelectedIndex == 1 && cbbSecond.SelectedIndex == 2)//男 二层
            {
                SelectAll("select floor,dormitoryno,gender,checknum,isfix from DormSum where floor=2 and gender='男'");
            }
            else if (cbbFirst.SelectedIndex == 2 && cbbSecond.SelectedIndex == 1)//女 一层
            {
                SelectAll("select floor,dormitoryno,gender,checknum,isfix from DormSum where floor=1 and gender='女'");
            }
            else if (cbbFirst.SelectedIndex == 2 && cbbSecond.SelectedIndex == 2)//女 二层
            {
                SelectAll("select floor,dormitoryno,gender,checknum,isfix from DormSum where floor=2 and gender='女'");
            }
            else if (cbbFirst.SelectedIndex == 0 && cbbSecond.SelectedIndex == 1)//全部 一层
            {
                SelectAll("select floor,dormitoryno,gender,checknum,isfix from DormSum where floor=1");
            }
            else if (cbbFirst.SelectedIndex == 0 && cbbSecond.SelectedIndex == 2)//全部 二层
            {
                SelectAll("select floor,dormitoryno,gender,checknum,isfix from DormSum where floor=2");
            }
            #endregion
        }

        private void WFManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Fm.Close();
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fm.ReLogin();
            Fm.Show();
            this.Dispose();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 宿舍详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WFDetailedInfo(Convert.ToInt32(skinDataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim()), skinDataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim()).ShowDialog();
        }

        
        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UpdataPwd(No, Pwd,"manager").ShowDialog();
        }

        //通知按钮
        private void btnNotice_Click(object sender, EventArgs e)
        {
            new WFMessage(No).ShowDialog();
        }

        //修理按钮
        private void btnFix_Click(object sender, EventArgs e)
        {
            new WFFix().ShowDialog();
        }

        //请假按钮
        private void btnHoliday_Click(object sender, EventArgs e)
        {
            new WFHoliday().ShowDialog();
        }

        //双击表格行打开宿舍信息表
        private void skinDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new WFDetailedInfo(Convert.ToInt32(skinDataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim()), skinDataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim()).ShowDialog();
        }

        //查看学生总表
        private void 学生总表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WFStudentTable().ShowDialog();
        }

        private void 离宿记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WFLog().ShowDialog();
        }
    }
}
