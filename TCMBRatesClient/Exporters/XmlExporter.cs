using System.Text;
using System.Xml.Serialization;
using TCMBRatesClient.Exporters.Core;
using TCMBRatesClient.Exporters.Enums;

namespace TCMBRatesClient.Exporters;

public class XmlExporter<T> : IExporter<T>
{
    public ExportType ExportType => ExportType.Xml;

    public ExportResult Export(IEnumerable<T> items)
    {
        XmlSerializer serializer = new(typeof(List<T>));

        var stringWriter = new StringWriter();
        serializer.Serialize(stringWriter, items.ToList());

        return new ExportResult
        {
            Data = Encoding.UTF8.GetBytes(stringWriter.ToString()),
            MimeType = "text/xml",
            FileExtension = ".xml"
        };
    }
}