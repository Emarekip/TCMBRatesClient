namespace TCMBRatesClient.Exporters.Base;

public sealed record ExportResult
{
    public required byte[] Data { get; set; }
    public required string MimeType { get; set; }
    public required string FileExtension { get; set; }
}
