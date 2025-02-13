using System;

namespace DisplayNums
{
    public static class NumberDisplay
    {
        public static void Display(long n)
        {
            int batchSize = 10000;
            char[] buffer = new char[batchSize * 6];
            int index = 0;
            for (long i = 1; i <= n; i++)
            {
                if (i.TryFormat(buffer.AsSpan(index), out int written))
                {
                    buffer[index + written] = ' ';
                    index += written + 1;
                }
                if (index >= buffer.Length - 6 || i == n)
                {
                    Console.Write(new string(buffer, 0, index));
                    index = 0;
                }
            }
            Console.WriteLine();
        }
    }
}
