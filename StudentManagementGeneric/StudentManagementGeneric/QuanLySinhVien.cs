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
        private static readonly string DefaultFilePath = "students.txt";
        private static readonly Random rand = new Random();

        public static SinhVien[] NhapTuBanPhim(int n)
        {
            var ds = new SinhVien[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập thông tin SV {i + 1}:");
                try
                {
                    Console.Write("M1: ");
                    int m1 = int.Parse(Console.ReadLine());
                    Console.Write("M2: ");
                    int m2 = int.Parse(Console.ReadLine());
                    Console.Write("M3: ");
                    int m3 = int.Parse(Console.ReadLine());

                    ds[i] = new SinhVien(i + 1, m1, m2, m3);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                    i--;
                }
            }
            return ds;
        }

        public static SinhVien[] NhapTuFile(string filePath = null)
        {
            filePath = filePath ?? DefaultFilePath;
            try
            {
                if (!File.Exists(filePath))
                {
                    TaoFileMau(filePath);
                    Console.WriteLine($"Đã tạo file mẫu: {filePath}");
                }

                return File.ReadLines(filePath)
                    .Select((line, index) =>
                    {
                        var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 4)
                            throw new FormatException($"Dòng {index + 1} không đúng định dạng");
                        return new SinhVien(
                            int.Parse(parts[0]),
                            int.Parse(parts[1]),
                            int.Parse(parts[2]),
                            int.Parse(parts[3])
                        );
                    })
                    .ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return Array.Empty<SinhVien>();
            }
        }

        public static SinhVien[] NhapNgauNhien(int n)
        {
            return Enumerable.Range(1, n)
                .Select(i => new SinhVien(
                    i,
                    rand.Next(0, 101),
                    rand.Next(0, 101),
                    rand.Next(0, 101)
                )).ToArray();
        }

        private static void TaoFileMau(string filePath)
        {
            string[] mauDuLieu = 
            {
                "1 85 90 95",
                "2 75 80 85",
                "3 70 75 80",
                "4 90 85 80",
                "5 85 85 85",
                "6 95 90 85",
                "7 80 85 90",
                "8 75 80 85",
                "9 85 90 95",
                "10 90 85 80"
            };
            File.WriteAllLines(filePath, mauDuLieu);
        }

        public static void LuuDanhSach(SinhVien[] ds, string filePath)
        {
            try
            {
                var lines = ds.Select(sv => $"{sv.MaSV} {sv.M1} {sv.M2} {sv.M3}");
                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"Đã lưu danh sách vào file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu file: {ex.Message}");
            }
        }
    }
}
