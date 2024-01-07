using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DOANCN1
{
    public partial class frmQLKhoHang : Form
    {
        SqlConnection conn;
        Panel panel = new Panel();
        public string connStr = "Data Source=DESKTOP-6FT616D;Initial Catalog=DOANCN1;Integrated Security=True";
        public string queryIP = "SELECT * FROM iPhone";
        public string queryMB = "SELECT * FROM MacBook";
        public string queryAP = "SELECT * FROM AirPods";

        public void LoadDataIP(string queryIP)
        {
            conn = new SqlConnection();
            conn.ConnectionString = connStr;
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(queryIP, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (panel.Visible)
            {
                dgvIP.AutoGenerateColumns = false;
                dgvIP.DataSource = dataTable;

                dgvIP.Columns["MaSP"].DataPropertyName = "MaSP";
                dgvIP.Columns["TenSP"].DataPropertyName = "TenSP";
                dgvIP.Columns["DungLuong"].DataPropertyName = "DungLuong";
                dgvIP.Columns["PhienBan"].DataPropertyName = "PhienBan";
                dgvIP.Columns["MauSac"].DataPropertyName = "MauSac";
                dgvIP.Columns["SoKieuMay"].DataPropertyName = "SoKieuMay";
                dgvIP.Columns["NamRaMat"].DataPropertyName = "NamRaMat";
                dgvIP.Columns["Gia"].DataPropertyName = "Gia";
                dgvIP.Columns["TinhTrang"].DataPropertyName = "TinhTrang";
            }
            conn.Close();
        }

        public void LoadDataMB(string queryMB)
        {
            conn = new SqlConnection();
            conn.ConnectionString = connStr;
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(queryMB, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (panel.Visible)
            {
                dgvMB.AutoGenerateColumns = false;
                dgvMB.DataSource = dataTable;
                dgvMB.Columns["MaMB"].DataPropertyName = "MaSP";
                dgvMB.Columns["TenMB"].DataPropertyName = "TenSP";
                dgvMB.Columns["DungLuongMB"].DataPropertyName = "DungLuong";
                dgvMB.Columns["RAM"].DataPropertyName = "RAM";
                dgvMB.Columns["ChipSet"].DataPropertyName = "ChipSet";
                dgvMB.Columns["PhienBanMB"].DataPropertyName = "PhienBan";
                dgvMB.Columns["MauSacMB"].DataPropertyName = "MauSac";
                dgvMB.Columns["SoKieuMayMB"].DataPropertyName = "SoKieuMay";
                dgvMB.Columns["NamRaMatMB"].DataPropertyName = "NamRaMat";
                dgvMB.Columns["GiaMB"].DataPropertyName = "Gia";
                dgvMB.Columns["TinhTrangMB"].DataPropertyName = "TinhTrang";
            }
            conn.Close();
        }

        public void LoadDataAP(string queryAP)
        {
            conn = new SqlConnection();
            conn.ConnectionString = connStr;
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(queryAP, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (panel.Visible)
            {
                dgvAP.AutoGenerateColumns = false;
                dgvAP.DataSource = dataTable;
                dgvAP.Columns["MaAP"].DataPropertyName = "MaSP";
                dgvAP.Columns["TenAP"].DataPropertyName = "TenSP";
                dgvAP.Columns["PhienBanAP"].DataPropertyName = "PhienBan";
                dgvAP.Columns["SoKieuMayAP"].DataPropertyName = "SoKieuMay";
                dgvAP.Columns["NamRaMatAP"].DataPropertyName = "NamRaMat";
                dgvAP.Columns["GiaAP"].DataPropertyName = "Gia";
                dgvAP.Columns["TinhTrangAP"].DataPropertyName = "TinhTrang";
            }
            conn.Close();
        }

        public frmQLKhoHang()
        {
            InitializeComponent();
        }

        private void frmQLKhoHang_Load(object sender, EventArgs e)
        {
            LoadDataIP(queryIP);
            LoadDataMB(queryMB);
            LoadDataAP(queryAP);
        }

        public void dgvIP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvIP.Rows[e.RowIndex];

                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                cbbDungLuong.Text = row.Cells["DungLuong"].Value.ToString();
                cbbPhienBan.Text = row.Cells["PhienBan"].Value.ToString();
                txtMauSac.Text = row.Cells["MauSac"].Value.ToString();
                txtSoKM.Text = row.Cells["SoKieuMay"].Value.ToString();
                txtNamRaMat.Text = row.Cells["NamRaMat"].Value.ToString();
                txtGia.Text = row.Cells["Gia"].Value.ToString();
                cbbTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString();
            }
        }

        public void dgvMB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMB.Rows[e.RowIndex];

                txtMaMB.Text = row.Cells["MaMB"].Value.ToString();
                txtTenMB.Text = row.Cells["TenMB"].Value.ToString();
                cbbDungLuongMB.Text = row.Cells["DungLuongMB"].Value.ToString();
                cbbRAM.Text = row.Cells["RAM"].Value.ToString();
                txtChipSet.Text = row.Cells["ChipSet"].Value.ToString();
                cbbPhienBanMB.Text = row.Cells["PhienBanMB"].Value.ToString();
                txtMauSacMB.Text = row.Cells["MauSacMB"].Value.ToString();
                txtSoKieuMayMB.Text = row.Cells["SoKieuMayMB"].Value.ToString();
                txtNamRaMatMB.Text = row.Cells["NamRaMatMB"].Value.ToString();
                txtGiaMB.Text = row.Cells["GiaMB"].Value.ToString();
                cbbTinhTrangMB.Text = row.Cells["TinhTrangMB"].Value.ToString();
            }
        }

        public void dgvAP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAP.Rows[e.RowIndex];

                txtMaAP.Text = row.Cells["MaAP"].Value.ToString();
                txtTenAP.Text = row.Cells["TenAP"].Value.ToString();
                cbbPhienBanAP.Text = row.Cells["PhienBanAP"].Value.ToString();
                txtSoKieuMayAP.Text = row.Cells["SoKieuMayAP"].Value.ToString();
                txtNamRaMatAP.Text = row.Cells["NamRaMatAP"].Value.ToString();
                txtGiaAP.Text = row.Cells["GiaAP"].Value.ToString();
                cbbTinhTrangAP.Text = row.Cells["TinhTrangAP"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            string maSP = txtMaSP.Text;
            string tenSPpro;
            string tenSP = txtTenSP.Text;
            string dungLuong = cbbDungLuong.Text;
            string phienBan = cbbPhienBan.Text;
            string mauSac = txtMauSac.Text;
            string sokieuMay = txtSoKM.Text;
            string namramatText = txtNamRaMat.Text;
            int Namramat;
            string giaText = txtGia.Text;
            int gia;
            string tinhTrang = cbbTinhTrang.Text;
            if (cbbPhienBan.Text == "Thường")
            {
                tenSPpro = txtTenSP.Text + " " + cbbDungLuong.Text + " " + txtMauSac.Text;
            }
            else { tenSPpro = txtTenSP.Text + " " + cbbPhienBan.Text + " " + cbbDungLuong.Text + " " + txtMauSac.Text; }


            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Products WHERE MaSP = @MaSP";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@MaSP", maSP);
                    int existingRecords = (int)checkCommand.ExecuteScalar();
                    if (maSP == "" || tenSP == "" || dungLuong == "" || phienBan == "" || mauSac == "" || sokieuMay == "" || namramatText == "" || giaText == "" || tinhTrang == "")
                    {
                        MessageBox.Show("Thêm sản phẩm thất bại! Hãy nhập toàn bộ thông tin của sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!int.TryParse(giaText, out gia))
                    {
                        MessageBox.Show("Giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(namramatText, out Namramat))
                    {
                        MessageBox.Show("Năm ra mắt không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (existingRecords > 0)
                    {

                        MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        string query1 = "INSERT INTO Products (MaSP, TenSP,LoaiSP) VALUES (@MaSP,@TenSPsua,@LoaiSP)";
                        string query2 = "INSERT INTO iPhone (MaSP, TenSP, DungLuong, PhienBan, MauSac, SoKieuMay, NamRaMat, Gia, TinhTrang) VALUES (@MaSP, @TenSP, @DungLuong, @PhienBan, @MauSac, @SoKieuMay, @NamRaMat, @Gia, @TinhTrang)";

                        using (SqlCommand cmd = new SqlCommand(query1, connection))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@TenSPsua", tenSPpro);
                            cmd.Parameters.AddWithValue("@LoaiSP", "Điện thoại");
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand command = new SqlCommand(query2, connection))
                        {
                            command.Parameters.AddWithValue("@MaSP", maSP);
                            command.Parameters.AddWithValue("@TenSP", tenSP);
                            command.Parameters.AddWithValue("@DungLuong", dungLuong);
                            command.Parameters.AddWithValue("@PhienBan", phienBan);
                            command.Parameters.AddWithValue("@MauSac", mauSac);
                            command.Parameters.AddWithValue("@SoKieuMay", sokieuMay);
                            command.Parameters.AddWithValue("@NamRaMat", namramatText);
                            command.Parameters.AddWithValue("@Gia", giaText);
                            command.Parameters.AddWithValue("@TinhTrang", tinhTrang);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Thêm sản phẩm thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtMaSP.Text = string.Empty;
                        txtTenSP.Text = string.Empty;
                        cbbDungLuong.Text = string.Empty;
                        cbbPhienBan.Text = string.Empty;
                        cbbTinhTrang.Text = string.Empty;
                        txtNamRaMat.Text = string.Empty;
                        txtMauSac.Text = string.Empty;
                        txtSoKM.Text = string.Empty;
                        txtGia.Text = string.Empty;
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            LoadDataIP(queryIP);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDataIP(queryIP);
            txtMaSP.Text = string.Empty;
            txtTenSP.Text = string.Empty;
            cbbDungLuong.Text = string.Empty;
            cbbPhienBan.Text = string.Empty;
            cbbTinhTrang.Text = string.Empty;
            txtNamRaMat.Text = string.Empty;
            txtMauSac.Text = string.Empty;
            txtSoKM.Text = string.Empty;
            txtGia.Text = string.Empty;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text;
            DialogResult result = MessageBox.Show("Bạn có xác nhận muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (maSP == " ")
            {
                MessageBox.Show("Hãy chọn một sản phẩm cần xóa trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection1 = new SqlConnection(connStr))
                    {
                        connection1.Open();

                        string deleteQuery = "IF EXISTS (SELECT * FROM iPhone WHERE MaSP = @MaSP)\r\nBEGIN\r\n " +
                            "DELETE FROM iPhone WHERE MaSP = @MaSP;\r\n \r\n DELETE FROM Products WHERE MaSP = @MaSP;\r\n \r\nEND";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection1))
                        {
                            deleteCommand.Parameters.AddWithValue("@MaSP", maSP);
                            int rowsAffected = deleteCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMaSP.Text = string.Empty;
                                txtTenSP.Text = string.Empty;
                                cbbDungLuong.Text = string.Empty;
                                cbbPhienBan.Text = string.Empty;
                                cbbTinhTrang.Text = string.Empty;
                                txtNamRaMat.Text = string.Empty;
                                txtMauSac.Text = string.Empty;
                                txtSoKM.Text = string.Empty;
                                txtGia.Text = string.Empty;
                                LoadDataIP(queryIP);
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

            string keyword = txtTimKiem.Text.Trim();

            LoadDataIP(queryIP);

            string query = "SELECT * FROM iPhone WHERE MaSP LIKE @Keyword OR TenSP LIKE @Keyword OR PhienBan LIKE @Keyword OR DungLuong LIKE @Keyword OR Gia LIKE @Keyword OR MauSac LIKE @Keyword OR TinhTrang LIKE @Keyword ";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvIP.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text;
            string tenSP = txtTenSP.Text;
            string tenSPpro;
            if (cbbPhienBan.Text == "Thường")
            {
                tenSPpro = txtTenSP.Text + " " + cbbDungLuong.Text + " " + txtMauSac.Text;
            }
            else { tenSPpro = txtTenSP.Text + " " + cbbPhienBan.Text + " " + cbbDungLuong.Text + " " + txtMauSac.Text; }

            string dungLuong = cbbDungLuong.Text;
            string phienBan = cbbPhienBan.Text;
            string mauSac = txtMauSac.Text;
            string soKieuMay = txtSoKM.Text;
            string namramatText = txtNamRaMat.Text;
            int Namramat;
            string giaText = txtGia.Text;
            int gia;
            string tinhTrang = cbbTinhTrang.Text;
            string querySua = "UPDATE Products SET MaSP = @MaSP, TenSP = @TenSPsua WHERE MaSP = @MaSP \r\n" +
                "UPDATE iPhone SET " +
                "TenSP = @TenSP," +
                "DungLuong = @DungLuong," +
                "PhienBan = @PhienBan," +
                "MauSac = @MauSac," +
                "SoKieuMay = @SoKieuMay," +
                "Gia = @Gia," +
                "NamRaMat = @NamRaMat," +
                "TinhTrang = @TinhTrang " +
                "WHERE MaSP = @MaSP";


            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                if (maSP == "" || tenSP == "" || dungLuong == "" || phienBan == "" || mauSac == "" || soKieuMay == "" || namramatText == "" || giaText == "" || tinhTrang == "")
                {
                    MessageBox.Show("Hãy chọn một sản phẩm cần sửa trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!int.TryParse(giaText, out gia))
                {
                    MessageBox.Show("Giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(namramatText, out Namramat))
                {
                    MessageBox.Show("Năm ra mắt không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlCommand command = new SqlCommand(querySua, connection))
                {
                    command.Parameters.AddWithValue("@MaSP", maSP);
                    command.Parameters.AddWithValue("@TenSPsua", tenSPpro);
                    command.Parameters.AddWithValue("@TenSP", tenSP);
                    command.Parameters.AddWithValue("@DungLuong", dungLuong);
                    command.Parameters.AddWithValue("@PhienBan", phienBan);
                    command.Parameters.AddWithValue("@MauSac", mauSac);
                    command.Parameters.AddWithValue("@SoKieuMay", soKieuMay);
                    command.Parameters.AddWithValue("@NamRaMat", namramatText);
                    command.Parameters.AddWithValue("@Gia", giaText);
                    command.Parameters.AddWithValue("@TinhTrang", tinhTrang);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataIP(queryIP);
                    }
                    else
                    {
                        MessageBox.Show("Sửa sản phẩm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                connection.Close();

            }
        }

        private void btnThemMB_Click(object sender, EventArgs e)
        {
            string maSP = txtMaMB.Text;
            string tenSPpro = txtTenMB.Text + " " + cbbPhienBanMB.Text + " " + cbbRAM.Text + "/" + txtChipSet.Text;
            string tenSP = txtTenMB.Text;
            string dungLuong = cbbDungLuongMB.Text;
            string ram = cbbRAM.Text;
            string chipSet = txtChipSet.Text;
            string phienBan = cbbPhienBanMB.Text;
            string mauSac = txtMauSacMB.Text;
            string sokieuMay = txtSoKieuMayMB.Text;
            string namramatText = txtNamRaMatMB.Text;
            int Namramat;
            string giaText = txtGiaMB.Text;
            int gia;
            string tinhTrang = cbbTinhTrangMB.Text;

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Products WHERE MaSP = @MaSP";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@MaSP", maSP);
                    int existingRecords = (int)checkCommand.ExecuteScalar();
                    if (maSP == "" || tenSP == "" || dungLuong == "" || phienBan == "" || ram == "" || chipSet == "" || mauSac == "" || sokieuMay == "" || namramatText == "" || giaText == "" || tinhTrang == "")
                    {
                        MessageBox.Show("Thêm sản phẩm thất bại! Hãy nhập toàn bộ thông tin của sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!int.TryParse(giaText, out gia))
                    {
                        MessageBox.Show("Giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(namramatText, out Namramat))
                    {
                        MessageBox.Show("Năm ra mắt không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (existingRecords > 0)
                    {

                        MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        string query1 = "INSERT INTO Products (MaSP, TenSP, LoaiSP) VALUES (@MaSP,@TenSP,@LoaiSP)";
                        string query2 = "INSERT INTO MacBook (MaSP, TenSP, DungLuong, RAM, ChipSet, PhienBan, MauSac, SoKieuMay, NamRaMat, Gia, TinhTrang) VALUES (@MaSP, @TenSP, @DungLuong, @RAM, @ChipSet, @PhienBan, @MauSac, @SoKieuMay, @NamRaMat, @Gia, @TinhTrang)";

                        using (SqlCommand cmd = new SqlCommand(query1, connection))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@TenSP", tenSPpro);
                            cmd.Parameters.AddWithValue("@LoaiSP", "Máy tính xách tay");
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand command = new SqlCommand(query2, connection))
                        {
                            command.Parameters.AddWithValue("@MaSP", maSP);
                            command.Parameters.AddWithValue("@TenSP", tenSP);
                            command.Parameters.AddWithValue("@DungLuong", dungLuong);
                            command.Parameters.AddWithValue("@RAM", ram);
                            command.Parameters.AddWithValue("@ChipSet", chipSet);
                            command.Parameters.AddWithValue("@PhienBan", phienBan);
                            command.Parameters.AddWithValue("@MauSac", mauSac);
                            command.Parameters.AddWithValue("@SoKieuMay", sokieuMay);
                            command.Parameters.AddWithValue("@NamRaMat", namramatText);
                            command.Parameters.AddWithValue("@Gia", giaText);
                            command.Parameters.AddWithValue("@TinhTrang", tinhTrang);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Thêm sản phẩm thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtMaMB.Text = string.Empty;
                        txtTenMB.Text = string.Empty;
                        cbbDungLuongMB.Text = string.Empty;
                        cbbRAM.Text = string.Empty;
                        txtChipSet.Text = string.Empty;
                        cbbPhienBanMB.Text = string.Empty;
                        cbbTinhTrangMB.Text = string.Empty;
                        txtNamRaMatMB.Text = string.Empty;
                        txtMauSacMB.Text = string.Empty;
                        txtSoKieuMayMB.Text = string.Empty;
                        txtGiaMB.Text = string.Empty;
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            LoadDataMB(queryMB);
        }
        private void btnLamMoiMB_Click(object sender, EventArgs e)
        {
            LoadDataMB(queryMB);
            txtMaMB.Text = string.Empty;
            txtTenMB.Text = string.Empty;
            cbbDungLuongMB.Text = string.Empty;
            cbbRAM.Text = string.Empty;
            txtChipSet.Text = string.Empty;
            cbbPhienBanMB.Text = string.Empty;
            cbbTinhTrangMB.Text = string.Empty;
            txtNamRaMatMB.Text = string.Empty;
            txtMauSacMB.Text = string.Empty;
            txtSoKieuMayMB.Text = string.Empty;
            txtGiaMB.Text = string.Empty;
        }

        private void btnSuaMB_Click(object sender, EventArgs e)
        {
            string maSP = txtMaMB.Text;
            string tenSPpro = txtTenMB.Text + " " + cbbPhienBanMB.Text + " " + cbbRAM.Text + "/" + txtChipSet.Text;
            string tenSP = txtTenMB.Text;
            string dungLuong = cbbDungLuongMB.Text;
            string ram = cbbRAM.Text;
            string chipSet = txtChipSet.Text;
            string phienBan = cbbPhienBanMB.Text;
            string mauSac = txtMauSacMB.Text;
            string sokieuMay = txtSoKieuMayMB.Text;
            string namramatText = txtNamRaMatMB.Text;
            int Namramat;
            string giaText = txtGiaMB.Text;
            int gia;
            string tinhTrang = cbbTinhTrangMB.Text;
            string querySua = "UPDATE Products SET MaSP = @MaSP, TenSP = @TenSPsua WHERE MaSP =@MaSP \r\n" +
                "UPDATE MacBook SET " +
                "TenSP = @TenSP," +
                "DungLuong = @DungLuong," +
                "PhienBan = @PhienBan," +
                "RAM = @RAM," +
                "ChipSet = @ChipSet," +
                "MauSac = @MauSac," +
                "SoKieuMay = @SoKieuMay," +
                "Gia = @Gia," +
                "NamRaMat = @NamRaMat," +
                "TinhTrang = @TinhTrang " +
                "WHERE MaSP = @MaSP";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                if (maSP == "" || tenSP == "" || dungLuong == "" || phienBan == "" || ram == "" || chipSet == "" || mauSac == "" || sokieuMay == "" || namramatText == "" || giaText == "" || tinhTrang == "")
                {
                    MessageBox.Show("Hãy chọn một sản phẩm cần sửa trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!int.TryParse(giaText, out gia))
                {
                    MessageBox.Show("Giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(namramatText, out Namramat))
                {
                    MessageBox.Show("Năm ra mắt không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlCommand command = new SqlCommand(querySua, connection))
                {
                    command.Parameters.AddWithValue("@MaSP", maSP);
                    command.Parameters.AddWithValue("@TenSPsua", tenSPpro);
                    command.Parameters.AddWithValue("@TenSP", tenSP);
                    command.Parameters.AddWithValue("@DungLuong", dungLuong);
                    command.Parameters.AddWithValue("@RAM", ram);
                    command.Parameters.AddWithValue("@ChipSet", chipSet);
                    command.Parameters.AddWithValue("@PhienBan", phienBan);
                    command.Parameters.AddWithValue("@MauSac", mauSac);
                    command.Parameters.AddWithValue("@SoKieuMay", sokieuMay);
                    command.Parameters.AddWithValue("@NamRaMat", namramatText);
                    command.Parameters.AddWithValue("@Gia", giaText);
                    command.Parameters.AddWithValue("@TinhTrang", tinhTrang);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataMB(queryMB);
                    }
                    else
                    {
                        MessageBox.Show("Sửa sản phẩm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                connection.Close();

            }
        }

        private void btnXoaMB_Click(object sender, EventArgs e)
        {
            string maSP = txtMaMB.Text;
            DialogResult result = MessageBox.Show("Bạn có xác nhận muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (maSP == " ")
            {
                MessageBox.Show("Hãy chọn một sản phẩm cần xóa trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection1 = new SqlConnection(connStr))
                    {
                        connection1.Open();

                        string deleteQuery = "IF EXISTS (SELECT * FROM MacBook WHERE MaSP = @MaSP)\r\nBEGIN\r\n " +
                            "DELETE FROM MacBook WHERE MaSP = @MaSP;\r\n \r\n DELETE FROM Products WHERE MaSP = @MaSP;\r\n \r\nEND";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection1))
                        {
                            deleteCommand.Parameters.AddWithValue("@MaSP", maSP);
                            int rowsAffected = deleteCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMaMB.Text = string.Empty;
                                txtTenMB.Text = string.Empty;
                                cbbDungLuongMB.Text = string.Empty;
                                cbbRAM.Text = string.Empty;
                                txtChipSet.Text = string.Empty;
                                cbbPhienBanMB.Text = string.Empty;
                                cbbTinhTrangMB.Text = string.Empty;
                                txtNamRaMatMB.Text = string.Empty;
                                txtMauSacMB.Text = string.Empty;
                                txtSoKieuMayMB.Text = string.Empty;
                                txtGiaMB.Text = string.Empty;
                                LoadDataMB(queryMB);
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

        private void btnTimKiemMB_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemMB.Text.Trim();

            LoadDataMB(queryMB);

            string query = "SELECT * FROM MacBook WHERE MaSP LIKE @Keyword OR TenSP LIKE @Keyword OR DungLuong LIKE @Keyword OR RAM LIKE @Keyword OR ChipSet LIKE @Keyword OR PhienBan LIKE @Keyword OR Gia LIKE @Keyword OR MauSac LIKE @Keyword OR TinhTrang LIKE @Keyword";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvMB.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        private void btnThemAP_Click(object sender, EventArgs e)
        {

            string maSP = txtMaAP.Text;
            string tenSPpro;
            string tenSP = txtTenAP.Text;
            string phienBan = cbbPhienBanAP.Text;
            string sokieuMay = txtSoKieuMayAP.Text;
            string namramatText = txtNamRaMatAP.Text;
            int Namramat;
            string giaText = txtGiaAP.Text;
            int gia;
            string tinhTrang = cbbTinhTrangAP.Text;
            if (cbbPhienBanAP.Text == "Thường")
            {
                tenSPpro = "Apple" + txtTenAP.Text;
            }
            else { tenSPpro = "Apple" + txtTenAP.Text + " " + cbbPhienBanAP.Text; }


            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Products WHERE MaSP = @MaSP";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@MaSP", maSP);
                    int existingRecords = (int)checkCommand.ExecuteScalar();
                    if (maSP == "" || tenSP == "" || phienBan == "" || sokieuMay == "" || namramatText == "" || giaText == "" || tinhTrang == "")
                    {
                        MessageBox.Show("Thêm sản phẩm thất bại! Hãy nhập toàn bộ thông tin của sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!int.TryParse(giaText, out gia))
                    {
                        MessageBox.Show("Giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(namramatText, out Namramat))
                    {
                        MessageBox.Show("Năm ra mắt không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        string query1 = "INSERT INTO Products (MaSP, TenSP,LoaiSP) VALUES (@MaSP,@TenSPsua,@LoaiSP)";
                        string query2 = "INSERT INTO AirPods (MaSP, TenSP, PhienBan, SoKieuMay, NamRaMat, Gia, TinhTrang) VALUES (@MaSP, @TenSP, @PhienBan, @SoKieuMay, @NamRaMat, @Gia, @TinhTrang)";

                        using (SqlCommand cmd = new SqlCommand(query1, connection))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@TenSPsua", tenSPpro);
                            cmd.Parameters.AddWithValue("@LoaiSP", "Tai nghe không dây");
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand command = new SqlCommand(query2, connection))
                        {
                            command.Parameters.AddWithValue("@MaSP", maSP);
                            command.Parameters.AddWithValue("@TenSP", tenSP);
                            command.Parameters.AddWithValue("@PhienBan", phienBan);
                            command.Parameters.AddWithValue("@SoKieuMay", sokieuMay);
                            command.Parameters.AddWithValue("@NamRaMat", namramatText);
                            command.Parameters.AddWithValue("@Gia", giaText);
                            command.Parameters.AddWithValue("@TinhTrang", tinhTrang);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Thêm sản phẩm thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtMaAP.Text = string.Empty;
                        txtTenAP.Text = string.Empty;
                        cbbPhienBanAP.Text = string.Empty;
                        cbbTinhTrangAP.Text = string.Empty;
                        txtNamRaMatAP.Text = string.Empty;
                        txtSoKieuMayAP.Text = string.Empty;
                        txtGiaAP.Text = string.Empty;
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            LoadDataAP(queryAP);
        }

        private void btnLamMoiAP_Click(object sender, EventArgs e)
        {
            LoadDataAP(queryAP);
            txtMaAP.Text = string.Empty;
            txtTenAP.Text = string.Empty;
            cbbPhienBanAP.Text = string.Empty;
            cbbTinhTrangAP.Text = string.Empty;
            txtNamRaMatAP.Text = string.Empty;
            txtSoKieuMayAP.Text = string.Empty;
            txtGiaAP.Text = string.Empty;
        }

        private void btnSuaAP_Click(object sender, EventArgs e)
        {

            string maSP = txtMaAP.Text;
            string tenSPpro;
            string tenSP = txtTenAP.Text;
            string phienBan = cbbPhienBanAP.Text;
            string sokieuMay = txtSoKieuMayAP.Text;
            string namramatText = txtNamRaMatAP.Text;
            int Namramat;
            string giaText = txtGiaAP.Text;
            int gia;
            string tinhTrang = cbbTinhTrangAP.Text;
            if (cbbPhienBanAP.Text == "Thường")
            {
                tenSPpro = "Apple" + txtTenAP.Text;
            }
            else { tenSPpro = "Apple" + txtTenAP.Text + " " + cbbPhienBanAP.Text; }

            string querySua = "UPDATE Products SET MaSP = @MaSP, TenSP = @TenSPsua WHERE MaSP = @MaSP \r\n" +
                "UPDATE AirPods SET " +
                "TenSP = @TenSP," +
                "PhienBan = @PhienBan," +
                "SoKieuMay = @SoKieuMay," +
                "Gia = @Gia," +
                "NamRaMat = @NamRaMat," +
                "TinhTrang = @TinhTrang " +
                "WHERE MaSP = @MaSP";


            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                if (maSP == "" || tenSP == "" || phienBan == "" || sokieuMay == "" || namramatText == "" || giaText == "" || tinhTrang == "")
                {
                    MessageBox.Show("Hãy chọn một sản phẩm cần sửa trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!int.TryParse(giaText, out gia))
                {
                    MessageBox.Show("Giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(namramatText, out Namramat))
                {
                    MessageBox.Show("Năm ra mắt không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlCommand command = new SqlCommand(querySua, connection))
                {
                    command.Parameters.AddWithValue("@MaSP", maSP);
                    command.Parameters.AddWithValue("@TenSPsua", tenSPpro);
                    command.Parameters.AddWithValue("@TenSP", tenSP);
                    command.Parameters.AddWithValue("@PhienBan", phienBan);
                    command.Parameters.AddWithValue("@SoKieuMay", sokieuMay);
                    command.Parameters.AddWithValue("@NamRaMat", namramatText);
                    command.Parameters.AddWithValue("@Gia", giaText);
                    command.Parameters.AddWithValue("@TinhTrang", tinhTrang);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataAP(queryAP);
                    }
                    else
                    {
                        MessageBox.Show("Sửa sản phẩm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                connection.Close();

            }
        }

        private void btnXoaAP_Click(object sender, EventArgs e)
        {
            string maSP = txtMaAP.Text;
            DialogResult result = MessageBox.Show("Bạn có xác nhận muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (maSP == " ")
            {
                MessageBox.Show("Hãy chọn một sản phẩm cần xóa trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection1 = new SqlConnection(connStr))
                    {
                        connection1.Open();

                        string deleteQuery = "IF EXISTS (SELECT * FROM AirPods WHERE MaSP = @MaSP)\r\nBEGIN\r\n " +
                            "DELETE FROM AirPods WHERE MaSP = @MaSP;\r\n \r\n DELETE FROM Products WHERE MaSP = @MaSP;\r\n \r\nEND";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection1))
                        {
                            deleteCommand.Parameters.AddWithValue("@MaSP", maSP);
                            int rowsAffected = deleteCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMaAP.Text = string.Empty;
                                txtTenAP.Text = string.Empty;
                                cbbPhienBanAP.Text = string.Empty;
                                cbbTinhTrangAP.Text = string.Empty;
                                txtNamRaMatAP.Text = string.Empty;
                                txtSoKieuMayAP.Text = string.Empty;
                                txtGiaAP.Text = string.Empty;
                                LoadDataAP(queryAP);
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

        private void btnTimKiemAP_Click(object sender, EventArgs e)
        {

            string keyword = txtTimKiemAP.Text.Trim();

            LoadDataAP(queryAP);

            string query = "SELECT * FROM AirPods WHERE MaSP LIKE @Keyword OR TenSP LIKE @Keyword OR PhienBan LIKE @Keyword OR Gia LIKE @Keyword OR TinhTrang LIKE @Keyword ";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvAP.DataSource = dataTable;
                }
                connection.Close();
            }
        }

    }
}

