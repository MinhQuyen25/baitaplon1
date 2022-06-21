using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLySuaChuaXeMay
{
    internal class DAO
    {

        private static string Connstring;

        public static SqlConnection con;

        public static void Connect()
        {
            try
            {
                Connstring = "Data Source = DESKTOP-EH2F7BB\\SQLEXPRESS;" +
                             "Initial Catalog=quanlyxemay;" +
                             "Integrated Security=True";
                con = new SqlConnection();
                con.ConnectionString = Connstring;
                con.Open();
                MessageBox.Show("Ket noi thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static void Close()
        {

            if (con.State == ConnectionState.Open)
            {

                con.Close();
                con.Dispose();

                con = null;
            }
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter();	// Khai báo
            // Tạo đối tượng Command thực hiện câu lệnh SELECT        
            Mydata.SelectCommand = new SqlCommand();
            Mydata.SelectCommand.Connection = DAO.con; 	// Kết nối CSDL
            Mydata.SelectCommand.CommandText = sql;	// Gán câu lệnh SELECT
            DataTable table = new DataTable();    // Khai báo DataTable nhận dữ liệu trả về
            Mydata.Fill(table); 	//Thực hiện câu lệnh SELECT và đổ dữ liệu vào bảng table
            return table;
        }

        public static void RunSql(string sql)
        {
            SqlCommand cmd;		                // Khai báo đối tượng SqlCommand
            cmd = new SqlCommand();	         // Khởi tạo đối tượng
            cmd.Connection = DAO.con;	  // Gán kết nối
            cmd.CommandText = sql;			  // Gán câu lệnh SQL
            try
            {
                cmd.ExecuteNonQuery();		  // Thực hiện câu lệnh SQL
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }




        public static bool CheckKey(string sql)
        {
            SqlCommand myCommand = new SqlCommand(sql, con);
            SqlDataReader myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
                return true;
            else
                return false;
        }
        public static DataTable LoadDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }
        public static bool CheckKeyExit(string sql)
        {
            SqlCommand mycommand = new SqlCommand(sql, con);
            SqlDataReader myReader = mycommand.ExecuteReader();


            if (myReader.HasRows)
                return true;
            else
                return false;
        }
        public static void FillDataToCombo(string sql, ComboBox cmb, string maNCC, string tenNCC)
        {
            
            SqlDataAdapter myadapter = new SqlDataAdapter(sql, con);
            DataTable mytable = new DataTable();
            myadapter.Fill(mytable);
            cmb.DataSource = mytable;
            cmb.ValueMember = maNCC;
            cmb.DisplayMember = tenNCC;
            



        }
        public static void FillDataToGridView(string sql, DataGridView dgv, string maphutung, string tenphutung, int soluong, int dongianhap, int dongiaban)

        {
            //do du lieu vao combobox
            SqlDataAdapter myadapter1 = new SqlDataAdapter(sql, con);
            DataTable mytable = new DataTable();
            myadapter1.Fill(mytable);
            dgv.DataSource = mytable;


        }
    }
}

    

       

    

