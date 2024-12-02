using TCMBRatesClient.TCMBClient;
using Xunit.Abstractions;

namespace TCMBRatesClient.Tests;

public class TcmbClientTest(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task TcmbClient_GetRatesAsync_Test()
    {
        ITcmbClient client = new TcmbClient();

        var rates = await client.GetTodayRatesAsync();

        foreach (var rate in rates)
        {
            testOutputHelper.WriteLine($"{rate.NameTr} - {rate.ForexBuying} - {rate.ForexSelling}");
        }

        Assert.NotNull(rates);
    }
}
