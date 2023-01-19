using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Twitter.Application.Contracts.Persistence;
using Twitter.Domain.Entities;

namespace Twitter.Persistence.Repositories
{

    public class TwitterStatisticRepository : BaseRepository<TwitterStatistic>, ITwitterStatisticRepository
    {
        public TwitterStatisticRepository(TwitterDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsTwitterStatisticHashTagUnique(string hashtag)
        {
            var matches = _dbContext.TwitterStatistics.Any(e => e.Hashtag.Equals(hashtag));// && e.Date.Date.Equals(twitterStatisticDate.Date));
            return Task.FromResult(matches);
        }
    }
}
