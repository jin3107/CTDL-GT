using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementGeneric
{
    public class SinhVien
    {
        public int MaSV { get; set; }
        public int M1 { get; set; }
        public int M2 { get; set; }
        public int M3 { get; set; }
        public double DTB => (M1 + M2 + M3) / 3.0;

        public SinhVien(int maSV, int m1, int m2, int m3)
        {
            MaSV = maSV;
            M1 = m1;
            M2 = m2;
            M3 = m3;
        }
    }
}
