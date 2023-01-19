using Twitter.Domain.Common;

namespace Twitter.Domain.Entities;

public class TwitterStatistic : AuditableEntity
{
    public int Id { get; set; }

    public int NumberOfTweets { get; set; }

    public string? Hashtag { get; set; }
}