using TCMBRatesClient.Exporters.Base;
using TCMBRatesClient.Models;

namespace TCMBRatesClient.TCMBClient;

public abstract class TcmbClientBase
{
    /// <summary>
    /// Get today rates from TCMB
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public abstract Task<IEnumerable<Currency>> GetTodayRatesAsync(CurrencyFilter? filter = null);

    /// <summary>
    /// Get rates by dateTime from TCMB
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public abstract Task<TcmbResponse?> GetHourlyRatesAsync(DateTime dateTime);

    /// <summary>
    /// Export rates
    /// </summary>
    /// <param name="exporter"> Export file type </param>
    /// <param name="filter"></param>
    /// <returns></returns>
    public virtual async Task<ExportResult> ExportRatesAsync(IExporter<Currency> exporter, CurrencyFilter? filter = null)
    {
        var currencyList = await GetTodayRatesAsync(filter);

        return exporter.Export(currencyList);
    }
}
