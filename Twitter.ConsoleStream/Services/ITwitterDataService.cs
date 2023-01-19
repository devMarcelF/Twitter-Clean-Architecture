using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.ConsoleStream.Models;
using TwitterStream.Models;

namespace Twitter.ConsoleStream.Services
{
    public interface ITwitterDataService
    {
        IAsyncEnumerable<string> GetTweetsAsync(CancellationToken cancellationToken = default);
        Task<CreateTwitterStatisticDto> AddTwitterStatistic(CreateTwitterStatisticDto employee);
    }
}
