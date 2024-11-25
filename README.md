# TCMBRatesClient

**TCMBRatesClient** is a .NET library for fetching exchange rates from the Central Bank of Turkey (TCMB). This package simplifies retrieving hourly exchange rate data as XML from the TCMB's official service.

---

## Features
- Fetch exchange rate data for specific dates and times.
- Parse XML responses into strongly-typed models.
- Easy integration with .NET applications.

---

## Installation

Install the package via NuGet Package Manager:

```bash
dotnet add package TCMBRatesClient
```

Or use the Visual Studio NuGet Package Manager UI to search for TCMBRatesClient.

---

## Usage

Basic Example

Below is an example of fetching exchange rate data for a specific date and time:

```csharp
using TCMBRatesClient.TCMBClient;

var client = TcmbRates.CreateClient();
var rates = await client.GetRatesAsync(DateTime.Now);

foreach (var rate in rates.ExchangeRates)
{
    Console.WriteLine($"{rate.CurrencyCode}: {rate.BuyRate}");
}
```
---
## Models

**TcmbResponse**

The response model contains the following properties:
- HeaderInfo: Metadata about the response, such as the timestamp.
- ExchangeRates: A list of ExchangeRate objects.

**ExchangeRate**

Represents individual exchange rates with:
- CurrencyCode (e.g., USD, EUR)
- BuyRate (decimal)


**Contribution**

Contributions are welcome! If you encounter a bug or have suggestions, please open an issue or submit a pull request on the [GitHub](TCMBRatesClient) repository.

---
## License

This package is licensed under the MIT License. See the LICENSE file for more details.

---

## Contact

For inquiries or support, please contact:
- Email: [emrah.atalay@outlook.com](mailto:emrah.atalay@outlook.com)
