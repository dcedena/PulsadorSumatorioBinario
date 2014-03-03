using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PulsadorSumatorioBinario_Classes;
using PulsadorSumatorioBinario_Design.Properties;

namespace PulsadorSumatorioBinario_Design
{
    public partial class FormMain : Form
    {
        private Pulsador pulsador = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pulsador = new Pulsador((int)numericUpDown1.Value);
            PintarResultNumber((int)numericUpDown1.Value);
        }

        private void btnPushMe_Click(object sender, EventArgs e)
        {
            flPanel.Controls.Clear();
            pulsador.Push();
            PintarLEDS();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void PintarLEDS()
        {
            string result = pulsador.GetResult();
            PintarResult(result);
        }

        private void PintarResult(string result)
        {
            char[] list = result.ToCharArray();
            foreach(char c in list)
            {
                PictureBox pb = new PictureBox();
                pb.Size = new Size(48, 48);
                if(c.ToString() == pulsador._TRUE_VALUE.ToString())
                    pb.Image = GetImagen(true);
                else
                    pb.Image = GetImagen(false);
                flPanel.Controls.Add(pb);
            }
        }

        private void PintarResultNumber(int num)
        {
            char c = pulsador._FALSE_.ToString().ToCharArray()[0];
            PintarResult("".PadLeft(num, c));
        }

        private Image GetImagen(bool v)
        {
            return ( v ? Resources.TRUE : Resources.FALSE );
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            flPanel.Controls.Clear();

            // Number of LEDs
            int nl = (int)numericUpDown1.Value;

            PintarResultNumber(nl);
            pulsador = new Pulsador(nl);
        }
    }
}
