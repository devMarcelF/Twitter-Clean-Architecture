using System.Text.Json;
using Twitter.B.App.ViewModels;

namespace Twitter.B.App.Services
{
    public class TwitterStatisticDataService : ITwitterStatisticDataService
    {
        private readonly HttpClient _httpClient;

        public TwitterStatisticDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TwitterStatisticDto?> GetMostRecentTwitterStatistic()
        {
            return await JsonSerializer.DeserializeAsync<TwitterStatisticDto>(
            await _httpClient.GetStreamAsync($"api/TwitterStatistic/recent"),
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
