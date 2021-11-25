using MauiTwitterApp.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.Hosting;

namespace MauiTwitterApp.Extensions;

internal static class MauiProgramExtensions
{
    public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
    {
        builder.Services.TryAddSingleton<ITweetsService, TweetsService>();
        return builder;
    }
}
