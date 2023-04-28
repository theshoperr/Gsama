using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theshoperr;

namespace Godinho_sama.scenes
{
    public partial class CreateNew : Form
    {
        bool fav = false;
        string fileName;
        Home h;
        
        public CreateNew(Home main)
        {
            InitializeComponent();
            h = main;
        }

        public void Favoritar(object sender, EventArgs e)
        {
            fav = !fav;
            if (fav) favBtn.Image = Properties.Resources.heart_fill; else favBtn.Image = Properties.Resources.heart;
        }

        public void Cancelar(object sender, EventArgs e)
        {
            SubForm.CloseAll();
        }

        public void RemoveImg(object sender, EventArgs e)
        {
            imagePath.Text = string.Empty; picture.Image = Properties.Resources.application;
        }

        public void Procurar(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image files (*.png)|*.png";
                ofd.Multiselect = false;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.Title = "Select an icon for the app";
                ofd.DefaultExt = ".png";
                ofd.ShowDialog();
                imagePath.Text = ofd.FileName;
                fileName = ofd.SafeFileName;
                if (ofd.FileName == string.Empty) return;
                picture.Image = Image.FromFile(ofd.FileName);
                ofd.Dispose();
            }
            catch { new Notification("There has been an error trying to open the file dialog. Try again later.", "Error", NotificationButtons.Ok, false).ShowDialog(); }
        }

        public void ProcurarApp(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Executable files (*.exe)|*.exe";
                ofd.Multiselect = false;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.Title = "Select the app to run";
                ofd.DefaultExt = ".exe";
                ofd.ShowDialog();
                appText.Text = ofd.FileName;
            }
            catch { new Notification("There has been an error trying to open the file dialog. Try again later.", "Error", NotificationButtons.Ok, false).ShowDialog(); }
        }

        public void LoadURL(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(urlText.Text))
            {
                new Notification("Please provide an URL for your image.", "No URL provided", NotificationButtons.Ok, false).ShowDialog();
                return;
            }

            WebClient wc = new WebClient();
            string[] n = urlText.Text.Split('/');
            string fname = n[n.Length - 1];

            try
            {
                if (!File.Exists(Properties.Settings.Default.appPath + @"\resources\" + fname))
                    wc.DownloadFile(urlText.Text, Properties.Settings.Default.appPath + @"\resources\" + fname);

                imagePath.Text = Properties.Settings.Default.appPath + @"\resources\" + fname;
                picture.Image = Image.FromFile(imagePath.Text);
                fileName = fname;
            }
            catch (Exception ex)
            {
                new Notification(ex.Message, "Error", NotificationButtons.Ok, false).ShowDialog();
            }
        }

        bool imgNull = false;
        public void Criar(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(appText.Text)) { new Notification("You need to fill all the required fields to continue.", "Error", NotificationButtons.Ok, true).ShowDialog(); return; }
            if (string.IsNullOrEmpty(appName.Text)) { new Notification("You need to fill all the required fields to continue.", "Error", NotificationButtons.Ok, true).ShowDialog(); return; }

            try
            {
                if (!string.IsNullOrEmpty(imagePath.Text))
                {
                    if (!File.Exists(Properties.Settings.Default.appPath + @"\resources\" + fileName)) File.Copy(imagePath.Text, Properties.Settings.Default.appPath + @"\resources\" + fileName); imgNull = false;
                }
                else imgNull = true;

                StreamWriter sw = File.CreateText(Properties.Settings.Default.appPath + @"\apps\" + appName.Text + ".gsm");
                sw.WriteLine(appName.Text);
                if (!imgNull) sw.WriteLine(Properties.Settings.Default.appPath + @"\resources\" + fileName);
                else sw.WriteLine("Default");
                sw.WriteLine(appText.Text);
                sw.Close();

                if (fav)
                {
                    StreamWriter sw2 = File.CreateText(Properties.Settings.Default.appPath + @"\favourites\" + appName.Text + ".gsm");
                    sw2.WriteLine(appName.Text);
                    if (!imgNull) sw2.WriteLine(Properties.Settings.Default.appPath + @"\resources\" + fileName);
                    else sw2.WriteLine("Default");
                    sw2.WriteLine(appText.Text);
                    sw2.Close();
                }

                this.Dispose(true);
                SubForm.CloseAll();
                h.ResetDocks();
            }
            catch { new Notification("There has been an error trying to create this shortcut. Check if you provided a correct executable file.", "Error creating shortcut", NotificationButtons.Ok, true).ShowDialog(); }
        }
    }
}
