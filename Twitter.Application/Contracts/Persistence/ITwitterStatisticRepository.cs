using Twitter.Domain.Entities;

namespace Twitter.Application.Contracts.Persistence;

public interface ITwitterStatisticRepository : IAsyncRepository<TwitterStatistic>
{
    Task<bool> IsTwitterStatisticHashTagUnique(string hashtag);
}