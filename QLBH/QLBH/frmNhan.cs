using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmNhan : Form
    {
        private int selectedRowIndex = -1;
        private string connectionString = "Server=PAOCHOUZ\\BAOCHAU; Database=QLBH; Integrated Security=True;";

        public frmNhan()
        {
            InitializeComponent();
            dateTimePicker_NgayNhan.Value = DateTime.Now;

            // Sự kiện
            checkBox_PTTTTienMat.CheckedChanged += checkBox_PTTTTienMat_CheckedChanged;
            checkBox_PTTTCKhoan.CheckedChanged += checkBox_PTTTCKhoan_CheckedChanged;
            dataGridView_HoadonNhap.CellClick += dataGridView_HoadonNhap_CellClick;

            // Tải dữ liệu từ SQL lên DataGridView
            LoadData();
        }
        private void dateTimePicker_NgayNhan_ValueChanged(object sender, EventArgs e)
        {

        }
        // 1️⃣ Tải dữ liệu từ SQL lên DataGridView
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT N.MaDDH, N.MaNV, N.MaNCC, CT.MaLH, CT.SoLuong, 
                               N.NgayNhan, 
                               FORMAT(N.NgayNhan, 'HH:mm:ss') AS ThoiGianNhan,
                               N.PTTT, N.TONGSL, N.TONGCONG
                        FROM NHAN N
                        JOIN CHITIET_NHAN CT ON N.MaDDH = CT.MaDDH";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView_HoadonNhap.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2️⃣ Phương thức chọn checkbox
        private void checkBox_PTTTTienMat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_PTTTTienMat.Checked) checkBox_PTTTCKhoan.Checked = false;
        }

        private void checkBox_PTTTCKhoan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_PTTTCKhoan.Checked) checkBox_PTTTTienMat.Checked = false;
        }

        // 3️⃣ Thêm mới vào SQL
        private void button_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_MaDDH.Text) ||
                string.IsNullOrWhiteSpace(textBox_MaNV.Text) ||
                string.IsNullOrWhiteSpace(textBox_MaNCC.Text) ||
                string.IsNullOrWhiteSpace(textBox_MaLH.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string pttt = checkBox_PTTTTienMat.Checked ? "Tiền mặt" : "Chuyển khoản";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Thêm vào bảng NHAN
                    string query1 = @"INSERT INTO NHAN (MaDDH, MaNV, MaNCC, NgayNhan, PTTT)
                                      VALUES (@MaDDH, @MaNV, @MaNCC, @NgayNhan, @PTTT)";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Parameters.AddWithValue("@MaDDH", textBox_MaDDH.Text);
                    command1.Parameters.AddWithValue("@MaNV", textBox_MaNV.Text);
                    command1.Parameters.AddWithValue("@MaNCC", textBox_MaNCC.Text);
                    command1.Parameters.AddWithValue("@NgayNhan", dateTimePicker_NgayNhan.Value);
                    command1.Parameters.AddWithValue("@PTTT", pttt);
                    command1.ExecuteNonQuery();

                    // Thêm vào bảng CHITIET_NHAN
                    string query2 = @"INSERT INTO CHITIET_NHAN (MaDDH, MaLH, SoLuong) VALUES (@MaDDH, @MaLH, @SoLuong)";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@MaDDH", textBox_MaDDH.Text);
                    command2.Parameters.AddWithValue("@MaLH", textBox_MaLH.Text);
                    command2.Parameters.AddWithValue("@SoLuong", numericUpDown_SoLuong.Value);
                    command2.ExecuteNonQuery();

                    string updateTongCong = @"
                    UPDATE NHAN
                    SET 
                        TONGSL = (SELECT SUM(SoLuong) FROM CHITIET_NHAN WHERE CHITIET_NHAN.MaDDH = NHAN.MaDDH),
                        TONGCONG = (SELECT SUM(SoLuong * GIANHAN)
                                    FROM CHITIET_NHAN CTN
                                    JOIN LOHANG LH ON CTN.MaLH = LH.MaLH
                                    WHERE CTN.MaDDH = NHAN.MaDDH)
                    WHERE MaDDH = @MaDDH";

                    SqlCommand cmd = new SqlCommand(updateTongCong, connection);
                    cmd.Parameters.AddWithValue("@MaDDH", textBox_MaDDH.Text);
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SelectRowByMaDDH(textBox_MaDDH.Text);
                    ClearForm();
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SelectRowByMaDDH(string maDDH)
        {
            foreach (DataGridViewRow row in dataGridView_HoadonNhap.Rows)
            {
                if (row.Cells["MaDDH"].Value != null && row.Cells["MaDDH"].Value.ToString() == maDDH)
                {
                    row.Selected = true;
                    dataGridView_HoadonNhap.CurrentCell = row.Cells[0];
                    dataGridView_HoadonNhap_CellClick(this, new DataGridViewCellEventArgs(0, row.Index));
                    break;
                }
            }
        }

        private void dataGridView_HoadonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_HoadonNhap.Rows[e.RowIndex];
                selectedRowIndex = e.RowIndex;

                string maDDH = row.Cells["MaDDH"].Value.ToString();
                textBox_MaDDH.Text = maDDH;
                textBox_MaNV.Text = row.Cells["MaNV"].Value.ToString();
                textBox_MaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                textBox_MaLH.Text = row.Cells["MaLH"].Value.ToString();
                dateTimePicker_NgayNhan.Value = DateTime.Parse(row.Cells["NgayNhan"].Value.ToString());
                if (row.Cells["SoLuong"].Value != null && decimal.TryParse(row.Cells["SoLuong"].Value.ToString(), out decimal sl))
                {
                    numericUpDown_SoLuong.Value = sl;
                }
                else
                {
                    numericUpDown_SoLuong.Value = 1; // hoặc giá trị mặc định nếu cần
                }
                string pttt = row.Cells["PTTT"].Value.ToString();
                checkBox_PTTTTienMat.Checked = pttt.Contains("Tiền mặt");
                checkBox_PTTTCKhoan.Checked = pttt.Contains("Chuyển khoản");

                // 🔽 Truy vấn thêm TONGSL và TONGCONG
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = @"SELECT TONGSL, TONGCONG FROM NHAN WHERE MaDDH = @MaDDH";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaDDH", maDDH);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            textBox_TongSL.Text = reader["TONGSL"].ToString();
                            textBox_TongCong.Text = string.Format("{0:N0} VND", reader["TONGCONG"]);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lấy tổng tiền: " + ex.Message);
                    }
                }
            }
        }

        // 4️⃣ Cập nhật thông tin
        private void button_Sua_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE NHAN 
                                     SET MaNV = @MaNV, MaNCC = @MaNCC, 
                                         NgayNhan = @NgayNhan, ThoiGianNhan = @ThoiGianNhan, PTTT = @PTTT 
                                     WHERE MaDDH = @MaDDH;

                                     UPDATE CHITIET_NHAN 
                                     SET MaLH = @MaLH, SoLuong = @SoLuong
                                     WHERE MaDDH = @MaDDH";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaDDH", textBox_MaDDH.Text);
                    command.Parameters.AddWithValue("@MaNV", textBox_MaNV.Text);
                    command.Parameters.AddWithValue("@MaNCC", textBox_MaNCC.Text);
                    command.Parameters.AddWithValue("@MaLH", textBox_MaLH.Text);
                    command.Parameters.AddWithValue("@SoLuong", numericUpDown_SoLuong.Value);
                    command.Parameters.AddWithValue("@NgayNhan", dateTimePicker_NgayNhan.Value);
                    command.Parameters.AddWithValue("@PTTT", checkBox_PTTTTienMat.Checked ? "Tiền mặt" : "Chuyển khoản");
                    command.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM NHAN WHERE MaDDH = @MaDDH";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaDDH", textBox_MaDDH.Text);
                    command.ExecuteNonQuery();
                }
                LoadData();
                ClearForm();
            }
        }
        private void ClearForm()
        {
            textBox_MaDDH.Clear();
            textBox_MaNV.Clear();
            textBox_MaNCC.Clear();
            textBox_MaLH.Clear();
            checkBox_PTTTTienMat.Checked = false;
            checkBox_PTTTCKhoan.Checked = false;
        }


    }
}
