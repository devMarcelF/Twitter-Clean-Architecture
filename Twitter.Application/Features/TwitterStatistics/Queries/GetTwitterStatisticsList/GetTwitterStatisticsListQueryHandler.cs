using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.Contracts.Persistence;
using Twitter.Domain.Entities;

namespace Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsList
{
    public class GetTwitterStatisticsListQueryHandler : IRequestHandler<GetTwitterStatisticsListQuery, List<TwitterStatisticListVm>>
    {
        private readonly IAsyncRepository<TwitterStatistic> _twitterStatisticRepository;
        private readonly IMapper _mapper;

        public GetTwitterStatisticsListQueryHandler(IMapper mapper, IAsyncRepository<TwitterStatistic> twitterStatisticRepository)
        {
            _mapper = mapper;
            _twitterStatisticRepository = twitterStatisticRepository;
        }

        public async Task<List<TwitterStatisticListVm>> Handle(GetTwitterStatisticsListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _twitterStatisticRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<TwitterStatisticListVm>>(allEvents);
        }
    }
}



