using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Godinho_sama
{
    public partial class Notification : Form
    {
        bool yesPressed = false;
        bool forceClosing = false;

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

        public Notification(string conteudo, string title, NotificationButtons buttons, bool forceClose)
        {   
            InitializeComponent();

            content.Text = conteudo;
            this.title.Text = title;
            forceClosing = forceClose;
            if(buttons == NotificationButtons.Ok) { button2.Text = "OK"; button2.Click += Fechar; }
            else if (buttons == NotificationButtons.YesNo) { button2.Text = "No"; button2.Click += Fechar; button2.BackColor = Color.Brown;
                button1.Text = "Yes"; button1.Visible = true; button1.Click += Yes;
            }

            this.FormClosed += OnClose;
        }

        public bool YesClicked()
        {
            return yesPressed;
        }
        private void Yes(object sender, EventArgs e)
        {
            yesPressed= true;
            Fechar(null, null);
        }
        private void Fechar(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Minimize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void OnClose(object sender, FormClosedEventArgs e)
        {
            if(forceClosing) Application.Exit();
        }
    }
}
