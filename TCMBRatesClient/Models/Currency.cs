using System.Xml.Serialization;

namespace TCMBRatesClient.Models;

[XmlRoot("Tarih_Date")]
public sealed record TcmbTodayResult
{
    [XmlAttribute("Tarih")]
    public required string DateTR { get; set; }

    [XmlAttribute("Date")]
    public required string Date { get; set; }

    [XmlAttribute("Bulten_No")]
    public required string BultenNo { get; set; }

    [XmlElement("Currency")]
    public List<Currency>? Currencies { get; set; }
}

public sealed record Currency
{
    [XmlAttribute("CrossOrder")]
    public int CrossOrder { get; set; }

    [XmlAttribute("Kod")]
    public required string Code { get; set; }

    [XmlAttribute("CurrencyCode")]
    public required string CurrencyCode { get; set; }

    [XmlElement("Unit")]
    public int Unit { get; set; }

    [XmlElement("Isim")]
    public required string NameTR { get; set; }

    [XmlElement("CurrencyName")]
    public required string CurrencyName { get; set; }

    [XmlElement("ForexBuying")]
    public decimal? ForexBuying { get; set; }

    [XmlElement("ForexSelling")]
    public decimal? ForexSelling { get; set; }

    [XmlElement("BanknoteBuying")]
    public decimal? BanknoteBuying { get; set; }

    [XmlElement("BanknoteSelling")]
    public decimal? BanknoteSelling { get; set; }

    [XmlElement("CrossRateUSD")]
    public decimal? CrossRateUSD { get; set; }

    [XmlElement("CrossRateOther")]
    public decimal? CrossRateOther { get; set; }
}
