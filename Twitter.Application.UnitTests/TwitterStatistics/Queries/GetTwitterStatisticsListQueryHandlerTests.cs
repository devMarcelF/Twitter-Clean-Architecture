using AutoMapper;
using Moq;
using Shouldly;
using Twitter.Application.Contracts.Persistence;
using Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsList;
using Twitter.Application.Profiles;
using Twitter.Application.UnitTests.Mocks;
using Twitter.Domain.Entities;

namespace Twitter.Application.UnitTests.TwitterStatistics.Queries
{
    public class GetTwitterStatisticsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<TwitterStatistic>> _mockTwitterStatisticRepository;

        public GetTwitterStatisticsListQueryHandlerTests()
        {
            _mockTwitterStatisticRepository = RepositoryMocks.GetTwitterStatisticRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetTwitterStatisticsListTest()
        {
            var handler = new GetTwitterStatisticsListQueryHandler(_mapper, _mockTwitterStatisticRepository.Object);

            var result = await handler.Handle(new GetTwitterStatisticsListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<TwitterStatisticListVm>>();

            result.Count.ShouldBe(3);
        }
    }
}
