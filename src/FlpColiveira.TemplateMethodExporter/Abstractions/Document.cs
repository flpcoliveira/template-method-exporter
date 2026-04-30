namespace Flpcoliveira.TemplateMethodExporter.Abstractions;

public abstract class Document
{
    public abstract string MimeType { get; }
    public string Name { get; init; } = string.Empty;
    public byte[] Content { get; set; } = [];
}