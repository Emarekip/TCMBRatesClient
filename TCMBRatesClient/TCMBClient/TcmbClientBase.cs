using TCMBRatesClient.Models;

namespace TCMBRatesClient.TCMBClient;

public abstract class TcmbClientBase : ITcmbClient
{
    public abstract Task<IEnumerable<Currency>> GetTodayRatesAsync(CurrencyFilter? filter = null, CancellationToken cancellationToken = default);
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
}
