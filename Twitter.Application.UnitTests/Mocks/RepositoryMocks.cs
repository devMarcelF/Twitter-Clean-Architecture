using Moq;
using Twitter.Application.Contracts.Persistence;
using Twitter.Domain.Entities;

namespace Twitter.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<TwitterStatistic>> GetTwitterStatisticRepository()
        {
            var twitterStatistics = new List<TwitterStatistic> {
            new TwitterStatistic{ Id = 1, NumberOfTweets=1000, Hashtag ="#brasil#saopaulo#competition#influencer#influencermarketing#fridayfeeling#MondayMotivation#tbt#traveltuesday#vegan"},
            new TwitterStatistic{ Id = 2, NumberOfTweets=2000, Hashtag ="#usa#tampa#competition#influencer#influencermarketing#fridayfeeling#MondayMotivation#tbt#traveltuesday#vegan"},
            new TwitterStatistic{ Id = 3, NumberOfTweets=3000, Hashtag ="#usa#miami#competition#influencer#influencermarketing#fridayfeeling#MondayMotivation#tbt#traveltuesday#vegan"},
            };

            var mockTwitterStatisticRepository = new Mock<IAsyncRepository<TwitterStatistic>>();
            mockTwitterStatisticRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(twitterStatistics);

            mockTwitterStatisticRepository.Setup(repo => repo.AddAsync(It.IsAny<TwitterStatistic>())).ReturnsAsync(
                (TwitterStatistic twitterStatistic) =>
                {
                    twitterStatistics.Add(twitterStatistic);
                    return twitterStatistic;
                });

            return mockTwitterStatisticRepository;
        }
    }
}
