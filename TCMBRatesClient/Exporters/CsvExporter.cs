using System.Reflection;
using System.Text;
using TCMBRatesClient.Exporters.Core;
using TCMBRatesClient.Exporters.Enums;

namespace TCMBRatesClient.Exporters;

public class CsvExporter<T> : IExporter<T>
{
    public ExportType ExportType => ExportType.Csv;

    public ExportResult Export(IEnumerable<T> items)
    {
        var isFirstIteration = true;
        StringBuilder sb = new ();
        foreach (var item in items)
        {
            if (item is null) continue;

            var propertyNames = item.GetType().GetProperties().Select(p => p.Name).ToArray();
            
            foreach (var prop in propertyNames)
            {
                if (isFirstIteration)
                {
                    foreach (var t in propertyNames)
                    {
                        sb.Append("\"" + t + "\"" + ',');
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\r\n");
                    isFirstIteration = false;
                }

                var propertyInfo = item.GetType().GetProperty(prop);

                if (propertyInfo is null) continue;
                
                var propValue = propertyInfo.GetValue(item, null);
                
                sb.Append("\"" + propValue + "\"" + ",");
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append("\r\n");
        }

        return new ExportResult
        {
            Data = Encoding.UTF8.GetBytes(sb.ToString()),
            MimeType = "text/csv",
            FileExtension = ".csv"
        };
    }
}
