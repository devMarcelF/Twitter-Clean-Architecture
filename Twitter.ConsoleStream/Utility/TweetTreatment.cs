using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Twitter.ConsoleStream.Utility
{
    public static class TweetTreatment
    {
        public static List<string> FindHashtags(string tweet)
        {
            var hashTagList = new List<string>();

            Regex rgx = new Regex(@"#\w+", RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(tweet);

            foreach (var hashtag in matches)
            {
                hashTagList.Add(hashtag.ToString());
            }

            return hashTagList;
        }

        public static List<string> GetTop10Hashtags(List<string> hashTagList)
        {
            var Top10HashTags = (from string n in hashTagList
                                 group n by n into g
                                 orderby g.Count() descending
                                 select g.Key).Take((10)).ToList();

            return Top10HashTags;
        }

        public static string ConvertTop10HashtagsToString(List<string> hashTagList)
        {
            var hashTags = "";
            foreach (var hashtag in hashTagList)
                hashTags += hashtag;

            return hashTags;
        }
    }
}
