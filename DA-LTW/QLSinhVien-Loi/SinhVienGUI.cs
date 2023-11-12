using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien_Loi
{
    internal class SinhVienGUI
    {
        string masv, tensv, lop, diem;
        public SinhVienGUI(string ma, string ten, string l, string di)
        {
            masv = ma;
            tensv = ten;
            lop = l;
            diem = di;
        }
        public string Ma
        {
            get { return masv; }
            set { masv = value; }
        }
        public string Ten
        { get { return tensv; } set { tensv = value; } }
        public string Lop
        {
            get { return lop; }
            set { lop = value; }
        }
        public string Diem
        {
            get { return diem; }
            set { diem = value; }
        }
    }
}
