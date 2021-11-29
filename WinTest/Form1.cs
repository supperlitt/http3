using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinTest
{
    public partial class Form1 : Form
    {
        private FishcHelper helper = null;
        private YYHelper yyhelper = null;
        private CMCCHelper cmcchelper = null;

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = "test2021";
            string pwd = "xxxxxxx";
            helper.Init();
            var result = helper.Login(name, pwd);
            this.ShowMsg("result " + result);
            if (result)
            {
                string info = helper.GetUserInfo();
                this.ShowMsg("info " + info);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            helper = new FishcHelper();
            yyhelper = new YYHelper();
            cmcchelper = new CMCCHelper();
        }

        private void ShowMsg(string msg)
        {
            this.Invoke(new Action<TextBox>(p =>
            {
                p.AppendText(msg + "\r\n");
            }), this.txtResult);
        }

        private void btnLoginYY_Click(object sender, EventArgs e)
        {
            string id = "2567628109";
            string pwd = "xxxxxxxxx";
            yyhelper.Init();
            var result = yyhelper.Login(id, pwd);
            this.ShowMsg("result " + result);
            if (result)
            {
                string info = yyhelper.GetUserInfo();
                this.ShowMsg("info " + info);
            }
        }

        private void btnLoginCmcc_Click(object sender, EventArgs e)
        {
            string phone = "187XXXXXXXX";
            Button btn = sender as Button;
            if (btn.Text == "登录CMCC1")
            {
                cmcchelper.Init();
                var sms = cmcchelper.GetSMS(phone);
                this.ShowMsg("sms " + sms);
            }
            else
            {
                var result = cmcchelper.Login(phone, this.txtName.Text);
                this.ShowMsg("result " + result);
                if (result)
                {
                    string info = cmcchelper.GetUserInfo();
                    this.ShowMsg("info " + info);
                }
            }
        }
    }
}
