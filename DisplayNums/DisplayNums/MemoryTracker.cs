using System;

namespace DisplayNums
{
    public static class MemoryTracker
    {
        public static long GetMemoryUsage()
        {
            return GC.GetTotalMemory(true);
        }
    }
}
