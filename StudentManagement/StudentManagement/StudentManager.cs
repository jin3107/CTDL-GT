using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class StudentManager
    {
        public Student[] Students;

        public StudentManager(int N)
        {
            Students = new Student[N];
        }

        public void NhapTuBanPhim()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < Students.Length; i++)
            {
                Console.Write($"Nhập điểm sinh viên {i + 1} (M1, M2, M3): ");
                string[] nhap = Console.ReadLine().Split();
                Students[i] = new Student
                {
                    Id = i + 1,
                    M1 = int.Parse( nhap[0]),
                    M2 = int.Parse( nhap[1]),
                    M3 = int.Parse( nhap[2]),
                };
            }
        }

        public void NhapTuPhatSinh()
        {
            Random rand = new Random();
            for (int i = 0; i < Students.Length; i++)
            {
                Students[i] = new Student
                {
                    Id = i + 1,
                    M1 = rand.Next(0, 101),
                    M2 = rand.Next(0, 101),
                    M3 = rand.Next(0, 101)
                };
            }
        }

        public void NhapTuFile()
        {
            string[] lines = File.ReadAllLines("students.txt");
            for (int i = 0; i < Math.Min(Students.Length, lines.Length); i++)
            {
                string[] parts = lines[i].Split();
                Students[i] = new Student
                {
                    Id = int.Parse(parts[0]),
                    M1 = int.Parse(parts[1]),
                    M2 = int.Parse(parts[2]),
                    M3 = int.Parse(parts[3])
                };
            }
        }

        public void DauVaoNgauNhien()
        {
            Random rand = new Random();
            for (int i = 0; i < Students.Length; i++)
            {
                Students[i] = new Student
                {
                    Id = i + 1,
                    M1 = rand.Next(0, 101),
                    M2 = rand.Next(0, 101),
                    M3 = rand.Next(0, 101)
                };
            }
        }

        public double TinhDTB_C1()
        {
            double sum = 0;
            foreach (var student in Students)
                sum += student.Average;
            return sum / Students.Length;
        }

        public double TinhDTB_C2()
        {
            double sumM1 = 0, sumM2 = 0, sumM3 = 0;
            foreach (var student in Students)
            {
                sumM1 += student.M1;
                sumM2 += student.M2;
                sumM3 += student.M3;
            }
            return (sumM1 / Students.Length + sumM2 / Students.Length + sumM3 / Students.Length) / 3;
        }

        public void DoLuongHieuSuat()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Stopwatch sw = new Stopwatch();
            using (StreamWriter writer = new StreamWriter("performance.txt", true))
            {
                writer.WriteLine($"\nSố lượng sinh viên: {Students.Length}");

                sw.Start();
                double dtbC1 = TinhDTB_C1();
                sw.Stop();
                writer.WriteLine($"Cách 1: {sw.ElapsedMilliseconds} ms (DTB: {dtbC1:F2})");

                sw.Restart();
                double dtbC2 = TinhDTB_C2();
                sw.Stop();
                writer.WriteLine($"Cách 2: {sw.ElapsedMilliseconds} ms (DTB: {dtbC2:F2})");
            }

            Console.WriteLine("Kết quả đã được lưu vào 'performance.txt'");
        }
    }
}
