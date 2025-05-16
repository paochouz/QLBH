using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void QuanLyDonNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhan nhan = new frmNhan();
            nhan.MdiParent = this;
            nhan.Show();
        }

        private void QuanLyTraNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTraNo traNo = new frmTraNo();
            traNo.MdiParent = this;
            traNo.Show();
        }
    }
}
