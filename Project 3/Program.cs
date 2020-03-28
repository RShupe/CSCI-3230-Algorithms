using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         Program.cs
//	Description:       This executes the main window of the program
//
//	Course:            CSCI 3230 - Algorithms
//	Author:            Ryan Shupe, shuper@etsu.edu, East Tennessee State University.
//	Created:           Wednesday, Mar 25 2020
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace Project_3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Main()); //launch the main window
        }
    }
}