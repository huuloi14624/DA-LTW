using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_Loi
{
    internal class SinhVienBLL
    {
        SinhVienDAL con = new SinhVienDAL();
        public DataSet getData_hienthi()
        {
            string sql = "select * from SinhVien ";
            return con.getDuLieu(sql);
        }
        public void ThemDl(SinhVienGUI svObj)
        {
            string sql = "insert into SinhVien (MaSV, TenSV,Lop,Diem) values ('" + svObj.Ma + "',N'" + svObj.Ten + "','" + svObj.Lop + "','" + svObj.Diem + "')";
            con.ExecuteNonQuery(sql);
        }
        public void XoaDl(String masv)
        {
            string sql = "delete from SinhVien where MaSV ='" + masv + "'";
            con.ExecuteNonQuery(sql);
        }

        public void Suadl(SinhVienGUI svObj)
        {
            string sql = "UPDATE SinhVien SET TenSV = N'" + svObj.Ten + "', Lop = '" + svObj.Lop + "' ,Diem='" + svObj.Diem + "' WHERE MaSV = '" + svObj.Ma + "' ";
            con.ExecuteNonQuery(sql);
        }
        public bool Kiemtrakey(string chuoi)
        {
            string sql = "Select *from SinhVien where MaSV=N'" + chuoi + "' ";
            DataSet d = con.getDuLieu(sql);
            if (d.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        public DataSet Search(string chuoi)
        {
            string sql = "SELECT * FROM SinhVien WHERE MaSV LIKE N'%" + chuoi + "%' OR TenSV LIKE N'%" + chuoi + "%' OR Lop LIKE N'%" + chuoi + "%' OR Diem LIKE N'%" + chuoi + "%'";
            return con.getDuLieu(sql);
        }
    }
}
