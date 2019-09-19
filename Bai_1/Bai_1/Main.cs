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

namespace Bai_1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        string UID = Form1.ID_User;

        

        List<string> listper = null;

        private string id_per()
        {
            string id = "";
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CE6UIQC\SQLEXPRESS;Initial Catalog=Bai1_baitapnhom;Integrated Security=True");
            try
            {
                
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.DN_NguoiDung_QuyenHan WHERE id_user_rel ='" + UID + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["suspended"].ToString() == "0")
                        {
                            id = dr["id_per_rel"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            conn.Close();
            conn.Dispose();
            return id;
        }

        private List<string> List_per()
        {
            string idper = id_per();
            List<string> termlist = new List<string>();
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CE6UIQC\SQLEXPRESS;Initial Catalog=Bai1_baitapnhom;Integrated Security=True");
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.DN_QuyenHanChiTiet WHERE id_per ='" + idper + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        termlist.Add(dr["code_action"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("có lỗi xảy ra");
            }
            finally
            {
                
            }
            conn.Close();
            conn.Dispose();
            return termlist;
        }

        private int checkper(string code)
        {
            int check = 0;
            foreach (string item in listper)
            {
                if (item == code)
                {
                    check = 1;
                    break;
                }
                else
                {
                    check = 0;
                }
            }
            return check;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkper("ADD") == 0)
            {
                MessageBox.Show("có quyền thêm");
            }
            else
            {
                MessageBox.Show("không có quyền");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkper("FIX") == 0)
            {
                MessageBox.Show("có quyền sửa");
            }
            else
            {
                MessageBox.Show("không có quyền sửa");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkper("DELETE") == 0)
            {
                MessageBox.Show("có quyền xóa");
            }
            else
            {
                MessageBox.Show("không có quyền xóa");
            }
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_Load_1(object sender, EventArgs e)
        {
            listper = List_per();

        }
    }
}
