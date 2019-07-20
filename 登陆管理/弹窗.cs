using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Runtime.InteropServices;

namespace 宿舍管理系统
{
    public partial class WFPop : CCSkinMain
    {
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果 
        public WFPop()
        {
            InitializeComponent();
        }


        private void WFPop_Load(object sender, EventArgs e)
        {
            try
            {
                //窗口右下角弹出淡入淡出效果
                int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
                int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
                this.Location = new Point(x, y);
                AnimateWindow(this.Handle, 1000, AW_ACTIVE);
                this.FormClosing += (a, b) => { AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE); };
                //天气引用
                cn.com.webxml.webservice.WeatherWebService wws = new cn.com.webxml.webservice.WeatherWebService();
                string[] data = wws.getWeatherbyCityName("石家庄");
                string[] s = data[6].Split(' ');

                TextWeather.Text += "省份：" + data[0] + "\r\n" + "城市：" + data[1] + "\r\n" + "城市代码：" + data[2] + "\r\n" + "气温：" + data[5] + "\r\n" + "概况：" + s[1] + "\r\n" + data[10] + "\r\n" + "风向和风力：" + data[7] + "\r\n" + "\r\t" + DateTime.Now.ToLocalTime().ToString();
                this.TextWeather.Select(0, 0);
            }
            catch (Exception )
            {
                //flag = false;
                MessageBoxEx.Show("网络连接失败!");
                TextWeather.Text += "省份：\r\n" + "城市：\r\n" + "城市代码：\r\n" + "气温：\r\n" + "概况：\r\n\r\n" + "风向和风力：\r\n" + "\r\t" + DateTime.Now.ToLocalTime().ToString();
                this.TextWeather.Select(0, 0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (flag)
            // { this.Close(); }
            this.Dispose();
        }

        private void WFPop_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
       
    }
}
