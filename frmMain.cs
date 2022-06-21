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
using System.Windows;

namespace BaiTapLon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DAO.Connect();
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void báoCáo6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCao6 baocao = new BaoCao6();
            baocao.Show();
        }

       
    }
    }

