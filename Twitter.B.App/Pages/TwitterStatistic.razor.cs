using Microsoft.AspNetCore.Components;
using Twitter.B.App.Services;
using Twitter.B.App.ViewModels;

namespace Twitter.B.App.Pages
{
    public partial class TwitterStatistic
    {
        [Inject]
        public ITwitterStatisticDataService? TwitterStatisticDataService { get; set; }

        private string Title = "Twitter Statistic Overview";

        public TwitterStatisticDto TwitterStatisticdto { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            TwitterStatisticdto = (await TwitterStatisticDataService.GetMostRecentTwitterStatistic());
            TwitterStatisticdto.Top10HashTag =
                TwitterStatisticdto.HashTag.Split('#', StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
