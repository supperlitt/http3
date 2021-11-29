using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace WinTest
{
    public class CMCCHelper
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private HttpHelper helper = null;
        private cmcc_loadToken loadToken = null;

        public CMCCHelper()
        {
            helper = new HttpHelper();
        }

        public void Init()
        {
            string url = "https://login.10086.cn/login.html";
            helper.GetAndGetHtml(url, null, null, false, Encoding.UTF8);

            url = "https://login.10086.cn/loadSendflag.htm?timestamp=";
            helper.GetAndGetHtml(url, null, null, false, Encoding.UTF8);

            url = "https://login.10086.cn/genqr.htm";
            helper.GetAndGetHtml(url, null, null, false, Encoding.UTF8);

            url = "https://login.10086.cn/checkUidAvailable.action";
            string postData = "";
            string result = helper.PostAndGetHtml(url, postData, null, null, false, Encoding.UTF8);
        }


        public bool GetSMS(string name)
        {
            string url = "https://login.10086.cn/chkNumberAction.action";
            string postData = "userName=" + name + "&loginMode=01&channelID=12003";
            string result = helper.PostAndGetHtml(url, postData, null, null, false, Encoding.UTF8);

            url = "https://login.10086.cn/loadToken.action";
            postData = "userName=" + name;

            // {"rspType":"0","rspCode":"0000","rspDesc":"成功","result":"80635536043686705232813392603779"}
            result = helper.PostAndGetHtml(url, postData, null, null, false, Encoding.UTF8);
            loadToken = js.Deserialize<cmcc_loadToken>(result);

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Xa-before", loadToken.result);
            header.Add("X-Requested-With", "XMLHttpRequest");
            url = "https://login.10086.cn/sendRandomCodeAction.action";
            postData = "userName=" + name + "&loginMode=01&channelID=12003";
            result = helper.PostAndGetHtml(url, postData, null, "https://login.10086.cn/login.html", false, Encoding.UTF8, null, header);
            if (result == "0")
            {
                return true;
            }

            return false;
        }

        public bool Login(string name, string pwd)
        {
            string url = "https://login.10086.cn/login.htm";
            string postData = string.Format("accountType=01&account={0}&password={1}&pwdType=02&smsPwd=&inputCode=&backUrl=https%3A%2F%2Fshop.10086.cn%2Fi%2F&rememberMe=0&channelID=12003&loginMode=01&protocol=https%3A&timestamp={2}", HttpUtility.UrlEncode(JsExecute.GetCMCCEnc(name)), HttpUtility.UrlEncode(JsExecute.GetCMCCEnc(pwd)), JsTool.GetLongFromTime());

            // {"artifact":"412c0d244f2e48acb311993c9c8583db","assertAcceptURL":"https://shop.10086.cn/i/v1/auth/getArtifact","code":"0000","desc":"认证成功","islocal":false,"result":"0","type":"00","uid":"54ad995adcff4e99b48fe6dafbfc6da4"}
            string result = helper.PostAndGetHtml(url, postData, null, null, false, Encoding.UTF8);

            return true;
        }

        public string GetUserInfo()
        {
            return null;
        }
    }

    public class cmcc_loadToken
    {
        public string rspType { get; set; }
        public string rspCode { get; set; }
        public string rspDesc { get; set; }
        public string result { get; set; }
    }
}
