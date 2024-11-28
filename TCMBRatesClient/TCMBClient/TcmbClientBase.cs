using TCMBRatesClient.Exporters.Core;
using TCMBRatesClient.Models;

namespace TCMBRatesClient.TCMBClient;

public abstract class TcmbClientBase
{
    /// <summary>
    /// Get today rates from TCMB
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public abstract IEnumerable<Currency> GetTodayRates(CurrencyFilter? filter = null);

    /// <summary>
    /// Export rates
    /// </summary>
    /// <param name="exporter"> Export file type </param>
    /// <param name="filter"></param>
    /// <returns></returns>
    public virtual ExportResult ExportRatesAsync(IExporter<Currency> exporter, CurrencyFilter? filter = null)
    {
        var currencyList = GetTodayRates(filter);

        return exporter.Export(currencyList);
    }
}
