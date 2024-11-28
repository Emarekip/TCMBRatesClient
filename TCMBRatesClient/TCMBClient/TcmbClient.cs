using System.Xml.Linq;
using System.Xml.Serialization;
using TCMBRatesClient.Models;

namespace TCMBRatesClient.TCMBClient;

public class TcmbClient(HttpClient httpClient) : TcmbClientBase
{
    private const string HouryBaseUrl = "https://www.tcmb.gov.tr/reeskontkur/";
    private const string TodayBaseUrl = "https://www.tcmb.gov.tr/kurlar/today.xml";

    private IEnumerable<Currency> currencyList = [];
    private DateTime _lastCheckTime;

    public short DataCacheMinute { get; set; }

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

    private IEnumerable<Currency> GetXmlDataList()
    {
        if ((currencyList != null && currencyList.Any()) && (DateTime.Now - _lastCheckTime).TotalMinutes < DataCacheMinute)
            return currencyList;

        XDocument xmlDocument = XDocument.Load(TodayBaseUrl);

        currencyList = xmlDocument.Descendants("Currency")
                               .Select(e => new Currency
                               {
                                   CurrencyCode = e.Attribute("CurrencyCode")?.Value ?? "",
                                   CurrenyName = e.Element("CurrencyName")?.Value ?? "",
                                   Isim = e.Element("Isim")?.Value ?? "",
                                   Unit = int.Parse(e.Element("Unit")?.Value ?? "0"),
                                   ForexBuying = decimal.TryParse(e.Element("ForexBuying")?.Value.Replace(".", ","), out decimal FbPrice) ? FbPrice : 0,
                                   ForexSelling = decimal.TryParse(e.Element("ForexSelling")?.Value.Replace(".", ","), out decimal FsPrice) ? FsPrice : 0,
                                   BanknoteBuying = decimal.TryParse(e.Element("BanknoteBuying")?.Value.Replace(".", ","), out decimal BbPrice) ? BbPrice : null,
                                   BanknoteSelling = decimal.TryParse(e.Element("BanknoteSelling")?.Value.Replace(".", ","), out decimal BsPrice) ? BsPrice : null,
                               });

        _lastCheckTime = DateTime.Now;

        return currencyList;
    }
}
