using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using System.Security.Cryptography;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Tools
{
    public static class DBHelper
    {
        //
        private static string conStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\DormitoryInfo.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

        //查询函数 第一个参数sql语句，
        public static DataSet Select(string sql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(com);

                    sda.Fill(ds);

                    con.Close();
                }
            }
            return ds;
        }

        //修改函数
        public static bool Update(string sql)
        {
            bool flag = false;//标记是否更新成功
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        flag = true;
                    }
                    con.Close();
                }
            }
            return flag;
        }


        #region 标明函数意义
		 
	
        //插入函数
        public static bool Insert(string sql)
        {
            return Update(sql);
        }

        //删除函数
        public static bool Delete(string sql)
        {
            return Update(sql);
        }
        #endregion
    }
}
