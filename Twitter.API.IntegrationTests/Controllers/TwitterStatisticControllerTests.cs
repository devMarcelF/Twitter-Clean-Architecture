using System.Text.Json;
using Twitter.Application.Features.TwitterStatistics.Queries.GetTwitterStatisticsList;
using Twitter.API.IntegrationTests.Base;

namespace Twitter.API.IntegrationTests.Controllers
{
    public class TwitterStatisticControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public TwitterStatisticControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/twitterStatistic/all");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<TwitterStatisticListVm>>(responseString);

            Assert.IsType<List<TwitterStatisticListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
