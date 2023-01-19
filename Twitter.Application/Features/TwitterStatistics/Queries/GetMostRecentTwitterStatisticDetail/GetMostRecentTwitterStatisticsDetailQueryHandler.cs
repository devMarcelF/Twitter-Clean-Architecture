using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.Contracts.Persistence;
using Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsList;
using Twitter.Domain.Entities;

namespace Twitter.Application.Features.TwitterStatistics.Queries.GetMostRecentTwitterStatisticDetail
{
    public class GetMostRecentTwitterStatisticsDetailQueryHandler : IRequestHandler<GetMostRecentTwitterStatisticsDetailQuery, MostRecentTwitterStatisticsDetailVm>
    {
        private readonly IAsyncRepository<TwitterStatistic> _twitterStatisticRepository;
        private readonly IMapper _mapper;

        public GetMostRecentTwitterStatisticsDetailQueryHandler(IMapper mapper, IAsyncRepository<TwitterStatistic> twitterStatisticRepository)
        {
            _mapper = mapper;
            _twitterStatisticRepository = twitterStatisticRepository;
        }

        public async Task<MostRecentTwitterStatisticsDetailVm> Handle(GetMostRecentTwitterStatisticsDetailQuery request, CancellationToken cancellationToken)
        {
            var twitterStatistic = (await _twitterStatisticRepository.ListAllAsync()).OrderByDescending(x => x.CreatedDate).FirstOrDefault();
            return _mapper.Map<MostRecentTwitterStatisticsDetailVm>(twitterStatistic);
        }
    }
}
