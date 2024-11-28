using System.Xml.Serialization;
using TCMBRatesClient.Models;

namespace TCMBRatesClient.TCMBClient;

public class TcmbClient(HttpClient httpClient) : TcmbClientBase
{
    private const string HouryBaseUrl = "https://www.tcmb.gov.tr/reeskontkur/";
    private const string TodayBaseUrl = "https://www.tcmb.gov.tr/kurlar/today.xml";
        
    public override async Task<TcmbResponse?> GetHourlyRatesAsync(DateTime dateTime)
    {
        dateTime = GetDateTime(dateTime);

        var url = $"{HouryBaseUrl}{dateTime:yyyy}{dateTime:MM}/{dateTime:dd}{dateTime:MM}{dateTime:yyyy}-{dateTime:HH}00.xml";

        var response = await httpClient.GetStringAsync(url);

        using var reader = new StringReader(response);

        var serializer = new XmlSerializer(typeof(TcmbResponse));

        var result = serializer.Deserialize(reader) as TcmbResponse;

        return result;
    }

    private static DateTime GetDateTime(DateTime dateTime)
    {
        switch (dateTime.Hour)
        {
            case < 10:
                var addDays = dateTime.AddDays(-1);
                return new DateTime(addDays.Year, addDays.Month, addDays.Day, 15, 0, 0);
            case > 15:
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 15, 0, 0);
            default:
                return dateTime;
        }
    }

    public override async Task<IEnumerable<Currency>> GetTodayRatesAsync(CurrencyFilter? filter = null)
    {
        var response = await httpClient.GetStringAsync(TodayBaseUrl);

        using var reader = new StringReader(response);

        var serializer = new XmlSerializer(typeof(Currency[]));

        if (serializer.Deserialize(reader) is not Currency[] result) return [];

        return result;
    }
}
