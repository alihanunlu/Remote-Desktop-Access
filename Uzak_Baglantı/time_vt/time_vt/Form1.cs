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
using Microsoft.Win32;

namespace time_vt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection vtbgln = new SqlConnection("Data Source = alihan.database.windows.net; Initial Catalog = alihahnunlu; User ID = unlu; Password=Hatay.31");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'alihahnunluDataSet1.acilis_saat' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.acilis_saatTableAdapter.Fill(this.alihahnunluDataSet1.acilis_saat);
            timer1.Start();
            this.acilis_saatTableAdapter.Fill(this.alihahnunluDataSet1.acilis_saat);

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            vtbgln.Open();
            SqlCommand eklesrgu = new SqlCommand("INSERT INTO acilis_saat(time) values('" + DateTime.Now.ToLongTimeString() + "')", vtbgln);
            eklesrgu.ExecuteNonQuery();
            vtbgln.Close();
            RegistryKey baslangıc = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            baslangıc.SetValue("Saat", "\"" + Application.ExecutablePath + "\"");
        }
    }
}
