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

namespace hafta_5_ders_4
{
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }
        SqlConnection coon = new SqlConnection("Server=DESKTOP-4B2QQPV\\SQLKODLAB;Database=Hastane;Integrated Security=true;");
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DoktorHastaRapor";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DoktorPoliklinikRapor";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HastaPoliklinikRapor";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ReceteDoktorRapor";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HastaArayuzRapor";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HastaDoktorRecetePoliRapor";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            coon.Close();
        }
    }
}
