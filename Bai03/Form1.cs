using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "";
            ofd.Filter = "AVI file|*.avi|MPEG file|*.mpeg|WAV File|*.wav|MIDI File|*.midi|MP4 File|*.mp4|MP3 File|*.mp3";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                WMP.URL = ofd.FileName;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"Hôm nay là ngày {DateTime.Now:dd/MM/yyyy} - Bây giờ là {DateTime.Now:hh:mm:ss tt}";
        }

       
    }
}
