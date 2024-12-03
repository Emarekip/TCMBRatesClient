using System.Xml.Serialization;
using TCMBRatesClient.Models;

namespace TCMBRatesClient.TCMBClient;

public abstract class TcmbClientBase : ITcmbClient
{
    private const string TodayBaseUrl = "https://www.tcmb.gov.tr/kurlar/today.xml";

    public abstract Task<IEnumerable<Currency>> GetTodayRatesAsync();
    public abstract Task<IEnumerable<Currency>> GetTodayRatesAsync(CancellationToken cancellationToken);

    public abstract Task<IEnumerable<Currency>> GetTodayRatesAsync(CurrencyFilter? filter,
        CancellationToken cancellationToken);

    protected async Task<IEnumerable<Currency>> GetXmlDataList(CancellationToken cancellationToken = default)
    {
        using var httpClient = new HttpClient();

        httpClient.BaseAddress = new Uri(TodayBaseUrl);

        var xmlData = await httpClient.GetStringAsync(TodayBaseUrl, cancellationToken);

        using var reader = new StringReader(xmlData);

        var serializer = new XmlSerializer(typeof(TcmbTodayResponse));

        var result = serializer.Deserialize(reader) as TcmbTodayResponse;

        return result?.Currencies ?? [];
    }
}