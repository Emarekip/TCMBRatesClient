using System.Reflection;

namespace TCMBRatesClient.Exporters.Base;

public sealed class ExporterFactory
{
    public static IEnumerable<Type> AllExporters()
    {
        var assembly = Assembly.GetAssembly(typeof(IExporter<>)) ?? throw new Exception("Assembly containing IExporter<> could not be found.");

        return from x in assembly.GetTypes()
               from z in x.GetInterfaces()
               let y = x.BaseType
               where
               y != null && y.IsGenericType &&
               typeof(IExporter<>).IsAssignableFrom(y.GetGenericTypeDefinition()) ||
               z.IsGenericType &&
               typeof(IExporter<>).IsAssignableFrom(z.GetGenericTypeDefinition())
               select x;
    }

    public static IEnumerable<string> ExporterNames()
    {
        var allExporter = AllExporters();

        if (!allExporter.Any())
            throw new Exception("Exporter could not be found.");

        return allExporter.Select(e => e.Name.Replace("Exporter", "").Replace("`1", ""));
    }

    public static IExporter<T> Create<T>(string format)
    {
        var exporter = AllExporters().FirstOrDefault(e => e.Name.Contains(format, StringComparison.CurrentCultureIgnoreCase)) ?? throw new Exception("Exporter could not be found.");

        return Activator.CreateInstance(exporter.MakeGenericType(typeof(T))) as IExporter<T> ?? throw new Exception("Failed to create an instance of the exporter.");
    }
}
