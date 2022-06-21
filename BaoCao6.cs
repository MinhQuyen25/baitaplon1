using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySuaChuaXeMay;

namespace BaiTapLon
{
    public partial class BaoCao6 : Form
    {
        DataTable tblSoLuong = new DataTable();
        public BaoCao6()
        {

            DAO.Connect();

            InitializeComponent();
        }



        private void BaoCao6_Load(object sender, EventArgs e)
        {
            cmbQuy.Items.Add("1");
            cmbQuy.Items.Add("2");
            cmbQuy.Items.Add("3");
            cmbQuy.Items.Add("4");
            btnIn.Enabled = false;
            btnThoat.Enabled = true;
            ResetValues();
            dgvBaoCao6.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtNam.Focus();
            cmbQuy.Focus();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            if (cmbQuy.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn quý", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbQuy.Focus();
                return;
            }

            if (txtNam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập năm", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNam.Focus();
                return;
            }
            if (tblSoLuong.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }

     

            string sql = "select top(3) maPhuTung, sum(soluong) 'tongsoluong'" + " from ChiTietHoaDonNhap join HoaDonNhapPhuTung on ChiTietHoaDonNhap.maHDN=HoaDonNhapPhuTung.maHDN where" + "(datepart(QQ, ngaynhap) = '" + cmbQuy.Text.Trim() + "') AND (YEAR(ngayxuat) = '" + txtNam.Text.Trim() + "') " + "group by maPhuTung , ngaynhap" + " order by tongsoluong desc " ;



            
            MessageBox.Show(sql);

            
            tblSoLuong = DAO.GetDataToTable(sql);
            dgvBaoCao6.DataSource = tblSoLuong;
              dgvBaoCao6.Columns[0].HeaderText = "Mã phụ tùng";
                dgvBaoCao6.Columns[1].HeaderText = "Số lượng";
                dgvBaoCao6.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBaoCao6.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBaoCao6.AllowUserToAddRows = false;
                dgvBaoCao6.EditMode = DataGridViewEditMode.EditProgrammatically;
                dgvBaoCao6.AllowUserToAddRows = false;
                dgvBaoCao6.EditMode = DataGridViewEditMode.EditProgrammatically;
            }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

    
