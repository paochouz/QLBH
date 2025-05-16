namespace QLBH
{
    partial class frmMain
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
            menuStrip1 = new MenuStrip();
            QuanLyDonNhanToolStripMenuItem = new ToolStripMenuItem();
            QuanLyTraNoToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { QuanLyDonNhanToolStripMenuItem, QuanLyTraNoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1138, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // QuanLyDonNhanToolStripMenuItem
            // 
            QuanLyDonNhanToolStripMenuItem.Name = "QuanLyDonNhanToolStripMenuItem";
            QuanLyDonNhanToolStripMenuItem.Size = new Size(176, 29);
            QuanLyDonNhanToolStripMenuItem.Text = "Quản Lý Đơn Nhận";
            QuanLyDonNhanToolStripMenuItem.Click += QuanLyDonNhanToolStripMenuItem_Click;
            // 
            // QuanLyTraNoToolStripMenuItem
            // 
            QuanLyTraNoToolStripMenuItem.Name = "QuanLyTraNoToolStripMenuItem";
            QuanLyTraNoToolStripMenuItem.Size = new Size(146, 29);
            QuanLyTraNoToolStripMenuItem.Text = "Quản Lý Trả Nợ";
            QuanLyTraNoToolStripMenuItem.Click += QuanLyTraNoToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 668);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            Text = "frmMain";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem QuanLyDonNhanToolStripMenuItem;
        private ToolStripMenuItem QuanLyTraNoToolStripMenuItem;
    }
}