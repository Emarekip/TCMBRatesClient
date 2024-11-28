using TCMBRatesClient.TCMBClient;

namespace TCMBRatesClient.Tests;

public class TcmbClientTest
{
    [Fact]
    public void TcmbClient_GetRatesAsync_Test()
    {
        var client = new TcmbClient(new HttpClient());

        var rates = client.GetTodayRatesAsync();

        Assert.NotNull(rates);
    }
}
