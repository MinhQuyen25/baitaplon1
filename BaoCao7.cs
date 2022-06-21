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
    public partial class BaoCao7 : Form
    {
        DataTable tblNhap = new DataTable();
        public BaoCao7()
        {
            InitializeComponent();
        }

        private void BaoCao7_Load(object sender, EventArgs e)
        {
            DAO.Connect();
            string sql = "select maNCC, tenNCC from NhaCungCap";
            DAO.FillDataToCombo(sql, cmbMaNCC, "maNCC", "tenNCC");
            btnHienThi.Enabled = true;
            btnIn.Enabled = false;
            btnTimLai.Enabled = true;
            btnThoat.Enabled = true;
            ResetValues();
        }
        private void ResetValues()
        {
            cmbMaNCC.Items.Clear();
        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select top(5) HoaDonNhapPhuTung.maHDN , ngaynhap, maNCC , tenNCC, maNhanVien , tongtien " +
                "from ((HoaDonNhapPhuTung join NhaCungCap on HoaDonNhapPhuTung.maNCC = NhaCungCap.maNCC ) join NhanVien on HoaDonNhapPhuTung.maNhanVien = NhanVien.maNhanVien) " +
                "WHERE NhaCungCap.maNCC = '" + cmbMaNCC.SelectedValue + 
                "' group by mahoadon, ngaynhap, maNCC, tenNCC, tongtien order by tongtien desc";
            
            

            if (cmbMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn mã nhà cung cấp", "Thông Báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaNCC.Focus();
                return;
            }
            if (cmbMaNCC.Text != "")
            {
                dgvBaoCao7.DataSource = tblNhap;
                
                btnIn.Enabled = true;

            }
            else if (tblNhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btnTimLai.Enabled = true;
            btnThoat.Enabled = true;

            tblNhap = DAO.GetDataToTable(sql);
            dgvBaoCao7.DataSource = tblNhap;
            dgvBaoCao7.Columns[0].HeaderText = "Mã sách";
            dgvBaoCao7.Columns[1].HeaderText = "Tên sách";
            dgvBaoCao7.Columns[2].HeaderText = "Tình trạng";
            dgvBaoCao7.Columns[3].HeaderText = "Ngày mượn";

            dgvBaoCao7.Columns[4].HeaderText = "Tên tác giả";

        }

        
    }
}

        