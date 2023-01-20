using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Twitter.App.ViewModels;

namespace Twitter.App.Services
{
    public class TwitterStatisticDataService : ITwitterStatisticDataService
    {
        private readonly HttpClient _httpClient;

        public TwitterStatisticDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TwitterStatisticDto?> GetTwitterStatisticDetails(int twitterStatisticId)
        {
            return await JsonSerializer.DeserializeAsync<TwitterStatisticDto>(
                await _httpClient.GetStreamAsync($"api/twitterStatistics/{twitterStatisticId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<TwitterStatisticDto?> GetMostRecentTwitterStatistic()
        {
            return await JsonSerializer.DeserializeAsync<TwitterStatisticDto>(
            await _httpClient.GetStreamAsync($"api/TwitterStatistic/recent"),
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
