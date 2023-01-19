using AutoMapper;
using MediatR;
using Twitter.Domain.Entities;
using Twitter.Application.Contracts.Persistence;

namespace Twitter.Application.Features.TwitterStatistics;

    public class GetTwitterStatisticDetailQueryHandler : IRequestHandler<GetTwitterStatisticDetailQuery, TwitterStatisticDetailVm>
    {
        private readonly IAsyncRepository<TwitterStatistic> _twitterStatisticRepository;
        private readonly IMapper _mapper;

        public GetTwitterStatisticDetailQueryHandler(IMapper mapper, IAsyncRepository<TwitterStatistic> twitterStatisticRepository)
        {
            _mapper = mapper;
            _twitterStatisticRepository = twitterStatisticRepository;
        }

        public async Task<TwitterStatisticDetailVm> Handle(GetTwitterStatisticDetailQuery request, CancellationToken cancellationToken)
        {
            var @twitterStatistic = await _twitterStatisticRepository.GetByIdAsync(request.Id);
            var @twitterStatisticDetailDto = _mapper.Map<TwitterStatisticDetailVm>(@twitterStatistic);

            return @twitterStatisticDetailDto;
        }
    }