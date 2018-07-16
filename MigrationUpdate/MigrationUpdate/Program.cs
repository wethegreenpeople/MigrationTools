using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Ionic.Zip;

namespace MigrationUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(1000);
            Console.Write(@"https://github.com/wethegreenpeople/MigrationTools/releases/download/" + args[0] + "/Migration.zip");
            // Downloading the update for our program
            using (var client = new WebClient())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DownloadFile(@"https://github.com/wethegreenpeople/MigrationTools/releases/download/" + args[0] + "/Migration.zip", "Migration.zip");
            }
            string update = "Migration.zip";
            // Extracting the update into a folder
            using (ZipFile zip1 = ZipFile.Read(update))
            {
                foreach (ZipEntry e in zip1)
                {
                    e.Extract("Migration Update", ExtractExistingFileAction.OverwriteSilently);
                }
            }
            // If any of the old files already exist (they all should) we're going to delete them
            if (File.Exists("ComputerMigration.exe"))
            {
                File.Delete("ComputerMigration.exe");
            }
            if (Directory.Exists("Scripts"))
            {
                Directory.Delete("Scripts", true);
            }
            if (Directory.Exists("mig_tools"))
            {
                Directory.Delete("mig_tools", true);
            }

            // Then we're going to move our updated files to the main directory and delete the update folder
            File.Move(@"Migration Update/ComputerMigration.exe", "ComputerMigration.exe");
            Directory.Move(@"Migration Update/Scripts", "Scripts");
            Directory.Move(@"Migration Update/mig_tools", "mig_tools");
            Directory.Delete("Migration Update", true);
        }
    }
}
