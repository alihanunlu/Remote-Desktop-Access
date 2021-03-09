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

namespace acilis_admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection adminbgln = new SqlConnection("Data Source = alihan.database.windows.net; Initial Catalog = alihahnunlu; User ID = unlu; Password=Hatay.31");
            // TODO: Bu kod satırı 'alihahnunluDataSet.vt_admin' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.vt_adminTableAdapter.Fill(this.alihahnunluDataSet.vt_admin);
            adminbgln.Open();
            SqlCommand ekleveri = new SqlCommand("select * from vt_admin",adminbgln);
            SqlDataReader dr1 = ekleveri.ExecuteReader();
            DataTable tb1 = new DataTable();
            tb1.Load(dr1);
            dataGridView1.DataSource = tb1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection adminbgln = new SqlConnection("Data Source = alihan.database.windows.net; Initial Catalog = alihahnunlu; User ID = unlu; Password=Hatay.31");
            adminbgln.Open();
            SqlCommand silveri = new SqlCommand("delete from vt_admin where id='"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'", adminbgln);
            silveri.ExecuteNonQuery();
            Form1_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PC Kapatıldı");
        }
    }
}
