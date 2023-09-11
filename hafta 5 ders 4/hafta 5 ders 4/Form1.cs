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
    public partial class Form1 : Form
    {
        SqlConnection coon = new SqlConnection("Server=DESKTOP-4B2QQPV\\SQLKODLAB;Database=Hastane;Integrated Security=true;");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label11.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Sekreter")
            {
                
                SqlCommand komut = new SqlCommand();
                komut.Connection = coon;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SekreteLogin";
                komut.Parameters.AddWithValue("sekreterKAdi", textBox1.Text);
                komut.Parameters.AddWithValue("sekreterSifre", textBox2.Text);
                coon.Open();
                SqlDataReader reader = komut.ExecuteReader();
                
                if (reader.Read())
                {
                    MessageBox.Show("Hoşgeldiniz.");

                    groupBox1.Visible = false;

                }
                else
                {
                    MessageBox.Show("Giriş Başarısız Tekrar Dene!");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                coon.Close();


            }
            else if(comboBox1.SelectedItem == "Yönetici")
            {
                
                SqlCommand komut = new SqlCommand();
                komut.Connection = coon;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "YoneticiLogin";
                komut.Parameters.AddWithValue("yoneticiKAdi", textBox1.Text);
                komut.Parameters.AddWithValue("yoneticiSifre", textBox2.Text);
                coon.Open();
                SqlDataReader reader = komut.ExecuteReader();
                
                if (reader.Read())
                {
                    MessageBox.Show("Hoşgeldiniz.");
                    Arayuz arayuz = new Arayuz();
                    arayuz.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız Tekrar Dene!");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                coon.Close();
            }
            else
            {
                MessageBox.Show("Giriş Türü Seçiniz!");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Sekreter")
            {
                coon.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = coon;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SekreterEkle";
                komut.Parameters.AddWithValue("sekreterKAdi", textBox3.Text);
                komut.Parameters.AddWithValue("sekreterSifre", textBox4.Text);
                komut.Parameters.AddWithValue("sekreterAdSoyad", textBox5.Text);
                komut.ExecuteNonQuery();
                coon.Close();
                MessageBox.Show("Başarıyla Kayıt Oldunuz");
                groupBox1.Visible = false;
            }
            else if (comboBox1.SelectedItem == "Yönetici")
            {
                coon.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = coon;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "YoneticiEkle";
                komut.Parameters.AddWithValue("yoneticiKAdi", textBox3.Text);
                komut.Parameters.AddWithValue("yoneticiSifre", textBox4.Text);
                komut.Parameters.AddWithValue("yoneticiAdSoyad", textBox5.Text);
                komut.ExecuteNonQuery();
                coon.Close();
                MessageBox.Show("Başarıyla Kayıt Oldunuz");
                groupBox1.Visible = false;

            }
            else
            {
                MessageBox.Show("Giriş Türü Seçiniz!");
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label11.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            button2.Visible = true;
        }
    }
}
