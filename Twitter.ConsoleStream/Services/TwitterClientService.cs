using Twitter.ConsoleStream.Models;
using Twitter.ConsoleStream.Services;
using Twitter.ConsoleStream.Utility;

namespace TwitterStream.Services
{
    public class TwitterClientService : ITwitterService
    {
        private readonly ITwitterDataService _twitterClient;

        public TwitterClientService(ITwitterDataService twitterClient)
        {
            _twitterClient = twitterClient;
        }

        public async Task ProcessTweetsAsync(CancellationToken cancellationToken)
        {
            int currentMessages = 0;
            var hashTagList = new List<string>();
            var top10HashTags = new List<string>();
            CreateTwitterStatisticDto createTwitterStatistic = new CreateTwitterStatisticDto();
            await foreach (var tweet in this._twitterClient.GetTweetsAsync(cancellationToken).WithCancellation(cancellationToken))
            {
                currentMessages++;

                foreach (var item in TweetTreatment.FindHashtags(tweet))
                    hashTagList.Add(item);

                if (currentMessages % 100 == 0)
                {
                    top10HashTags = TweetTreatment.GetTop10Hashtags(hashTagList);

                    if (top10HashTags.Count == 10)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Top 10 Hashtags: ");
                        foreach (var item in top10HashTags)
                        {
                            Console.Write(item);
                        }
                        Console.WriteLine();

                        createTwitterStatistic.NumberOfTweets = currentMessages;
                        createTwitterStatistic.HashTag = TweetTreatment.ConvertTop10HashtagsToString(top10HashTags);

                        await AddTwitterStatistic(createTwitterStatistic);
                    }
                }
            }
        }

        public async Task AddTwitterStatistic(CreateTwitterStatisticDto createTwitterStatistic)
        {
            var addedEmployee = await _twitterClient.AddTwitterStatistic(createTwitterStatistic);
        }
    }
}