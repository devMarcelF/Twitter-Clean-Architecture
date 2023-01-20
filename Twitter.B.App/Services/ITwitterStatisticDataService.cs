using Twitter.B.App.ViewModels;

namespace Twitter.B.App.Services
{
    public interface ITwitterStatisticDataService
    {
        Task<TwitterStatisticDto?> GetMostRecentTwitterStatistic();
    }
}
