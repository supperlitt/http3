using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WinTest
{
    public class JsExecute
    {
        public static string GetYYPwd(string password)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetEntryAssembly();
            System.IO.StreamReader txtStream = new System.IO.StreamReader(asm.GetManifestResourceStream("WinTest.yy.js"));
            // string path = AppDomain.CurrentDomain.BaseDirectory + "getpwd.js";
            string str2 = txtStream.ReadToEnd();

            string fun = string.Format(@"enc('{0}')", password);
            string result = ExecuteScript(fun, str2);

            return result;
        }

        public static string GetCMCCEnc(string password)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetEntryAssembly();
            System.IO.StreamReader txtStream = new System.IO.StreamReader(asm.GetManifestResourceStream("WinTest.yy.js"));
            // string path = AppDomain.CurrentDomain.BaseDirectory + "getpwd.js";
            string str2 = txtStream.ReadToEnd();

            string fun = string.Format(@"encrypt('{0}')", password);
            string result = ExecuteScript(fun, str2);

            return result;
        }

        /// <summary>
        /// 执行JS
        /// </summary>
        /// <param name="sExpression">参数体</param>
        /// <param name="sCode">JavaScript代码的字符串</param>
        /// <returns></returns>
        private static string ExecuteScript(string sExpression, string sCode)
        {
            MSScriptControl.ScriptControl scriptControl = new MSScriptControl.ScriptControl();
            scriptControl.UseSafeSubset = true;
            scriptControl.Language = "JScript";
            scriptControl.AddCode(sCode);
            try
            {
                string str = scriptControl.Eval(sExpression).ToString();
                return str;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return null;
        }
    }
}
