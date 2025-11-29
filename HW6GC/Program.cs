using HW6GC.Lib;
using System;

namespace HW6GC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StagePlay.Test();
            GC.Collect();
            Console.ReadKey();
        }
    }
}