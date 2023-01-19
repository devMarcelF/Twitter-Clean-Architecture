using System.Net.Http;
using System.Text.RegularExpressions;
using Twitter.App.Models;

namespace Twitter.App.Utility
{
    public class TwitterStream
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TwitterStream(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ??
                                 throw new ArgumentNullException(nameof(httpClientFactory));
        }
    }
}
