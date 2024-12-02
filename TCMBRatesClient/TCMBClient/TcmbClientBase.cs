using TCMBRatesClient.Exporters.Core;
using TCMBRatesClient.Models;

namespace TCMBRatesClient.TCMBClient;

public abstract class TcmbClientBase : ITcmbClient
{
    public abstract Task<IEnumerable<Currency>> GetTodayRatesAsync(CurrencyFilter? filter = null, CancellationToken cancellationToken = default);
    
    public virtual async Task<ExportResult> ExportRatesAsync(IExporter<Currency> exporter, CurrencyFilter? filter = null, CancellationToken cancellationToken = default)
    {
        var currencyList = await GetTodayRatesAsync(filter, cancellationToken);

        return exporter.Export(currencyList);
    }
}

public interface ITcmbClient    
{
    /// <summary>
    /// Get today rates from TCMB
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<Currency>> GetTodayRatesAsync(CurrencyFilter? filter = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Export rates
    /// </summary>
    /// <param name="exporter"> Export file type </param>
    /// <param name="filter"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ExportResult> ExportRatesAsync(IExporter<Currency> exporter, CurrencyFilter? filter = null, CancellationToken cancellationToken = default);
}
