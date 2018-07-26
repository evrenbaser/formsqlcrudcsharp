using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;// sql bağlantıları için kütüphane
namespace WindowsFormsAppsqlcrud
{
    public partial class Form1 : Form
    {

        public int i = 0;


        public Form1() // yapıcı metotlar sınıf aktif olduğunda doğrudan çalışan
            //metotlardır. 
        {
            InitializeComponent();
        }
        void GridDoldur() // veri tabanındaki veriyi yenilemek
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J75JJU5\SQLEXPRESS;Initial Catalog=yaznet;Integrated Security=True");//***
            SqlDataAdapter sorguda = new SqlDataAdapter("Select * From Kisiler",baglanti);
            DataSet veriyitutds = new DataSet();
            baglanti.Open();
            sorguda.Fill(veriyitutds, "Kisiler");
            dataGridView1.DataSource = veriyitutds.Tables["Kisiler"];
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // kaydetme işlemi  yani database e veri ekleme işlemi 
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J75JJU5\SQLEXPRESS;Initial Catalog=yaznet;Integrated Security=True");//***
            SqlCommand komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "insert into Kisiler(Id,Ad,Soyad,Tel,Adres)values("+textBox1.Text+",'"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            GridDoldur();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // güncelleme işlemi 
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J75JJU5\SQLEXPRESS;Initial Catalog=yaznet;Integrated Security=True");//***
            SqlCommand komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update Kisiler set Ad='"+textBox2.Text+"',Soyad='"+textBox3.Text+"',Tel='"+textBox4.Text+"',Adres='"+textBox5.Text+"' where Id="+textBox1.Text+"";
            komut.ExecuteNonQuery();
            baglanti.Close();
            GridDoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // silme işlemi 
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J75JJU5\SQLEXPRESS;Initial Catalog=yaznet;Integrated Security=True");//***
            SqlCommand komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from Kisiler where Id="+textBox1.Text+"";
            komut.ExecuteNonQuery();
            baglanti.Close();
            GridDoldur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GridDoldur();
        }

        private void button5_Click(object sender, EventArgs e)
        {

                i= dataGridView1.RowCount+3;
            int y = i + 30;
            for (  ; i < y; i++)
            {
                SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-J75JJU5\SQLEXPRESS;Initial Catalog=yaznet;Integrated Security=True");//***
                SqlCommand komut = new SqlCommand();
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "insert into Kisiler(Id,Ad,Soyad,Tel,Adres)values(" + i + ",'" + textBox2.Text+i + "','" + textBox3.Text+i + "','" + textBox4.Text+i + "','" + textBox5.Text+i + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                GridDoldur();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int lastindex = dataGridView1.RowCount;
            label1.Text = lastindex.ToString();
        }
    }

    


}
