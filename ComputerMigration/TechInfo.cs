using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerMigration
{
    public partial class TechInfo : Form
    {
        public TechInfo()
        {
            InitializeComponent();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo(@"JustinBieber.bat");
            info.UseShellExecute = true;
            info.Verb = "runas";
            Process.Start(info);

        }
    }
}
