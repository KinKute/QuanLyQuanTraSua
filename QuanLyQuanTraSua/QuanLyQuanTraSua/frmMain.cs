using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
			customizeDesign();
		}
		#region hàm mở form con
		private Form activeForm = null;

		private void btnDoiMatKhau_Click(object sender, EventArgs e)
		{
			openChildForm(new frmAccount());
		}

		private void openChildForm(Form childForm)
		{
			if (activeForm != null)
				activeForm.Close();
			activeForm = childForm;
			childForm.TopLevel = false;
			childForm.FormBorderStyle = FormBorderStyle.None;
			childForm.Dock = DockStyle.Fill;
			pnlChildForm.Controls.Add(childForm);
			pnlChildForm.Tag = childForm;
			pnlChildForm.BringToFront();
			childForm.Show();
		}
		private void customizeDesign()
		{
			// ẩn panel admin
			pnlAdmin.Visible = false;
			// ẩn panel nhân viên
			pnlNhanVien.Visible = false;
		}

		// ẩn panel nếu đang mở thì đóng
		private void hideMenu()
		{
			if (pnlNhanVien.Visible == true)
				pnlNhanVien.Visible = false;
			if (pnlAdmin.Visible == true)
				pnlAdmin.Visible = false;
		}

		// xem menu con và ẩn panel chức năng
		private void showSubMenu(Panel subMenu)
		{
			if (subMenu.Visible == false)
			{
				hideMenu();
				subMenu.Visible = true;
			}
			else
				subMenu.Visible = false;
		}
		#endregion

		private void btnDangXuat_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (MessageBox.Show("Bạn có đăng xuất ứng dụng hay không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK)
			{
				e.Cancel = true;
			}
		}
    }
}
