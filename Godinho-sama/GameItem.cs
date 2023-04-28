using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theshoperr;

namespace Godinho_sama
{
    public partial class GameItem : UserControl
    {
        bool highlighted = false;
        Home main;

        public GameItem(Home main)
        {
            InitializeComponent();
            this.main = main;
        }

        public void Entrou(object sender, EventArgs e)
        {
            if(!highlighted) this.BackColor = Color.FromArgb(68, 73, 82);
            highlighted = true;
        }
        public void Saiu(object sender, EventArgs e)
        {
            if(highlighted) this.BackColor = Color.FromArgb(57, 61, 69);
            highlighted = false;
        }

        public void Run(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_executable);
                AddRecent.Adicionar(_name + ".gsm");
                SubForm.CloseAll();
            }
            catch { MessageBox.Show("There has been an error while trying to launch that app. Maybe it's directory has been changed. Edit the path and try again.", "Error launching", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void Editar(object sender, EventArgs e)
        {
            main.FilePath = _path;
            main.OpenEdit(null, null);
        }

        private string _name;
        private Image _image;
        private string _executable;
        private string _path;

        [Category("Item Properties")]
        public string GameName
        {
            get { return _name; }
            set { _name = value; name.Text = value; }
        }
        public Image Picture
        {
            get { return _image; }
            set { _image = value; picture.Image = value; }
        }
        public string Executable
        {
            get { return _executable; }
            set { _executable = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
}
