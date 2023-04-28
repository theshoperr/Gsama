using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theshoperr
{
    public static class DragWindow
    {
        static public Form form;
        static public float opacity = 0.5f;
        static public bool translucent = true;

        private static bool move = false;
        private static int mx, my;

		/// <summary>
        /// Função para quando clicar em cima da barra.
        /// </summary>
        public static void Bar_Down(object sender, MouseEventArgs e)
        {
            move = true;
            mx = e.X;
            my = e.Y;
        }

		/// <summary>
        /// Função para quando mover o mouse.
        /// </summary>
        public static void Bar_Move(object sender, MouseEventArgs e)
        {
            if (move) { form.SetDesktopLocation(Control.MousePosition.X - mx, Control.MousePosition.Y - my); if(translucent) form.Opacity = opacity; }
        }

		/// <summary>
        /// Função para quando parar de clicar.
        /// </summary>
        public static void Bar_Up(object sender, MouseEventArgs e)
        {
            form.Opacity = 1.0f;
            move = false;
        }
    }
}
