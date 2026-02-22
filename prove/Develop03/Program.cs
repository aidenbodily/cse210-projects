using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScriptures("scriptures.txt");
        Random random = new Random();
        int randomIndex = random.Next(scriptures.Count);
        Scripture scripture = scriptures[randomIndex];

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplay());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");

            string input = Console.ReadLine();
            if (input != null && input.ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandom();
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplay());
        Console.WriteLine();
        Console.WriteLine("All words are hidden. Great work!");
    }

    private static List<Scripture> LoadScriptures(string fileName)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] lineParts = line.Split('|');
                if (lineParts.Length != 2)
                {
                    continue;
                }

                Reference reference = ParseReference(lineParts[0].Trim());
                if (reference == null)
                {
                    continue;
                }

                string scriptureText = lineParts[1].Trim();
                scriptures.Add(new Scripture(reference, scriptureText));
            }
        }

        if (scriptures.Count == 0)
        {
            scriptures.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));

            scriptures.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));

            scriptures.Add(new Scripture(
                new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God."));
        }

        return scriptures;
    }

    private static Reference ParseReference(string text)
    {
        int lastSpaceIndex = text.LastIndexOf(' ');
        if (lastSpaceIndex <= 0)
        {
            return null;
        }

        string book = text.Substring(0, lastSpaceIndex).Trim();
        string chapterAndVerses = text.Substring(lastSpaceIndex + 1).Trim();

        string[] chapterVerseParts = chapterAndVerses.Split(':');
        if (chapterVerseParts.Length != 2)
        {
            return null;
        }

        int chapter;
        if (!int.TryParse(chapterVerseParts[0], out chapter))
        {
            return null;
        }

        string verses = chapterVerseParts[1];
        if (verses.Contains('-'))
        {
            string[] verseRange = verses.Split('-');
            if (verseRange.Length != 2)
            {
                return null;
            }

            int startVerse;
            int endVerse;
            if (!int.TryParse(verseRange[0], out startVerse) ||
                !int.TryParse(verseRange[1], out endVerse))
            {
                return null;
            }

            return new Reference(book, chapter, startVerse, endVerse);
        }

        int singleVerse;
        if (!int.TryParse(verses, out singleVerse))
        {
            return null;
        }

        return new Reference(book, chapter, singleVerse);
    }
}