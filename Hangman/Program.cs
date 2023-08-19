﻿using Hangman.Game;
using Hangman.WordGenerator;

public class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string secretWord = await RandomWordGenerator.GetRandomWord();
            Console.WriteLine("Received secretWord: " + secretWord);

            if (secretWord != null)
            {
                secretWord = secretWord.ToLower();

                var correctLetters = new List<char>();
                var incorrectLetters = new List<char>();

                while (true)
                {
                    Console.Clear();

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
                        Console.WriteLine("You won!");
                        Print.Winner(secretWord, correctLetters, incorrectLetters);
                        break;
                    }

                    if (incorrectLetters.Count > 6)
                    {
                        Console.WriteLine("You lost!");
                        Print.Loser(secretWord);
                        break;

                    }


                }
            }
            else
            {
                // Handle the case when the secretWord is null or couldn't be fetched.
                Console.WriteLine("Failed to get a random word. Please try again later.");
            }
        }
        catch (HttpRequestException ex)
        {
            // Handle the exception gracefully if an error occurs while retrieving the random word.
            Console.WriteLine($"An error occurred while fetching a random word: {ex.Message}");
        }


        Console.WriteLine("Press enter to exit the game");
        Console.ReadLine();
    }
}
