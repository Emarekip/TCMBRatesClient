using System.Xml.Serialization;

namespace TCMBRatesClient.Models;

public record ExchangeRate
{
    [XmlElement("doviz_cinsi")]
    public required string CurrencyCode { get; set; }

    [XmlElement("alis")]
    public required string BuyRate { get; set; }
}
