using System.Xml.Serialization;
using TCMBRatesClient.Models;

namespace TCMBRatesClient.TCMBClient;

public class TcmbClient(HttpClient httpClient)
{
    private const string BaseUrl = "https://www.tcmb.gov.tr/reeskontkur/";

    public async Task<TcmbResponse?> GetRatesAsync(DateTime dateTime)
    {
        dateTime = GetDateTime(dateTime);

        var url = $"{BaseUrl}{dateTime:yyyy}{dateTime:MM}/{dateTime:dd}{dateTime:MM}{dateTime:yyyy}-{dateTime:HH}00.xml";

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
}
