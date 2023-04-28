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

namespace Godinho_sama
{
    public partial class RecentItem : UserControl
    {
        public RecentItem()
        {
            InitializeComponent();
        }

        public void Entrar(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(221, 223, 227);
        }
        public void Sair(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(210, 212, 218);
        }

        public void Executar(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_executable);
                AddRecent.Adicionar(_name + ".gsm");
            }
            catch { MessageBox.Show("There has been an error while trying to launch that app. Maybe it's directory has been changed. Edit the path and try again.", "Error launching", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        [Category("Recent Item Properties")]
        private Image _picture;
        private string _executable;
        private string _name;

        public Image Picture
        {
            get { return _picture; }
            set { _picture = value; pictureBox1.Image = value; }
        }
        public string Executable
        {
            get { return _executable; }
            set { _executable = value; }
        }
        public string GameName
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
