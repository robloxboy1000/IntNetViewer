using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntNetViewer
{
    internal class IntNetConfig
    {
        public static string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36";
        public static string CachePath = Path.GetFullPath(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\IntNetViewer\Cache\");
        public static string ErrorPage = "intnetviewer://assets/error.html";
        public static string BrandLower = "intnetviewer";
        public static string BrandUpper = "IntNetViewer";
        public string version = "";
    }
}
