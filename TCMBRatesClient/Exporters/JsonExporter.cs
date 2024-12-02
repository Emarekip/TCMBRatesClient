using System.Text;
using System.Text.Json;
using TCMBRatesClient.Exporters.Core;
using TCMBRatesClient.Exporters.Enums;

namespace TCMBRatesClient.Exporters;

public class JsonExporter<T> : IExporter<T>
{
    public ExportType ExportType => ExportType.Json;

    public ExportResult Export(IEnumerable<T> items)
    {
        var jsonData = JsonSerializer.Serialize(items);

        return new ExportResult
        {
            Data = Encoding.UTF8.GetBytes(jsonData),
            MimeType = "application/json",
            FileExtension = ".json"
        };
    }
}
