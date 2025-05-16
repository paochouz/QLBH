using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmTraNo : Form
    {
        private int selectedRowIndex = -1;
        private bool isUpdatingCheckBox = false;
        private string connectionString = "Server=PAOCHOUZ\\BAOCHAU; Database=QLBH; Integrated Security=True;";
        SqlDataAdapter adapter;
        DataTable dt;

        public frmTraNo()
        {
            InitializeComponent();
            checkBox_DaTraHet.CheckedChanged += checkBox_DaTraHet_CheckedChanged;
            checkBox_TraMotPhan.CheckedChanged += checkBox_TraMotPhan_CheckedChanged;
            checkBox_ChuaTra.CheckedChanged += checkBox_ChuaTra_CheckedChanged;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    adapter = new SqlDataAdapter("SELECT * FROM TRANO", connection);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView_TraNo.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(textBox_MaNCC.Text) ||
                string.IsNullOrWhiteSpace(textBox_TongTienTra.Text) ||
                string.IsNullOrWhiteSpace(dateTimePicker_NgayTra.Text) ||
                string.IsNullOrWhiteSpace(checkBox_DaTraHet.Checked ? "Đã trả hết" : (checkBox_TraMotPhan.Checked ? "Trả một phần" : "Chưa trả")))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return false;
            }

            if (!DateTime.TryParse(dateTimePicker_NgayTra.Text, out DateTime ngayTra))
            {
                MessageBox.Show("Định dạng ngày không hợp lệ.");
                return false;
            }

            if (ngayTra >= DateTime.Now)
            {
                MessageBox.Show("Ngày trả phải nhỏ hơn ngày hiện tại.");
                return false;
            }

            return true;
        }
        private void checkBox_DaTraHet_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingCheckBox) return;

            if (checkBox_DaTraHet.Checked)
            {
                isUpdatingCheckBox = true;
                checkBox_TraMotPhan.Checked = false;
                checkBox_ChuaTra.Checked = false;
                isUpdatingCheckBox = false;
            }
        }

        private void checkBox_TraMotPhan_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingCheckBox) return;

            if (checkBox_TraMotPhan.Checked)
            {
                isUpdatingCheckBox = true;
                checkBox_DaTraHet.Checked = false;
                checkBox_ChuaTra.Checked = false;
                isUpdatingCheckBox = false;
            }
        }

        private void checkBox_ChuaTra_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingCheckBox) return;

            if (checkBox_ChuaTra.Checked)
            {
                isUpdatingCheckBox = true;
                checkBox_DaTraHet.Checked = false;
                checkBox_TraMotPhan.Checked = false;
                isUpdatingCheckBox = false;
            }
        }
        private void textBox_MaNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_TongTienTra_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO TRANO (MANCC, TONGTIEN_TRA, NGAYTRA, TRANGTHAI_TRA) 
                                     VALUES (@MANCC, @TONGTIEN_TRA, @NGAYTRA, @TRANGTHAI_TRA)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MANCC", textBox_MaNCC.Text);
                    string rawTien = textBox_TongTienTra.Text.Replace("VND", "").Replace(",", "").Trim();
                    if (!decimal.TryParse(rawTien, out decimal tongTienTra))
                    {
                        MessageBox.Show("Tổng tiền trả không hợp lệ.");
                        return;
                    }
                    command.Parameters.AddWithValue("@TONGTIEN_TRA", tongTienTra);

                    command.Parameters.AddWithValue("@NGAYTRA", DateTime.Parse(dateTimePicker_NgayTra.Text));
                    command.Parameters.AddWithValue("@TRANGTHAI_TRA", checkBox_DaTraHet.Checked ? "Đã trả hết" : (checkBox_TraMotPhan.Checked ? "Trả một phần" : "Chưa trả"));

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm mới thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}");
            }
        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE TRANO 
                                     SET TONGTIEN_TRA = @TONGTIEN_TRA, NGAYTRA = @NGAYTRA, TRANGTHAI_TRA = @TRANGTHAI_TRA
                                     WHERE MANCC = @MANCC";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MANCC", textBox_MaNCC.Text);
                    string rawTien = textBox_TongTienTra.Text.Replace("VND", "").Replace(",", "").Trim();
                    if (!decimal.TryParse(rawTien, out decimal tongTienTra))
                    {
                        MessageBox.Show("Tổng tiền trả không hợp lệ.");
                        return;
                    }
                    command.Parameters.AddWithValue("@TONGTIEN_TRA", tongTienTra);

                    command.Parameters.AddWithValue("@NGAYTRA", DateTime.Parse(dateTimePicker_NgayTra.Text));
                    command.Parameters.AddWithValue("@TRANGTHAI_TRA", checkBox_DaTraHet.Checked ? "Đã trả hết" : (checkBox_TraMotPhan.Checked ? "Trả một phần" : "Chưa trả"));

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}");
            }
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0 && MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM TRANO WHERE MANCC = @MANCC";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MANCC", textBox_MaNCC.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}");
                }
            }
        }

        private void dataGridView_TraNo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_TraNo.Rows[e.RowIndex];
                selectedRowIndex = e.RowIndex;

                textBox_MaNCC.Text = row.Cells["MANCC"].Value.ToString();
                if (decimal.TryParse(row.Cells["TONGTIEN_TRA"].Value.ToString(), out decimal tongTien))
                {
                    textBox_TongTienTra.Text = string.Format("{0:N0} VND", tongTien);
                }
                else
                {
                    textBox_TongTienTra.Text = row.Cells["TONGTIEN_TRA"].Value.ToString();
                }

                dateTimePicker_NgayTra.Text = row.Cells["NGAYTRA"].Value.ToString();

                // Lấy giá trị trạng thái trả từ DataGridView
                string trangThaiTra = row.Cells["TRANGTHAI_TRA"].Value.ToString();

                // Cập nhật vào các checkbox dựa trên giá trị lấy được
                if (trangThaiTra == "Đã trả hết")
                {
                    checkBox_DaTraHet.Checked = true;
                    checkBox_TraMotPhan.Checked = false;
                    checkBox_ChuaTra.Checked = false;
                }
                else if (trangThaiTra == "Trả một phần")
                {
                    checkBox_DaTraHet.Checked = false;
                    checkBox_TraMotPhan.Checked = true;
                    checkBox_ChuaTra.Checked = false;
                }
                else
                {
                    checkBox_ChuaTra.Checked = true;
                    checkBox_DaTraHet.Checked = false;
                    checkBox_TraMotPhan.Checked = false;
                }
            }
        }

    }
}
