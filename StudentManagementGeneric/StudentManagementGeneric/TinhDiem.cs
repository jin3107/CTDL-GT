using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementGeneric
{
    public class TinhDiem
    {
        public static double TinhDTBCach1<T>(T ds) where T : IEnumerable<SinhVien>
        {
            return ds.Average(sv => sv.DTB);
        }

        public static double TinhDTBCach2<T>(T ds) where T : IEnumerable<SinhVien>
        {
            var avgScores = ds.Aggregate(
                new { M1 = 0.0, M2 = 0.0, M3 = 0.0, Count = 0 },
                (acc, sv) => new
                {
                    M1 = acc.M1 + sv.M1,
                    M2 = acc.M2 + sv.M2,
                    M3 = acc.M3 + sv.M3,
                    Count = acc.Count + 1
                });

            return (avgScores.M1 + avgScores.M2 + avgScores.M3) / (3.0 * avgScores.Count);
        }

        public static (long ThoiGian, double KetQua) DoThoiGian<T>(Func<T, double> func, T ds) where T : IEnumerable<SinhVien>
        {
            var sw = Stopwatch.StartNew();
            var ketQua = func(ds);
            sw.Stop();
            return (sw.ElapsedMilliseconds, ketQua);
        }

        public static void LuuKetQua(string filePath, string noiDung)
        {
            try
            {
                File.AppendAllText(filePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {noiDung}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu kết quả: {ex.Message}");
            }
        }
    }
}
