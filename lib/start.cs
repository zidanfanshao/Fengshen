using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

namespace Fengshen.Lib
{
    public static class SelectLib
    {
        public static void Select(string app, string appInstallPath)
        {
            string[] targetProcesses = { "foxmail", "xshell", "chrome" };

            if (app == "foxmail")
            {
                Console.WriteLine($" [+] {app} 已选中,正在开始处理。。");
                foxmail.foundmail(appInstallPath);  
            }
            else if (app == "xshell")
            {
                Console.WriteLine($" [+] {app} 已选中,正在开始处理。。");
            }
            else if (app == "chrome")
            {
                Console.WriteLine($" [+] {app} 已选中,正在开始处理。。");
            }
            else
            {
                Console.WriteLine("[-] 未识别的应用程序");
            }
        }
    }
}
