using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySuaChuaXeMay;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class frmDMPhuTung : Form
    {
        public frmDMPhuTung()
        {
            InitializeComponent();
        }

        private void DMPhuTung_Load(object sender, EventArgs e)
        {
            string sql = "select maPhuTung, tenPhuTung from PhuTung";
            DAO.FillDataToCombo(sql, cboMaPhuTung, "maPhuTung", "tenPhuTung");
        }

        
    }
}
