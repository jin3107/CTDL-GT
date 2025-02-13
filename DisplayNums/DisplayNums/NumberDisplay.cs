using System;
using System.Text;

namespace DisplayNums
{
    public static class NumberDisplay
    {
        public static void Display(long n)
        {
            int batchSize = 10000;
            StringBuilder sb = new StringBuilder(batchSize * 5);
            for (long i = 1; i <= n; i++)
            {
                sb.Append(i).Append(" ");
                if (i % batchSize == 0 || i == n)
                {
                    Console.Write(sb.ToString());
                    sb.Clear();
                }
            }
            Console.WriteLine();
        }
    }
}
