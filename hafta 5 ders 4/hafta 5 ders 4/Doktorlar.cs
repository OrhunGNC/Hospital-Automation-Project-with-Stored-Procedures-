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
    public partial class Doktorlar : Form
    {
        public Doktorlar()
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
            cmd.CommandText = "ListDoktor";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource=dataTable;
            coon.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DoktorEkle";
            command.Parameters.AddWithValue("doktorAdSoyad", textBox1.Text);
            command.Parameters.AddWithValue("doktorBolum", textBox2.Text);
            command.Parameters.AddWithValue("doktorUnvan", textBox3.Text);
            command.Parameters.AddWithValue("poliklinikNo", textBox4.Text);
            command.ExecuteNonQuery();
            coon.Close();
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
            command.CommandText = "updateDoktor";
            command.Parameters.AddWithValue("doktorNo", textBox1.Tag);
            command.Parameters.AddWithValue("doktorAdSoyad", textBox1.Text);
            command.Parameters.AddWithValue("doktorBolum", textBox2.Text);
            command.Parameters.AddWithValue("doktorUnvan", textBox3.Text);
            command.Parameters.AddWithValue("poliklinikNo", textBox4.Text);
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
            command.CommandText = "DoktorDel";
            command.Parameters.AddWithValue("doktorNo", textBox1.Tag);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            Temizle();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["doktorNo"].Value.ToString();
            textBox1.Text = satir.Cells["doktorAdSoyad"].Value.ToString();
            textBox2.Text = satir.Cells["doktorBolum"].Value.ToString();
            textBox3.Text = satir.Cells["doktorUnvan"].Value.ToString();
            textBox4.Text = satir.Cells["poliklinikNo"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "AdSoyad")
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoktorAra";
                cmd.Parameters.AddWithValue("doktorAdSoyad", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else if (comboBox1.SelectedItem == "Bolum")
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoktorAraBolum";
                cmd.Parameters.AddWithValue("doktorBolum", textBox2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else if (comboBox1.SelectedItem == "Unvan")
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoktorAraUnvan";
                cmd.Parameters.AddWithValue("doktorUnvan", textBox3.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else if (comboBox1.SelectedItem == "PoliNo")
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoktorAraPoliNo";
                cmd.Parameters.AddWithValue("poliklinikNo", textBox4.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else
            {
                MessageBox.Show("Arama Kriteri Giriniz!");
            }
        }

        private void Doktorlar_Load(object sender, EventArgs e)
        {

        }
    }
}
