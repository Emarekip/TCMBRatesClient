using TCMBRatesClient.TCMBClient;
using Xunit.Abstractions;

namespace TCMBRatesClient.Tests;

public class TcmbClientTest(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task TcmbClient_GetRatesAsync_Test()
    {
        var client = TcmbRates.CreateClient();
        var rates = await client.GetRatesAsync(DateTime.Now);

        if (rates is null)
        {
            Assert.Null(rates);
            return;
        }

        foreach (var rate in rates.ExchangeRates)
        {
            testOutputHelper.WriteLine($"{rate.CurrencyCode}: {rate.BuyRate}");
        }

        Assert.NotNull(rates);
    }
}
