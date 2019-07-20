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

namespace 宿舍管理系统
{
    public partial class WFDetailedInfo : Skin_Mac
    {
        private int Dormitorymo;//宿舍号
        private bool isAdd;//标记是添加 true 还是修改 false
        public string Sex { get; set; }//性别
        public WFDetailedInfo(int dormitoryno,string sex)
        {
            this.Dormitorymo = dormitoryno;
            this.Sex = sex;
            InitializeComponent();
        }

        private void reLoad()
        {
            DataSet ds = DBHelper.Select("select * from StudentInfo where dormitoryno='" + Dormitorymo + "'");
            this.skinDataGridView1.DataSource = ds.Tables[0].DefaultView;

            this.skinDataGridView1.Columns[0].HeaderText = "宿舍号";
            this.skinDataGridView1.Columns[1].HeaderText = "学号";
            this.skinDataGridView1.Columns[2].HeaderText = "姓名";
            this.skinDataGridView1.Columns[3].HeaderText = "性别";
            this.skinDataGridView1.Columns[4].HeaderText = "床铺号";
            this.skinDataGridView1.Columns[5].HeaderText = "入住时间";
            if (this.Sex != "男")
            {
                rdoWoman.Checked = true;
            }
        }

        private void WFDetailedInfo_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void 增加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (skinDataGridView1.Rows.Count >= 4)
            {
                MessageBoxEx.Show("宿舍已满!");
                return;
            }
            txtNo.Enabled = true;
            skinDataGridView1.Enabled = false;
            isAdd = true;
            skinGroupBox1.Text = "增加";
            skinGroupBox1.Enabled = true;
            
            toCbbValue();
            cbbBedNo.SelectedIndex = 0;
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (skinDataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("选择您要修改的学生！");
                return;
            }
            skinDataGridView1.Enabled = false;
            isAdd = false;
            skinGroupBox1.Text = "修改";
            skinGroupBox1.Enabled = true;

            //修改时不允许操作主键学号
            txtNo.Enabled = false;

            //默认赋值操作
            txtNo.Text = skinDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtName.Text = skinDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            

            //下拉选赋值代码
            toCbbValue();
            cbbBedNo.Items.Add(skinDataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            cbbBedNo.SelectedIndex = 0;
        }

        //下拉选赋值代码
        private void toCbbValue()
        {
            //清空
            cbbBedNo.Items.Clear();

            int[] tempArr = new int[4] { 1, 2, 3, 4 };//用于校对下拉选赋值
            for (int i = 0; i < skinDataGridView1.Rows.Count; i++)
            {
                if (skinDataGridView1.Rows[i].Cells[4].Value.ToString() == "1")
                {
                    tempArr[0] = 0;
                }
                else if (skinDataGridView1.Rows[i].Cells[4].Value.ToString() == "2")
                {
                    tempArr[1] = 0;
                }
                else if (skinDataGridView1.Rows[i].Cells[4].Value.ToString() == "3")
                {
                    tempArr[2] = 0;
                }
                else if (skinDataGridView1.Rows[i].Cells[4].Value.ToString() == "4")
                {
                    tempArr[3] = 0;
                }
            }
            for (int i = 0; i < tempArr.Length; i++)
            {
                if (tempArr[i] != 0)
                {
                    cbbBedNo.Items.Add((i + 1) + "");
                }
            }
        }



        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (skinDataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("没有学生可以删除！");
                return;
            }

            int no =Convert.ToInt32(skinDataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            string name = skinDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            if (MessageBoxEx.Show("您真的要删除学号:"+no+"的用户吗？", "此删除不可恢复", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (DBHelper.Delete("delete from StudentInfo where sno='" + no + "'") 
                    && DBHelper.Update("update DormSum set checknum='" + (skinDataGridView1.Rows.Count - 1) 
                    + "' where dormitoryno='" + Dormitorymo + "'"))
               {
                   RemoveStuXml(no);
                   MessageBoxEx.Show("删除成功！");
                   reLoad();
               }
            }
        }

        //使groupbox恢复默认
        private void DefaultGroupBox()
        {
            txtNo.Text = "";
            txtName.Text = "";
            cbbBedNo.Items.Clear();
            skinGroupBox1.Text = "---";
            skinGroupBox1.Enabled = false;
            skinDataGridView1.Enabled = true;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DefaultGroupBox();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            
            //取值代码
            int sno;
            string name;
            //判断是否输入有误
            if (int.TryParse(txtNo.Text.Trim(),out sno)&&txtName.Text.Trim()!="")
            {
                name = txtName.Text.Trim();
            }
            else
            {
                MessageBoxEx.Show("输入错误！");
                return;
            }
            string gender = Sex;//rdoMan.Checked ? "男" : "女";
            int bedname = Convert.ToInt32(cbbBedNo.SelectedItem.ToString().Trim());
            System.DateTime dt = dateTimePicker1.Value.Date;
            
            
            //提交 添加或修改
            if (isAdd)
            {
                DataSet ds=DBHelper.Select("select * from StudentInfo where sno='" + sno + "'");
                if (!(ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0))
                {
                    MessageBoxEx.Show("当前学号学生已存在！");
                    return;
                }
                AddStuXml(sno);
                bool a = DBHelper.Insert("insert into StudentInfo (dormitoryno,sno,sname,sgender,bednum,checktime) values ('"
                    + Dormitorymo + "','" + sno + "','" + name + "','" + gender + "','" + bedname + "','" + dt + "')");
                bool b = DBHelper.Update("update DormSum set checknum='" + (skinDataGridView1.Rows.Count + 1) 
                    + "' where dormitoryno='" + Dormitorymo + "'");
                if (a && b)
                {
                    MessageBoxEx.Show("添加成功！");
                    DefaultGroupBox();
                    reLoad();
                }
                else
                {
                    MessageBoxEx.Show("添加失败！");
                }
            }
            else
            { 
                bool isUpdate = DBHelper.Update("update StudentInfo set sname='" + name + "',sgender='"
                    + gender + "',bednum='" + bedname + "',checktime='" + dt + "' where sno='" + sno + "'");
                if (isUpdate)
                {
                    MessageBoxEx.Show("修改成功");
                    DefaultGroupBox();
                    reLoad();
                }
            }
        }

        #region XML操作
        //在XML登录表中添加学生，帐号为学号，密码为1234
        private void AddStuXml(int sno)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("用户登录表.xml");
            XmlElement Users = doc.DocumentElement;

            XmlElement student = doc.CreateElement("student");
            XmlElement no = doc.CreateElement("no");
            XmlElement psw = doc.CreateElement("psw");

            no.InnerText = sno.ToString();
            psw.InnerText = MyMD5.myMD5("1234");

            Users.AppendChild(student);
            student.AppendChild(no);
            student.AppendChild(psw);

            doc.Save("用户登录表.xml");
        }
        //在XML登录表中删除学生的帐号
        private void RemoveStuXml(int no)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("用户登录表.xml");
            XmlElement Users = doc.DocumentElement;

            XmlNode xn = Users.SelectSingleNode("/Users/student[no='" + no + "']");
            Users.RemoveChild(xn);
            doc.Save("用户登录表.xml");
        }
        #endregion
    }
}
