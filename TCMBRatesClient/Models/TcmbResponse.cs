using System.Xml.Serialization;

namespace TCMBRatesClient.Models;

[XmlRoot("tcmbVeri")]
public record TcmbResponse
{
    [XmlElement("baslik_bilgi")]
    public required HeaderInfo HeaderInfo { get; set; }

    [XmlArray("doviz_kur_liste")]
    [XmlArrayItem("kur")]
    public required List<ExchangeRate> ExchangeRates { get; set; }
}
