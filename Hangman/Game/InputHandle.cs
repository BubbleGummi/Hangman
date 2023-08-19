namespace Hangman.Game
{
    public class InputHandle
    {
        public static char GetInput(List<char> correctLetters, List<char> incorrectLetters)
        {
            while (true)
            {
                Console.WriteLine("Give me a letter: ");
                string? input = Console.ReadLine();

                if (input != null && input.Length == 1 && char.TryParse(input, out char result))
                {
                    char normalizedInput = char.ToLower(result);

                    if (!char.IsLetter(normalizedInput))
                    {
                        Console.WriteLine("Enter a valid letter.");
                    }
                    else if (correctLetters.Contains(normalizedInput) || incorrectLetters.Contains(normalizedInput))
                    {
                        Console.WriteLine("You have already guessed this letter. Try something else.");
                    }
                    else
                    {
                        Console.WriteLine($"Correct letters: {string.Join(", ", correctLetters)}");
                        Console.WriteLine($"Incorrect letters: {string.Join(", ", incorrectLetters)}");
                        Console.WriteLine($"Selected letter: {normalizedInput}");
                        return normalizedInput;
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid letter.");
                }
            }
        }

        public static bool IsCorrectGuess(char input, string secretWord)
        {
            return secretWord.Contains(input);
        }
    }
}
