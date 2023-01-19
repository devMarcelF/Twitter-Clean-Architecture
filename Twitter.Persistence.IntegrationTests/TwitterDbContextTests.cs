using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.Contracts;
using Twitter.Domain.Entities;

namespace Twitter.Persistence.IntegrationTests
{
    public class TwitterDbContextTests
    {
        private readonly TwitterDbContext _twitterDbContextDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public TwitterDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TwitterDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _twitterDbContextDbContext = new TwitterDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ts = new TwitterStatistic() { Id = 1, Hashtag = "Test Twitter Statistic"};

            _twitterDbContextDbContext.TwitterStatistics.Add(ts);
            await _twitterDbContextDbContext.SaveChangesAsync();

            ts.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
