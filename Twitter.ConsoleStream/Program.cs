using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TwitterStream.Services;
using System.Net.Http;
using System.Reflection;
using TwitterStream.Models;
using Twitter.ConsoleStream.Services;

namespace TwitterStream
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVRIONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();

            var host = Host.CreateDefaultBuilder()
                       .ConfigureServices((context, services) =>
                       {
                           services.AddHostedService<TwitterService>();

                           services.AddSingleton<ITwitterService, TwitterClientService>();

                           services.AddHttpClient<ITwitterDataService, TwitterDataService>(client =>
                           client.BaseAddress = new Uri("https://localhost:7271"));

                       })
                       .Build();

            await host.RunAsync();
        }
    }
}