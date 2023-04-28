using Godinho_sama;
using Godinho_sama.scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theshoperr
{
    public static class SubForm
    {

        public static Control dock;
        public static Home main;
        public static List<string> pages = new List<string>();

        private static Form activeForm = null;

        private static Form lastForm = null;
        private static Form nextForm = null;

        /// <summary>
        /// Função para abrir um sub-formulário no controle especificado pela variável 'dock'.
        /// </summary>
        public static void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                lastForm = activeForm;
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            dock.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        /// <summary>
        /// Função para fechar todos os sub-formulários e deixar o dock vazio.
        /// </summary>
        public static void CloseAll()
        {
            if(activeForm!=null) activeForm.Close();
        }

        /// <summary>
        /// Função para voltar uma cena atrás.
        /// </summary>
        public static void Previous()
        {
            switch (pages[pages.Count - 1])
            {
                case "create":
                    OpenChildForm(new CreateNew(main));
                    break;
                case "edit":
                    //OpenChildForm(new EditItem(main));
                    break;
                case "home":
                    CloseAll();
                    break;
            }

            if (lastForm != null)
            {
                nextForm = activeForm;
                Form f = new Form();
                f = lastForm;
                OpenChildForm(f);
            }
            if(activeForm!= null)
            {
                nextForm = activeForm;
                CloseAll();
            }
        }

        /// <summary>
        /// Função para avançar uma cena.
        /// </summary>
        public static void Next()
        {
            if (nextForm != null)
            {
                Form f = new Form();
                f = nextForm;
                OpenChildForm(f);
            }
        }

    }
}
