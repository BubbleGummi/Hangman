﻿using Hangman.Models;
using System.Net.Http;
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

                Console.WriteLine($"Sending API request to: {fetchReq.RequestUri}");

                var response = await client.SendAsync(fetchReq);
                response.EnsureSuccessStatusCode();

                string respBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response status code: {response.StatusCode}");
                Console.WriteLine($"API Response body: {respBody}");

                // Return the fetched random word
                return respBody;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching a random word: {ex.Message}");
                throw new HttpRequestException("Could not get any random word, try again");
            }
        }
    }
}
