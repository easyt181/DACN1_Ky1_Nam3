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

namespace DOANCN1
{
    public partial class frmDangNhap : Form
    {
        public string connStr = "Data Source=DESKTOP-6FT616D;Initial Catalog=DOANCN1;Integrated Security=True";
        public static string ID;
        public static string Ten;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        public void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            SqlCommand command = new SqlCommand("SELECT ID,Ten FROM DangNhap WHERE TaiKhoan=@user AND MatKhau=@pass", conn);
            command.Parameters.AddWithValue("@user", taiKhoan);
            command.Parameters.AddWithValue("@pass", matKhau);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                ID = reader.GetString(0);
                Ten = reader.GetString(1);
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmGiaoDienQL frmGiaoDienQL = new frmGiaoDienQL();
                frmGiaoDienQL.ShowDialog(); 
                this.Hide();
                return;
            }

                if (taiKhoan == "")
                {
                    MessageBox.Show("Tài khoản không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (matKhau == "")
                {
                    MessageBox.Show("Mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (taiKhoan != "@user" || matKhau != "@pass")
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                reader.Close();
                conn.Close();
            
        }  

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
