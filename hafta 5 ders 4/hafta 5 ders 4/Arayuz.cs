using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hafta_5_ders_4
{
    public partial class Arayuz : Form
    {
        public Arayuz()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hastalar hastalar = new Hastalar();
            hastalar.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Doktorlar doktorlar = new Doktorlar();
            doktorlar.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Poliklinikler poliklinikler = new Poliklinikler();
            poliklinikler.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Receteler receteler = new Receteler();
            receteler.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Sekreterler sekreterler = new Sekreterler();
            sekreterler.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Yoneticiler yoneticiler = new Yoneticiler();
            yoneticiler.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Raporlar go = new Raporlar();
            go.Show();
            this.Hide();
        }
    }
}
