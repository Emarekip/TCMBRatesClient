using TCMBRatesClient.Models;

namespace TCMBRatesClient.TCMBClient;

public interface ITcmbClient
{
    /// <summary>
    ///     Get today rates from TCMB
    /// </summary>
    Task<IEnumerable<Currency>> GetTodayRatesAsync();

    /// <summary>
    ///     Get today rates from TCMB
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    Task<IEnumerable<Currency>> GetTodayRatesAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Get today rates from TCMB
    /// </summary>
    /// <param name="filter">Currency filter</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    Task<IEnumerable<Currency>> GetTodayRatesAsync(CurrencyFilter? filter, CancellationToken cancellationToken);
}