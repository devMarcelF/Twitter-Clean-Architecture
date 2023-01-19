using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Twitter.Application.Contracts.Infrastructure;
using Twitter.Application.Contracts.Persistence;
using Twitter.Application.Models.Mail;
using Twitter.Domain.Entities;

namespace Twitter.Application.Features.TwitterStatistics.Commands.CreateTwitterStatistic
{
    public class CreateTwitterStatisticCommandHandler : IRequestHandler<CreateTwitterStatisticCommand, CreateTwitterStatisticCommandResponse>
    {
        private readonly IAsyncRepository<TwitterStatistic> _twitterStatisticRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateTwitterStatisticCommandHandler> _logger;


        public CreateTwitterStatisticCommandHandler(
            IMapper mapper,
            IAsyncRepository<TwitterStatistic> twitterStatisticRepository)
        {
            _mapper = mapper;
            _twitterStatisticRepository = twitterStatisticRepository;
        }
        public CreateTwitterStatisticCommandHandler(
            IMapper mapper,
            IAsyncRepository<TwitterStatistic> twitterStatisticRepository,
            IEmailService emailService,
            ILogger<CreateTwitterStatisticCommandHandler> logger)
        {
            _mapper = mapper;
            _twitterStatisticRepository = twitterStatisticRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<CreateTwitterStatisticCommandResponse> Handle(CreateTwitterStatisticCommand request, CancellationToken cancellationToken)
        {
            var createTwitterStatisticCommandResponse = new CreateTwitterStatisticCommandResponse();

            var validator = new CreateTwitterStatisticCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createTwitterStatisticCommandResponse.Success = false;
                createTwitterStatisticCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createTwitterStatisticCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createTwitterStatisticCommandResponse.Success)
            {
                var twitterStatistic = new TwitterStatistic() { NumberOfTweets = request.NumberOfTweets, Hashtag = request.Hashtag, CreatedDate = DateTime.UtcNow };
                twitterStatistic = await _twitterStatisticRepository.AddAsync(twitterStatistic);
                createTwitterStatisticCommandResponse.TwitterStatistic = _mapper.Map<CreateTwitterStatisticDto>(twitterStatistic);

            }

            //Sending email notification to admin address
            //var email = new Email() { To = "devmarcelf@outlook.com", Body = $"A new twitter statistic was created: {request}", Subject = "A new twitter statistic was created" };

            //try
            //{
            //    await _emailService.SendEmail(email);
            //}
            //catch (Exception ex)
            //{
            //    //this shouldn't stop the API from doing else so this can be logged
            //    _logger.LogError($"Mailing about twitter statistic {createTwitterStatisticCommandResponse.TwitterStatistic.Id} failed due to an error with the mail service: {ex.Message}");
            //}

            return createTwitterStatisticCommandResponse;
        }
    }
}