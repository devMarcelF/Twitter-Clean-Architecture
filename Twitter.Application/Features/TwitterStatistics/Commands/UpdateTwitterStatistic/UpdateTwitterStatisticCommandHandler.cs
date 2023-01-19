using AutoMapper;
using MediatR;
using Twitter.Application.Contracts.Persistence;
using Twitter.Application.Exceptions;
using Twitter.Domain.Entities;

namespace Twitter.Application.Features.TwitterStatistics.Commands.UpdateTwitterStatistic
{
    public class UpdateTwitterStatisticCommandHandler : IRequestHandler<UpdateTwitterStatisticCommand>
    {
        private readonly IAsyncRepository<TwitterStatistic> _twitterStatisticRepository;
        private readonly IMapper _mapper;

        public UpdateTwitterStatisticCommandHandler(IMapper mapper, IAsyncRepository<TwitterStatistic> twitterStatisticRepository)
        {
            _mapper = mapper;
            _twitterStatisticRepository = twitterStatisticRepository;
        }

        public async Task<Unit> Handle(UpdateTwitterStatisticCommand request, CancellationToken cancellationToken)
        {

            var twitterStatisticToUpdate = await _twitterStatisticRepository.GetByIdAsync(request.Id);
            if (twitterStatisticToUpdate == null)
            {
                throw new NotFoundException(nameof(twitterStatisticToUpdate), request.Id);
            }

            var validator = new UpdateTwitterStatisticCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, twitterStatisticToUpdate, typeof(UpdateTwitterStatisticCommand), typeof(TwitterStatistic));

            await _twitterStatisticRepository.UpdateAsync(twitterStatisticToUpdate);

            return Unit.Value;
        }
    }
}