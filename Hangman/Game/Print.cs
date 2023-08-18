namespace Hangman.Game
{
    public class Print
    {
        public static void ShowPartialHidden(string secretWord, List<char> guessedLetters)
        {
            Console.WriteLine(GetGuessedLetters(secretWord, guessedLetters) + "\n");
        }

        public static string GetGuessedLetters(string secretWord, List<char> guessedLetters)
        {
            string print = "";

            for(int i = 0; i < secretWord.Length; i++)
            {
                if (guessedLetters.Contains(secretWord[i]))
                {
                    print += secretWord[i];
                }
                else
                {
                    print += "_";
                }
            }
            return (print);
        }

        public static void ShowIncorrectGuess(List<char> incorrectGuess)
        {
            string guessedLetters = "";

            for(int i = 0; i < incorrectGuess.Count;i++)
            {
                if (i == incorrectGuess.Count - 1)
                {
                    guessedLetters += $"{incorrectGuess[i]}, ";
                }
                else
                {
                    guessedLetters += $"{incorrectGuess[i]}, ";
                }
            }
            Console.WriteLine($"Incorrect letters: {guessedLetters} \n");
        }
        public static void Lives(int guess)
        {
            switch (guess)
            {

                case 1:
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;

                case 2:
                    Console.WriteLine("\r\n  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;

                case 3:
                    Console.WriteLine("\r\n  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 4:
                    Console.WriteLine("\r\n  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 5:
                    Console.WriteLine("\r\n  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 6:
                    Console.WriteLine("\r\n  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\ |");
                    Console.WriteLine(" /    |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
                case 7:
                    Console.WriteLine("\r\n  +---+");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" / \\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("=========");
                    break;
            }
            for (int i = 0; i < 100000000; i++) ; // This loop introduces a delay to create the slower print effect
            Console.WriteLine();
        }
        public static void Winner(string secretWord, List<char> correctLetters, List<char> incorrectGuess)
        {
            Console.Clear(); 
            Console.WriteLine("\r\n\r\n____    __  ____    _    _     __    _    ___  _  ._   _.  _  \r\n\\   \\  /   / /  _  \\  |  |  |  |    \\   \\  /  \\  /   / |  | |  \\ |  | |  | \r\n \\   \\/   / |  |  |  | |  |  |  |     \\   \\/    \\/   /  |  | |   \\|  | |  | \r\n  \\    /  |  |  |  | |  |  |  |      \\            /   |  | |  . `  | |  | \r\n    |  |    |  `--'  | |  `--'  |       \\    /\\    /    |  | |  |\\   | |__| \r\n    |__|     \\______/   \\______/         \\__/  \\__/     |__| |__| \\__| (_) \r\n                                                                            \r\n\r\n");
            Console.WriteLine($"Nice, you got it right winner! \"{secretWord}\" in {correctLetters.Count + incorrectGuess.Count} guesses");
        }

        public static void Loser(string secretWord)
        {
            Console.Clear();
            Lives(7);
            Console.WriteLine("\r\n\r\n  _____      _      .___  _.  _____      ____   __    __  _____ .______       _  \r\n /  _____|    /   \\     |   \\/   | |   ____|    /  _  \\  \\   \\  /   / |   ___||   _  \\     |  | \r\n|  |  _     /  ^  \\    |  \\  /  | |  |__      |  |  |  |  \\   \\/   /  |  |__   |  |_)  |    |  | \r\n|  | |_ |   /  /_\\  \\   |  |\\/|  | |   _|     |  |  |  |   \\      /   |   __|  |      /     |  | \r\n|  |__| |  /  ____  \\  |  |  |  | |  |____    |  --'  |    \\    /    |  |____ |  |\\  \\----.|__| \r\n \\______| /__/     \\__\\ |__|  |__| |_______|    \\______/      \\__/     |_______|| _| ._____|(__) \r\n                                                                                                  \r\n\r\n");
            Console.WriteLine($"\nThe correct word was \"{secretWord}\". Better luck next time!");
        }
    }
}
