namespace Twitter.Application.Features.TwitterStatistics;

public class TwitterStatisticDetailVm
{
    public int Id { get; set; }

    public int NumberOfTweets { get; set; }

    public string? Hashtag { get; set; }

    public DateTime CreatedDate { get; set; }
}