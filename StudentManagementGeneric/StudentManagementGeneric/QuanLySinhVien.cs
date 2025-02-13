using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementGeneric
{
    public class QuanLySinhVien
    {
        public static SinhVien[] NhapTuKhoa(int n)
        {
            SinhVien[] ds = new SinhVien[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập điểm SV {i + 1}: ");
                int m1 = int.Parse(Console.ReadLine());
                int m2 = int.Parse(Console.ReadLine());
                int m3 = int.Parse(Console.ReadLine());
                ds[i] = new SinhVien(i + 1, m1, m2, m3);
            }
            return ds;
        }

        public static SinhVien[] NhapKhoiTao(int n)
        {
            SinhVien[] ds = new SinhVien[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                ds[i] = new SinhVien(i + 1, rand.Next(0, 101), rand.Next(0, 101), rand.Next(0, 101));
            return ds;
        }

        public static SinhVien[] NhapTuFile(string filePath)
        {
            List<SinhVien> ds = new List<SinhVien>();
            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split();
                ds.Add(new SinhVien(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
            }
            return ds.ToArray();
        }

        public static SinhVien[] NhapNgauNhien(int n)
        {
            SinhVien[] ds = new SinhVien[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                ds[i] = new SinhVien(i + 1, rand.Next(0, 101), rand.Next(0, 101), rand.Next(0, 101));
            return ds;
        }
    }
}
