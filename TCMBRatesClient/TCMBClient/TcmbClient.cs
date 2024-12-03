using TCMBRatesClient.Helpers.Extensions;
using TCMBRatesClient.Models;

namespace TCMBRatesClient.TCMBClient;

public class TcmbClient : TcmbClientBase
{
    public override Task<IEnumerable<Currency>> GetTodayRatesAsync()
    {
        return GetRatesAsync();
    }

    public override Task<IEnumerable<Currency>> GetTodayRatesAsync(CancellationToken cancellationToken)
    {
        return GetRatesAsync(cancellationToken: cancellationToken);
    }

    public override Task<IEnumerable<Currency>> GetTodayRatesAsync(CurrencyFilter? filter,
        CancellationToken cancellationToken)
    {
        return GetRatesAsync(filter, cancellationToken);
    }

    #region GetRates

    private async Task<IEnumerable<Currency>> GetRatesAsync(CurrencyFilter? filter = null,
        CancellationToken cancellationToken = default)
    {
        var currencyList = await GetXmlDataList(cancellationToken);

        if (filter is null)
            return currencyList;

        var query = currencyList.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.CurrencyCode))
            query = query.Where(e =>
                e.CurrencyCode.Contains(filter.CurrencyCode, StringComparison.CurrentCultureIgnoreCase));

        if (!string.IsNullOrWhiteSpace(filter.SearchKey))
            query = query.Where(e =>
                e.NameTr.Contains(filter.SearchKey, StringComparison.CurrentCultureIgnoreCase) ||
                e.CurrencyName.Contains(filter.SearchKey, StringComparison.CurrentCultureIgnoreCase));

        if (filter.Unit.HasValue)
            query = query.Where(e => e.Unit == filter.Unit);

        if (filter.MinForexBuying.HasValue)
            query = query.Where(e => e.ForexBuying >= filter.MinForexBuying);

        if (filter.MaxForexBuying.HasValue)
            query = query.Where(e => e.ForexBuying <= filter.MaxForexBuying);

        if (filter.MinForexSelling.HasValue)
            query = query.Where(e => e.ForexSelling >= filter.MinForexSelling);

        if (filter.MaxForexSelling.HasValue)
            query = query.Where(e => e.ForexBuying >= filter.MaxForexSelling);

        if (filter.MinBanknoteBuying.HasValue)
            query = query.Where(e => e.BanknoteBuying >= filter.MinBanknoteBuying);

        if (filter.MaxBanknoteBuying.HasValue)
            query = query.Where(e => e.BanknoteBuying <= filter.MaxBanknoteBuying);

        if (filter.MinBanknoteSelling.HasValue)
            query = query.Where(e => e.BanknoteSelling >= filter.MinBanknoteSelling);

        if (filter.MaxBanknoteSelling.HasValue)
            query = query.Where(e => e.BanknoteBuying >= filter.MaxBanknoteSelling);

        if (!string.IsNullOrWhiteSpace(filter.OrderBy))
            query = query.DynamicOrder(filter.OrderBy, filter.OrderDirection);

        return query.AsEnumerable();
    }

    #endregion
}