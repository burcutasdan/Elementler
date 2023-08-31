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


namespace Elementler
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source =.\\MSSQLSERVER02; Initial Catalog = Elementler; integrated security=true;");

        public void Listeleme()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MetallerListele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Giriş";
            komut.Parameters.AddWithValue("KullaniciAdi", textBox1.Text);
            komut.Parameters.AddWithValue("KullaniciSifre", textBox2.Text);
            conn.Open();
            SqlDataReader dr; // bu sanırım tabloyu okuyor
            dr = komut.ExecuteReader();
            if (dr.Read()) //eğer textboxa yazılan kullanıcı adı ve şifre tablodakiyle aynıysa
            {
                MessageBox.Show("Sisteme Hoşgeldiniz");
               Secimsayfası frm = new Secimsayfası();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız. Lütfen tekrar deneyin");
                textBox1.Clear();
                textBox2.Clear();
            }
            conn.Close();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
