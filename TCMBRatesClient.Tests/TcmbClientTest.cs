using TCMBRatesClient.TCMBClient;
using Xunit.Abstractions;

namespace TCMBRatesClient.Tests;

public class TcmbClientTest
{
    [Fact]
    public void TcmbClient_GetRatesAsync_Test()
    {
        var client = new TcmbClient();

        var rates = client.GetTodayRates();

        Assert.NotNull(rates);
    }
}
