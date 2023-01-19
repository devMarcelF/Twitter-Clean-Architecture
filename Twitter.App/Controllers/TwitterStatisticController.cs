using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using Twitter.App.ViewModels;

namespace Twitter.App.Controllers
{
    [Authorize]
    public class TwitterStatisticController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public TwitterStatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ??
                                 throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient("APIRoot");

            var twitterStatistics = await JsonSerializer.DeserializeAsync<TwitterStatisticDto>(
            await httpClient.GetStreamAsync($"api/TwitterStatistic/recent"),
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            twitterStatistics.Top10HashTag = 
                twitterStatistics.HashTag.Split('#', StringSplitOptions.RemoveEmptyEntries).ToList();

            return View(twitterStatistics);

        }
    }
}