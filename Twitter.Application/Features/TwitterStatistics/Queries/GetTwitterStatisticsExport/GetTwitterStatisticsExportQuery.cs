using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsExport
{
    public class GetTwitterStatisticsExportQuery : IRequest<TwitterStatisticExportFileVm>
    {
    }
}
