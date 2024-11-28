namespace TCMBRatesClient.Exporters.Base;

public interface IExporter<T>
{
    ExportResult Export(IEnumerable<T> items);
}