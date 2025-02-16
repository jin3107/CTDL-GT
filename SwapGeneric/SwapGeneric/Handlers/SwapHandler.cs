using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapGeneric
{
    public static class SwapHandler
    {
        public static void SwapIntegers()
        {
            int a = InputHandler.ReadInt("Nhập giá trị int a: ");
            int b = InputHandler.ReadInt("Nhập giá trị int b: ");
            Utils.Swap(ref a, ref b);
            Console.WriteLine($"Swapped int: a = {a}, b = {b}\n");
        }

        public static void SwapDoubles()
        {
            double x = InputHandler.ReadDouble("Nhập giá trị double x: ");
            double y = InputHandler.ReadDouble("Nhập giá trị double y: ");
            Utils.Swap(ref x, ref y);
            Console.WriteLine($"Swapped double: x = {x}, y = {y}\n");
        }

        public static void SwapStrings()
        {
            string s1 = InputHandler.ReadString("Nhập chuỗi s1: ");
            string s2 = InputHandler.ReadString("Nhập chuỗi s2: ");
            Utils.Swap(ref s1, ref s2);
            Console.WriteLine($"Swapped string: s1 = {s1}, s2 = {s2}\n");
        }

        public static void SwapNhanVien()
        {
            NhanVien nv1 = new NhanVien
            (
                InputHandler.ReadString("Nhập tên nhân viên 1: "),
                InputHandler.ReadInt("Nhập mã nhân viên 1: "),
                InputHandler.ReadDouble("Nhập hệ số lương nhân viên 1: ")
            );

            NhanVien nv2 = new NhanVien
            (
                InputHandler.ReadString("Nhập tên nhân viên 2: "),
                InputHandler.ReadInt("Nhập mã nhân viên 2: "),
                InputHandler.ReadDouble("Nhập hệ số lương nhân viên 2: ")
            );
            Utils.Swap(ref nv1, ref nv2);
            Console.WriteLine($"Swapped NhanVien:\n  NV1: {nv1}\n  NV2: {nv2}");
        }
    }
}