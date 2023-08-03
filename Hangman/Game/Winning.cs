namespace Hangman.Game; 

public class Winning
{
    public static bool Won(string secretWord, List<char> correctLetters)
    {
        string guessedWord = Print.GetGuessedLetters(secretWord, correctLetters);

        if(guessedWord == secretWord) 
        {
            return true;
        }
        return false;
    }
}