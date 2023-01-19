using Twitter.Application.Models.Mail;

namespace Twitter.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
