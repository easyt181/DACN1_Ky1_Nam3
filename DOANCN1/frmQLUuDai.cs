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
    public partial class frmQLUuDai : Form
    {   

        Panel panel = new Panel();
        public string connStr = "Data Source=DESKTOP-6FT616D;Initial Catalog=DOANCN1;Integrated Security=True";

        public frmQLUuDai()
        {
            InitializeComponent();
        }

        private void frmQLUuDai_Load(object sender, EventArgs e)
        {
            LoadUuDai();

        }
        
        public void LoadUuDai()
        {
            string queryUD = "SELECT UuDai.*, LoaiUuDai.LoaiUuDai FROM UuDai INNER JOIN LoaiUuDai ON LoaiUuDai.MaLoaiUD = UuDai.MaLoaiUD";
            
            SqlConnection conn = new SqlConnection();
            conn = new SqlConnection();
            conn.ConnectionString = connStr;
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(queryUD, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (panel.Visible)
            {
                dgvUuDai.AutoGenerateColumns = false;
                dgvUuDai.DataSource = dataTable;
                dgvUuDai.Columns["MaUuDai"].DataPropertyName = "MaUuDai";
                dgvUuDai.Columns["LoaiUuDai"].DataPropertyName = "LoaiUuDai";
                dgvUuDai.Columns["TenUD"].DataPropertyName = "TenUD";
                dgvUuDai.Columns["DieuKien"].DataPropertyName = "DieuKien";
                dgvUuDai.Columns["ChiTiet"].DataPropertyName = "ChiTiet";               
              
            }
            
            conn.Close();
        }

        public void dgvUuDai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string loaiUD = cbbLoaiUD.Text; 
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUuDai.Rows[e.RowIndex];

                txtMaUD.Text = row.Cells["MaUuDai"].Value.ToString();
                cbbLoaiUD.Text = row.Cells["LoaiUuDai"].Value.ToString();
                txtTenUD.Text = row.Cells["TenUD"].Value.ToString();
                txtDieuKien.Text = row.Cells["DieuKien"].Value.ToString();
                txtChiTiet.Text = row.Cells["ChiTiet"].Value.ToString();
               
            }            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maUD = txtMaUD.Text;
            string tenUD = txtTenUD.Text;
            string loaiUD = cbbLoaiUD.Text;
            string chiTiet = txtChiTiet.Text;
            int dieuKien;
            string dieuKientxt = txtDieuKien.Text;
            

           
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string getMaLoaiUD = null;
                string checkQuery = "SELECT COUNT(*) FROM UuDai WHERE MaUuDai = @MaUuDai;";
                string query = "INSERT INTO UuDai(MaUuDai,MaLoaiUD,TenUD,DieuKien,ChiTiet) VALUES(@MaUuDai,@MaLoaiUD,@TenUD,@DieuKien,@ChiTiet);";
                string queryLUD = "SELECT * FROM LoaiUuDai WHERE LoaiUuDai = @LoaiUuDai";
                SqlCommand cmd = new SqlCommand(queryLUD, conn);
                cmd.Parameters.AddWithValue("@LoaiUuDai", loaiUD);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    getMaLoaiUD = reader.GetString(0);
                }
                reader.Close();
                using (SqlCommand checkcmd = new SqlCommand(checkQuery,conn))
                {
                    checkcmd.Parameters.AddWithValue("@MaUuDai", maUD);
                    int existingRecords = (int)checkcmd.ExecuteScalar();
                    if (maUD == "" || tenUD == "" || loaiUD == "" || chiTiet == "" || dieuKientxt == " " )
                    {
                        MessageBox.Show("Thêm ưu đãi thất bại! Hãy nhập toàn bộ thông tin của sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!int.TryParse(dieuKientxt, out dieuKien))
                    {
                        MessageBox.Show("Điều kiện không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (existingRecords > 0)
                    {

                        MessageBox.Show("Mã ưu đãi đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    try
                    {
                        using(SqlCommand cmd1 = new SqlCommand(query,conn)) 
                        {
                            cmd1.Parameters.AddWithValue("@MaUuDai", maUD);
                            cmd1.Parameters.AddWithValue("@MaLoaiUD", getMaLoaiUD);
                            cmd1.Parameters.AddWithValue("@TenUD",tenUD );
                            cmd1.Parameters.AddWithValue("DieuKien", dieuKientxt);
                            cmd1.Parameters.AddWithValue("ChiTiet", chiTiet);
                            cmd1.ExecuteNonQuery();
                        }

                        MessageBox.Show("Thêm ưu đãi thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtChiTiet.Text = string.Empty;
                        txtDieuKien.Text = string.Empty;
                        txtMaUD.Text = string.Empty;    
                        txtTenUD.Text = string.Empty;  
                        cbbLoaiUD.Text = string.Empty;
                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm ưu đãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();


                }
                LoadUuDai();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maUD = txtMaUD.Text;
            string tenUD = txtTenUD.Text;
            string loaiUD = cbbLoaiUD.Text;
            string chiTiet = txtChiTiet.Text;
            int dieuKien;
            string dieuKientxt = txtDieuKien.Text;
            string getMaLoaiUD = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();               
                string query = "UPDATE UuDai SET MaLoaiUD = @MaLoaiUD, TenUD = @TenUD, DieuKien = @DieuKien, ChiTiet = @ChiTiet WHERE MaUuDai = @MaUuDai;";
                string queryLUD = "SELECT * FROM LoaiUuDai WHERE LoaiUuDai = @LoaiUuDai";
                SqlCommand cmd = new SqlCommand(queryLUD, conn);
                cmd.Parameters.AddWithValue("@LoaiUuDai", loaiUD);
                SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                    getMaLoaiUD = reader.GetString(0);
                    }
                    reader.Close();
               
                    if (maUD == "" || tenUD == "" || loaiUD == "" || chiTiet == "" || dieuKientxt == " ")
                    {
                        MessageBox.Show("Hãy nhập toàn bộ thông tin của ưu đãi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(dieuKientxt, out dieuKien))
                    {
                        MessageBox.Show("Điều kiện không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        using (SqlCommand cmd1 = new SqlCommand(query, conn))
                        {
                            cmd1.Parameters.AddWithValue("@MaUuDai", maUD);
                            cmd1.Parameters.AddWithValue("@MaLoaiUD", getMaLoaiUD);
                            cmd1.Parameters.AddWithValue("@TenUD", tenUD);
                            cmd1.Parameters.AddWithValue("DieuKien", dieuKientxt);
                            cmd1.Parameters.AddWithValue("ChiTiet", chiTiet);

                        int rowAff = cmd1.ExecuteNonQuery();
                        if (rowAff > 0)
                        {
                            MessageBox.Show("Sửa ưu đãi thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtChiTiet.Text = string.Empty;
                            txtDieuKien.Text = string.Empty;
                            txtMaUD.Text = string.Empty;
                            txtTenUD.Text = string.Empty;
                            cbbLoaiUD.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi sửa ưu đãi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi sửa ưu đãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();      
                LoadUuDai();

            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtChiTiet.Text = string.Empty;
            txtDieuKien.Text = string.Empty;
            txtMaUD.Text = string.Empty;
            txtTenUD.Text = string.Empty;
            cbbLoaiUD.Text = string.Empty;
            LoadUuDai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maUD = txtMaUD.Text;
            DialogResult result = MessageBox.Show("Bạn có xác nhận muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (maUD == " ")
            {
                MessageBox.Show("Hãy chọn một ưu đãi cần xóa trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection1 = new SqlConnection(connStr))
                    {
                        connection1.Open();

                        string deleteQuery = "DELETE FROM UuDai WHERE MaUuDai = @MaUuDai";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection1))
                        {
                            deleteCommand.Parameters.AddWithValue("@MaUuDai", maUD);
                            int rowsAffected = deleteCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMaUD.Text = string.Empty;
                                txtTenUD.Text = string.Empty;
                                cbbLoaiUD.Text = string.Empty;
                                txtDieuKien.Text = string.Empty;
                                txtChiTiet.Text = string.Empty;
                                LoadUuDai();
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

            string query = "SELECT UuDai.*, LoaiUuDai.LoaiUuDai FROM UuDai INNER JOIN LoaiUuDai ON LoaiUuDai.MaLoaiUD = UuDai.MaLoaiUD WHERE MaUuDai LIKE @tuKhoa OR TenUD LIKE @tuKhoa " +
                "OR DieuKien LIKE @tuKhoa";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            using (SqlCommand command = new SqlCommand(query, conn))
            {

                command.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvUuDai.AutoGenerateColumns = false;

                dgvUuDai.Columns["MaUuDai"].DataPropertyName = "MaUuDai";
                dgvUuDai.Columns["LoaiUuDai"].DataPropertyName = "LoaiUuDai";
                dgvUuDai.Columns["TenUD"].DataPropertyName = "TenUD";
                dgvUuDai.Columns["DieuKien"].DataPropertyName = "DieuKien";
                dgvUuDai.Columns["ChiTiet"].DataPropertyName = "ChiTiet";
                dgvUuDai.DataSource = dataTable;
            }
            conn.Close();

        }
    }
}
