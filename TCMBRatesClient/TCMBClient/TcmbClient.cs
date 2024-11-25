using System.Xml.Serialization;
using TCMBRatesClient.Models;

namespace TCMBRatesClient.TCMBClient;

public class TcmbClient(HttpClient httpClient)
{
    private const string BaseUrl = "https://www.tcmb.gov.tr/reeskontkur/";

    public async Task<TcmbResponse?> GetRatesAsync(DateTime dateTime)
    {
        if (dateTime.Hour < 10)
        {
            dateTime.AddDays(-1);
            dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 15, 0, 0);
        }
        else if (dateTime.Hour > 15)
            dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 15, 0, 0);

        string url = $"{BaseUrl}{dateTime:yyyy}{dateTime:MM}/{dateTime:dd}{dateTime:MM}{dateTime:yyyy}-{dateTime:HH}00.xml";

        var response = await httpClient.GetStringAsync(url);

        using var reader = new StringReader(response);

        var serializer = new XmlSerializer(typeof(TcmbResponse));

        if (serializer is null) return null;

        var result = serializer!.Deserialize(reader) as TcmbResponse;

        return result;
    }
}
