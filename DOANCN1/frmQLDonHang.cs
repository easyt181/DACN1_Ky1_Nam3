using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DOANCN1
{
    public partial class frmQLDonHang : Form
    { 
        public string connStr = "Data Source=DESKTOP-6FT616D;Initial Catalog=DOANCN1;Integrated Security=True";


        public frmQLDonHang()
        {
            InitializeComponent();
        }

        private void frmQLDonHang_Load(object sender, EventArgs e)
        {

            LoadChiTietDH();
            LoadDonHang();

        }

        private void cbbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLoaiSP = cbbLoaiSP.Text;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string query = "SELECT TenSP FROM Products WHERE LoaiSP = @LoaiSP";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoaiSP", selectedLoaiSP);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> danhSachTenSP = new List<string>();
                        while (reader.Read())
                        {
                            string tenSP = reader["TenSP"].ToString();
                            danhSachTenSP.Add(tenSP);
                        }

                        cbbTenSP.DataSource = danhSachTenSP;
                    }
                }
            }
        }  

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            string maCT = txtMaChiTiet.Text;
            string maSP = null;
            string tenSP = cbbTenSP.Text;
            string loaiSP = cbbLoaiSP.Text; 
            

            int soLuong =   (int)numChiTietSL.Value;
            int gia1;
            int gia = 0;

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                string layiPhone = "SELECT Products.MaSP, iPhone.Gia  FROM Products INNER JOIN iPhone ON iPhone.MaSP = Products.MaSP WHERE Products.TenSP = @TenSP";
                string layMacBook = "SELECT Products.MaSP, MacBook.Gia  FROM Products INNER JOIN MacBook ON Products.MaSP = MacBook.MaSP WHERE Products.TenSP = @TenSP";
                string layAirPods = "SELECT Products.MaSP, AirPods.Gia  FROM Products INNER JOIN AirPods ON Products.MaSP = AirPods.MaSP WHERE Products.TenSP = @TenSP";


                string checkQuery = "SELECT COUNT(*) FROM ChiTietDH WHERE MaChiTiet = @MaChiTiet";

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@MaChiTiet", maCT);
                    int existingRecords = (int)checkCommand.ExecuteScalar();
                    if (maCT == " " || tenSP == " " || loaiSP == "")
                    {
                        MessageBox.Show("Hãy nhập đầy đủ thông tin chi tiết đơn cần thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (existingRecords > 0)
                    {

                        MessageBox.Show("Mã chi tiết đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    bool daTonTai = false;
                    foreach (DataGridViewRow row in dgvChiTiet.Rows)
                    {
                        if (row.Cells["MaChiTiet"].Value != null && row.Cells["MaChiTiet"].Value.ToString() == maCT)
                        {
                            daTonTai = true;
                            break;
                        }
                    }

                    if (daTonTai)
                    {
                        MessageBox.Show("Mã chi tiết đã tồn tại trong Giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    txtMaChiTiet.Text = string.Empty;
                    cbbLoaiSP.Text = string.Empty;  
                    cbbTenSP.Text = string.Empty;   
                    try
                    {
                        if (loaiSP == "Điện thoại")
                        {
                            using (SqlCommand command = new SqlCommand(layiPhone, connection))
                            {
                                command.Parameters.AddWithValue("@TenSP", tenSP);
                                SqlDataReader reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    maSP = reader.GetString(0);
                                    gia1 = reader.GetInt32(1);
                                    gia = gia1 * soLuong;
                                }
                                reader.Close();
                                DataGridViewRow newRow = dgvChiTiet.Rows[dgvChiTiet.Rows.Add()];
                                newRow.Cells["MaChiTiet"].Value = maCT;
                                newRow.Cells["MaSP"].Value = maSP;
                                newRow.Cells["TenSP"].Value = tenSP;
                                newRow.Cells["SoLuong"].Value = soLuong;
                                newRow.Cells["ThanhTien"].Value = gia;

                            }
                            return;

                        }
                        if (loaiSP == "Máy tính xách tay")
                        {
                            using (SqlCommand command = new SqlCommand(layMacBook, connection))
                            {
                                command.Parameters.AddWithValue("@TenSP", tenSP);
                                SqlDataReader reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    maSP = reader.GetString(0);
                                    gia1 = reader.GetInt32(1);
                                    gia = gia1 * soLuong;
                                }
                                reader.Close();
                                DataGridViewRow newRow = dgvChiTiet.Rows[dgvChiTiet.Rows.Add()];
                                newRow.Cells["MaChiTiet"].Value = maCT;
                                newRow.Cells["MaSP"].Value = maSP;
                                newRow.Cells["TenSP"].Value = tenSP;
                                newRow.Cells["SoLuong"].Value = soLuong;
                                newRow.Cells["ThanhTien"].Value = gia;
                            }
                            return;
                        }
                        if (loaiSP == "Tai nghe không dây")
                        {
                            using (SqlCommand command = new SqlCommand(layAirPods, connection))
                            {
                                command.Parameters.AddWithValue("@TenSP", tenSP);
                                SqlDataReader reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    maSP = reader.GetString(0);
                                    gia1 = reader.GetInt32(1);
                                    gia = gia1 * soLuong;
                                }
                                reader.Close();
                                DataGridViewRow newRow = dgvChiTiet.Rows[dgvChiTiet.Rows.Add()];
                                newRow.Cells["MaChiTiet"].Value = maCT;
                                newRow.Cells["MaSP"].Value = maSP;
                                newRow.Cells["TenSP"].Value = tenSP;
                                newRow.Cells["SoLuong"].Value = soLuong;
                                newRow.Cells["ThanhTien"].Value = gia;
                            }
                            return;
                        }
                        
                    } 
                    catch
                    {
                        MessageBox.Show("Lỗi","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                 
 
                connection.Close();
            }

        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            string maChiTietXoa = txtMaChiTiet.Text; // Thay thế bằng giá trị MaChiTiet cần xóa

            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.Cells["MaChiTiet"].Value != null && row.Cells["MaChiTiet"].Value.ToString() == maChiTietXoa)
                {
                 
                    dgvChiTiet.Rows.Remove(row);
                    break; 
                }
            }
            UpdateTongTien();
        }
    
        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            
            decimal tongTien = decimal.Parse(txtTongTien.Text);   

            string queryUuDai = "SELECT ChiTiet FROM UuDai WHERE DieuKien <= @TongTien";


            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryUuDai, connection))
                {
                    command.Parameters.AddWithValue("@TongTien", tongTien);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter1.Fill(dataTable);

                    cbbUuDai.Items.Clear();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        cbbUuDai.Items.Add(row["ChiTiet"].ToString());
                    }
                    cbbUuDai.Items.Add("Không có");
                    if (cbbUuDai.Items.Count == 0)
                    {
                        cbbUuDai.Items.Add("Không có");
                        cbbUuDai.SelectedIndex = 0;
                    }
                    else
                    {
                        cbbUuDai.SelectedIndex = 0;
                    }
                }            
                connection.Close();
            }         
            
        }

        public void LoadDonHang()
        {       
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStr;
            conn.Open();
            string query = "SELECT DonHang.*, KhachHang.TenKH, KhachHang.SDT FROM DonHang INNER JOIN KhachHang ON DonHang.MaKH = KhachHang.MaKH";
            SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

                dgvDonHang.AutoGenerateColumns = false;
                dgvDonHang.DataSource = dt;
                dgvDonHang.Columns["MaDonHang"].DataPropertyName = "MaDonHang";
                dgvDonHang.Columns["MaKH"].DataPropertyName = "MaKH"; 
                dgvDonHang.Columns["MaUuDai"].DataPropertyName = "MaUuDai";
                dgvDonHang.Columns["TenKH"].DataPropertyName = "TenKH";
                dgvDonHang.Columns["SDT"].DataPropertyName = "SDT";
                dgvDonHang.Columns["SoLuongChiTiet"].DataPropertyName = "SoLuongChiTiet";
                dgvDonHang.Columns["NgayDatHang"].DataPropertyName = "NgayDatHang";
                dgvDonHang.Columns["TongTien"].DataPropertyName = "ThanhTien";
                dgvDonHang.Columns["TrangThai"].DataPropertyName = "TrangThai";
                conn.Close();
            
        }

        public void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string chitietuudai = null;
            string diachi = null;
            
            dgvChiTiet.Rows.Clear();
            
            if (e.RowIndex >= 0)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connStr;
                conn.Open();
                string query = "SELECT ChiTiet FROM UuDai WHERE MaUuDai = @MaUuDai";
                string query2 = "SELECT * FROM KhachHang WHERE MaKH = @MaKH";
                string query3 = "SELECT ChiTietDH.*, Products.TenSP FROM ChiTietDH INNER JOIN Products ON ChiTietDH.MaSP = Products.MaSP WHERE MaDonHang = @MaDonHang";
                
                DataGridViewRow row = dgvDonHang.Rows[e.RowIndex];
                string mauudai = row.Cells["MaUuDai"].Value.ToString();
                string makh = row.Cells["MaKH"].Value.ToString();
                txtMaDonHang.Text = row.Cells["MaDonHang"].Value.ToString();
                string maDonHang = txtMaDonHang.Text;
                dateNgayDatHang.Text = row.Cells["NgayDatHang"].Value.ToString();
                txtTongTien.Text = row.Cells["TongTien"].Value.ToString();    
                cbbTrangThai.Text = row.Cells["TrangThai"].Value.ToString();

                using (SqlCommand cmd = new SqlCommand(query3, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDonHang", maDonHang);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string maCT = reader["MaChiTiet"].ToString();
                        string maSP = reader["MaSP"].ToString();
                        string tenSP = reader["TenSP"].ToString();
                        int thanhTien = Convert.ToInt32(reader["ThanhTien"]);
                        int soLuong = Convert.ToInt32(reader["SoLuong"]);
                        dgvChiTiet.Rows.Add(maCT, maSP,tenSP, soLuong, thanhTien);
                    }
                    reader.Close();
                }

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MaUuDai", mauudai);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        chitietuudai = reader.GetString(0);
                    }
                    reader.Close();

                }

                using (SqlCommand command = new SqlCommand(query2, conn))
                {
                    command.Parameters.AddWithValue("@MaKH", makh);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        diachi = reader.GetString(3);
                    }
                    reader.Close();

                }
                txtDiaChi.Text = diachi;
                txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();

                cbbUuDai.Text = chitietuudai;
                conn.Close();   

            }
            UpdateTongTien();
        }       

        private void dgvChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTongTien();
        }

        private void cbbUuDai_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTongTien();
        }

        private void UpdateTongTien()
        {
            int tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += int.Parse(row.Cells["ThanhTien"].Value.ToString());
                }
            }
            txtTongTien.Text = tongTien.ToString();
        }

        public void LoadChiTietDH()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStr;
            conn.Open();
            string query = "SELECT ChiTietDH.*, Products.TenSP, DonHang.NgayDatHang FROM ChiTietDH JOIN Products ON Products.MaSP = ChiTietDH.MaSP JOIN DonHang ON ChiTietDH.MaDonHang = DonHang.MaDonHang";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dgvTraCuuCT.AutoGenerateColumns = false;
            dgvTraCuuCT.DataSource = dataTable;
            dgvTraCuuCT.Columns["MaChiTietCT"].DataPropertyName = "MaChiTiet";
            dgvTraCuuCT.Columns["MaDonHangCT"].DataPropertyName = "MaDonHang";
            dgvTraCuuCT.Columns["MaSPCT"].DataPropertyName = "MaSP";
            dgvTraCuuCT.Columns["TenSPCT"].DataPropertyName = "TenSP";
            dgvTraCuuCT.Columns["SoLuongCT"].DataPropertyName = "SoLuong";
            dgvTraCuuCT.Columns["ThanhTienCT"].DataPropertyName = "ThanhTien";
            dgvTraCuuCT.Columns["NgayDatHangCT"].DataPropertyName = "NgayDatHang";

            conn.Close();
        }
        public void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChiTiet.Rows[e.RowIndex];
                txtMaChiTiet.Text = row.Cells["MaChiTiet"].Value.ToString();
                cbbTenSP.Text = row.Cells["TenSP"].Value.ToString();
                cbbLoaiSP.Text = string.Empty;
                if (row.Cells["SoLuong"].Value != null)
                {
                    int soLuong;
                    if (int.TryParse(row.Cells["SoLuong"].Value.ToString(), out soLuong))
                    {
                        numChiTietSL.Value = soLuong;
                    }
                }
            }
        }

        private void btnThemDH_Click(object sender, EventArgs e)
        { 
            //khach hang
            string maKH = txtMaKH.Text;
            string tenKH = txtTenKH.Text;
            string SDT = txtSDT.Text;
            string diaChi = txtDiaChi.Text;
            //don hang
            string maDonHang = txtMaDonHang.Text;
            DateTime ngayDatHang = dateNgayDatHang.Value;
            string ngayDatHangStr = ngayDatHang.ToString("MM-dd-yyyy");
            int tongCTDH = dgvChiTiet.Rows.Count;
            string tongTien = txtTongTien.Text;
            string trangThai = cbbTrangThai.Text;
            string chitietUD = cbbUuDai.Text;
            string maUuDai = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStr;
            conn.Open();

            string insertDonHang = "INSERT INTO DonHang (MaDonHang, MaKH, MaUuDai, SoLuongChiTiet, NgayDatHang, ThanhTien, TrangThai) VALUES(@MaDonHang, @MaKH, @MaUuDai, @SoLuongChiTiet, @NgayDatHang, @ThanhTien, @TrangThai)";
            string insertCTDH = "INSERT INTO ChiTietDH (MaChiTiet, MaDonHang, MaSP, SoLuong, ThanhTien) VALUES (@MaChiTiet, @MaDonHang, @MaSP, @SoLuong, @ThanhTien)";
            string insertKH = "INSERT INTO KhachHang (MaKH, TenKH, SDT, DiaChi) VALUES (@MaKH, @TenKH, @SDT, @DiaChi) ";
            string checkQuery = "SELECT COUNT(*) FROM DonHang WHERE MaDonHang = @MaDonHang";
            string timUuDai = "SELECT MaUuDai FROM UuDai WHERE ChiTiet = @ChiTiet";
            string checkKHQuery = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH";
            


            decimal tongTienSauGiamGia = 0;
        
            using(SqlCommand cmd = new SqlCommand(timUuDai, conn))
            {
                cmd.Parameters.AddWithValue("@ChiTiet", chitietUD);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    maUuDai = reader.GetString(0);

                }
                reader.Close();          
            }
            if (maUuDai == "UD003 ")
            {
                tongTienSauGiamGia = decimal.Parse(tongTien)*0.95m ;
                
                
            }
            else if (maUuDai == "UD005 ")
            {
                tongTienSauGiamGia = decimal.Parse(tongTien) * 0.92m;
                
            }
            else
            {
                tongTienSauGiamGia = decimal.Parse(tongTien);
            }


            using (SqlCommand checkcommand = new SqlCommand(checkQuery, conn))
            {
                checkcommand.Parameters.AddWithValue("@MaDonHang", maDonHang);
                int existingRecords = (int)checkcommand.ExecuteScalar();
                if (maDonHang == " " || maKH == " " || maUuDai == " " || ngayDatHangStr == " " || tongTien == " " ||
                trangThai == " " || tenKH == " " || SDT == " " || diaChi == " ")
                {
                    MessageBox.Show("Hãy nhập đầy đủ thông tin thiết yếu của một đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (tongCTDH == 0)
                {
                    MessageBox.Show("Hãy thêm chi tiết đơn hàng! Phải có tối thiểu có 1 chi tiết đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (existingRecords > 0)
                {

                    MessageBox.Show("Mã đơn hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (SqlCommand cmdKHCheck = new SqlCommand(checkKHQuery, conn))
                    {
                        cmdKHCheck.Parameters.AddWithValue("@MaKH", maKH);
                        int existingKHCount = (int)cmdKHCheck.ExecuteScalar();

                        if (existingKHCount == 0)
                        {
                            // Mã khách hàng chưa tồn tại, thêm khách hàng mới
                            using (SqlCommand cmdKH = new SqlCommand(insertKH, conn))
                            {
                                cmdKH.Parameters.AddWithValue("@MaKH", maKH);
                                cmdKH.Parameters.AddWithValue("@TenKH", tenKH);
                                cmdKH.Parameters.AddWithValue("@SDT", SDT);
                                cmdKH.Parameters.AddWithValue("@DiaChi", diaChi);
                                cmdKH.ExecuteNonQuery();
                            }
                        }
                    }


                    // them don hang
                    using (SqlCommand cmdDH = new SqlCommand(insertDonHang, conn))
                    {
                        cmdDH.Parameters.AddWithValue("@MaDonHang", maDonHang);
                        cmdDH.Parameters.AddWithValue("@MaKH", maKH);
                        cmdDH.Parameters.AddWithValue("@MaUuDai", maUuDai);
                        cmdDH.Parameters.AddWithValue("@SoLuongChiTiet", tongCTDH);
                        cmdDH.Parameters.AddWithValue("@NgayDatHang", ngayDatHangStr);
                        cmdDH.Parameters.AddWithValue("@ThanhTien", tongTienSauGiamGia);
                        cmdDH.Parameters.AddWithValue("@TrangThai", trangThai);

                        cmdDH.ExecuteNonQuery();
                    }

                    // them chi tiet don hang
                    foreach (DataGridViewRow row in dgvChiTiet.Rows)
                    {

                        string maChiTiet = row.Cells["MaChiTiet"].Value.ToString();
                        string maSP = row.Cells["MaSP"].Value.ToString();
                        int soLuong = int.Parse(row.Cells["SoLuong"].Value.ToString());
                        int thanhTien = int.Parse(row.Cells["ThanhTien"].Value.ToString());

                        using (SqlCommand cmdCTDH = new SqlCommand(insertCTDH, conn))
                        {
                            cmdCTDH.Parameters.AddWithValue("@MaChiTiet", maChiTiet);
                            cmdCTDH.Parameters.AddWithValue("@MaSP", maSP);
                            cmdCTDH.Parameters.AddWithValue("@MaDonHang", maDonHang);
                            cmdCTDH.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmdCTDH.Parameters.AddWithValue("@ThanhTien", thanhTien);

                            cmdCTDH.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Thêm đơn hàng thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtDiaChi.Text = string.Empty;
                    txtMaKH.Text = string.Empty; 
                    txtMaDonHang.Text = string.Empty;   
                    txtTenKH.Text = string.Empty;   
                    txtSDT.Text = string.Empty;
                    txtDiaChi.Text = string.Empty; 
                    cbbUuDai.Text = string.Empty;
                    dateNgayDatHang.Text = default;
                    cbbTrangThai.Text = string.Empty;
                    numChiTietSL.Value = 1;
                    dgvChiTiet.Rows.Clear();
                    txtTongTien.Text = "0";
                    

                    
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Lỗi khi thêm đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                conn.Close();
            }
            LoadDonHang();
            LoadChiTietDH();
            UpdateTongTien();
        }

        private void btnSuaDH_Click(object sender, EventArgs e)
        {
            string maDonHang = txtMaDonHang.Text;
            DateTime ngayDatHang = dateNgayDatHang.Value;
            string ngayDatHangStr = ngayDatHang.ToString("MM-dd-yyyy");
            int tongCTDH = dgvChiTiet.Rows.Count;
            string tongTien = txtTongTien.Text;
            string trangThai = cbbTrangThai.Text;
            string chitietUD = cbbUuDai.Text;
            string maUuDai = null;

           
            string querySuaDH = "UPDATE DonHang SET NgayDatHang = @NgayDatHang, MaUuDai = @MaUuDai,SoLuongChiTiet = @SoLuongChiTiet, ThanhTien = @ThanhTien, TrangThai = @TrangThai  WHERE MaDonHang = @MaDonHang";
            
            string timUuDai = "SELECT MaUuDai FROM UuDai WHERE ChiTiet = @ChiTiet";
            
            string deleteCTDH = "DELETE FROM ChiTietDH\r\nWHERE MaDonHang = @MaDonHang;";

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            //uudai
            using (SqlCommand cmd = new SqlCommand(timUuDai, conn))
            {
                cmd.Parameters.AddWithValue("@ChiTiet", chitietUD);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    maUuDai = reader.GetString(0);

                }
                reader.Close();
            }

            decimal tongTienSauGiamGia;
            if (maUuDai == "UD003 ")
            {
                tongTienSauGiamGia = decimal.Parse(tongTien) * 0.95m;
            }
            else if (maUuDai == "UD005 ")
            {
                tongTienSauGiamGia = decimal.Parse(tongTien) * 0.92m;

            }
            else
            {
                tongTienSauGiamGia = decimal.Parse(tongTien);
            }

            if (maDonHang == null)
                    {
                        MessageBox.Show("Hãy chọn một đơn hàng cần sửa trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            if (tongCTDH == 0)
                    {
                        MessageBox.Show("Hãy thêm chi tiết đơn hàng! Phải có tối thiểu có 1 chi tiết đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


            using (SqlCommand cmdDeleteCTDH = new SqlCommand(deleteCTDH, conn))
                {
                    cmdDeleteCTDH.Parameters.AddWithValue("@MaDonHang", maDonHang);
                    
                    cmdDeleteCTDH.ExecuteNonQuery();
                }

                
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    string maChiTiet = row.Cells["MaChiTiet"].Value.ToString();
                    string maSP = row.Cells["MaSP"].Value.ToString();
                    int soLuong = int.Parse(row.Cells["SoLuong"].Value.ToString());
                    int thanhTien = int.Parse(row.Cells["ThanhTien"].Value.ToString());

                    string insertCTDH = "INSERT INTO ChiTietDH (MaChiTiet, MaDonHang, MaSP, SoLuong, ThanhTien) VALUES (@MaChiTiet, @MaDonHang, @MaSP, @SoLuong, @ThanhTien)";
                    using (SqlCommand cmdInsertCTDH = new SqlCommand(insertCTDH, conn))
                    {
                        cmdInsertCTDH.Parameters.AddWithValue("@MaChiTiet", maChiTiet);
                        cmdInsertCTDH.Parameters.AddWithValue("@MaDonHang", maDonHang);
                        cmdInsertCTDH.Parameters.AddWithValue("@MaSP", maSP);
                        cmdInsertCTDH.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdInsertCTDH.Parameters.AddWithValue("@ThanhTien", thanhTien);
                        cmdInsertCTDH.ExecuteNonQuery();
                    }
                }
            using (SqlCommand commandSua = new SqlCommand(querySuaDH, conn))
                {
                    commandSua.Parameters.AddWithValue("@MaDonHang", maDonHang);
                    commandSua.Parameters.AddWithValue("@NgayDatHang", ngayDatHangStr);
                    commandSua.Parameters.AddWithValue("@MaUuDai", maUuDai);
                    commandSua.Parameters.AddWithValue("@SoLuongChiTiet", tongCTDH);
                    commandSua.Parameters.AddWithValue("@ThanhTien", tongTienSauGiamGia);
                    commandSua.Parameters.AddWithValue("@TrangThai", trangThai);

                    int rowsAffected = commandSua.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDiaChi.Text = string.Empty;
                        txtMaKH.Text = string.Empty;
                        txtMaDonHang.Text = string.Empty;
                        txtTenKH.Text = string.Empty;
                        txtSDT.Text = string.Empty;
                        txtDiaChi.Text = string.Empty;
                        cbbUuDai.Text = string.Empty;
                        dateNgayDatHang.Text = default;
                        cbbTrangThai.Text = string.Empty;
                        numChiTietSL.Value = 1;
                        dgvChiTiet.Rows.Clear();
                        txtTongTien.Text = "0";
                    }
                    else
                    {
                        MessageBox.Show("Sửa đơn hàng không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            LoadChiTietDH();
            LoadDonHang();

            }

        private void btnXoaDH_Click(object sender, EventArgs e)
        {
            string maDonHang = txtMaDonHang.Text; 

            DialogResult result = MessageBox.Show("Bạn có xác nhận muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (maDonHang == " ")
            {
                MessageBox.Show("Hãy chọn một sản phẩm cần xóa trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result == DialogResult.Yes)
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connStr;
                conn.Open();

                // Xóa tất cả các chi tiết đơn hàng có MaDonHang trùng với đơn hàng cần xóa
                string deleteCTDH = "DELETE FROM ChiTietDH WHERE MaDonHang = @MaDonHang";
                using (SqlCommand cmdDeleteCTDH = new SqlCommand(deleteCTDH, conn))
                {
                    cmdDeleteCTDH.Parameters.AddWithValue("@MaDonHang", maDonHang);
                    cmdDeleteCTDH.ExecuteNonQuery();
                }

                // Xóa đơn hàng cụ thể
                string deleteDonHang = "DELETE FROM DonHang WHERE MaDonHang = @MaDonHang";
                using (SqlCommand cmdDeleteDonHang = new SqlCommand(deleteDonHang, conn))
                {
                    cmdDeleteDonHang.Parameters.AddWithValue("@MaDonHang", maDonHang);
                    cmdDeleteDonHang.ExecuteNonQuery();
                }

                MessageBox.Show("Xóa đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                LoadChiTietDH();
                LoadDonHang();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvChiTiet.Rows.Clear();
            txtDiaChi.Text = string.Empty;
            txtMaChiTiet.Text = string.Empty;
            txtMaDonHang.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtMaKH.Text = string.Empty;
            cbbTenSP.Text = string.Empty;
            cbbLoaiSP.Text = string.Empty;
            numChiTietSL.Value = 1;
            cbbUuDai.Text = default;
            txtTongTien.Text = "0";
            dateNgayDatHang.Text = default;
            LoadChiTietDH();
            LoadDonHang();
        }

        private void btnTimKiemDH_Click(object sender, EventArgs e)
        {   

            frmSearch frmSearch = new frmSearch();
            frmSearch.ShowDialog();
            string tuKhoa = frmSearch.TuKhoa;



            string query = "SELECT DonHang.*,KhachHang.*,UuDai.* FROM DonHang JOIN KhachHang ON DonHang.MaKH = KhachHang.MaKH JOIN UuDai ON UuDai.MaUuDai = DonHang.MaUuDai WHERE MaDonHang LIKE @tuKhoa OR DonHang.MaKH LIKE @tuKhoa";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa  + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvDonHang.AutoGenerateColumns = false;
                    
                    dgvDonHang.Columns["MaDonHang"].DataPropertyName = "MaDonHang";
                    dgvDonHang.Columns["MaKH"].DataPropertyName = "MaKH";
                    dgvDonHang.Columns["MaUuDai"].DataPropertyName = "MaUuDai";
                    dgvDonHang.Columns["TenKH"].DataPropertyName = "TenKH";
                    dgvDonHang.Columns["SoLuongChiTiet"].DataPropertyName = "SoLuongChiTiet";
                    dgvDonHang.Columns["NgayDatHang"].DataPropertyName = "NgayDatHang";
                    dgvDonHang.Columns["TongTien"].DataPropertyName = "ThanhTien";
                    dgvDonHang.Columns["TrangThai"].DataPropertyName = "TrangThai";
                    dgvDonHang.DataSource = dataTable;
                }
                connection.Close();
            }

            

        }

        private void btnTimKiemCT_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtMaCT2.Text;

            string query = "SELECT ChiTietDH.*, Products.TenSP, DonHang.NgayDatHang FROM ChiTietDH JOIN Products ON Products.MaSP = ChiTietDH.MaSP JOIN DonHang ON ChiTietDH.MaDonHang = DonHang.MaDonHang WHERE MaChiTiet LIKE @tuKhoa OR ChiTietDH.MaSP LIKE @tuKhoa " +
                "OR DonHang.MaDonHang LIKE @tuKhoa OR Products.TenSP LIKE @tuKhoa OR SoLuong LIKE @tuKhoa;";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    
                    dgvTraCuuCT.AutoGenerateColumns = false;
                    dgvTraCuuCT.Columns["MaDonHangCT"].DataPropertyName = "MaDonHang";
                    dgvTraCuuCT.Columns["MaChiTietCT"].DataPropertyName = "MaChiTiet";
                    dgvTraCuuCT.Columns["TenSPCT"].DataPropertyName = "MaSP";
                    dgvTraCuuCT.Columns["TenSPCT"].DataPropertyName = "TenSP";
                    dgvTraCuuCT.Columns["SoLuongCT"].DataPropertyName = "SoLuong";
                    dgvTraCuuCT.Columns["NgayDatHangCT"].DataPropertyName = "NgayDatHang";
                    dgvTraCuuCT.Columns["ThanhTienCT"].DataPropertyName = "ThanhTien";
                    dgvTraCuuCT.DataSource = dataTable;
                }
                connection.Close();
            }
        }
    }
                        


            
}
 
