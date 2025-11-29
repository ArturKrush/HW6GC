using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW6GC.Lib
{
    public class Shop : IDisposable
    {
        public enum ShopType
        {
            food,
            building_materials,
            cloth,
            shoe,
            undefined
        }

        private static string wordPattern = @"[A-Za-z]+(?:-[A-Za-z]+)*";

        private static string fullPattern = $@"^{wordPattern}(?:\s{wordPattern}){{0,3}}$";

        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidDataException("Shop name cannot be empty.");


                if (!Regex.IsMatch(value, fullPattern))
                {
                    throw new InvalidDataException("Shop name must consist of 1-4 words (Latin). " +
                        "Hyphens allowed only inside words (e.g. Epicentr-K). No double hyphens.");
                }
                name = value;
            }
        }

        public ShopType Type { get; private set; }

        private string cityPattern = @"^[A-Za-z][A-Za-z\s-]*(?:,\s*[A-Za-z0-9\s.-]+)*$";

        private string address;
        public string Address
        {
            get { return address; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidDataException("Address cannot be empty.");


                if (!Regex.IsMatch(value, cityPattern))
                {
                    throw new InvalidDataException("Shop address must match the pattern. " +
                        "Here is an example: USA, Washington, D.C., Pennsylvania Ave, 1600");
                }
                address = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} {Type} shop in {Address}";
        }

        public Shop(string name, ShopType type, string address)
        {
            Name = name;
            Type = type;
            Address = address;
        }

        public void Dispose()
        {
            Console.WriteLine(ToString() + " was closed");
            Name = "XXX XXX XXX";
            Type = ShopType.undefined;
            Address = "blank address";
            Console.WriteLine(ToString());
        }

        public static void Test()
        {
            Shop shop1 = new("Thirty three square meters", ShopType.building_materials,
                "Ukraine, Kyiv city, prosp. Gnata Hotkevicha, 10");
            Console.WriteLine($"{shop1.ToString()} is working.");
        }

        ~Shop()
        {
            Console.WriteLine(ToString() + " was closed.");
            Name = "XXX XXX XXX";
            Type = ShopType.undefined;
            Address = "blank address";
            Console.WriteLine(ToString());
        }
    }
}