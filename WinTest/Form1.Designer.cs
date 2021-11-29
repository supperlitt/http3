namespace WinTest
{
    partial class Form1
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnLoginYY = new System.Windows.Forms.Button();
            this.btnLoginCmcc = new System.Windows.Forms.Button();
            this.btnLoginCmcc2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(26, 76);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(26, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 1;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(146, 12);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(401, 230);
            this.txtResult.TabIndex = 1;
            // 
            // btnLoginYY
            // 
            this.btnLoginYY.Location = new System.Drawing.Point(26, 127);
            this.btnLoginYY.Name = "btnLoginYY";
            this.btnLoginYY.Size = new System.Drawing.Size(75, 23);
            this.btnLoginYY.TabIndex = 0;
            this.btnLoginYY.Text = "登录YY";
            this.btnLoginYY.UseVisualStyleBackColor = true;
            this.btnLoginYY.Click += new System.EventHandler(this.btnLoginYY_Click);
            // 
            // btnLoginCmcc
            // 
            this.btnLoginCmcc.Location = new System.Drawing.Point(26, 183);
            this.btnLoginCmcc.Name = "btnLoginCmcc";
            this.btnLoginCmcc.Size = new System.Drawing.Size(75, 23);
            this.btnLoginCmcc.TabIndex = 0;
            this.btnLoginCmcc.Text = "登录CMCC1";
            this.btnLoginCmcc.UseVisualStyleBackColor = true;
            this.btnLoginCmcc.Click += new System.EventHandler(this.btnLoginCmcc_Click);
            // 
            // btnLoginCmcc2
            // 
            this.btnLoginCmcc2.Location = new System.Drawing.Point(26, 219);
            this.btnLoginCmcc2.Name = "btnLoginCmcc2";
            this.btnLoginCmcc2.Size = new System.Drawing.Size(75, 23);
            this.btnLoginCmcc2.TabIndex = 0;
            this.btnLoginCmcc2.Text = "登录CMCC2";
            this.btnLoginCmcc2.UseVisualStyleBackColor = true;
            this.btnLoginCmcc2.Click += new System.EventHandler(this.btnLoginCmcc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 262);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnLoginCmcc2);
            this.Controls.Add(this.btnLoginCmcc);
            this.Controls.Add(this.btnLoginYY);
            this.Controls.Add(this.btnLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnLoginYY;
        private System.Windows.Forms.Button btnLoginCmcc;
        private System.Windows.Forms.Button btnLoginCmcc2;
    }
}

