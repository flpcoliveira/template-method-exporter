namespace Flpcoliveira.TemplateMethodExporter;

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public class ColumnAttribute : Attribute
{
    /// <summary>
    /// Name displayed in the exported document for this column. If not set, the property name will be used.
    /// </summary>
    public string Label { get; init; } = string.Empty;
    /// <summary>
    /// Indicates whether this column should be ignored in the exported document.
    /// </summary>
    public bool Ignore { get; set; }
}