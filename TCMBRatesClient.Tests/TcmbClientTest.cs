using TCMBRatesClient.TCMBClient;

namespace TCMBRatesClient.Tests;

public class TcmbClientTest
{
    [Fact]
    public async Task TcmbClient_GetRatesAsync_Test()
    {
        var client = new TcmbClient(new HttpClient());

        var rates = await client.GetTodayRatesAsync();

        Assert.NotNull(rates);
    }
}
