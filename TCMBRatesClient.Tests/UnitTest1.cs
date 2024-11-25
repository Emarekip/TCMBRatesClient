using TCMBRatesClient.TCMBClient;

namespace TCMBRatesClient.Tests;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
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
            Console.WriteLine($"{rate.CurrencyCode}: {rate.BuyRate}");
        }

        Assert.NotNull(client);

    }
}
