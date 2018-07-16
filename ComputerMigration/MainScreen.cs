using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace ComputerMigration
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RestoreItems().Show();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            string currentVersion = Convert.ToString(System.Reflection.Assembly.GetEntryAssembly().GetName().Version);
            string latestVersion;
            using (var client = new WebClient())
            {
                client.DownloadFile("https://raw.githubusercontent.com/wethegreenpeople/MigrationTools/master/migrationversion.txt", "migrationversion.txt");
            }
            latestVersion = File.ReadAllText("migrationversion.txt");
            latestVersion = latestVersion.Trim();
            //MessageBox.Show(currentVersion + " " + latestVersion);
            if (currentVersion != latestVersion)
            {
                DialogResult update = MessageBox.Show("Update available. Close and update now?", "Update?", MessageBoxButtons.OKCancel);
                if (update == DialogResult.OK)
                {
                    File.Delete("MigrationUpdate.exe");
                    using (var client = new WebClient())
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        client.DownloadFile(@"https://github.com/wethegreenpeople/MigrationTools/releases/download/" + latestVersion + "/MigrationUpdate.exe", "MigrationUpdate.exe");
                    }
                    ProcessStartInfo info = new ProcessStartInfo(@"MigrationUpdate.exe");
                    info.UseShellExecute = true;
                    info.Verb = "runas";
                    info.Arguments = latestVersion;
                    Process.Start(info);
                    Application.Exit();
                }
            }
        }
    }
}
