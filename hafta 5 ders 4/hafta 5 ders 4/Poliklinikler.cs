using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace hafta_5_ders_4
{
    public partial class Poliklinikler : Form
    {
        public Poliklinikler()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-4B2QQPV\\SQLKODLAB;Database=Hastane;Integrated Security=true;");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PoliklinikDel";
            command.Parameters.AddWithValue("poliklinikNo", textBox1.Tag);
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
            command.CommandText = "updatePoliklinik";
            command.Parameters.AddWithValue("poliklinikNo", textBox1.Tag);
            command.Parameters.AddWithValue("poliklinikBolum", textBox1.Text);
            command.Parameters.AddWithValue("poliklinikCalisanSayisi", textBox2.Text);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
            Temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele()
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PoliklinikList";
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            coon.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = coon;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PoliklinikEkle";
            command.Parameters.AddWithValue("poliklinikBolum", textBox1.Text);
            command.Parameters.AddWithValue("poliklinikCalisanSayisi", textBox2.Text);
            command.ExecuteNonQuery();
            coon.Close();
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "PoliklinikBolum")
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PoliklinikAra";
                cmd.Parameters.AddWithValue("poliklinikBolum", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            else if (comboBox1.SelectedItem == "CalisanSayisi")
            {
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PoliklinikAraCSayisi";
                cmd.Parameters.AddWithValue("poliklinikCalisanSayisi", textBox2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                coon.Close();
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
