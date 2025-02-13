using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementGeneric
{
    class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string fileKetQua = "ketqua.txt";
            int[] testCases = { 100, 100000 };
            foreach (int n in testCases)
            {
                Console.WriteLine($"🔹 Đang kiểm tra với {n} sinh viên...");

                // 1. Dùng Array
                SinhVien[] ds1 = QuanLySinhVien.NhapNgauNhien(n);
                long t1C1 = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach1, ds1);
                long t1C2 = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach2, ds1);
                TinhDiem.LuuKetQua(fileKetQua, $"Array - {n} SV: C1 = {t1C1}ms, C2 = {t1C2}ms");

                // 2. Dùng List
                var ds2 = new List<SinhVien>(ds1);
                long t2C1 = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach1, ds2.ToArray());
                long t2C2 = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach2, ds2.ToArray());
                TinhDiem.LuuKetQua(fileKetQua, $"List - {n} SV: C1 = {t2C1}ms, C2 = {t2C2}ms\n");

                Console.WriteLine($"✅ Kết quả lưu vào {fileKetQua}\n");
            }
        }
    }
}
