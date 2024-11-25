using System.Xml.Serialization;

namespace TCMBRatesClient.Models;

public record HeaderInfo
{
    [XmlElement("kod")]
    public required string Code { get; set; }

    [XmlElement("zaman_etiketi")]
    public required string Timestamp { get; set; }
}
