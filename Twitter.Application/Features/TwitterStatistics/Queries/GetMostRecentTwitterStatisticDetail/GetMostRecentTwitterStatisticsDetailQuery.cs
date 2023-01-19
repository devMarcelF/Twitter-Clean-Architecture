using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsList;

namespace Twitter.Application.Features.TwitterStatistics.Queries.GetMostRecentTwitterStatisticDetail
{
    public class GetMostRecentTwitterStatisticsDetailQuery : IRequest<MostRecentTwitterStatisticsDetailVm>
    {
    }
}
