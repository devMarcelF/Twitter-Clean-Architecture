
using Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsExport;

namespace Twitter.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<TwitterStatisticExportDto> twitterStatisticExportDto);
    }
}
