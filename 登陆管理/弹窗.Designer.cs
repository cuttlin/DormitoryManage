namespace 宿舍管理系统
{
    partial class WFPop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPop));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TextWeather = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TextWeather
            // 
            this.TextWeather.AcceptsReturn = true;
            this.TextWeather.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.TextWeather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextWeather.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextWeather.ForeColor = System.Drawing.Color.DarkViolet;
            this.TextWeather.HideSelection = false;
            this.TextWeather.Location = new System.Drawing.Point(4, 28);
            this.TextWeather.Multiline = true;
            this.TextWeather.Name = "TextWeather";
            this.TextWeather.ReadOnly = true;
            this.TextWeather.Size = new System.Drawing.Size(293, 247);
            this.TextWeather.TabIndex = 0;
            this.TextWeather.TabStop = false;
            // 
            // WFPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 279);
            this.Controls.Add(this.TextWeather);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WFPop";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "登陆成功!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WFPop_FormClosed);
            this.Load += new System.EventHandler(this.WFPop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox TextWeather;
    }
}