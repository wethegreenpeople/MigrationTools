using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.IO;
using Microsoft.Win32;


namespace ComputerMigration
{
    public partial class RestoreItems : Form
    {
        private BookmarkRestore bookmark;

        public RestoreItems()
        {
            InitializeComponent();
        }

        private void checkBoxMigration_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RestoreItems_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonDodat_Click(object sender, EventArgs e)
        {
            if (checkBoxInfo.Checked == true && checkBoxDomain.Checked == true)
            {
                ChangeComputerInfo();
                File.Copy(@"Scripts\rejoinDomain.exe", @"C:\rejoinDomain.exe", true);
                RegistryKey key;
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce", true);
                key.SetValue("rejoinDomain", @"C:\rejoinDomain.exe");
                key.Close();
            }
            if (checkBoxMigration.Checked == true)
            {
                Process.Start(@"mig_tools\migwiz\migwiz.exe");
            }
            if (checkBoxInfo.Checked == true && checkBoxDomain.Checked == false)
            {
                ChangeComputerInfo();
            }
            if (checkBoxDomain.Checked == true && checkBoxInfo.Checked == false)
            {
                AddToDomain();
            }
            if (checkBoxBookmarks.Checked == true)
            {
                bookmark = new BookmarkRestore();
                bookmark.Show();
            }

            if (checkBoxPrinters.Checked == true)
            {
                var printerPort = new ProcessStartInfo();
                printerPort.WorkingDirectory = Directory.GetCurrentDirectory() + @"\Scripts";
                printerPort.FileName = "printerPort.exe";
                printerPort.Verb = "runas";
                printerPort.Arguments = "import";
                Process.Start(printerPort);
            }
        }

        private void checkBoxInfo_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void AddToDomain()
        {
            var rejoinProcess = new ProcessStartInfo();
            rejoinProcess.WorkingDirectory = Directory.GetCurrentDirectory() + @"\Scripts";
            rejoinProcess.FileName = "rejoinDomain.exe";
            Process.Start(rejoinProcess);
        }

        private void ChangeComputerInfo()
        {
            var renameProcess = new ProcessStartInfo();
            renameProcess.WorkingDirectory = Directory.GetCurrentDirectory() + @"\Scripts";
            renameProcess.FileName = "computerRename.exe";
            Process.Start(renameProcess).WaitForExit();
            // Change computer description
            string computerDescription = File.ReadAllLines("computer.txt").ElementAtOrDefault(1);
            RegistryKey key;
            key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters", true);
            key.SetValue("SrvComment", computerDescription);
            key.Close();
        }
    }
}
