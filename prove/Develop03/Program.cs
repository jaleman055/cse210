using System;

namespace Develop03
{
    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture("Proverbs 3:5-6", "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
            Scripture scripture2 = new Scripture("Luke 2:19", "But Mary kept all these things, and apondered them in her heart.");
            Scripture scripture3 = new Scripture("Luke 1:37", "For with God nothing shall be impossible.");

            Scripture[] scriptures = new Scripture[] { scripture, scripture2, scripture3 };
            Random random = new Random();
            int randomIndex = random.Next(0, scriptures.Length);
            Scripture randomScripture = scriptures[randomIndex];
            randomScripture.HideWords();
            scripture.HideWords();
        }
    }

    class Scripture
    {
        private string reference;
        private string text;
        private string[] words;
        private Random random = new Random();

        public Scripture(string reference, string text)
        {
            this.reference = reference;
            this.text = text;
            words = text.Split(' ');
        }

        public void HideWords()
        {
            Console.WriteLine(reference);
            Console.WriteLine(text);
            Console.WriteLine("Press enter to hide words or type quit to exit.");
            string input = Console.ReadLine();
            
            while (input != "quit")
            {
                int randomIndex = random.Next(0, words.Length);
                words[randomIndex] = "*****";
                Console.Clear();
                Console.WriteLine(reference);
                Console.WriteLine(string.Join(" ", words));
                Console.WriteLine("Press enter to hide words or type quit to exit.");
                input = Console.ReadLine();
            }
            
        }
    }

}