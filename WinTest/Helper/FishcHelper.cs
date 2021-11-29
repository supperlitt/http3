using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinTest
{
    public class FishcHelper
    {
        private HttpHelper helper = null;

        public FishcHelper()
        {
            helper = new HttpHelper();
        }

        public void Init()
        {
            string url = "https://fishc.com.cn/forum.php";

            string result = helper.GetAndGetHtml(url, null, null, false, Encoding.UTF8);
        }

        public bool Login(string name, string pwd)
        {
            string url = "https://fishc.com.cn/member.php?mod=logging&action=login&loginsubmit=yes&infloat=yes&lssubmit=yes&inajax=1";
            string postData = "username=test2021&password=" + JsTool.GetMD5String(pwd).ToLower() + "&quickforward=yes&handlekey=ls";

            // <?xml version="1.0" encoding="gbk"?><root><![CDATA[<script type="text/javascript" reload="1">window.location.href='https://fishc.com.cn/forum.php';</script>]]></root>
            string result = helper.PostAndGetHtml(url, postData, null, null, false, Encoding.UTF8);
            if (result.Contains("window.location.href='https://fishc.com.cn/';"))
            {
                return true;
            }

            return false;
        }

        public string GetUserInfo()
        {
            string url = "https://fishc.com.cn/home.php?mod=spacecp&ac=usergroup&showextgroups=1&inajax=1&ajaxtarget=g_upmine_menu";

            return helper.GetAndGetHtml(url, null, null, false, Encoding.GetEncoding("gbk"));
        }
    }
}
