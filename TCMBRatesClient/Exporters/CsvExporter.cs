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
        bool isFirstIteration = true;
        StringBuilder sb = new StringBuilder();
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (T item in items)
        {
            if (item is null) continue;

            string[] propertyNames = item.GetType().GetProperties().Select(p => p.Name).ToArray();
            foreach (var prop in propertyNames)
            {
                if (isFirstIteration == true)
                {
                    for (int j = 0; j < propertyNames.Length; j++)
                    {
                        sb.Append("\"" + propertyNames[j] + "\"" + ',');
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\r\n");
                    isFirstIteration = false;
                }

                var propertyInfo = item.GetType().GetProperty(prop);

                if (propertyInfo is not null)
                {
                    object? propValue = propertyInfo.GetValue(item, null);
                    sb.Append("\"" + propValue + "\"" + ",");
                }
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
