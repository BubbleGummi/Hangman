using Hangman.Models;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Hangman.WordGenerator
{
    public class RandomWordGenerator
    {
        public static async Task<string> GetRandomWord()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<RandomWordGenerator>()
                .Build();
            string? apikey = "pq0H7mvCz3aSKgvWOA7nqc4zhZhve0SYGjBNjkxK";

            HttpClient client = new();

            try
            {
                var fetchReq = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://api.api-ninjas.com/v1/randomword"),
                    Headers =
                    {
                        {"X-Api-Key", apikey }
                    }
                };
                var response = await client.SendAsync(fetchReq);
                response.EnsureSuccessStatusCode();

                string respBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response body: {respBody}");

                //Console.WriteLine(respBody); // Print the API response to the console for debugging
                RandomWordModel? RandomWord = JsonSerializer.Deserialize<RandomWordModel>(respBody);

                /* string respBody = await response.Content.ReadAsStringAsync();
                RandomWordModel? RandomWord = JsonSerializer.Deserialize<RandomWordModel>(respBody);
                */
                // If RandomWord is null or the Word property is null or empty, return a default word
                if (RandomWord == null || string.IsNullOrEmpty(RandomWord.Word))
                {
                    return "default_word";
                }
                return RandomWord.Word.ToLower();
            }
            catch
            {
                throw new HttpRequestException("Could not get any random word, try again");
            }
        }
    }
}
