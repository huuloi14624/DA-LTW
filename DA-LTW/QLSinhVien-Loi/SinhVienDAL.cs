using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_Loi
{
    internal class SinhVienDAL
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataAdapter dataadap;
        public string strConn = @"Data Source=DESKTOP-CV4E30L\HUULOI;Initial Catalog=QLSinhVien;Integrated Security=True";
        public DataSet getDuLieu(string sql)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                dataadap = new SqlDataAdapter(sql, conn);
                DataSet d = new DataSet();
                dataadap.Fill(d, sql);
                conn.Close();
                return d;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void ExecuteNonQuery(string sql)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                command.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
