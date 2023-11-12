using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhVien_Loi
{
    public partial class frmMain : Form
    {
        bool flag = true;
        SinhVienBLL svl = new SinhVienBLL();
        string imagePath;

        public frmMain()
        {
            InitializeComponent();
            txtDiem.KeyPress += txtDiem_KeyPress;
            pictureBox.Click += pictureBox_Click;
        }
        void Dieukhien(bool b)
        {
            btnThem.Enabled = b;
            btnSua.Enabled = b;
            btnXoa.Enabled = b;
            btnHuy.Enabled = !b;
            btnLuu.Enabled = !b;
            dataGridSinhVien.Enabled = b;
            txtMaSV.ReadOnly = b;
            txtTenSV.ReadOnly = b;
            txtLop.ReadOnly = b;
            txtDiem.ReadOnly = b;

        }
        void Xoadl()
        {
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            txtLop.Text = "";
            txtDiem.Text = "";
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            DataSet ds = svl.getData_hienthi();
            dataGridSinhVien.DataSource = ds.Tables[0];
            Dieukhien(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = true;
            Xoadl();
            Dieukhien(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = false;
            Dieukhien(false);
            dataGridSinhVien.Enabled = true;
            txtMaSV.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
                svl.XoaDl(txtMaSV.Text);
                DataSet ds = svl.getData_hienthi();
                dataGridSinhVien.DataSource = ds.Tables[0];
                MessageBox.Show("Xoá thành công");
                if (dataGridSinhVien.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn sinh viên nào để xóa");
                    return;
                }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Equals("") || txtTenSV.Text == "" || txtLop.Text == "" || txtDiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (flag)
            {
                if (svl.Kiemtrakey(txtMaSV.Text))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại");
                    return;
                }

                SinhVienGUI dmo = new SinhVienGUI(txtMaSV.Text, txtTenSV.Text, txtLop.Text, txtDiem.Text);
                svl.ThemDl(dmo);
                DataSet ds = svl.getData_hienthi();
                dataGridSinhVien.DataSource = ds.Tables[0];
                MessageBox.Show("Thêm thành công");

            }
            else
            {
                SinhVienGUI dmo = new SinhVienGUI(txtMaSV.Text, txtTenSV.Text, txtLop.Text, txtDiem.Text);
                svl.Suadl(dmo);
                DataSet ds = svl.getData_hienthi();
                dataGridSinhVien.DataSource = ds.Tables[0];
                MessageBox.Show("Sửa thành công");
            }
            Dieukhien(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Xoadl();
            Dieukhien(true);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = svl.Search(txtTimKiem.Text);
            dataGridSinhVien.DataSource = ds.Tables[0];
        }

        private void dataGridSinhVien_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridSinhVien.CurrentCell.RowIndex;
                txtMaSV.Text = dataGridSinhVien[0, i].Value.ToString();
                txtTenSV.Text = dataGridSinhVien[1, i].Value.ToString();
                txtLop.Text = dataGridSinhVien[2, i].Value.ToString();
                txtDiem.Text = dataGridSinhVien[3, i].Value.ToString();
            }
            catch
            {

            }
        }
        private void txtDiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtTenSV_TextChanged(object sender, EventArgs e)
        {
            string input = txtTenSV.Text;
            string result = "";

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    result += c;
                }
            }

            txtTenSV.Text = result;
            txtTenSV.SelectionStart = result.Length;

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.jpeg, *.gif, *.bmp) | *.jpg; *.png; *.jpeg; *.gif; *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                pictureBox.Image = Image.FromFile(imagePath);
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.jpeg, *.gif, *.bmp) | *.jpg; *.png; *.jpeg; *.gif; *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox.Image = Image.FromFile(imagePath);
            }
        }
    }
}
