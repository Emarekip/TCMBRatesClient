using System.Xml.Serialization;

namespace TCMBRatesClient.Models;

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
    public required string NameTr { get; set; }

    [XmlElement("CurrencyName")]
    public required string CurrencyName { get; set; }
    
    [XmlElement("ForexBuying")]
    public string? ForexBuyingRaw { get; set; }
    
    [XmlIgnore]
    public decimal? ForexBuying => decimal.TryParse(ForexBuyingRaw?.Replace(".",","), out var value) ? value : null;
    
    [XmlElement("ForexSelling")]
    public string? ForexSellingRaw { get; set; }
    
    [XmlIgnore]
    public decimal? ForexSelling => decimal.TryParse(ForexSellingRaw?.Replace(".",","), out var value) ? value : null;
    
    [XmlElement("BanknoteBuying")]
    public string? BanknoteBuyingRaw { get; set; }
    
    [XmlIgnore]
    public decimal? BanknoteBuying => decimal.TryParse(BanknoteBuyingRaw?.Replace(".",","), out var value) ? value : null;
    
    [XmlElement("BanknoteSelling")]
    public string? BanknoteSellingRaw { get; set; }
    
    [XmlIgnore]
    public decimal? BanknoteSelling => decimal.TryParse(BanknoteSellingRaw?.Replace(".",","), out var value) ? value : null;
    
    [XmlElement("CrossRateUSD")]
    public string? CrossRateUsdRaw { get; set; }
    
    [XmlIgnore]
    public decimal? CrossRateUsd => decimal.TryParse(CrossRateUsdRaw?.Replace(".",","), out var value) ? value : null;
    
    [XmlElement("CrossRateOther")]
    public string? CrossRateOtherRaw { get; set; }
    
    [XmlIgnore]
    public decimal? CrossRateOther => decimal.TryParse(CrossRateOtherRaw?.Replace(".",","), out var value) ? value : null;
}
