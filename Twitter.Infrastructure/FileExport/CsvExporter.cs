
using CsvHelper;
using System.Globalization;
using Twitter.Application.Contracts.Infrastructure;
using Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsExport;

namespace Twitter.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<TwitterStatisticExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
