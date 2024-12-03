using TCMBRatesClient.Models;
using TCMBRatesClient.TCMBClient;
using Xunit.Abstractions;

namespace TCMBRatesClient.Tests;

public class TcmbClientTest(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task TcmbClient_GetRatesAsync_Test()
    {
        var client = new TcmbClient();

        var rates = await client.GetTodayRatesAsync();

        foreach (var rate in rates)
        {
            testOutputHelper.WriteLine($"{rate.NameTr} - {rate.ForexBuying} - {rate.ForexSelling}");
        }

        Assert.NotNull(rates);
    }

    [Fact]
    public async Task TcmbClient_GetRatesAsync_With_Filter_Test()
    {
        var client = new TcmbClient();

        var filter = new CurrencyFilter
        {
            CurrencyCode = "USD"
        };

        var rates = await client.GetTodayRatesAsync(filter, CancellationToken.None);

        var currencies = rates as Currency[] ?? rates.ToArray();

        Assert.NotEmpty(currencies);

        foreach (var rate in currencies)
            testOutputHelper.WriteLine($"{rate.NameTr} - {rate.ForexBuying} - {rate.ForexSelling}");

        Assert.All(currencies, rate => Assert.Equal("USD", rate.CurrencyCode));
    }

    [Fact]
    public async Task TcmbClient_GetRatesAsync_With_Cancellation_Test()
    {
        var client = new TcmbClient();

        var cts = new CancellationTokenSource();
        cts.CancelAfter(100);

        await Assert.ThrowsAsync<TaskCanceledException>(async () => { await client.GetTodayRatesAsync(cts.Token); });
    }
}