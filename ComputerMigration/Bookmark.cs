using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Threading;

namespace ComputerMigration
{
    public partial class Bookmark : Form
    {
        private Form1 mainForm;

        public Bookmark()
        {
            InitializeComponent();

            DirectoryInfo directory = new DirectoryInfo(@"C:\Users");
            DirectoryInfo[] directories = directory.GetDirectories();

            foreach (DirectoryInfo folder in directories)
                checkedListBoxUsers.Items.Add(folder.Name);
        }

        private void Bookmark_Load(object sender, EventArgs e)
        {
            
        }

        private void Bookmark_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            buttonBackup.Visible = false;
            progressBar.Visible = true;
            progressBar.Maximum = checkedListBoxUsers.CheckedItems.Count;

            foreach (var item in checkedListBoxUsers.CheckedItems)
            {
                string fireFoxProfiles = String.Format(@"C:\Users\{0}\AppData\Roaming\Mozilla\Firefox\Profiles", item);
                DirectoryInfo fireFoxdirectory = new DirectoryInfo(fireFoxProfiles);
                DirectoryInfo[] directories = fireFoxdirectory.GetDirectories();

                string chromeSource = String.Format(@"C:\Users\{0}\AppData\Local\Google\Chrome\User Data\Default\Bookmarks", item);
                string chromeDestination = String.Format(@"Bookmarks\{0}\User Data\Default", item);
                string fireFoxSource = String.Format(@"C:\Users\{0}\AppData\Roaming\Mozilla\Firefox\Profiles\{1}", item, directories[0].ToString());
                string fireFoxDestination = String.Format(@"Bookmarks\{0}\Profiles\{1}", item, directories[0].ToString());

                try
                {
                    Directory.CreateDirectory(chromeDestination);
                    File.Copy(chromeSource, chromeDestination + @"\Bookmarks");
                    File.Copy(chromeSource + ".bak", chromeDestination + @"\Bookmarks.bak");

                    Copy(fireFoxSource + @"\bookmarkbackups", fireFoxDestination + @"\bookmarkbackups");
                    File.Copy(fireFoxSource + @"\places.sqlite", fireFoxDestination + @"\places.sqlite");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    progressBar.Increment(1);
                }
            }
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }


        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                Directory.CreateDirectory(target.FullName);

                // Copy each file into the new directory.
                foreach (FileInfo fi in source.GetFiles())
                {
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                }

                // Copy each subdirectory using recursion.
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
