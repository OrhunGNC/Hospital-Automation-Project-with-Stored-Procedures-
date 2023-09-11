using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hafta_5_ders_4
{
    public partial class Yoneticiler : Form
    {
        public Yoneticiler()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-4B2QQPV\\SQLKODLAB;Database=Hastane;Integrated Security=true;");
        public void Listele()
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "YoneticiList";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            coon.Close();
        }
        public void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["yoneticiNo"].Value.ToString();
            textBox1.Text = satir.Cells["yoneticiAdSoyad"].Value.ToString();
            textBox2.Text = satir.Cells["yoneticiKAdi"].Value.ToString();
            textBox3.Text = satir.Cells["yoneticiSifre"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "YoneticiEkle";
            cmd.Parameters.AddWithValue("yoneticiAdSoyad", textBox1.Text);
            cmd.Parameters.AddWithValue("yoneticiKAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("yoneticiSifre", textBox3.Text);
            cmd.ExecuteNonQuery();
            coon.Close();
            Listele();
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updateYonetici";
            cmd.Parameters.AddWithValue("yoneticiNo", textBox1.Tag);
            cmd.Parameters.AddWithValue("yoneticiAdSoyad", textBox1.Text);
            cmd.Parameters.AddWithValue("yoneticiKAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("yoneticiSifre", textBox3.Text);
            cmd.ExecuteNonQuery();
            coon.Close();
            Listele();
            Temizle();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "YoneticiDel";
            cmd.Parameters.AddWithValue("yoneticiNo", textBox1.Tag);
            cmd.ExecuteNonQuery();
            coon.Close();
            Listele();
            Temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (adSoyad.Checked)
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "YoneticiAra";
                cmd.Parameters.AddWithValue("yoneticiAdSoyad", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else if (kAdi.Checked)
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "YoneticiArakAdi";
                cmd.Parameters.AddWithValue("yoneticiKAdi", textBox2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else if (sifre.Checked)
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "YoneticiAraSifre";
                cmd.Parameters.AddWithValue("yoneticiSifre", textBox3.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else
            {
                MessageBox.Show("Bir Arama Kriteri Seçiniz!");
            }
        }
    }
}
