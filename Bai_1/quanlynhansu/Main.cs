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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string UID = Form1.ID_User;

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CE6UIQC\SQLEXPRESS;Initial Catalog=Bai1_baitapnhom;Integrated Security=True");

        List <string> listper = null;

        private string id_per()
        {
            string id = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.QL_USER_PERMISION WHERE id_user_rel ='" + UID + "'", conn);
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
            finally
            {
                conn.Close();
            }

            return id;
        }

        private List<string> List_per()
        {
            string idper = id_per();
            List<string> termlist = new List<string>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.QL_PERMISION_DETAIL WHERE id_per ='" + idper + "'", conn);
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
                conn.Close();
            }
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

        private void Main_Load(object sender, EventArgs e)
        {
            listper = List_per();
        }
    }
}
