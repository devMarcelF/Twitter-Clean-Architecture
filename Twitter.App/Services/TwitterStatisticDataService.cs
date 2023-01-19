using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Twitter.App.ViewModels;

namespace Twitter.App.Services
{
    public class TwitterStatisticDataService : ITwitterStatisticDataService
    {
        private readonly HttpClient _httpClient;
        protected readonly ILocalStorageService _localStorage;

        public TwitterStatisticDataService(HttpClient httpClient , ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<TwitterStatisticDto?> GetTwitterStatisticDetails(int twitterStatisticId)
        {
            await AddBearerToken();

            return await JsonSerializer.DeserializeAsync<TwitterStatisticDto>(
                await _httpClient.GetStreamAsync($"api/twitterStatistics/{twitterStatisticId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainKeyAsync("token"))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
        }
    }
}
