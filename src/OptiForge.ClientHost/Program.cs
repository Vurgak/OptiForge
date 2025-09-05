using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace OptiForge.ClientHost;

internal static class Program
{
    [STAThread]
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.Build();

        app.MapGet("/health", () => Results.Text("ok"));

        await app.StartAsync();

        ApplicationConfiguration.Initialize();
        Application.Run(new TrayContext());

        await app.StopAsync();
    }
}
