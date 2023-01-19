using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Twitter.ConsoleStream.Models;
using TwitterStream.Models;

namespace Twitter.ConsoleStream.Services
{
    public class TwitterDataService : ITwitterDataService
    {
        private readonly HttpClient _httpClient;

        public TwitterDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreateTwitterStatisticDto> AddTwitterStatistic(CreateTwitterStatisticDto twitterStatistic)
        {
            var twitterStatisticJson = new StringContent(JsonSerializer.Serialize(twitterStatistic), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/TwitterStatistic", twitterStatisticJson);

            return null;
        }

        public async IAsyncEnumerable<string> GetTweetsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var messages = 0;
            var requestUri = "https://api.twitter.com/2/tweets/sample/stream?tweet.fields=entities";
            var bearerToken = "AAAAAAAAAAAAAAAAAAAAADYElAEAAAAAczLHx1IoHHRch7gGXMdaZtlrB5M%3DUE7JY24DDaAMHjJTo5Kl9qIcgcFCtjAolwjSBkObllr9rYUdwo";

            _httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", bearerToken);

            using var stream = await this._httpClient.GetStreamAsync(requestUri);
            using var streamReader = new StreamReader(stream);

            Console.Clear();
            Console.WriteLine("Starting Sample Stream From Twitter API V2");
            while (!streamReader.EndOfStream)
            {
                messages++;
                yield return await streamReader.ReadLineAsync();
                Console.Write("\r{0} Total number of tweets received", messages);
            }
        }
    }
}
