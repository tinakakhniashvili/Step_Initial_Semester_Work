using System;

class NumberGuessing
{
    static void Main()
    {
        Random random = new Random();
        int lowest = 1;
        int highest = 100;
        int target = random.Next(lowest, highest + 1);
        Console.WriteLine($"There is a number between {lowest} and {highest}");

        int guess = 0;  
        int attempts = 0;  

        while (true)
        {
            Console.Write("Guess the number: ");
            string input = Console.ReadLine();
            
            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Invalid input. Please enter a valid number!");
                continue;  
            }
            
            if (guess < lowest || guess > highest)
            {
                Console.WriteLine($"Please guess a number between {lowest} and {highest}.");
                continue;  
            }
            
            attempts++;  

            if (guess == target)
            {
                Console.WriteLine($"Congratulations, you guessed the number in {attempts} attempts!");
                break;  
            }
            else if (guess > target)
            {
                Console.WriteLine("The target number is lower than your guess.");
            }
            else
            {
                Console.WriteLine("The target number is higher than your guess.");
            }
        }
    }
}