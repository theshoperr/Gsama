using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theshoperr;

namespace Godinho_sama.scenes
{
    public partial class Settings : Form
    {
        Home main;
        string DefaultImg = "https://raw.githubusercontent.com/theshoperr/Gsama/main/application.png";
        string DefaultIcon = "https://raw.githubusercontent.com/theshoperr/Gsama/main/Gsama-Logo.ico";
        string verURL = "https://raw.githubusercontent.com/theshoperr/Gsama/main/version.txt";
        string UpdateURL = "https://raw.githubusercontent.com/theshoperr/Gsama/main/updateURL.txt";
        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        public Settings(Home h)
        {
            InitializeComponent();
            main = h;
            dirText.Text = Properties.Settings.Default.appPath;

            verLabel.Text = Application.ProductVersion;
            updateBtn.Enabled = false;
            CheckUpdate();

            if (Properties.Settings.Default.showAlert == "first") notificationBox.SelectedItem = notificationBox.Items[1]; else notificationBox.SelectedItem = notificationBox.Items[0];
            if (Properties.Settings.Default.closeFunction == "tray") closeModeBox.SelectedItem = closeModeBox.Items[1]; else closeModeBox.SelectedItem = closeModeBox.Items[0];
        }
        void CheckUpdate()
        {
            try
            {
                WebClient wc = new WebClient();
                recentVerLabel.Text = wc.DownloadString(verURL);

                if (verLabel.Text.Trim() != recentVerLabel.Text.Trim()) updateBtn.Enabled = true;
                else updateBtn.Enabled = false;
            }
            catch { recentVerLabel.Text = "Something went wrong."; }
        }

        public void OpenPath(object sender, EventArgs e)
        {
            try
            {
                Process.Start(dirText.Text);
            }
            catch { new Notification("Couldn't find the path for your files. Try checking for corrupted files.", "Error", NotificationButtons.Ok, true).ShowDialog(); }
        }
        public void ClearCache(object sender, EventArgs e)
        {
            try
            {
                File.Delete(dirText.Text + @"\cache.gsc");
                new Notification("Your cache has been cleared.", "Done", NotificationButtons.Ok, false).ShowDialog();
                main.ResetDocks();
            }
            catch { new Notification("There has been an error trying to delete your cache.", "Error", NotificationButtons.Ok, true).ShowDialog(); }
        }
        public void CheckCorrupted(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.appPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GSama";
                Properties.Settings.Default.Save();

                if (!Directory.Exists(Properties.Settings.Default.appPath + @"\favourites")) Directory.CreateDirectory(Properties.Settings.Default.appPath + @"\favourites");
                if (!Directory.Exists(Properties.Settings.Default.appPath + @"\apps")) Directory.CreateDirectory(Properties.Settings.Default.appPath + @"\apps");
                if (!Directory.Exists(Properties.Settings.Default.appPath + @"\resources")) Directory.CreateDirectory(Properties.Settings.Default.appPath + @"\resources");

                if (!File.Exists(Properties.Settings.Default.appPath + @"\resources\application.png"))
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFile(DefaultImg, Properties.Settings.Default.appPath + @"\resources\application.png");
                }
                if (!File.Exists(Properties.Settings.Default.appPath + @"\resources\Gsama-Logo.ico"))
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFile(DefaultIcon, Properties.Settings.Default.appPath + @"\resources\Gsama-Logo.ico");
                }

                Associate();
                AssociateCache();

                new Notification("Your files have been checked and fixed in case a problem was found!", "Done", NotificationButtons.Ok, false).ShowDialog();
            }
            catch { new Notification("There has been an error trying to retrieve your files.", "Error", NotificationButtons.Ok, true).ShowDialog(); }
        }
        public void DeleteAll(object sender, EventArgs e)
        {
            try
            {
                Notification n = new Notification("Are you sure you want to delete all of your shortcuts? This action can't be undone.", "Confirmation", NotificationButtons.YesNo, false);
                n.ShowDialog();
                bool yesClicked = n.YesClicked();
                //DialogResult res = MessageBox.Show("Are you sure you want to delete all of your shortcuts? This action can't be undone.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                //if (res == DialogResult.Yes)
                if (yesClicked)
                {
                    string[] af = Directory.GetFiles(Properties.Settings.Default.appPath + @"\apps");
                    string[] ff = Directory.GetFiles(Properties.Settings.Default.appPath + @"\favourites");
                    foreach (string f in af) { File.Delete(f); }
                    foreach (string f in ff) { File.Delete(f); }
                    File.Delete(Properties.Settings.Default.appPath + @"\cache.gsc");

                    main.ResetDocks();
                    new Notification("All of your shortcuts have been deleted!", "Done", NotificationButtons.Ok, false).ShowDialog();
                }
            }
            catch { new Notification("There has been an error trying to retrieve your files.", "Error", NotificationButtons.Ok, true).ShowDialog(); }
        }
        public void ResetAppSettings(object sender, EventArgs e)
        {
            try
            {
                Notification n = new Notification("Are you sure you want to reset your app settings? This action can't be undone.", "Confirmation", NotificationButtons.YesNo, false);
                n.ShowDialog();
                bool yesClicked = n.YesClicked();

                if (yesClicked)
                {
                    Properties.Settings.Default.Reset();
                    Properties.Settings.Default.Save();

                    new Notification("Your app settings have been reseted!", "Done", NotificationButtons.Ok, false).ShowDialog();
                }
            }
            catch { new Notification("There has been an error while attempting this action.", "Error", NotificationButtons.Ok, false).ShowDialog(); }
        }
        public void UpdateClick(object sender, EventArgs e)
        {
            try
            {
                WebClient wc = new WebClient();

                Process.Start(wc.DownloadString(UpdateURL));
            }
            catch { new Notification("There has been an error while trying to access the download URL. Access manually at 'https://www.godinho.work' to find the correct URL to update the app.", "Error", NotificationButtons.Ok, false).ShowDialog(); }
        }
        public void ChangeMode(object sender, EventArgs e)
        {
            if (closeModeBox.SelectedIndex == 0) Properties.Settings.Default.closeFunction = "exit";
            else Properties.Settings.Default.closeFunction = "tray";

            Properties.Settings.Default.Save();
        }
        public void ChangeNotification(object sender, EventArgs e)
        {
            if (notificationBox.SelectedIndex == 0) Properties.Settings.Default.showAlert = "always";
            else Properties.Settings.Default.showAlert = "first";

            Properties.Settings.Default.Save();
        }

        #region App association
        public static void Associate()
        {
            try
            {
                RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + Properties.Settings.Default.fileExtension);
                RegistryKey AppReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\GSama.exe");
                RegistryKey AppAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + Properties.Settings.Default.fileExtension);

                string caminho = Properties.Settings.Default.appPath + @"\resources\Gsama-Logo.ico";
                string[] c = caminho.Split('\u005c');
                string completo = "";
                foreach (string s in c)
                {
                    if (c[c.Length - 1] != s) completo += s + @"\\";
                    else completo += s;
                }

                FileReg.CreateSubKey("DefaultIcon").SetValue("", completo);
                FileReg.CreateSubKey("PerceivedType").SetValue("", "Text");

                AppReg.CreateSubKey("shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
                AppReg.CreateSubKey("shell\\edit\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
                AppReg.CreateSubKey("DefaultIcon").SetValue("", completo);

                AppAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Applications\\GSama.exe");
                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
            catch { new Notification("There has been an error while trying to associate the app extension to its files. Try again later.", "Error", NotificationButtons.Ok, false).ShowDialog(); }
        }
        public static void AssociateCache()
        {
            try
            {
                RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + Properties.Settings.Default.cacheExtension);
                RegistryKey AppReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\GSama.exe");
                RegistryKey AppAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + Properties.Settings.Default.cacheExtension);

                string caminho = Properties.Settings.Default.appPath + @"\resources\Gsama-Logo.ico";
                string[] c = caminho.Split('\u005c');
                string completo = "";
                foreach (string s in c)
                {
                    if (c[c.Length - 1] != s) completo += s + @"\\";
                    else completo += s;
                }

                FileReg.CreateSubKey("DefaultIcon").SetValue("", completo);
                FileReg.CreateSubKey("PerceivedType").SetValue("", "Text");

                AppReg.CreateSubKey("shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
                AppReg.CreateSubKey("shell\\edit\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
                AppReg.CreateSubKey("DefaultIcon").SetValue("", completo);

                AppAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Applications\\GSama.exe");
                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
            catch { new Notification("There has been an error while trying to associate the app extension to its files. Try again later.", "Error", NotificationButtons.Ok, false).ShowDialog(); }
        }
        #endregion
    }
}