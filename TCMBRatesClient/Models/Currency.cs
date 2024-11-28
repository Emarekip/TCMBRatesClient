using System.Xml.Serialization;

namespace TCMBRatesClient.Models;

public sealed record Currency
{
    [XmlElement("CurrencyCode")]
    public required string CurrencyCode { get; set; }

    [XmlElement("Unit")]
    public int Unit { get; set; }

    [XmlElement("CurrencyName")]
    public required string CurrenyName { get; set; }

    [XmlElement("Isim")]
    public required string Isim { get; set; }

    [XmlElement("ForexBuying")]
    public decimal ForexBuying { get; set; }

    [XmlElement("ForexSelling")]
    public decimal ForexSelling { get; set; }

    [XmlElement("BanknoteBuying")]
    public decimal? BanknoteBuying { get; set; }

    [XmlElement("BanknoteSelling")]
    public decimal? BanknoteSelling { get; set; }
}
