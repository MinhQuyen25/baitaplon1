using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHD.Enabled = true;
            txtMaHD.Focus();
            cboMaNhanVien.Enabled = true;
            cboMaNhanVien.Focus();

        }
        //thu tuc reset values
        

            private void ResetValues()
            {
            txtMaHD.Text = "";
            cboMaNhanVien.Text = "";
            }
        }
    }

