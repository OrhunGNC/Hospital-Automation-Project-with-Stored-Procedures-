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
    public partial class Receteler : Form
    {
        public Receteler()
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
            command.CommandText = "ReceteList";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            coon.Close();

        }
        public void Temizle()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ReceteEkle";
            command.Parameters.AddWithValue("receteTarih", dateTimePicker1.Text);
            command.Parameters.AddWithValue("receteTanimi", textBox2.Text);
            command.Parameters.AddWithValue("hastaNo", textBox3.Text);
            command.Parameters.AddWithValue("doktorNo", textBox4.Text);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "updateRecete";
            command.Parameters.AddWithValue("receteNo", dateTimePicker1.Tag);
            command.Parameters.AddWithValue("receteTarih", dateTimePicker1.Text);
            command.Parameters.AddWithValue("receteTanimi", textBox2.Text);
            command.Parameters.AddWithValue("hastaNo", textBox3.Text);
            command.Parameters.AddWithValue("doktorNo", textBox4.Text);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ReceteDel";
            command.Parameters.AddWithValue("receteNo", dateTimePicker1.Tag);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            Temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            dateTimePicker1.Tag = satir.Cells["receteNo"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["receteTarih"].Value.ToString();
            textBox2.Text = satir.Cells["receteTanimi"].Value.ToString();
            textBox3.Text = satir.Cells["hastaNo"].Value.ToString();
            textBox4.Text = satir.Cells["doktorNo"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Tanim")
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReceteAra";
                cmd.Parameters.AddWithValue("receteTanimi", textBox2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else if (comboBox1.SelectedItem == "Tarih")
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReceteAraTarih";
                cmd.Parameters.AddWithValue("receteTarih", dateTimePicker1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else if (comboBox1.SelectedItem == "HastaNo")
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReceteAraHastaNo";
                cmd.Parameters.AddWithValue("hastaNo", textBox3.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else if (comboBox1.SelectedItem == "DoktorNo")
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReceteAraDoktorNo";
                cmd.Parameters.AddWithValue("doktorNo", textBox4.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else
            {
                MessageBox.Show("Arama Kriteri Seçiniz!");
            }
        }
    }
}
