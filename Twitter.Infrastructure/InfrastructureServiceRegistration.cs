using Microsoft.Extensions.DependencyInjection;
using Twitter.Application.Contracts.Infrastructure;
using Twitter.Application.Models.Mail;
using Twitter.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Twitter.Infrastructure.FileExport;

namespace Twitter.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<ICsvExporter, CsvExporter>();
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
