namespace Hangman.Game
{
    public class InputHandle
    {
        public static char GetInput(List<char> correctLetters, List<char> incorrectLetters)
        {
            while (true)
            {
                Console.WriteLine("Give me a letter: "); 
                string result = Console.ReadLine()!;

                try
                {
                    char results = Convert.ToChar(result); 

                    if(!char.IsLetter(results))
                    {
                        throw new ArgumentException("Enter a valid letter."); 
                    }
                    if (correctLetters.Contains(results) || incorrectLetters.Contains(results))
                    {
                        throw new ArgumentException("You have already said this. Try something else.");
                    }
                    return Char.ToLower(results);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch
                {
                    Console.WriteLine("Enter a valid letter");
                }
            }
        }
        public static bool IsCorrectGuess(char input, string secretWord)
        {
            if(secretWord.Contains(input))
            {
                return true;
            }
            return false;
        }
    }
}
