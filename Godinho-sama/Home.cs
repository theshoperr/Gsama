using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theshoperr;

namespace Godinho_sama
{
    public partial class Home : Form
    {
        public List<string> toDelete = new List<string>();
        public string args = string.Empty;
        string verURL = "https://raw.githubusercontent.com/theshoperr/Gsama/main/version.txt";
        string UpdateURL = "https://raw.githubusercontent.com/theshoperr/Gsama/main/updateURL.txt";
        bool firstOpen = true;

        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }

        public Home(string arg)
        {
            InitializeComponent();
            
            if(Properties.Settings.Default.firstOpen) new Intro().ShowDialog();

            DragWindow.form = this;
            DragWindow.translucent = false;
            bar.MouseDown += DragWindow.Bar_Down;
            bar.MouseUp += DragWindow.Bar_Up;
            bar.MouseMove += DragWindow.Bar_Move;

            SubForm.dock = dock;
            SubForm.main = this;

            AddRecent.main = this;

            args = arg;
            if(args != string.Empty) OpenEdit(null, null);

            LoadItems();

            appsDock.Visible = Properties.Settings.Default.appsOpened;
            favDock.Visible = Properties.Settings.Default.favOpened;
            if (Properties.Settings.Default.favOpened) favBtn.Text = "Favourites ▴"; else favBtn.Text = "Favourites ▾";
            if (Properties.Settings.Default.appsOpened) appBtn.Text = "Apps ▴"; else appBtn.Text = "Apps ▾";

            switch(Properties.Settings.Default.windowState)
            {
                case "minimized":
                    Normal(null, null);
                    break;
                case "maximized":
                    Max(null, null);
                    break;
                case "normal":
                    Normal(null, null);
                    break;
            }

            CheckUpdate();

            bar.DoubleClick += Max;
        }

        void CheckUpdate()
        {
            try
            {
                WebClient wc = new WebClient();
                string onlineVer = wc.DownloadString(verURL);

                if(onlineVer.Trim() != Application.ProductVersion.ToString())
                {
                    Notification n = new Notification("There is a new update available for the app. Would you like to be redirected to the download page?", "Update available", NotificationButtons.YesNo, false);
                    n.ShowDialog();
                    bool yesClicked = n.YesClicked();
                    if (yesClicked)
                    {
                        string url = wc.DownloadString(UpdateURL);
                        Process.Start(url);
                    }
                }
            }
            catch { new Notification("There has been an error while trying to run the update function. Try again later.", "Error", NotificationButtons.Ok, false); }
        }

        void LoadItems()
        {
            try
            {
                //FAV ITEMS
                string[] fFiles = Directory.GetFiles(Properties.Settings.Default.appPath + @"\favourites");
                foreach (string ff in fFiles)
                {
                    RichTextBox rb = new RichTextBox();
                    StreamReader sr = File.OpenText(ff);
                    rb.Text = sr.ReadToEnd();
                    sr.Close();
                    GameItem gi = new GameItem(this);
                    gi.GameName = rb.Lines[0];
                    if (rb.Lines[1] != "Default") gi.Picture = Image.FromFile(rb.Lines[1]);
                    else gi.Picture = Image.FromFile(Properties.Settings.Default.appPath + @"\resources\application.png");
                    gi.Executable = rb.Lines[2];
                    gi.Path = ff;

                    favDock.Controls.Add(gi);
                }

                //APP ITEMS
                string[] aFiles = Directory.GetFiles(Properties.Settings.Default.appPath + @"\apps");
                foreach (string af in aFiles)
                {
                    RichTextBox rb = new RichTextBox();
                    StreamReader sr = File.OpenText(af);
                    rb.Text = sr.ReadToEnd();
                    sr.Close();
                    GameItem gi = new GameItem(this);
                    gi.GameName = rb.Lines[0];
                    if (rb.Lines[1] != "Default") gi.Picture = Image.FromFile(rb.Lines[1]);
                    else gi.Picture = Image.FromFile(Properties.Settings.Default.appPath + @"\resources\application.png");
                    gi.Executable = rb.Lines[2];
                    gi.Path = af;

                    appsDock.Controls.Add(gi);
                }
                LoadRecents();
            }
            catch { new Notification("There has been an error trying to retrieve your files.", "Error", NotificationButtons.Ok, true).ShowDialog(); }
        }
        void LoadRecents()
        {
            try
            {
                if (!File.Exists(Properties.Settings.Default.appPath + @"\cache.gsc")) return;

                StreamReader sr = File.OpenText(Properties.Settings.Default.appPath + @"\cache.gsc");
                RichTextBox rb = new RichTextBox();
                rb.Text = sr.ReadToEnd();
                sr.Close();
                for (int i = 0; i < rb.Lines.Length; i++)
                {
                    if (!string.IsNullOrEmpty(rb.Lines[i]))
                    {
                        StreamReader s = File.OpenText(Properties.Settings.Default.appPath + @"\apps\" + rb.Lines[i]);
                        RichTextBox r = new RichTextBox();
                        r.Text = s.ReadToEnd();
                        s.Close();

                        RecentItem ri = new RecentItem();
                        ri.Executable = r.Lines[2];
                        if (r.Lines[1] != "Default") ri.Picture = Image.FromFile(r.Lines[1]);
                        else ri.Picture = Properties.Resources.application;
                        ri.GameName = r.Lines[0].Split('.')[0];

                        recentDock.Controls.Add(ri);
                    }
                }
            }
            catch { new Notification("There has been an error trying to retrieve your files.", "Error", NotificationButtons.Ok, true).ShowDialog(); }
        }
        public void ResetDocks()
        {
            favDock.Controls.Clear();
            appsDock.Controls.Clear();
            recentDock.Controls.Clear();

            LoadItems();
        }

        public string FilePath = null;
        public void OpenEdit(object sender, EventArgs e)
        {
            if (args != string.Empty) FilePath = args;
            SubForm.OpenChildForm(new scenes.EditItem(this, FilePath));
            FilePath = null;
        }
        public void OpenCreate(object sender, EventArgs e)
        {
            SubForm.OpenChildForm(new scenes.CreateNew(this));
        }
        public void OpenSettings(object sender, EventArgs e)
        {
            SubForm.OpenChildForm(new scenes.Settings(this));
        }
        public void GoHome(object sender, EventArgs e)
        {
            SubForm.CloseAll();
        }
        public void Previous(object sender, EventArgs e)
        {
            SubForm.Previous();
        }
        public void Next(object sender, EventArgs e)
        {
            SubForm.Next();
        }

        #region System
        public void Favs(object sender, EventArgs e)
        {
            favDock.Visible = !favDock.Visible;
            Properties.Settings.Default.favOpened = favDock.Visible;
            Properties.Settings.Default.Save();
            if (favDock.Visible) favBtn.Text = "Favourites ▴"; else favBtn.Text = "Favourites ▾";
        }
        public void Apps(object sender, EventArgs e)
        {
            appsDock.Visible = !appsDock.Visible;
            Properties.Settings.Default.appsOpened = appsDock.Visible;
            Properties.Settings.Default.Save();
            if (appsDock.Visible) appBtn.Text = "Apps ▴"; else appBtn.Text = "Apps ▾";
        }
        public void Fechar(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.closeFunction == "tray")
            {
                this.WindowState = FormWindowState.Minimized;
                //Mini(null, null);

                bool MouseNotOnTaskbar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

                if (MouseNotOnTaskbar)
                {
                    if (Properties.Settings.Default.showAlert == "first")
                    {
                        if (firstOpen)
                        {
                            trayApp.ShowBalloonTip(1000, "Notice", "App minimized to system tray.", ToolTipIcon.Info);
                            firstOpen = false;
                        }
                    }
                    //else if (Properties.Settings.Default.showAlert == "always")
                        //trayApp.ShowBalloonTip(1000, "Notice", "App minimized to system tray.", ToolTipIcon.Info);

                    ShowInTaskbar = false;
                    trayApp.Visible = true;
                    Hide();
                }
            }
            else if(Properties.Settings.Default.closeFunction == "exit") Application.Exit();
        }
        public void HardClose(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void Mini(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { bar.DoubleClick -= Max; bar.DoubleClick += Normal; }
            else { bar.DoubleClick -= Normal; bar.DoubleClick += Max; }
            this.WindowState = FormWindowState.Minimized;
            Properties.Settings.Default.windowState = "normal";
            Properties.Settings.Default.Save();
        }
        public void Max(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            maximizeBtn.Click -= Max;
            maximizeBtn.Click += Normal;
            maximizeBtn.Text = "◱";

            bar.DoubleClick -= Max;
            bar.DoubleClick += Normal;

            Properties.Settings.Default.windowState = "maximized";
            Properties.Settings.Default.Save();
        }
        public void Normal(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            maximizeBtn.Click -= Normal;
            maximizeBtn.Click += Max;
            maximizeBtn.Text = "▢";

            bar.DoubleClick -= Normal;
            bar.DoubleClick += Max;

            Properties.Settings.Default.windowState = "normal";
            Properties.Settings.Default.Save();
        }
        public void OpenFromTray(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.windowState == "maximized") Max(null, null);
            else if (Properties.Settings.Default.windowState == "normal") Normal(null, null);
            else if (Properties.Settings.Default.windowState == "minimized") Normal(null, null);

            ShowInTaskbar = true;
            trayApp.Visible = false;
            Show();
        }
        public void SettingsFromTray(object sender, EventArgs e)
        {
            OpenFromTray(null, null);
            SubForm.OpenChildForm(new scenes.Settings(this));
        }
        #endregion
    }
}
