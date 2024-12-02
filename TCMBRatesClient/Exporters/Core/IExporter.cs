using TCMBRatesClient.Exporters.Enums;

namespace TCMBRatesClient.Exporters.Core;

public interface IExporter<T>
{
    ExportType ExportType { get; }

    ExportResult Export(IEnumerable<T> items);
}