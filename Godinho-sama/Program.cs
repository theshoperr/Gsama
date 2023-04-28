using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Godinho_sama
{
    internal static class Program
    {
        static string DefaultImg = "https://raw.githubusercontent.com/theshoperr/Gsama/main/application.png";
        static string DefaultIcon = "https://raw.githubusercontent.com/theshoperr/Gsama/main/Gsama-Logo.ico";

        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Impedir de abrir mais de uma instância do aplicativo ao mesmo tempo!
            Process[] p = Process.GetProcesses();
            Process[] esse = Process.GetProcessesByName("Godinho-sama");
            if (esse.Length != 0) foreach (Process e in esse) if (e.Id != Process.GetCurrentProcess().Id) e.Kill();

            //Separa os argumentos em uma string unica
            string arg = "";
            for (int i = 0; i < args.Length; i++) arg = arg + " " + args[i];

            //Setar sempre a variável do app path. Sempre ativo caso o usuário troque algo no windows
            Properties.Settings.Default.appPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\GSama";
            Properties.Settings.Default.Save();

            //Criar pastas padrões do app
            if (!Directory.Exists(Properties.Settings.Default.appPath + @"\favourites")) Directory.CreateDirectory(Properties.Settings.Default.appPath + @"\favourites");
            if (!Directory.Exists(Properties.Settings.Default.appPath + @"\apps")) Directory.CreateDirectory(Properties.Settings.Default.appPath + @"\apps");
            if (!Directory.Exists(Properties.Settings.Default.appPath + @"\resources")) Directory.CreateDirectory(Properties.Settings.Default.appPath + @"\resources");

            //Baixar os recursos padrões como o icone do app e o icone de app vazio
            if (!File.Exists(Properties.Settings.Default.appPath + @"\resources\application.png"))
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(DefaultImg, Properties.Settings.Default.appPath + @"\resources\application.png");
            }
            if (!File.Exists(Properties.Settings.Default.appPath + @"\resources\Gsama-Logo.ico"))
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(DefaultIcon, Properties.Settings.Default.appPath + @"\resources\Gsama-Logo.ico");
            }

            //Associar as extensões .gsm e .gsc com o App
            if (Properties.Settings.Default.firstOpen) { Associate(); AssociateCache(); }
            else
            {
                if (!IsAssociated()) { }
                else { Associate(); }

                if (!IsAssociated2()) { }
                else { AssociateCache(); }
            }

            if (arg.Contains(Properties.Settings.Default.cacheExtension)) new Notification("You cannot open this file with this extension.", "Wrong file format", NotificationButtons.Ok, true).ShowDialog();
            else
            {
                if (args.Length == 0) Application.Run(new Home(string.Empty));
                else Application.Run(new Home(arg));
            }
        }

        public static bool IsAssociated()
        {
            return (Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + Properties.Settings.Default.fileExtension, false) == null);
        }
        public static bool IsAssociated2()
        {
            return (Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + Properties.Settings.Default.cacheExtension, false) == null);
        }

        public static void Associate()
        {
            try
            {
                RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + Properties.Settings.Default.fileExtension);
                RegistryKey AppReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\GSama.exe");
                RegistryKey AppAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + Properties.Settings.Default.fileExtension);

                string caminho = Properties.Settings.Default.appPath + @"\resources\Gsama-Logo.ico";
                string[] c = caminho.Split('\u005c');
                string completo = "";
                foreach (string s in c)
                {
                    if (c[c.Length - 1] != s) completo += s + @"\\";
                    else completo += s;
                }

                FileReg.CreateSubKey("DefaultIcon").SetValue("", completo);
                FileReg.CreateSubKey("PerceivedType").SetValue("", "Text");

                AppReg.CreateSubKey("shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
                AppReg.CreateSubKey("shell\\edit\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
                AppReg.CreateSubKey("DefaultIcon").SetValue("", completo);

                AppAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Applications\\GSama.exe");
                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
            catch { new Notification("There has been an error trying to register the app's extension to your system. It's not something that will affect the use of the app.", "Error", NotificationButtons.Ok, false).ShowDialog(); }
        }
        public static void AssociateCache()
        {
            try
            {
                RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + Properties.Settings.Default.cacheExtension);
                RegistryKey AppReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\GSama.exe");
                RegistryKey AppAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + Properties.Settings.Default.cacheExtension);

                string caminho = Properties.Settings.Default.appPath + @"\resources\Gsama-Logo.ico";
                string[] c = caminho.Split('\u005c');
                string completo = "";
                foreach (string s in c)
                {
                    if (c[c.Length - 1] != s) completo += s + @"\\";
                    else completo += s;
                }

                FileReg.CreateSubKey("DefaultIcon").SetValue("", completo);
                FileReg.CreateSubKey("PerceivedType").SetValue("", "Text");

                AppReg.CreateSubKey("shell\\open\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
                AppReg.CreateSubKey("shell\\edit\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
                AppReg.CreateSubKey("DefaultIcon").SetValue("", completo);

                AppAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Applications\\GSama.exe");
                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
            catch { new Notification("There has been an error trying to register the app's extension to your system. It's not something that will affect the use of the app.", "Error", NotificationButtons.Ok, false).ShowDialog(); }
        }
    }
}
