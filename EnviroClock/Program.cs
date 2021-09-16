using EnviroClock;
using Microsoft.Win32;
using System;
using System.Threading;
using System.Windows.Forms;

namespace EnviroClock
{
    static class Program
    {
		private static Mutex singleton = new Mutex(true, "EnviroClock");
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
            

            if (!Program.singleton.WaitOne(TimeSpan.Zero, true))
            {
                Application.Exit();
                MessageBox.Show("Application instance already running ");
            }
            else
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                registryKey.SetValue("EnviroClock", Application.ExecutablePath);
                Access.GrantAccess(Application.StartupPath);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Welcome());
            }

        }
    }
}
