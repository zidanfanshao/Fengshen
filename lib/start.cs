using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

namespace Fengshen.Lib
{
    public static class SelectLib   // 修改为 class 并加上 class 关键字
    {
        public static void Select(string app, string appInstallPath)  // 修正了方法名 seclect -> select，并修正了参数名
        {
            string[] targetProcesses = { "foxmail", "xshell", "chrome" };

            if (app == "foxmail")
            {
                Console.WriteLine($" [+] {app} 已选中,正在开始处理。。");
                // 确保 foxmail 类存在，并且包含 foundmail 方法
                foxmail.foundmail(appInstallPath);  
            }
            else if (app == "xshell")  // 修正了拼写错误：xhsell -> xshell
            {
                Console.WriteLine($" [+] {app} 已选中,正在开始处理。。");
                // 在这里添加对 xshell 的处理
            }
            else if (app == "chrome")
            {
                Console.WriteLine($" [+] {app} 已选中,正在开始处理。。");
                // 在这里添加对 chrome 的处理
            }
            else
            {
                Console.WriteLine("[-] 未识别的应用程序");
            }
        }
    }
}
