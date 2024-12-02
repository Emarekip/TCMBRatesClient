using System.Xml.Serialization;

namespace TCMBRatesClient.Models;

[XmlRoot("Tarih_Date")]
public sealed record TcmbTodayResponse
{
    [XmlAttribute("Tarih")]
    public required string DateTr { get; set; }

    [XmlAttribute("Date")]
    public required string Date { get; set; }

    [XmlAttribute("Bulten_No")]
    public required string BultenNo { get; set; }

    [XmlElement("Currency")]
    public List<Currency>? Currencies { get; set; }
}
