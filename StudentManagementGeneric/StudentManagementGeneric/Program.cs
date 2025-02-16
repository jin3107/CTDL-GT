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

            while (true)
            {
                Console.WriteLine("\n=== CHƯƠNG TRÌNH QUẢN LÝ ĐIỂM SINH VIÊN ===");
                Console.WriteLine("1. Nhập điểm từ bàn phím");
                Console.WriteLine("2. Đọc điểm từ file");
                Console.WriteLine("3. Tạo điểm ngẫu nhiên (test hiệu năng)");
                Console.WriteLine("4. Thoát");
                Console.Write("\nChọn chức năng (1-4): ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Vui lòng nhập số từ 1-4!");
                    continue;
                }

                if (choice == 4) break;

                SinhVien[] dsArray = null;
                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Nhập số lượng sinh viên: ");
                            int n = int.Parse(Console.ReadLine());
                            dsArray = QuanLySinhVien.NhapTuBanPhim(n);
                            break;
                        case 2:
                            Console.Write("Nhập đường dẫn file khác (Enter để dùng file mặc định): ");
                            string filePath = Console.ReadLine();
                            dsArray = QuanLySinhVien.NhapTuFile(string.IsNullOrWhiteSpace(filePath) ? null : filePath);
                            if (dsArray.Length == 0)
                            {
                                Console.WriteLine("Không thể đọc dữ liệu từ file!");
                                continue;
                            }
                            Console.WriteLine($"Đã đọc thành công {dsArray.Length} sinh viên từ file");
                            break;
                        case 3:
                            int[] testCases = { 100, 100_000, 1_000_000 };
                            foreach (int size in testCases)
                            {
                                Console.WriteLine($"\n🔹 Testing với {size:N0} sinh viên...");

                                Console.Write("Array: ");
                                dsArray = QuanLySinhVien.NhapNgauNhien(size);
                                var (t1C1, kq1C1) = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach1, dsArray);
                                var (t1C2, kq1C2) = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach2, dsArray);

                                Console.Write("List: ");
                                var dsList = new List<SinhVien>(dsArray);
                                var (t2C1, kq2C1) = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach1, dsList);
                                var (t2C2, kq2C2) = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach2, dsList);

                                var ketQua = new StringBuilder()
                                    .AppendLine($"Test với {size:N0} sinh viên:")
                                    .AppendLine($"Array - Cách 1: {t1C1}ms (DTB = {kq1C1:F2})")
                                    .AppendLine($"Array - Cách 2: {t1C2}ms (DTB = {kq1C2:F2})")
                                    .AppendLine($"List  - Cách 1: {t2C1}ms (DTB = {kq2C1:F2})")
                                    .AppendLine($"List  - Cách 2: {t2C2}ms (DTB = {kq2C2:F2})")
                                    .AppendLine();

                                TinhDiem.LuuKetQua(fileKetQua, ketQua.ToString());
                                Console.WriteLine($"✅ Đã lưu kết quả vào {fileKetQua}");
                            }
                            continue;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ!");
                            continue;
                    }

                    if (choice != 3 && dsArray != null)
                    {
                        var dsList = new List<SinhVien>(dsArray);
                        Console.WriteLine("\n=== KẾT QUẢ TÍNH ĐIỂM ===");

                        Console.WriteLine("\nSử dụng Array:");
                        var (timeArrayC1, resultArrayC1) = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach1, dsArray);
                        var (timeArrayC2, resultArrayC2) = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach2, dsArray);
                        Console.WriteLine($"Cách 1: {resultArrayC1:F2} (thời gian: {timeArrayC1}ms)");
                        Console.WriteLine($"Cách 2: {resultArrayC2:F2} (thời gian: {timeArrayC2}ms)");

                        Console.WriteLine("\nSử dụng List:");
                        var (timeListC1, resultListC1) = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach1, dsList);
                        var (timeListC2, resultListC2) = TinhDiem.DoThoiGian(TinhDiem.TinhDTBCach2, dsList);
                        Console.WriteLine($"Cách 1: {resultListC1:F2} (thời gian: {timeListC1}ms)");
                        Console.WriteLine($"Cách 2: {resultListC2:F2} (thời gian: {timeListC2}ms)");

                        var ketQua = new StringBuilder()
                            .AppendLine($"Test với dữ liệu {(choice == 1 ? "nhập từ bàn phím" : "đọc từ file")}:")
                            .AppendLine($"Số lượng sinh viên: {dsArray.Length}")
                            .AppendLine($"Array - Cách 1: {timeArrayC1}ms (DTB = {resultArrayC1:F2})")
                            .AppendLine($"Array - Cách 2: {timeArrayC2}ms (DTB = {resultArrayC2:F2})")
                            .AppendLine($"List  - Cách 1: {timeListC1}ms (DTB = {resultListC1:F2})")
                            .AppendLine($"List  - Cách 2: {timeListC2}ms (DTB = {resultListC2:F2})")
                            .AppendLine();
                        TinhDiem.LuuKetQua(fileKetQua, ketQua.ToString());
                        Console.WriteLine($"\n✅ Đã lưu kết quả vào {fileKetQua}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                }
            }
            Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
        }
    }
}
