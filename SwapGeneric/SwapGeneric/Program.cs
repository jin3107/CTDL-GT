using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            SwapHandler.SwapIntegers();
            SwapHandler.SwapDoubles();
            SwapHandler.SwapStrings();
            SwapHandler.SwapNhanVien();
        }
    }
}
