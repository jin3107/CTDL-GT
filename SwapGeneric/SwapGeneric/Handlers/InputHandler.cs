using System;

namespace SwapGeneric
{
    public static class InputHandler
    {
        public static int ReadInt(string message)
        {
            Console.Write(message);
            return int.Parse(Console.ReadLine());
        }

        public static double ReadDouble(string message)
        {
            Console.Write(message);
            return double.Parse(Console.ReadLine());
        }

        public static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}