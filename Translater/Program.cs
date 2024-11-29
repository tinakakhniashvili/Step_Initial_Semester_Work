class TranslatorApp
{
    static void Main()
    {
        string dictionaryFile = "dictionary.txt";
        Dictionary<string, string> translations = LoadDictionary(dictionaryFile);

        Console.WriteLine("Welcome to the Translator App!");
        Console.WriteLine("Available language pairs:");
        Console.WriteLine("1. Georgian-English");
        Console.WriteLine("2. Georgian-Russian");
        Console.WriteLine("3. English-Georgian");
        Console.WriteLine("4. Russian-Georgian");

        Console.Write("Select a language pair (e.g., 1, 2, 3, 4): ");
        string languagePair = Console.ReadLine();

        string direction = GetTranslationDirection(languagePair);
        if (direction == null)
        {
            Console.WriteLine("Invalid language pair selected.");
            return;
        }

        Console.WriteLine($"You selected: {direction}");
        Console.Write("Enter a word or phrase to translate: ");
        string inputWord = Console.ReadLine();

        if (translations.ContainsKey(inputWord))
        {
            Console.WriteLine($"Translation: {translations[inputWord]}");
        }
        else
        {
            Console.WriteLine("The word/phrase is not found in the dictionary.");
            Console.Write("Would you like to add it? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            if (response == "yes")
            {
                Console.Write("Enter the translation: ");
                string translation = Console.ReadLine();

                translations[inputWord] = translation;
                SaveToDictionary(dictionaryFile, inputWord, translation);

                Console.WriteLine("The word/phrase has been added to the dictionary.");
            }
            else
            {
                Console.WriteLine("The word/phrase was not added.");
            }
        }
    }

    static Dictionary<string, string> LoadDictionary(string filePath)
    {
        Dictionary<string, string> translations = new Dictionary<string, string>();

        if (File.Exists(filePath))
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split('=');
                if (parts.Length == 2)
                {
                    translations[parts[0]] = parts[1];
                }
            }
        }

        return translations;
    }

    static void SaveToDictionary(string filePath, string word, string translation)
    {
        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            sw.WriteLine($"{word}={translation}");
        }
    }

    static string GetTranslationDirection(string choice)
    {
        return choice switch
        {
            "1" => "Georgian-English",
            "2" => "Georgian-Russian",
            "3" => "English-Georgian",
            "4" => "Russian-Georgian",
            _ => null,
        };
    }
}
