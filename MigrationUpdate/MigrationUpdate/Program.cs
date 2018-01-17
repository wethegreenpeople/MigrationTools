using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace MigrationUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(1000);
            File.Delete("ComputerMigration.exe");
            using (var client = new WebClient())
            {
                client.DownloadFile(@"https://github.com/wethegreenpeople/MigrationTools/releases/download/" + args[0] + "ComputerMigration.exe", "ComputerMigration.exe");
            }
        }
    }
}
