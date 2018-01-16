using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerMigration
{
    public partial class BookmarkRestore : Form
    {
        public BookmarkRestore()
        {
            InitializeComponent();
            DirectoryInfo directory = new DirectoryInfo(@"Bookmarks\");
            DirectoryInfo[] directories = directory.GetDirectories();

            foreach (DirectoryInfo folder in directories)
                checkedListBoxUsers.Items.Add(folder.Name);
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

                string chromeDestination = String.Format(@"C:\Users\{0}\AppData\Local\Google\Chrome\User Data\Default\Bookmarks", item);
                string chromeSource = String.Format(@"Bookmarks\{0}\User Data\Default\Bookmarks", item);
                string fireFoxDestination = String.Format(@"C:\Users\{0}\AppData\Roaming\Mozilla\Firefox\Profiles\{1}", item, directories[0].ToString());

                string localProfile = String.Format(@"Bookmarks\{0}\Profiles", item);
                DirectoryInfo local = new DirectoryInfo(localProfile);
                DirectoryInfo[] localDirectories = local.GetDirectories();
                string fireFoxSource = String.Format(@"Bookmarks\{0}\Profiles\{1}", item, localDirectories[0].ToString());

                try
                {
                    if (File.Exists(chromeDestination))
                    {
                        File.Delete(chromeDestination);
                        File.Delete(chromeDestination + ".bak");
                    }
                    File.Copy(chromeSource, chromeDestination);
                    File.Copy(chromeSource + ".bak", chromeDestination + @".bak");

                    string sqlFileDelete = String.Format(@"C:\Users\{0}\AppData\Roaming\Mozilla\Firefox\Profiles\{1}\places.sqlite", item, directories[0].ToString());
                    if (File.Exists(sqlFileDelete))
                    {
                        File.Delete(sqlFileDelete);
                    }
                    Copy(fireFoxSource + @"\bookmarkbackups", fireFoxDestination + @"\bookmarkbackups");
                    File.Copy(fireFoxSource + @"\places.sqlite", fireFoxDestination + @"\places.sqlite");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    string user = String.Format(@"Bookmarks\{0}", item);
                    progressBar.Increment(1);
                    Directory.Delete(user, true);
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
    }
}
