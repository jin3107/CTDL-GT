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
        public static double TinhDTBCach1(SinhVien[] ds)
        {
            double tong = 0;
            foreach (var sv in ds)
                tong += sv.DTB;
            return tong / ds.Length;
        }

        public static double TinhDTBCach2(SinhVien[] ds)
        {
            double tongM1 = 0, tongM2 = 0, tongM3 = 0;
            foreach (var sv in ds)
            {
                tongM1 += sv.M1;
                tongM2 += sv.M2;
                tongM3 += sv.M3;
            }
            return (tongM1 + tongM2 + tongM3) / (3.0 * ds.Length);
        }

        public static long DoThoiGian(Func<SinhVien[], double> func, SinhVien[] ds)
        {
            Stopwatch sw = Stopwatch.StartNew();
            func(ds);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static void LuuKetQua(string filePath, string noiDung)
        {
            File.AppendAllText(filePath, noiDung + Environment.NewLine);
        }
    }
}
