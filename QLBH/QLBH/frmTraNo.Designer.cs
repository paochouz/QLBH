namespace QLBH
{
    partial class frmTraNo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox_MaNCC = new TextBox();
            textBox_TongTienTra = new TextBox();
            dateTimePicker_NgayTra = new DateTimePicker();
            checkBox_DaTraHet = new CheckBox();
            checkBox_TraMotPhan = new CheckBox();
            checkBox_ChuaTra = new CheckBox();
            button_Them = new Button();
            button_Xoa = new Button();
            button_Sua = new Button();
            dataGridView_TraNo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView_TraNo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(286, 9);
            label1.Name = "label1";
            label1.Size = new Size(252, 38);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ TRẢ NỢ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(61, 68);
            label2.Name = "label2";
            label2.Size = new Size(87, 28);
            label2.TabIndex = 1;
            label2.Text = "Mã NCC";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(61, 211);
            label3.Name = "label3";
            label3.Size = new Size(147, 28);
            label3.TabIndex = 2;
            label3.Text = "Trạng Thái Trả";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(61, 163);
            label4.Name = "label4";
            label4.Size = new Size(97, 28);
            label4.TabIndex = 3;
            label4.Text = "Ngày Trả";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(61, 117);
            label5.Name = "label5";
            label5.Size = new Size(142, 28);
            label5.TabIndex = 4;
            label5.Text = "Tổng Tiền Trả";
            // 
            // textBox_MaNCC
            // 
            textBox_MaNCC.Location = new Point(273, 65);
            textBox_MaNCC.Name = "textBox_MaNCC";
            textBox_MaNCC.Size = new Size(336, 31);
            textBox_MaNCC.TabIndex = 5;
            textBox_MaNCC.TextChanged += textBox_MaNCC_TextChanged;
            // 
            // textBox_TongTienTra
            // 
            textBox_TongTienTra.Location = new Point(273, 117);
            textBox_TongTienTra.Name = "textBox_TongTienTra";
            textBox_TongTienTra.Size = new Size(336, 31);
            textBox_TongTienTra.TabIndex = 6;
            textBox_TongTienTra.TextChanged += textBox_TongTienTra_TextChanged;
            // 
            // dateTimePicker_NgayTra
            // 
            dateTimePicker_NgayTra.Format = DateTimePickerFormat.Short;
            dateTimePicker_NgayTra.Location = new Point(273, 163);
            dateTimePicker_NgayTra.Name = "dateTimePicker_NgayTra";
            dateTimePicker_NgayTra.Size = new Size(147, 31);
            dateTimePicker_NgayTra.TabIndex = 7;
            // 
            // checkBox_DaTraHet
            // 
            checkBox_DaTraHet.AutoSize = true;
            checkBox_DaTraHet.Location = new Point(273, 213);
            checkBox_DaTraHet.Name = "checkBox_DaTraHet";
            checkBox_DaTraHet.Size = new Size(116, 29);
            checkBox_DaTraHet.TabIndex = 8;
            checkBox_DaTraHet.Text = "Đã Trả Hết";
            checkBox_DaTraHet.UseVisualStyleBackColor = true;
            checkBox_DaTraHet.CheckedChanged += checkBox_DaTraHet_CheckedChanged;
            // 
            // checkBox_TraMotPhan
            // 
            checkBox_TraMotPhan.AutoSize = true;
            checkBox_TraMotPhan.Location = new Point(422, 213);
            checkBox_TraMotPhan.Name = "checkBox_TraMotPhan";
            checkBox_TraMotPhan.Size = new Size(138, 29);
            checkBox_TraMotPhan.TabIndex = 9;
            checkBox_TraMotPhan.Text = "Trả Một Phần";
            checkBox_TraMotPhan.UseVisualStyleBackColor = true;
            checkBox_TraMotPhan.CheckedChanged += checkBox_TraMotPhan_CheckedChanged;
            // 
            // checkBox_ChuaTra
            // 
            checkBox_ChuaTra.AutoSize = true;
            checkBox_ChuaTra.Location = new Point(587, 213);
            checkBox_ChuaTra.Name = "checkBox_ChuaTra";
            checkBox_ChuaTra.Size = new Size(102, 29);
            checkBox_ChuaTra.TabIndex = 10;
            checkBox_ChuaTra.Text = "Chưa Trả";
            checkBox_ChuaTra.UseVisualStyleBackColor = true;
            checkBox_ChuaTra.CheckedChanged += checkBox_ChuaTra_CheckedChanged;
            // 
            // button_Them
            // 
            button_Them.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Them.Location = new Point(99, 273);
            button_Them.Name = "button_Them";
            button_Them.Size = new Size(104, 45);
            button_Them.TabIndex = 11;
            button_Them.Text = "Thêm";
            button_Them.UseVisualStyleBackColor = true;
            button_Them.Click += button_Them_Click;
            // 
            // button_Xoa
            // 
            button_Xoa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Xoa.Location = new Point(535, 273);
            button_Xoa.Name = "button_Xoa";
            button_Xoa.Size = new Size(104, 45);
            button_Xoa.TabIndex = 12;
            button_Xoa.Text = "Xóa";
            button_Xoa.UseVisualStyleBackColor = true;
            button_Xoa.Click += button_Xoa_Click;
            // 
            // button_Sua
            // 
            button_Sua.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Sua.Location = new Point(316, 273);
            button_Sua.Name = "button_Sua";
            button_Sua.Size = new Size(104, 45);
            button_Sua.TabIndex = 13;
            button_Sua.Text = "Sửa";
            button_Sua.UseVisualStyleBackColor = true;
            button_Sua.Click += button_Sua_Click;
            // 
            // dataGridView_TraNo
            // 
            dataGridView_TraNo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_TraNo.Location = new Point(30, 345);
            dataGridView_TraNo.Name = "dataGridView_TraNo";
            dataGridView_TraNo.RowHeadersWidth = 51;
            dataGridView_TraNo.Size = new Size(741, 192);
            dataGridView_TraNo.TabIndex = 14;
            dataGridView_TraNo.CellContentClick += dataGridView_TraNo_CellContentClick;
            // 
            // frmTraNo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 561);
            Controls.Add(dataGridView_TraNo);
            Controls.Add(button_Sua);
            Controls.Add(button_Xoa);
            Controls.Add(button_Them);
            Controls.Add(checkBox_ChuaTra);
            Controls.Add(checkBox_TraMotPhan);
            Controls.Add(checkBox_DaTraHet);
            Controls.Add(dateTimePicker_NgayTra);
            Controls.Add(textBox_TongTienTra);
            Controls.Add(textBox_MaNCC);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmTraNo";
            Text = "frmTraNo";
            ((System.ComponentModel.ISupportInitialize)dataGridView_TraNo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox_MaNCC;
        private TextBox textBox_TongTienTra;
        private DateTimePicker dateTimePicker_NgayTra;
        private CheckBox checkBox_DaTraHet;
        private CheckBox checkBox_TraMotPhan;
        private CheckBox checkBox_ChuaTra;
        private Button button_Them;
        private Button button_Xoa;
        private Button button_Sua;
        private DataGridView dataGridView_TraNo;
    }
}