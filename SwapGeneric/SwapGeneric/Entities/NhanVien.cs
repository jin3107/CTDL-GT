using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapGeneric
{
    public struct NhanVien
    {
        public string HoTen;
        public int MaNhanVien;
        public double HeSoLuong;

        public NhanVien(string hoTen, int maNhanVien, double heSoLuong)
        {
            HoTen = hoTen;
            MaNhanVien = maNhanVien;
            HeSoLuong = heSoLuong;
        }

        public override string ToString()
        {
            return $"{MaNhanVien} - {HoTen} - HSL: {HeSoLuong}";
        }
    }
}
