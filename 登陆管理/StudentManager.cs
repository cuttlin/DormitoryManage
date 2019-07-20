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
using System.Xml;
using System.IO;

namespace 宿舍管理系统
{
    
    public partial class StudentManager : Skin_Mac
    {
        #region 字段属性
        private WFLogin Fm;//登陆的窗体
        public int Sno { get; set; }//自己的学号
        private bool isHide = true;//标记是否隐藏通知
        private bool isChecked = false;//标记报修是否选择其他
        private string Pwd;//登录的密码
        public int Dormitoryno { get; set; }//此学生的宿舍号
        private DataSet dataset;//用于数据比对
        #endregion
        
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fm">登陆窗体</param>
        /// <param name="sno">学号</param>
        /// <param name="pwd">密码</param>
        public StudentManager(WFLogin fm,string sno,string pwd)
        {
            this.Fm = fm;
            this.Sno = Convert.ToInt32(sno);
            this.Pwd = pwd;
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentManager_Load(object sender, EventArgs e)
        {
            //操作我的信息
            DataSet ds = DBHelper.Select("select * from StudentInfo where sno='"+Sno+"'");
            this.skinDataGridView1.DataSource = ds.Tables[0].DefaultView;
            //将宿舍号记录并赋值
            Dormitoryno = Convert.ToInt32(skinDataGridView1.Rows[0].Cells[0].Value.ToString().Trim());

            this.skinDataGridView1.Columns[0].HeaderText = "宿舍号";
            this.skinDataGridView1.Columns[1].HeaderText = "学号";
            this.skinDataGridView1.Columns[2].HeaderText = "姓名";
            this.skinDataGridView1.Columns[3].HeaderText = "性别";
            this.skinDataGridView1.Columns[4].HeaderText = "床铺号";
            this.skinDataGridView1.Columns[5].HeaderText = "入住时间";
            this.skinDataGridView1.Columns[0].Width = 83;
            this.skinDataGridView1.Columns[1].Width = 83;
            this.skinDataGridView1.Columns[2].Width = 83;
            this.skinDataGridView1.Columns[3].Width = 83;
            this.skinDataGridView1.Columns[4].Width = 83;
            this.skinDataGridView1.Columns[5].Width = 83;

            this.skinDataGridView1.Enabled = false;
            
            //操作宿舍舍友信息 根据宿舍号&性别进行查询
            DataSet ds2 = DBHelper.Select("select * from StudentInfo where dormitoryno='"
                + Dormitoryno + "' and sgender='"
                + skinDataGridView1.Rows[0].Cells[3].Value.ToString().Trim() + "'");
            this.skinDataGridView2.DataSource = ds2.Tables[0].DefaultView;
            //设置datagridview2样式
            this.skinDataGridView2.Columns[0].HeaderText = "宿舍号";
            this.skinDataGridView2.Columns[1].HeaderText = "学号";
            this.skinDataGridView2.Columns[2].HeaderText = "姓名";
            this.skinDataGridView2.Columns[3].HeaderText = "性别";
            this.skinDataGridView2.Columns[4].HeaderText = "床铺号";
            this.skinDataGridView2.Columns[5].HeaderText = "入住时间";
            this.skinDataGridView2.Columns[0].Width = 84;
            this.skinDataGridView2.Columns[1].Width = 84;
            this.skinDataGridView2.Columns[2].Width = 84;
            this.skinDataGridView2.Columns[3].Width = 84;
            this.skinDataGridView2.Columns[4].Width = 84;
            this.skinDataGridView2.Columns[5].Width = 84;


            #region  通知栏代码
            XmlDocument doc = new XmlDocument();
            doc.Load("事物表.xml");
            XmlElement Users = doc.DocumentElement;

            XmlNode xnl = Users.SelectSingleNode("/Users/manager[@no='1234']");
            this.label1.Text = xnl.InnerText;
            #endregion

            dataset = DBHelper.Select("select * from DormSum where dormitoryno='" + Dormitoryno + "'");

            this.Text += this.skinDataGridView1.Rows[0].Cells[2].Value.ToString();
            this.skinTabControl1.SelectedIndex = 0;
        }

        
        #region 事件
        
        //不让datagridview被选中的代码
        private void skinDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.skinDataGridView1.ClearSelection();
        }

        //通知按钮
        private void btnUpOrDown_Click(object sender, EventArgs e)
        {
            if (isHide)
            {
                skinGroupBox1.Hide();
                btnUpOrDown.Text = "查看通知";
            }
            else if (!isHide)
            {
                skinGroupBox1.Show();
                btnUpOrDown.Text = "我知道了";
            }
            isHide = !isHide;
        }

        //控制报修 其他内容的代码
        private void skinCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = !isChecked;
            if (isChecked)
            {
                txtAreaQue.Enabled = true;
            }
            else
            {
                txtAreaQue.Enabled = false;
            }

        }

        //关闭窗口时关闭程序
        private void StudentManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Fm.Close();
        }

        //提交报修的方法
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //如果任何项都没有选择，就返回
            if (cb1.Checked == false && cb2.Checked == false && cb3.Checked == false && cb4.Checked == false && cb5.Checked == false && cb6.Checked == false && cb7.Checked == false && cb8.Checked == false)
            {
                MessageBoxEx.Show("选择您要修理的项！");
                return;
            }

            dataset = DBHelper.Select("select * from DormSum where dormitoryno='" + Dormitoryno + "'");
            if (dataset.Tables[0].Rows[0][4].ToString() == "无修理项")
            {
                string fixItem = "";
                string things = "";
                fixItem += cb1.Checked ? cb1.Text + " " : "";
                fixItem += cb2.Checked ? cb2.Text + " " : "";
                fixItem += cb3.Checked ? cb3.Text + " " : "";
                fixItem += cb4.Checked ? cb4.Text + " " : "";
                fixItem += cb5.Checked ? cb5.Text + " " : "";
                fixItem += cb6.Checked ? cb6.Text + " " : "";
                fixItem += cb7.Checked ? cb7.Text : "";

                if (cb8.Checked == true)
                {
                    things = txtAreaQue.Text.Trim();
                }

                if (DBHelper.Update("update DormSum set isfix='已提交',fixItem='" + fixItem
                    + "',things='" + things + "' where dormitoryno='" + Dormitoryno + "'"))
                {
                    MessageBoxEx.Show("提交成功！");

                    #region 重置按钮
                    cb1.Checked = false;
                    cb2.Checked = false;
                    cb3.Checked = false;
                    cb4.Checked = false;
                    cb5.Checked = false;
                    cb6.Checked = false;
                    cb7.Checked = false;
                    cb8.Checked = false;
                    txtAreaQue.Text = "请填写您的问题。。。";
                    #endregion
                }
            }
            else if (dataset.Tables[0].Rows[0][4].ToString() == "已提交" || dataset.Tables[0].Rows[0][4].ToString() == "维修中")
            {
                MessageBoxEx.Show("您的宿舍已经提交了请求，请等待。。");
            }
            else
            {
                MessageBoxEx.Show("发生未知错误！");

            }
        }

        //重置按钮
        private void btnReset_Click(object sender, EventArgs e)
        {
            cb1.Checked = false;
            cb2.Checked = false;
            cb3.Checked = false;
            cb4.Checked = false;
            cb5.Checked = false;
            cb6.Checked = false;
            cb7.Checked = false;
            cb8.Checked = false;
            txtAreaQue.Text = "请填写您的问题。。。";
        }

        //退出按钮
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //注销按钮
        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fm.ReLogin();
            Fm.Show();
            this.Dispose();
        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UpdataPwd(Sno, Pwd, "student").ShowDialog();
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            dataset = DBHelper.Select("select * from DormSum where dormitoryno='" + Dormitoryno + "'");
            if (dataset.Tables[0].Rows[0][4].ToString() == "否")
            {
                MessageBoxEx.Show("您的宿舍还没有提交修理内容！");
                return;
            }
            new WFDormSch(Dormitoryno).ShowDialog();
        }

        //提交离宿
        private void btnDate_Click(object sender, EventArgs e)
        {
            System.DateTime dt = dateTimePicker1.Value.Date;
            System.DateTime dt2 = dateTimePicker2.Value.Date;
            if (dt.CompareTo(dt2) > 0)
            {
                MessageBoxEx.Show("日期有误！");
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load("事物表.xml");
            XmlElement Users = doc.DocumentElement;

            if (Users.SelectSingleNode("/Users/student[sno='" + Sno + "']") != null)
            {
                MessageBoxEx.Show("您还有假期未消除！");
                return;
            }

            XmlElement student = doc.CreateElement("student");
            XmlElement sno = doc.CreateElement("sno");
            XmlElement leavetime = doc.CreateElement("leavetime");
            XmlElement arrivetime = doc.CreateElement("arrivetime");
            XmlElement state = doc.CreateElement("state");

            Users.AppendChild(student);
            student.AppendChild(sno);
            student.AppendChild(leavetime);
            student.AppendChild(arrivetime);
            student.AppendChild(state);

            sno.InnerText = Sno.ToString();
            leavetime.InnerText = dt.Date.ToString();
            arrivetime.InnerText = dt2.Date.ToString();
            state.InnerText = "未消假";

            doc.Save("事物表.xml");
            MessageBoxEx.Show("申请成功！");
        }

        //查看自己请假信息
        private void btnHld_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("事物表.xml");
            XmlElement Users = doc.DocumentElement;

            if (Users.SelectSingleNode("/Users/student[sno='" + Sno + "']") == null)
            {
                MessageBoxEx.Show("您已经没有请假信息！");
                return;
            }
            new WFHld(Sno).ShowDialog();
        }
        #endregion


    }
}
