using System;
using System.IO; // Для InvalidDataException
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

                // Пояснення Regex:
                // ^ - початок рядка
                // [A-Za-z]+ - слово починається з літер
                // (?:-[A-Za-z]+)* - необов'язкова група: дефіс і знову літери (забороняє "--" або закінчення на "-")
                // \s - пробіл
                // Повторюємо цю логіку для трьох слів: Ім'я, Середнє ім'я, Прізвище

                string wordPattern = @"[A-Za-z]+(?:-[A-Za-z]+)*";
                string fullPattern = $@"^{wordPattern}\s{wordPattern}\s{wordPattern}$";

                if (!Regex.IsMatch(value, fullPattern))
                {
                    throw new InvalidDataException("Author must consist of 3 words (Latin)." +
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
            return $"Title: \"{PlayName}\"\nAuthor: {Author}\nGenre: {Genre}\nYear: {Year}";
        }

        ~StagePlay()
        {
            Console.WriteLine($"{PlayName} of {Author} ({Year}) has been deleted");
        }

        void Test()
        {
            StagePlay Romeo_and_Juliette = new StagePlay("Romeo and Juliette", "Whillam Shekspire", PlayGenre.Tragedy, 1597);
        }
    }
}
