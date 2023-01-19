using AutoMapper;
using MediatR;
using Twitter.Application.Contracts.Persistence;
using Twitter.Domain.Entities;
using Twitter.Application.Exceptions;

namespace Twitter.Application.Features.TwitterStatistics.Commands.DeleteTwitterStatistic
{
    public class DeleteTwitterStatisticCommandHandler : IRequestHandler<DeleteTwitterStatisticCommand>
    {
        private readonly IAsyncRepository<TwitterStatistic> _twitterStatisticRepository;
        private readonly IMapper _mapper;

        public DeleteTwitterStatisticCommandHandler(IMapper mapper, IAsyncRepository<TwitterStatistic> twitterStatisticRepository)
        {
            _mapper = mapper;
            _twitterStatisticRepository = twitterStatisticRepository;
        }

        public async Task<Unit> Handle(DeleteTwitterStatisticCommand request, CancellationToken cancellationToken)
        {
            var twitterStatisticToDelete = await _twitterStatisticRepository.GetByIdAsync(request.Id);

            if (twitterStatisticToDelete == null)
            {
                throw new NotFoundException(nameof(TwitterStatistic), request.Id);
            }

            await _twitterStatisticRepository.DeleteAsync(twitterStatisticToDelete);

            return Unit.Value;
        }
    }
}