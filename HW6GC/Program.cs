using HW6GC.Lib;
using System;
using static HW6GC.Lib.Shop;

namespace HW6GC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Task 1
            //StagePlay.Test();
            //GC.Collect();


            //Task 2
            //using (Shop shop = new("Silpo", ShopType.food, "Ukraine, Odesa city, vul. Zalyznychna, 3"))
            //{
            //    Console.WriteLine($"{shop.ToString()} is working.");
            //}
            //Console.WriteLine("-----");

            //Task 3
            using (StagePlay stage = new("To Kill a Mockingbird", "Harper Lee", PlayGenre.Drama, 1960))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(stage.ToString() + " in progress.");
            }


        }
    }
}