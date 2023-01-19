using MediatR;

namespace Twitter.Application.Features.TwitterStatistics;

public class GetTwitterStatisticDetailQuery : IRequest<TwitterStatisticDetailVm>
{
    public int Id { get; set; }
}