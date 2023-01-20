using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using Twitter.App.Services;
using Twitter.App.ViewModels;

namespace Twitter.App.Controllers
{
    [Authorize]
    public class TwitterStatisticController : Controller
    {

        private readonly ITwitterStatisticDataService _twitterStatisticDataService;

        public TwitterStatisticController(ITwitterStatisticDataService twitterStatisticDataService)
        {
            _twitterStatisticDataService = twitterStatisticDataService;
        }

        public async Task<IActionResult> Index()
        {
            var twitterStatistics = await _twitterStatisticDataService.GetMostRecentTwitterStatistic();

            twitterStatistics.Top10HashTag = 
                twitterStatistics.HashTag.Split('#', StringSplitOptions.RemoveEmptyEntries).ToList();

            return View(twitterStatistics);

        }
    }
}