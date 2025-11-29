using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HW6GC.Lib
{
    public enum PlayGenre
    {
        Tragedy,
        Comedy,
        Drama,
        Melodrama,
        Musical,
        Satire,
        Historical,
        Fantasy
    }

    public class StagePlay
    {
        private string playName;
        public string PlayName
        {
            get { return playName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidDataException("Play must have a name.");
                playName = value;
            }
        }

        private string author;
        public string Author
        {
            get { return author; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidDataException("Author name cannot be empty.");

                // Патерн для ОДНОГО слова (такий самий, як був: літери, всередині можливі дефіси)
                string wordPattern = @"[A-Za-z]+(?:-[A-Za-z]+)*";

                // Повний патерн:
                // ^               - початок
                // {wordPattern}   - перше слово (обов'язкове)
                // (?:             - початок групи (без запам'ятовування)
                //   \s            - пробіл
                //   {wordPattern} - наступне слово
                // )
                // {0,2}           - квантифікатор: ця група (пробіл+слово) може бути 0, 1 або 2 рази
                // $               - кінець

                string fullPattern = $@"^{wordPattern}(?:\s{wordPattern}){{0,2}}$";

                if (!Regex.IsMatch(value, fullPattern))
                {
                    throw new InvalidDataException("Author name must consist of 1-3 words (Latin). " +
                        "Hyphens allowed only inside words (e.g. Jean-Paul). No double hyphens.");
                }
                author = value;
            }
        }

        public PlayGenre Genre { get; private set; }

        private int year;
        public int Year
        {
            get { return year; }
            private set
            {
                if (value > DateTime.Now.Year)
                {
                    throw new InvalidDataException($"Year cannot be in the future. Current year is {DateTime.Now.Year}.");
                }
                year = value;
            }
        }

        public StagePlay(string name, string author, PlayGenre genre, int year)
        {
            PlayName = name;
            Author = author;
            Genre = genre;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Genre} play {PlayName} ({Year}) of {Author}";
        }

        ~StagePlay()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{ToString()} has been deleted.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Stage was ended.");
        }

        public static void Test()
        {
            StagePlay Romeo_and_Juliete = new StagePlay("Romeo and Juliete", "William Shakespeare", PlayGenre.Tragedy, 1597);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Romeo_and_Juliete.ToString() + " in progress.");
        }
    }
}
