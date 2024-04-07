using System;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace rmodo
{
    internal class Program
    {
        private static string exename = "";
        static void OnKeyDown(Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                const string message = "• Author: Michaël André Franiatte.\n\r\n\r• Contact: michael.franiatte@gmail.com.\n\r\n\r• Publisher: https://github.com/michaelandrefraniatte.\n\r\n\r• Copyrights: All rights reserved, no permissions granted.\n\r\n\r• License: Not open source, not free of charge to use.";
                const string caption = "About";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a exe name to create a shortcut on your desktop:");
            exename = Console.ReadLine();
            CreateShortcut();
            Environment.Exit(0);
        }
        private static void CreateShortcut()
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + exename + ".lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Shortcut for " + exename;
            shortcut.TargetPath = System.Windows.Forms.Application.StartupPath + @"\" + exename + ".exe";
            shortcut.WorkingDirectory = System.Windows.Forms.Application.StartupPath;
            shortcut.Save();
        }
    }
}