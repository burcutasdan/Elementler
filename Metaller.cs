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

namespace Elementler
{
    public partial class Metaller : Form
    {
        public Metaller()
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
        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void buttonListele_Click(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listeleme();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MetallerYenile";
            komut.Parameters.AddWithValue("AtomNo", textBox1.Tag);
            komut.Parameters.AddWithValue("ElementAdi", textBox1.Text);
            komut.Parameters.AddWithValue("GrupAdi", textBox2.Text);
            komut.Parameters.AddWithValue("ElementSembolu", textBox3.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "MetallerSil";
            komut.Parameters.AddWithValue("AtomNo", textBox1.Tag);
            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow; //datagridroew adında nesne ürettik dtagrid 1 de seçili satırı al
            textBox1.Tag = satir.Cells["AtomNo"].Value.ToString();
            textBox1.Text = satir.Cells["ElementAdi"].Value.ToString();
            textBox2.Text = satir.Cells["GrupAdi"].Value.ToString();
            textBox3.Text = satir.Cells["ElementSembolu"].Value.ToString();
           
        }
    }
}
