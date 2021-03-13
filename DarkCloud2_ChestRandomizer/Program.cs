using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkCloud2_ChestRandomizer
{
    static class Program
    {

        public static void PressEntertoContinue() //Added a simple function for pausing and waiting for input from the user.
        {
            Console.WriteLine("\n\nPress the Enter key to continue");
            Console.Read(); //Wait for input and then discard it.
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("\nDark Cloud 2 Chest Randomizer");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Memory.CloseHandle(Memory.processH); //Close our handle to the process, we are finished with our program
 

            PressEntertoContinue();
        }

        public static void ExitProgram()
        {
            Environment.Exit(0);
        }

    }
}
