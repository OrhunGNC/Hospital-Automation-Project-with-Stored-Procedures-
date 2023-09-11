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
    public partial class Sekreterler : Form
    {
        public Sekreterler()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-4B2QQPV\\SQLKODLAB;Database=Hastane;Integrated Security=true;");
        public void Listele()
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SekreterList";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
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
        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SekreterEkle";
            command.Parameters.AddWithValue("sekreterKAdi", textBox1.Text);
            command.Parameters.AddWithValue("sekreterSifre", textBox2.Text);
            command.Parameters.AddWithValue("sekreterAdSoyad", textBox3.Text);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "updateSekreter";
            command.Parameters.AddWithValue("sekreterNo", textBox1.Tag);
            command.Parameters.AddWithValue("sekreterKAdi", textBox1.Text);
            command.Parameters.AddWithValue("sekreterSifre", textBox2.Text);
            command.Parameters.AddWithValue("sekreterAdSoyad", textBox3.Text);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["sekreterNo"].Value.ToString();
            textBox1.Text = satir.Cells["sekreterKAdi"].Value.ToString();
            textBox2.Text = satir.Cells["sekreterSifre"].Value.ToString();
            textBox3.Text = satir.Cells["sekreterAdSoyad"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SekreterDel";
            command.Parameters.AddWithValue("sekreterNo", textBox1.Tag);
            command.ExecuteNonQuery();
            coon.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "AdSoyad")
            {
                coon.Close();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SekreterAra";
                cmd.Parameters.AddWithValue("sekreterAdSoyad", textBox3.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else if (comboBox1.SelectedItem == "Sifre")
            {
                coon.Close();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SekreterAraSifre";
                cmd.Parameters.AddWithValue("sekreterSifre", textBox2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else if (comboBox1.SelectedItem== "KullaniciAdi")
            {
                coon.Close();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SekreterAraKAdi";
                cmd.Parameters.AddWithValue("sekreterKAdi", textBox1.Text);
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
