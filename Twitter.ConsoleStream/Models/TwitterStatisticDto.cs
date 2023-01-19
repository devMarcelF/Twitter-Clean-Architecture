using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterStream.Models
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
