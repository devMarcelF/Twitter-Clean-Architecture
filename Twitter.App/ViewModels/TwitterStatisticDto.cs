namespace Twitter.App.ViewModels
{
    public class TwitterStatisticDto
    {
        public int Id { get; set; }

        public int NumberOfTweets { get; set; }

        public string HashTag { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<string>? Top10HashTag { get; set; }
    }
}
