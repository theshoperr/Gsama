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
    public partial class Intro : Form
    {

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

        public Intro()
        {
            InitializeComponent();
        }

        public void Fechar(object sender, EventArgs e)
        {
            Properties.Settings.Default.firstOpen = false;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
