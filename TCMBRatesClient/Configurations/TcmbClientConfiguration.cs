using Microsoft.Extensions.DependencyInjection;
using TCMBRatesClient.TCMBClient;

namespace TCMBRatesClient.Configurations;

public static class TcmbClientConfiguration
{
    public static IServiceCollection AddTcmbClient(this IServiceCollection services)
    {
        services.AddScoped<ITcmbClient,TcmbClient>();

        return services;
    }
}
