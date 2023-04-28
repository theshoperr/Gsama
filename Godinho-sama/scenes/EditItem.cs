using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theshoperr;

namespace Godinho_sama.scenes
{
    public partial class EditItem : Form
    {
        Home main;
        string Path;
        bool fav = false;
        string fileName;
        string firstImage;
        string firstName;
        bool wasFav = false;

        public EditItem(Home h, string path)
        {
            InitializeComponent();
            main= h;
            Path = path;

            LoadItem();
        } 

        void LoadItem()
        {
            try
            {
                StreamReader sr = File.OpenText(Path);
                RichTextBox rb = new RichTextBox();
                rb.Text = sr.ReadToEnd();
                sr.Close();
                appName.Text = rb.Lines[0];
                firstName = rb.Lines[0];
                if (rb.Lines[1] != "Default")
                {
                    imagePath.Text = rb.Lines[1];
                    picture.Image = Image.FromFile(rb.Lines[1]);
                    fileName = rb.Lines[1];
                }
                firstImage = rb.Lines[1];
                appText.Text = rb.Lines[2];

                string[] a = Path.Split('\u005c');
                if (File.Exists(Properties.Settings.Default.appPath + @"\favourites\" + a[a.Length - 1]))
                {
                    favBtn.Image = Properties.Resources.heart_fill;
                    fav = true;
                    wasFav = true;
                }
            }
            catch { new Notification("There has been an error trying to retrieve your files.", "Error", NotificationButtons.Ok, true).ShowDialog(); }
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
        public void Salvar(object sender, EventArgs e) 
        {
            if (string.IsNullOrEmpty(appText.Text)) { new Notification("You need to fill all the required fields to continue.", "Error", NotificationButtons.Ok, false).ShowDialog(); return; }
            if (string.IsNullOrEmpty(appName.Text)) { new Notification("You need to fill all the required fields to continue.", "Error", NotificationButtons.Ok, false).ShowDialog(); return; }

            try
            {
                //Se tiver começado com uma imagem
                if (firstImage != "Default")
                {
                    //Se tiver trocado a imagem original
                    if (imagePath.Text != firstImage)
                    {
                        //Se só tiver trocado de imagem
                        if (!string.IsNullOrEmpty(imagePath.Text))
                        {
                            //File.Delete(firstImage);
                            main.toDelete.Add(firstImage);
                            if (!File.Exists(Properties.Settings.Default.appPath + @"\resources\" + fileName))
                            {
                                File.Copy(imagePath.Text, Properties.Settings.Default.appPath + @"\resources\" + fileName, true);
                            }
                            imgNull = false;
                        }
                        //Se tiver removido a imagem
                        else
                        {
                            imgNull = true;
                            //File.Delete(firstImage);
                            main.toDelete.Add(firstImage);
                        }
                    }
                    //Se não tiver trocado e for vazio
                    else if (string.IsNullOrEmpty(imagePath.Text)) imgNull = true;
                    //Se não tiver trocado e tiver imagem
                    else
                    {
                        imgNull = false;
                        string[] p = fileName.Split('\u005c');
                        fileName = p[p.Length - 1];
                    }
                }
                //Se não tiver começado com uma imagem
                else
                {
                    //Se tiver escolhido uma imagem
                    if (!string.IsNullOrEmpty(imagePath.Text))
                    {
                        imgNull = false;
                        if (!File.Exists(Properties.Settings.Default.appPath + @"\resources\" + fileName)) File.Copy(imagePath.Text, Properties.Settings.Default.appPath + @"\resources\" + fileName, true);
                    }
                    //Se não tiver escolhido imagem nenhuma
                    else imgNull = true;
                }

                if (appName.Text != firstName || fav != wasFav)
                {
                    File.Delete(Properties.Settings.Default.appPath + @"\apps\" + firstName + ".gsm");
                    if (wasFav) File.Delete(Properties.Settings.Default.appPath + @"\favourites\" + firstName + ".gsm");
                }

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

                if (fileName != appName.Text) AddRecent.Atualizar(firstName + ".gsm", appName.Text + ".gsm");
                this.Dispose();
                SubForm.CloseAll();
                main.ResetDocks();
            }
            catch { new Notification("There has been an error trying to editing and saving the file for your shortcut.", "Error", NotificationButtons.Ok, true).ShowDialog(); }
        }

        public void Deletar(object sender, EventArgs e)
        {
            Notification n = new Notification("Are you sure you want to delete this?", "Confirmation", NotificationButtons.YesNo, false);
            n.ShowDialog();
            bool yesClicked = n.YesClicked();
            //DialogResult res = MessageBox.Show("Are you sure you want to delete this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            //if(res == DialogResult.Yes) 
            if(yesClicked) 
            {
                try
                {
                    string[] b = Path.Split('\u005c');
                    File.Delete(Properties.Settings.Default.appPath + @"\apps\" + b[b.Length - 1]);
                    if (wasFav)
                    {
                        File.Delete(Properties.Settings.Default.appPath + @"\favourites\" + b[b.Length - 1]);
                    }
                    if (firstImage != "Default")
                    {
                        //File.Delete(firstImage);
                        main.toDelete.Add(firstImage);
                    }

                    StreamReader sr = File.OpenText(Properties.Settings.Default.appPath + @"\cache.gsc");
                    RichTextBox rb = new RichTextBox();
                    rb.Text = sr.ReadToEnd();
                    sr.Dispose();
                    bool tem = false;
                    RichTextBox r = new RichTextBox();
                    for (int i = 0; i < rb.Lines.Length; i++)
                        if (rb.Lines[i] == b[b.Length - 1]) { tem = true; }
                        else { r.AppendText(rb.Lines[i] + '\n'); }

                    rb.Text = r.Text.Trim();

                    if (tem)
                    {
                        StreamWriter sw = File.CreateText(Properties.Settings.Default.appPath + @"\cache.gsc");
                        sw.Write(rb.Text);
                        sw.Dispose();
                    }

                    main.ResetDocks();
                    SubForm.CloseAll();
                }
                catch { new Notification("There has been an error trying to delete your file.", "Error", NotificationButtons.Ok, true).ShowDialog(); }
            }
        }
    }
}