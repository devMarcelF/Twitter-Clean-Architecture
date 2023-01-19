using AutoMapper;
using EmptyFiles;
using Moq;
using Shouldly;
using Twitter.Application.Contracts.Persistence;
using Twitter.Application.Features.TwitterStatistics.Commands.CreateTwitterStatistic;
using Twitter.Application.Profiles;
using Twitter.Application.UnitTests.Mocks;
using Twitter.Domain.Entities;

namespace Twitter.Application.UnitTests.TwitterStatistics.Commands
{
    public class CreateTwitterStatisticTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<TwitterStatistic>> _mockTwitterStatisticRepository;

        public CreateTwitterStatisticTests()
        {
            _mockTwitterStatisticRepository = RepositoryMocks.GetTwitterStatisticRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToTwitterStatisticsRepo()
        {
            var handler = new CreateTwitterStatisticCommandHandler(_mapper, _mockTwitterStatisticRepository.Object);

            await handler.Handle(new CreateTwitterStatisticCommand() {NumberOfTweets = 100, Hashtag = "Test" }, CancellationToken.None);

            var allTwitterStatistics = await _mockTwitterStatisticRepository.Object.ListAllAsync();
            allTwitterStatistics.Count.ShouldBe(4);
        }
    }
}
