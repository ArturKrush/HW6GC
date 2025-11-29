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
            //Тестування деструктора класу StagePlay
            StagePlay.Test();
            GC.Collect();
            GC.WaitForPendingFinalizers(); //Без цього програма іноді ломається

            //Task 2
            //За областю видимості using викликається метод Dispose()
            using (Shop shop = new("Silpo", ShopType.food, "Ukraine, Odesa city, vul. Zalyznychna, 3"))
            {
                Console.WriteLine($"{shop.ToString()} is working.");
            }
            Console.WriteLine("-----");

            //Task 3
            using (StagePlay stage = new("To Kill a Mockingbird", "Harper Lee", PlayGenre.Drama, 1960))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(stage.ToString() + " in progress.");
            }

            //Тестування деструктора для класу Shop
            Shop.Test();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}