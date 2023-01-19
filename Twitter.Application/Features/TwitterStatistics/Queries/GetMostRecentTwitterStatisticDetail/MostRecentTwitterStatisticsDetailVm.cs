using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Features.TwitterStatistics.Queries.GetMostRecentTwitterStatisticDetail
{
    public class MostRecentTwitterStatisticsDetailVm
    {
        public int Id { get; set; }

        public int NumberOfTweets { get; set; }

        public string? Hashtag { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
