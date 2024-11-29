using System;
using System.Text;

class Hangman
{
    private static string[] wordList = 
    {
        "Apple",
        "Horizon",
        "Crystal",
        "Whisper",
        "Falcon",
        "Ocean",
        "Thunder",
        "Lantern",
        "Harmony",
        "Galaxy",
        "Meadow",
        "Summit",
        "Eclipse",
        "Phoenix",
        "Velvet",
        "Orbit",
        "Prism",
        "Echo",
        "Frost",
        "Blossom",
        "Serene",
        "Cascade",
        "Nimbus",
        "Twilight",
        "Ember",
        "Aurora",
        "Solstice",
        "Radiant",
        "Zenith"
    };

    public static void Main()
    {
        Console.WriteLine("Word List:");
        foreach (string word in wordList)
        {
            Console.WriteLine(word);
        }
        
        int attempts = 20;
        Random random = new Random();
        int index = random.Next(0, wordList.Length);
        string target = wordList[index];
        StringBuilder hiddenWord = new StringBuilder(new string('_', target.Length));

        Console.WriteLine($"Hidden word: {hiddenWord}");

        int k = 0;
        while (k < attempts)
        {
            Console.WriteLine("\nEnter a letter to uncover the word:");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char input = keyInfo.KeyChar;

            if (target.Contains(input, StringComparison.OrdinalIgnoreCase))
            {
                for (int i = 0; i < target.Length; i++)
                {
                    if (char.ToLower(target[i]) == char.ToLower(input))
                    {
                        hiddenWord[i] = target[i]; 
                    }
                }
                Console.WriteLine($"\nGood guess! Current word: {hiddenWord}");
            }
            else
            {
                Console.WriteLine($"\nWrong guess! Current word: {hiddenWord}");
            }
            
            if (!hiddenWord.ToString().Contains("_"))
            {
                Console.WriteLine($"Congratulations! You guessed the word: {target}");
                break;
            }

            k++; 
        }

        if (hiddenWord.ToString().Contains("_"))
        {
            Console.WriteLine($"Out of attempts! The word was: {target}");
        }
    }
}
