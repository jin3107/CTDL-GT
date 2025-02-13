using System;
using System.Text;

namespace StudentManagement
{
    class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập số lượng sinh viên: ");
            int N = int.Parse(Console.ReadLine());
            StudentManager manager = new StudentManager(N);

            Console.WriteLine("\nChọn cách nhập điểm:");
            Console.WriteLine("1. Nhập từ bàn phím");
            Console.WriteLine("2. Khởi tạo sẵn");
            Console.WriteLine("3. Đọc từ file");
            Console.WriteLine("4. Phát sinh ngẫu nhiên");
            Console.Write("Lựa chọn: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: manager.NhapTuBanPhim(); break;
                case 2: manager.NhapTuPhatSinh(); break;
                case 3: manager.NhapTuFile(); break;
                case 4: manager.DauVaoNgauNhien(); break;
                default: Console.WriteLine("Lựa chọn không hợp lệ!"); return;
            }

            manager.DoLuongHieuSuat();
        }
    }
}
