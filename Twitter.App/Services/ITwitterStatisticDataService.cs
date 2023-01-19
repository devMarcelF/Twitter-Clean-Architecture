using Twitter.App.ViewModels;

namespace Twitter.App.Services
{
    public interface ITwitterStatisticDataService
    {
        Task<TwitterStatisticDto?> GetTwitterStatisticDetails(int twitterStatisticId);
    }
}
