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

        private int ValidateScore(int score)
        {
            if (score < 0 || score > 100)
                throw new ArgumentException("Điểm phải nằm trong khoảng 0-100");
            return score;
        }

        public double DTB => (M1 + M2 + M3) / 3.0;

        public SinhVien(int maSV, int m1, int m2, int m3)
        {
            MaSV = maSV;
            M1 = ValidateScore(m1);
            M2 = ValidateScore(m2);
            M3 = ValidateScore(m3);
        }

        public override string ToString()
        {
            return $"SV{MaSV:D4}: M1={M1}, M2={M2}, M3={M3}, DTB={DTB:F2}";
        }
    }
}
