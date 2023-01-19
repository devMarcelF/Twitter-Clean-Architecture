using AutoMapper;
using MediatR;
using Twitter.Application.Contracts.Infrastructure;
using Twitter.Application.Contracts.Persistence;
using Twitter.Domain.Entities;

namespace Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsExport
{
    public class GetTwitterStatisticsExportQueryHandler : IRequestHandler<GetTwitterStatisticsExportQuery, TwitterStatisticExportFileVm>
    {
        private readonly IAsyncRepository<TwitterStatistic> _twitterStatisticRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetTwitterStatisticsExportQueryHandler(IMapper mapper, IAsyncRepository<TwitterStatistic> twitterStatisticRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _twitterStatisticRepository = twitterStatisticRepository;
            _csvExporter = csvExporter;
        }

        public async Task<TwitterStatisticExportFileVm> Handle(GetTwitterStatisticsExportQuery request, CancellationToken cancellationToken)
        {
            var allTwitterStatistics = _mapper.Map<List<TwitterStatisticExportDto>>((await _twitterStatisticRepository.ListAllAsync()).OrderBy(x => x.CreatedDate));

            var fileData = _csvExporter.ExportEventsToCsv(allTwitterStatistics);

            var eventExportFileDto = new TwitterStatisticExportFileVm() { ContentType = "text/csv", Data = fileData, EventExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
