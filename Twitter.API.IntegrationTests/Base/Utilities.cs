using Twitter.Domain.Entities;
using Twitter.Persistence;

namespace Twitter.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(TwitterDbContext context)
        {
            context.TwitterStatistics.Add(new TwitterStatistic
            {
                
            });

            context.SaveChanges();
        }
    }
}
