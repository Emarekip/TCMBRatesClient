using Microsoft.Extensions.DependencyInjection;
using TCMBRatesClient.Exporters.Core;
using TCMBRatesClient.TCMBClient;

namespace TCMBRatesClient.Configurations;

public static class TcmbClientConfiguration
{
    public static IServiceCollection AddTcmbClient(this IServiceCollection services)
    {
        services.AddScoped<TcmbClient>();

        services.AddScoped(typeof(IExporter<>));

        return services;
    }
}
