using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OptiForge.ClientHost.Robots;

namespace OptiForge.ClientHost;

internal static class Program
{
    [STAThread]
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Only set URLs if Aspire hasn't already set ASPNETCORE_URLS
        if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("ASPNETCORE_URLS")))
        {
            var urls = builder.Configuration.GetValue<string>("Urls")
                       ?? throw new Exception("Urls must be set in appsettings.json");
            builder.WebHost.UseUrls(urls);
        }

        builder.Services.AddGrpc();
        builder.Services.AddGrpcReflection();

        var app = builder.Build();

        app.MapGrpcService<RobotsGrpcService>();
        app.MapGrpcReflectionService();

        app.MapGet("/health", () => Results.Text("ok"));

        await app.StartAsync();

        ApplicationConfiguration.Initialize();
        Application.Run(new TrayContext());

        await app.StopAsync();
    }
}
