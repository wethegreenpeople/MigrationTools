using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Diagnostics;

namespace ComputerMigration
{
    public partial class Form1 : Form
    {
        private StreamWriter write;
        private Bookmark bookmark;
        private TechInfo signin;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDodat_Click(object sender, EventArgs e)
        {
            if (checkBoxInfo.Checked == true)
            {
                try
                {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    string computerName = Environment.MachineName;
                    
                    string key = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\lanmanserver\parameters";
                    string computerDescription = (string)Registry.GetValue(key, "srvcomment", null);
                    string techNum = Environment.UserName;
                    DateTime date = DateTime.Now;

                    FileStream file = new FileStream("computer.txt", FileMode.OpenOrCreate, FileAccess.Write);

                    write = new StreamWriter(file);
                    write.WriteLine(computerName);
                    write.WriteLine(computerDescription);
                    for (int i = 0; i < host.AddressList.Length - 1; ++i)
                    {
                        string ipAddress = host.AddressList[i].ToString();
                        string macAddress = GetMacAddress()[i].ToString();
                        write.WriteLine(ipAddress);
                        write.WriteLine(macAddress);
                    }
                    write.WriteLine(techNum);
                    write.WriteLine(date);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    write.Close();
                    Process.Start("computer.txt");
                }
            }

            if (checkBoxBookmarks.Checked == true)
            {
                bookmark = new Bookmark();
                bookmark.Show();
            }

            if (checkBoxMigration.Checked == true)
            {
                Process.Start(@"mig_tools\migwiz\migwiz.exe");
            }

            if (checkBoxDomain.Checked == true)
            {
                var disjoinProcess = new ProcessStartInfo();
                disjoinProcess.WorkingDirectory = Directory.GetCurrentDirectory() + @"\Scripts";
                disjoinProcess.FileName = "disjoinDomain.exe";
                Process.Start(disjoinProcess);
            }
        }

        private List<string> GetMacAddress()
        {
            List<string> macAddresses = new List<string>();

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses.Add(nic.GetPhysicalAddress().ToString());
                }
            }

            return macAddresses;
        }

        private void checkBoxInfo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxDomain_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBoxBookmarks_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxMigration_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
