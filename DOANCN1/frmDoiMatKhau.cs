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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DOANCN1
{
    public partial class frmDoiMatKhau : Form
    {
        public string connStr = "Data Source=DESKTOP-6FT616D;Initial Catalog=DOANCN1;Integrated Security=True";
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string IDHT = frmDangNhap.ID;
            string checkPass = null;
            string oldPass = txtMatKhauCu.Text;
            string newPass = txtMatKhauMoi.Text;
            string xacNhan = txtXacNhanMK.Text;
            
            SqlCommand command = new SqlCommand("SELECT MatKhau FROM DangNhap WHERE ID=@id", conn);
            SqlCommand command2 = new SqlCommand("UPDATE DangNhap SET MatKhau = @NewPassword WHERE ID = @id",conn);
            command.Parameters.AddWithValue("@id", IDHT);
            command2.Parameters.AddWithValue("@id", IDHT);
            command2.Parameters.AddWithValue("@NewPassword", newPass);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                checkPass = reader.GetString(0);
            }
            reader.Close();
            
          
            if (oldPass == "" && newPass == "" && xacNhan == "")
            {
                MessageBox.Show("Hãy nhập thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (oldPass == "")
            {
                MessageBox.Show("Hãy nhập mật khẩu hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPass == "")
            {
                MessageBox.Show("Hãy nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (xacNhan == "")
            {
                MessageBox.Show("Hãy xác nhận lại mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (oldPass != checkPass)
            {
                MessageBox.Show("Mật khẩu nhập sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (newPass != xacNhan)
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (oldPass == checkPass && newPass == xacNhan && txtMatKhauCu.Text != null && txtMatKhauMoi.Text != null && txtXacNhanMK.Text != null)
            {
                int rowsAffected = command2.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                return;
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng hoặc có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     
            conn.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
