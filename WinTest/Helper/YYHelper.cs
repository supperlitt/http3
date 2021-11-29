using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace WinTest
{
    public class YYHelper
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private string oauth_token = string.Empty;
        private YYToken token = null;
        private HttpHelper helper = null;

        public YYHelper()
        {
            helper = new HttpHelper();
        }

        public void Init()
        {
            string url = "https://aq.yy.com/p/wklogin.do?callbackURL=https://aq.yy.com/welcome.do";
            string postData = "";

            // {"success":"1","url":"https://lgn.yy.com/lgn/oauth/authorize.do?oauth_token=a5916b55ff5da77c798b2d8de3e5b0a4b8728fe68de20ce5aaa7e766baf0f5b29429e214d7b5be93bd9f103f118afd81a1fe27d941cd785f04132283292b2c48","ttokensec":"D4254DF74ADF65FA0F15D390CF7681875E259DCA48BDC72868A51C926744BFB472DCEA6E219EA8E349802C08A0A2ACA4","ttoken":"95B8037AAF8445CE965629C6F1E787F4AFE6348F28B82F6915D0A2DD1AB219B09B2E7C84F58DCD9A558BF0B4CBAEA0B9959031332EE4BE6E6287112B168E332D54A9A391F609F6C02B95AA4CE34EB0E94CA5877319DE6BDABCC78AC4816C6DD21266D477B1262ABB18F603C1A46D9EF4DB6491CE0759D5AF51943E47AFBA527072DCEA6E219EA8E349802C08A0A2ACA4"}
            string result = helper.PostAndGetHtml(url, postData, null, null, false, Encoding.UTF8);
            Regex regex = new Regex(@"oauth_token=(?<oauth_token>[^""]+)");
            oauth_token = regex.Match(result).Groups["oauth_token"].Value;
            token = js.Deserialize<YYToken>(result);
        }

        public bool Login(string name, string pwd)
        {
            string url = "https://lgn.yy.com/lgn/oauth/x2/s/login_asyn.do";
            string postData = string.Format("username={2}&pwdencrypt={0}&oauth_token={1}&denyCallbackURL=&UIStyle=xelogin&appid=1&cssid=1&mxc=&vk=&isRemMe=0&mmc=&vv=&hiido=1", JsExecute.GetYYPwd(pwd), oauth_token, name);

            // {"code":"0","msg":null,"obj":{"callbackURL":"https://aq.yy.com/p/logincbk.do?jump=https://aq.yy.com/welcome.do&oauth_token=a5916b55ff5da77c798b2d8de3e5b0a4b8728fe68de20ce5aaa7e766baf0f5b29429e214d7b5be93bd9f103f118afd81a1fe27d941cd785f04132283292b2c48&oauth_verifier=246003adcf50da7513eeb1fc169e1a75&isRemMe=0","redirectURL":null,"vk":null,"vt":null,"pos":"1","verifyid":null,"qin":"up","yyuid":2612904792,"passport":"2567628109","svpic":null,"itvjs":null,"strategy":null},"hdcode":"0"}
            string result = helper.PostAndGetHtml(url, postData, null, null, false, Encoding.UTF8);
            var info = js.Deserialize<YY_Rootobject>(result);
            if (info.code == "0")
            {
                url = info.obj.callbackURL;

                helper.CC.Add(new System.Net.Cookie()
                {
                    Name = "udboauthtmptoken",
                    Value = token.ttoken,
                    Domain = "aq.yy.com",
                    Expires = DateTime.Now.AddDays(30)
                });

                helper.CC.Add(new System.Net.Cookie()
                {
                    Name = "udboauthtmptokensec",
                    Value = token.ttokensec,
                    Domain = "aq.yy.com",
                    Expires = DateTime.Now.AddDays(30)
                });

                result = helper.GetAndGetHtml(url, null, null, false, Encoding.UTF8);
                // <html><head><script language="JavaScript" type="text/javascript">function udb_callback(){self.parent.UDB.sdk.PCWeb.writeCrossmainCookieWithCallBack('https://lgn.yy.com/lgn/oauth/wck_n.do?oauth_mckey4cookie=cb8c65090a5fd40985faa4567bfe8791e4cf44d7afd51287c5011f417c95dcc7f89d926800f40347da5a11c4239a5638210442961c75863d3059e2cf437e215e&oauth_signature=eehJxBT6eei27NrP9tGJeZuVfHE%3D',function(){self.parent.document.location="https://aq.yy.com/welcome.do";});};udb_callback();</script></head><body></body></html>

                Regex regex = new Regex(@"writeCrossmainCookieWithCallBack\('(?<url>[^']+)");
                url = regex.Match(result).Groups["url"].Value;

                result = helper.GetAndGetHtml(url, null, null, false, Encoding.UTF8);
                if (result.Contains("write cookie for oauth"))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public string GetUserInfo()
        {
            string url = "https://aq.yy.com/initUserInfo.do";
            string postData = "type=webdb";

            return helper.PostAndGetHtml(url, postData, null, null, false, Encoding.UTF8);
        }
    }

    public class YY_Rootobject
    {
        public string code { get; set; }
        public object msg { get; set; }
        public YY_Obj obj { get; set; }
        public string hdcode { get; set; }
    }

    public class YY_Obj
    {
        public string callbackURL { get; set; }
        public object redirectURL { get; set; }
        public object vk { get; set; }
        public object vt { get; set; }
        public string pos { get; set; }
        public object verifyid { get; set; }
        public string qin { get; set; }
        public long yyuid { get; set; }
        public string passport { get; set; }
        public object svpic { get; set; }
        public object itvjs { get; set; }
        public object strategy { get; set; }
    }
    public class YYToken
    {
        public string success { get; set; }
        public string url { get; set; }
        public string ttokensec { get; set; }
        public string ttoken { get; set; }
    }


}
