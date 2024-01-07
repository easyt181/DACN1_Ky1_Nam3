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
    public partial class frmQLKhachHang : Form
    {
        Panel panel = new Panel();
        public string connStr = "Data Source=DESKTOP-6FT616D;Initial Catalog=DOANCN1;Integrated Security=True";
        public frmQLKhachHang()
        {
            InitializeComponent();
        }

        private void frmQLKhachHang_Load(object sender, EventArgs e)
        {
            LoadKH();

        }

        public void LoadKH()
        {
            string query = "SELECT * FROM KhachHang";

            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection();
            conn.ConnectionString = connStr;
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (panel.Visible)
            {
                dgvKH.AutoGenerateColumns = false;
                dgvKH.DataSource = dataTable;
                dgvKH.Columns["MaKH"].DataPropertyName = "MaKH";
                dgvKH.Columns["TenKH"].DataPropertyName = "TenKH";
                dgvKH.Columns["SDT"].DataPropertyName = "SDT";
                dgvKH.Columns["DiaChi"].DataPropertyName = "DiaChi";
            }

            conn.Close();
        }

        public void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKH.Rows[e.RowIndex];

                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                

            }
        }

      
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text;
            string tenKH = txtTenKH.Text;
            string SDT = txtSDT.Text;
            string diaChi = txtDiaChi.Text;
            
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE KhachHang SET TenKH = @TenKH, SDT = @SDT, DiaChi = @DiaChi WHERE MaKH = @MaKH;";
                if (maKH == "" || tenKH == "" || SDT == "" || diaChi == "" )
                {
                    MessageBox.Show("Hãy nhập toàn bộ thông tin của khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    using (SqlCommand cmd1 = new SqlCommand(query, conn))
                    {
                        cmd1.Parameters.AddWithValue("@MaKH", maKH);
                        cmd1.Parameters.AddWithValue("@TenKH", tenKH);
                        cmd1.Parameters.AddWithValue("@SDT", SDT);
                        cmd1.Parameters.AddWithValue("@DiaChi", diaChi);
                        

                        int rowAff = cmd1.ExecuteNonQuery();
                        if (rowAff > 0)
                        {
                            MessageBox.Show("Sửa thông tin khách hàng thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDiaChi.Text = string.Empty;
                            txtMaKH.Text = string.Empty;
                            txtSDT.Text = string.Empty;
                            txtTenKH.Text = string.Empty;
                            
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa thông tin khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
                LoadKH();

            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = string.Empty;
            txtMaKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            LoadKH();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text;
            DialogResult result = MessageBox.Show("Bạn có xác nhận muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (maKH == " ")
            {
                MessageBox.Show("Hãy chọn một khách hàng cần xóa thông tin trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection1 = new SqlConnection(connStr))
                    {
                        connection1.Open();

                        string deleteQuery = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection1))
                        {
                            deleteCommand.Parameters.AddWithValue("@MaKH", maKH);
                            int rowsAffected = deleteCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtDiaChi.Text = string.Empty;
                                txtMaKH.Text = string.Empty;
                                txtSDT.Text = string.Empty;
                                txtTenKH.Text = string.Empty;
                                LoadKH();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại vì có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmSearch frmSearch = new frmSearch();
            frmSearch.ShowDialog();
            string tuKhoa = frmSearch.TuKhoa;

            string query = "SELECT * FROM KhachHang WHERE MaKH LIKE @tuKhoa OR TenKH LIKE @tuKhoa OR SDT LIKE @tuKhoa OR DiaChi LIKE @tuKhoa";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            using (SqlCommand command = new SqlCommand(query, conn))
            {

                command.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvKH.AutoGenerateColumns = false;
                dgvKH.Columns["MaKH"].DataPropertyName = "MaKH";
                dgvKH.Columns["TenKH"].DataPropertyName = "TenKH";
                dgvKH.Columns["SDT"].DataPropertyName = "SDT";
                dgvKH.Columns["DiaChi"].DataPropertyName = "DiaChi";
                dgvKH.DataSource = dataTable;
            }
            conn.Close();

        }



    }
}
