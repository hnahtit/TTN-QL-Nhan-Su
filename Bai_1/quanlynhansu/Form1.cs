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

namespace quanlynhansu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string ID_User = "";

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CE6UIQC\SQLEXPRESS;Initial Catalog=Bai1_baitapnhom;Integrated Security=True");
            string sqlSelect = "Select * from QL_USER where name_account = N'" + textBox1.Text + "'and pass = N'" + textBox2.Text+"'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()==true)
            {
                this.Hide();
                Form main = new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("Bạn đăng nhập không thành công");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
            conn.Close();
        }
    }
}
