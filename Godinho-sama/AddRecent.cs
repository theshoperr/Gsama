using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Godinho_sama
{
    public static class AddRecent
    {
        public static Home main;

        public static void Adicionar(string item)
        {
            if (!File.Exists((Properties.Settings.Default.appPath + @"\cache.gsc")))
            {
                FileStream f = File.Create(Properties.Settings.Default.appPath + @"\cache.gsc");
                f.Close();
            }

            StreamReader sr = File.OpenText(Properties.Settings.Default.appPath + @"\cache.gsc");
            RichTextBox rb = new RichTextBox();
            rb.Text = sr.ReadToEnd();
            sr.Close();

            if (rb.Text.Contains(item))
            {
                RichTextBox r = new RichTextBox();
                for (int i = 0; i < rb.Lines.Length; i++)
                {
                    if (rb.Lines[i] != item) if(!string.IsNullOrEmpty(rb.Lines[i])) r.AppendText(rb.Lines[i]+'\n');
                }
                rb.Text = r.Text;

            }
            rb.AppendText(item+'\n');
            rb.Text.Trim();

            RichTextBox r2 = new RichTextBox();
            for(int i = rb.Lines.Length - 1; i >= 0; i--)
            {
                r2.AppendText(rb.Lines[i]+'\n');
            }
            r2.Text.Trim();
            rb.Text = r2.Text;

            StreamWriter sw = File.CreateText(Properties.Settings.Default.appPath + @"\cache.gsc");
            sw.Write(rb.Text);
            sw.Close();

            main.ResetDocks();
        }

        public static void Atualizar(string oldName, string newName)
        {
            if (!File.Exists((Properties.Settings.Default.appPath + @"\cache.gsc")))
            {
                FileStream f = File.Create(Properties.Settings.Default.appPath + @"\cache.gsc");
                f.Close();
            }

            StreamReader sr = File.OpenText(Properties.Settings.Default.appPath + @"\cache.gsc");
            RichTextBox rb = new RichTextBox();
            rb.Text = sr.ReadToEnd();
            sr.Close();

            RichTextBox r = new RichTextBox();
            for(int i = 0; i < rb.Lines.Length; i++)
            {
                if (rb.Lines[i] != oldName) r.AppendText(rb.Lines[i] + '\n');
                else r.AppendText(newName+'\n');
            }
            r.Text.Trim();
            rb.Text = r.Text;
            rb.Text.Trim();

            StreamWriter sw = File.CreateText(Properties.Settings.Default.appPath + @"\cache.gsc");
            sw.Write(rb.Text);
            sw.Close();
        }
    }
}
