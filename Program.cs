using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using Fengshen.Lib; 

class Program
{
    static List<string> targetApps = new List<string>
    {
        "MobaXterm", "Xmanager", "RDCMan", "FinalShell", "Navicat",
        "SQLyog", "SecureCRT", "Outlook", "MailBird", "WinSCP",
        "DBeaver", "CoreFTP", "Snowflake", "HeidiSQL","foxmail"
    };

    static void Main()
    {
        foreach (var app in targetApps)
        {
            string installPath = FindApplicationInstallPath(app);
            if (installPath != null)
            {
                Console.WriteLine($"[+] {app} install path: {installPath}.");
                SelectLib.Select(app,installPath);
            }
            else
            {
                Console.WriteLine($"[-] {app} not install.");
            }
        }
    }
    static string FindApplicationInstallPath(string appName)
    {
        string installPath = null;

        installPath = SearchRegistryForApp(appName);
        if (installPath != null) return installPath;

        installPath = CheckCommonInstallPaths(appName);
        return installPath;
    }

    static string SearchRegistryForApp(string appName)
    {
        string[] registryPaths = {
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
            @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        };

        foreach (var path in registryPaths)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(path))
            {
                if (key != null)
                {
                    foreach (var subKeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                        {
                            var displayName = subKey.GetValue("DisplayIcon")?.ToString();
                            if (displayName != null && displayName.Contains(appName, StringComparison.OrdinalIgnoreCase))
                            {
                                var installLocation = subKey.GetValue("DisplayIcon")?.ToString();
                                if (!string.IsNullOrEmpty(installLocation))
                                {
                                    return installLocation;
                                }
                            }
                        }
                    }
                }
            }
        }
        return null;
    }

    static string CheckCommonInstallPaths(string appName)
    {
        string[] possiblePaths = new string[]
        {
            @"C:\Program Files",
            @"C:\Program Files (x86)"
        };

        Dictionary<string, string[]> appSubfolders = new Dictionary<string, string[]>
        {
            { "MobaXterm", new[] { "MobaXterm" } },
            { "Xmanager", new[] { "Xmanager" } },
            { "RDCMan", new[] { "RDCMan" } },
            { "FinalShell", new[] { "FinalShell" } },
            { "Navicat", new[] { "Navicat" } },
            { "SQLyog", new[] { "SQLyog" } },
            { "SecureCRT", new[] { "SecureCRT" } },
            { "Outlook", new[] { "Microsoft Office", "Office" } },
            { "MailBird", new[] { "Mailbird" } },
            { "WinSCP", new[] { "WinSCP" } },
            { "DBeaver", new[] { "DBeaver" } },
            { "CoreFTP", new[] { "CoreFTP" } },
            { "Snowflake", new[] { "Snowflake" } },
            { "HeidiSQL", new[] { "HeidiSQL" } }
        };

        if (appSubfolders.ContainsKey(appName))
        {
            foreach (var rootPath in possiblePaths)
            {
                foreach (var subFolder in appSubfolders[appName])
                {
                    string fullPath = Path.Combine(rootPath, subFolder);
                    if (Directory.Exists(fullPath))
                    {
                        return fullPath;
                    }
                }
            }
        }

        return null;
    }
}