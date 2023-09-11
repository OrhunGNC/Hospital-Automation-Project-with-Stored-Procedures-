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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hafta_5_ders_4
{
    public partial class Hastalar : Form
    {
        
        public Hastalar()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-4B2QQPV\\SQLKODLAB;Database=Hastane;Integrated Security=true;");
        private void Hastalar_Load(object sender, EventArgs e)
        {

        }
        public void Listele()
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HastaList2";
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable filldata = new DataTable();
            dr.Fill(filldata);
            dataGridView1.DataSource = filldata;
            coon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "HastaEkle";
            command.Parameters.AddWithValue("hastaAdSoyad", textBox1.Text);
            command.Parameters.AddWithValue("hastaYas", textBox2.Text);
            command.Parameters.AddWithValue("hastaBoy", textBox3.Text);
            command.Parameters.AddWithValue("hastaKilo", textBox4.Text);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            Temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listele();
        }
        public void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "updateHasta";
            command.Parameters.AddWithValue("hastaNo", textBox1.Tag);
            command.Parameters.AddWithValue("hastaAdSoyad", textBox1.Text);
            command.Parameters.AddWithValue("hastaYas", textBox2.Text);
            command.Parameters.AddWithValue("hastaBoy", textBox3.Text);
            command.Parameters.AddWithValue("hastaKilo", textBox4.Text);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            Temizle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["hastaNo"].Value.ToString();
            textBox1.Text = satir.Cells["hastaAdSoyad"].Value.ToString();
            textBox2.Text = satir.Cells["hastaYas"].Value.ToString();
            textBox3.Text = satir.Cells["hastaBoy"].Value.ToString();
            textBox4.Text = satir.Cells["hastaKilo"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "HastaDel";
            command.Parameters.AddWithValue("hastaNo", textBox1.Tag);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            Temizle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "AdSoyad")
            {
                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "HastaList";
                command.Parameters.AddWithValue("hastaAdSoyad", textBox1.Text);
                SqlDataAdapter dr = new SqlDataAdapter(command);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
                coon.Close();
            }
            else if (comboBox1.SelectedItem == "Yas")
            {
                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "HastaAraYas";
                command.Parameters.AddWithValue("hastaYas", textBox2.Text);
                SqlDataAdapter dr = new SqlDataAdapter(command);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
                coon.Close();
            }
            else if (comboBox1.SelectedItem == "Boy")
            {
                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "HastaAraBoy";
                command.Parameters.AddWithValue("hastaBoy", textBox3.Text);
                SqlDataAdapter dr = new SqlDataAdapter(command);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
                coon.Close();
            }
            else if (comboBox1.SelectedItem == "Kilo")
            {
                coon.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = coon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "HastaAraKilo";
                command.Parameters.AddWithValue("hastaKilo", textBox4.Text);
                SqlDataAdapter dr = new SqlDataAdapter(command);
                DataTable filldata = new DataTable();
                dr.Fill(filldata);
                dataGridView1.DataSource = filldata;
                coon.Close();
            }
            else
            {
                MessageBox.Show("Arama Kriteri Seçiniz!");
            }
        }
    }
}
