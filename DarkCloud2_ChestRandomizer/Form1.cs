using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace DarkCloud2_ChestRandomizer
{
    public partial class Form1 : Form
    {
        public bool gameCheck = false;
        public static bool versionCheck;
        public Form1()
        {
            InitializeComponent();
            if (Memory.PID != 0)
            {
                label2.Text = "This mod randomizes the chest loots in Dark Cloud 2. You must be using PCSX2 and have Dark Cloud 2 (USA) / Dark Chronicle (PAL).";

                if (Memory.ReadInt(0x203694D0) == 1701667175)
                {
                    gameCheck = true;
                    Randomizer.gameVersion = 1;
                    label3.Text = "Detected Dark Chronicle (PAL version)! Press begin to start randomizing chests.";
                }
                else if (Memory.ReadInt(0x20364BD0) == 1701667175)
                {
                    gameCheck = true;
                    Randomizer.gameVersion = 2;
                    label3.Text = "Detected Dark Cloud 2 (USA version)! Press begin to start randomizing chests.";
                }
                else
                {
                    button1.Enabled = false;
                    label3.Text = "Cannot find active Dark Cloud 2 game, please launch Dark Cloud 2 and restart this mod.";
                }
            }
            else
            {
                label3.Enabled = false;
                button1.Enabled = false;               
            }
        }

        public static Thread chestThread = new Thread(new ThreadStart(Randomizer.ChestRandomizer));

        private void button1_Click(object sender, EventArgs e)
        {

            label3.Text = "Randomizing chests! Do not use save states, as they can break the mod. If or when you exit the game, this program closes automatically.";
            label3.Font = new Font(label3.Font, FontStyle.Bold);
            button1.Enabled = false;
            if (!chestThread.IsAlive) //If we are not already running
                chestThread.Start(); //Start thread
        }
    }
}
