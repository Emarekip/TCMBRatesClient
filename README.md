# TcmbExchangeRates

**TcmbExchangeRates** is a .NET library for fetching exchange rates from the Central Bank of Turkey (TCMB). This package simplifies retrieving hourly exchange rate data as XML from the TCMB's official service.

---

## Features
- Fetch exchange rate data for specific dates and times.
- Parse XML responses into strongly-typed models.
- Easy integration with .NET applications.

---

## Installation

Install the package via NuGet Package Manager:

```bash
dotnet add package TcmbExchangeRates
```

Or use the Visual Studio NuGet Package Manager UI to search for TcmbExchangeRates.

Usage

Basic Example

Below is an example of fetching exchange rate data for a specific date and time:

```csharp
using TcmbExchangeRates;

var client = new TcmbClient();
var response = await client.GetExchangeRatesAsync(year: 2024, month: 11, day: 25, hour: 15);

foreach (var rate in response.ExchangeRates)
{
    Console.WriteLine($"Currency: {rate.CurrencyCode}, Buy Rate: {rate.BuyRate}");
}
```

Get Exchange Rates for Current Date

To fetch the latest hourly rates:
    
```csharp
var response = await client.GetExchangeRatesAsync(DateTime.UtcNow);
Console.WriteLine(response.ExchangeRates.FirstOrDefault()?.BuyRate);
```

Models

TcmbResponse

The response model contains the following properties:
•	HeaderInfo: Metadata about the response, such as the timestamp.
•	ExchangeRates: A list of ExchangeRate objects.

ExchangeRate

Represents individual exchange rates with:
•	CurrencyCode (e.g., USD, EUR)
•	BuyRate (decimal)


Contribution

Contributions are welcome! If you encounter a bug or have suggestions, please open an issue or submit a pull request on the GitHub repository.

License

This package is licensed under the MIT License. See the LICENSE file for more details.

Contact

For inquiries or support, please contact:
•	Email: emrah.atalay@outlook.com