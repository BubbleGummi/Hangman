using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using Hangman.WordGenerator;
using Hangman.Models;
using Newtonsoft.Json;

namespace Hangman.Tests
{
    [TestClass]
    public class RandomWordGeneratorTests
    {
        private class TestHttpMessageHandler : HttpMessageHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                // Simulate a response with a predefined word
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new RandomWordModel { Word = "testword" }))
                };
                return response;
            }
        }

        [TestMethod]
        public async Task GetRandomWord_ReturnsRandomWord()
        {
            // Arrange
            var httpClient = new HttpClient(new TestHttpMessageHandler());

            // Act
            string result = await Task.Run(() => RandomWordGenerator.GetRandomWord());

            // Assert
            Assert.AreEqual("testword", result);
        }

    }
}
