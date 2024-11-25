namespace TCMBRatesClient.TCMBClient;

public static class TcmbRates
{
    public static TcmbClient CreateClient()
    {
        var httpClient = new HttpClient();
        return new TcmbClient(httpClient);
    }
}