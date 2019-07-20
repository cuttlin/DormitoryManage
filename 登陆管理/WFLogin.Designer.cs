namespace 宿舍管理系统
{
    partial class WFLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFLogin));
            this.BtnLogin = new CCWin.SkinControl.SkinButton();
            this.TextSno = new CCWin.SkinControl.SkinTextBox();
            this.TextPwd = new CCWin.SkinControl.SkinTextBox();
            this.LBLName = new CCWin.SkinControl.SkinLabel();
            this.LBLPwd = new CCWin.SkinControl.SkinLabel();
            this.RdoStudent = new CCWin.SkinControl.SkinRadioButton();
            this.RdoMag = new CCWin.SkinControl.SkinRadioButton();
            this.LblUserNo = new System.Windows.Forms.Label();
            this.LblUserPwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BtnLogin.DownBack = null;
            this.BtnLogin.Location = new System.Drawing.Point(215, 236);
            this.BtnLogin.MouseBack = null;
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.NormlBack = null;
            this.BtnLogin.Size = new System.Drawing.Size(75, 23);
            this.BtnLogin.TabIndex = 4;
            this.BtnLogin.Text = "登录";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // TextSno
            // 
            this.TextSno.BackColor = System.Drawing.Color.Transparent;
            this.TextSno.DownBack = null;
            this.TextSno.Icon = null;
            this.TextSno.IconIsButton = false;
            this.TextSno.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.TextSno.IsPasswordChat = '\0';
            this.TextSno.IsSystemPasswordChar = false;
            this.TextSno.Lines = new string[0];
            this.TextSno.Location = new System.Drawing.Point(171, 96);
            this.TextSno.Margin = new System.Windows.Forms.Padding(0);
            this.TextSno.MaxLength = 32767;
            this.TextSno.MinimumSize = new System.Drawing.Size(28, 28);
            this.TextSno.MouseBack = null;
            this.TextSno.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.TextSno.Multiline = false;
            this.TextSno.Name = "TextSno";
            this.TextSno.NormlBack = null;
            this.TextSno.Padding = new System.Windows.Forms.Padding(5);
            this.TextSno.ReadOnly = false;
            this.TextSno.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextSno.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.TextSno.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextSno.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextSno.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TextSno.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.TextSno.SkinTxt.Name = "BaseText";
            this.TextSno.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.TextSno.SkinTxt.TabIndex = 0;
            this.TextSno.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TextSno.SkinTxt.WaterText = "";
            this.TextSno.TabIndex = 0;
            this.TextSno.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextSno.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TextSno.WaterText = "";
            this.TextSno.WordWrap = true;
            // 
            // TextPwd
            // 
            this.TextPwd.BackColor = System.Drawing.Color.Transparent;
            this.TextPwd.DownBack = null;
            this.TextPwd.Icon = null;
            this.TextPwd.IconIsButton = false;
            this.TextPwd.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.TextPwd.IsPasswordChat = '*';
            this.TextPwd.IsSystemPasswordChar = false;
            this.TextPwd.Lines = new string[0];
            this.TextPwd.Location = new System.Drawing.Point(171, 152);
            this.TextPwd.Margin = new System.Windows.Forms.Padding(0);
            this.TextPwd.MaxLength = 32767;
            this.TextPwd.MinimumSize = new System.Drawing.Size(28, 28);
            this.TextPwd.MouseBack = null;
            this.TextPwd.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.TextPwd.Multiline = false;
            this.TextPwd.Name = "TextPwd";
            this.TextPwd.NormlBack = null;
            this.TextPwd.Padding = new System.Windows.Forms.Padding(5);
            this.TextPwd.ReadOnly = false;
            this.TextPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextPwd.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.TextPwd.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextPwd.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextPwd.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TextPwd.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.TextPwd.SkinTxt.Name = "BaseText";
            this.TextPwd.SkinTxt.PasswordChar = '*';
            this.TextPwd.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.TextPwd.SkinTxt.TabIndex = 0;
            this.TextPwd.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TextPwd.SkinTxt.WaterText = "";
            this.TextPwd.TabIndex = 1;
            this.TextPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextPwd.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TextPwd.WaterText = "";
            this.TextPwd.WordWrap = true;
            // 
            // LBLName
            // 
            this.LBLName.AutoSize = true;
            this.LBLName.BackColor = System.Drawing.Color.Transparent;
            this.LBLName.BorderColor = System.Drawing.Color.White;
            this.LBLName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBLName.Location = new System.Drawing.Point(117, 101);
            this.LBLName.Name = "LBLName";
            this.LBLName.Size = new System.Drawing.Size(51, 20);
            this.LBLName.TabIndex = 5;
            this.LBLName.Text = "学号：";
            // 
            // LBLPwd
            // 
            this.LBLPwd.AutoSize = true;
            this.LBLPwd.BackColor = System.Drawing.Color.Transparent;
            this.LBLPwd.BorderColor = System.Drawing.Color.White;
            this.LBLPwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBLPwd.Location = new System.Drawing.Point(117, 156);
            this.LBLPwd.Name = "LBLPwd";
            this.LBLPwd.Size = new System.Drawing.Size(51, 20);
            this.LBLPwd.TabIndex = 6;
            this.LBLPwd.Text = "密码：";
            // 
            // RdoStudent
            // 
            this.RdoStudent.AutoSize = true;
            this.RdoStudent.BackColor = System.Drawing.Color.Transparent;
            this.RdoStudent.Checked = true;
            this.RdoStudent.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.RdoStudent.DownBack = null;
            this.RdoStudent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RdoStudent.Location = new System.Drawing.Point(254, 189);
            this.RdoStudent.MouseBack = null;
            this.RdoStudent.Name = "RdoStudent";
            this.RdoStudent.NormlBack = null;
            this.RdoStudent.SelectedDownBack = null;
            this.RdoStudent.SelectedMouseBack = null;
            this.RdoStudent.SelectedNormlBack = null;
            this.RdoStudent.Size = new System.Drawing.Size(50, 21);
            this.RdoStudent.TabIndex = 2;
            this.RdoStudent.TabStop = true;
            this.RdoStudent.Text = "学生";
            this.RdoStudent.UseVisualStyleBackColor = true;
            // 
            // RdoMag
            // 
            this.RdoMag.AutoSize = true;
            this.RdoMag.BackColor = System.Drawing.Color.Transparent;
            this.RdoMag.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.RdoMag.DownBack = null;
            this.RdoMag.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RdoMag.Location = new System.Drawing.Point(310, 189);
            this.RdoMag.MouseBack = null;
            this.RdoMag.Name = "RdoMag";
            this.RdoMag.NormlBack = null;
            this.RdoMag.SelectedDownBack = null;
            this.RdoMag.SelectedMouseBack = null;
            this.RdoMag.SelectedNormlBack = null;
            this.RdoMag.Size = new System.Drawing.Size(62, 21);
            this.RdoMag.TabIndex = 3;
            this.RdoMag.Text = "管理员";
            this.RdoMag.UseVisualStyleBackColor = true;
            // 
            // LblUserNo
            // 
            this.LblUserNo.AutoSize = true;
            this.LblUserNo.ForeColor = System.Drawing.Color.Red;
            this.LblUserNo.Location = new System.Drawing.Point(369, 104);
            this.LblUserNo.Name = "LblUserNo";
            this.LblUserNo.Size = new System.Drawing.Size(0, 12);
            this.LblUserNo.TabIndex = 7;
            // 
            // LblUserPwd
            // 
            this.LblUserPwd.AutoSize = true;
            this.LblUserPwd.ForeColor = System.Drawing.Color.Red;
            this.LblUserPwd.Location = new System.Drawing.Point(369, 162);
            this.LblUserPwd.Name = "LblUserPwd";
            this.LblUserPwd.Size = new System.Drawing.Size(0, 12);
            this.LblUserPwd.TabIndex = 7;
            // 
            // WFLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 332);
            this.Controls.Add(this.LblUserPwd);
            this.Controls.Add(this.LblUserNo);
            this.Controls.Add(this.RdoMag);
            this.Controls.Add(this.RdoStudent);
            this.Controls.Add(this.LBLPwd);
            this.Controls.Add(this.LBLName);
            this.Controls.Add(this.TextPwd);
            this.Controls.Add(this.TextSno);
            this.Controls.Add(this.BtnLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WFLogin";
            this.Text = "     欢迎使用，请登录";
            this.Load += new System.EventHandler(this.WFLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton BtnLogin;
        private CCWin.SkinControl.SkinTextBox TextSno;
        private CCWin.SkinControl.SkinTextBox TextPwd;
        private CCWin.SkinControl.SkinLabel LBLName;
        private CCWin.SkinControl.SkinLabel LBLPwd;
        private CCWin.SkinControl.SkinRadioButton RdoStudent;
        private CCWin.SkinControl.SkinRadioButton RdoMag;
        private System.Windows.Forms.Label LblUserNo;
        private System.Windows.Forms.Label LblUserPwd;
    }
}

