using Hangman.WordGenerator;
using Hangman.Game;

public class Program
{
    static async Task Main(string[]args)
    {
        try
        {
            string secretWord = await RandomWordGenerator.GetRandomWord();
            secretWord = secretWord.ToLower();

            Console.WriteLine("Random word: " + secretWord);
            var correctLetters = new List<char>();
            var incorrectLetters = new List<char>();

            while (true)
            {
                Print.Lives(incorrectLetters.Count);
                Print.ShowPartialHidden(secretWord, correctLetters);
                Print.ShowIncorrectGuess(incorrectLetters);

                char input = InputHandle.GetInput(correctLetters, incorrectLetters);
                Console.WriteLine($"User input: {input}");
                if (InputHandle.IsCorrectGuess(input, secretWord))
                {
                    correctLetters.Add(input);
                }
                else
                {
                    incorrectLetters.Add(input);
                }

                if (Winning.Won(secretWord, correctLetters))
                {
                    Print.Winner(secretWord, correctLetters, incorrectLetters);

                    break;
                }

                if (incorrectLetters.Count > 6)
                {
                    Print.Loser(secretWord);
                    break;
                }
                Console.Clear();
            }




            Console.WriteLine("Press enter to exit the game");
            Console.ReadLine();
        }
        catch (HttpRequestException ex)
        {
            // Handle the exception gracefully if an error occurs while retrieving the random word.
            Console.WriteLine(ex.Message);
        }
    }
}

