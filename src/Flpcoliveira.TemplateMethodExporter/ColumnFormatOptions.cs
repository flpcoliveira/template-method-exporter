namespace Flpcoliveira.TemplateMethodExporter;

public enum ColumnFormatOptions
{
    /// <summary>
    /// Default data type, will be treated as text
    /// </summary>
    Text,
    /// <summary>
    /// Format data for integer values, e.g: 1,234,567(en-US) or 1.234.567(pt-BR)
    /// </summary>
    Integer,
    /// <summary>
    /// Format data for decimal values, e.g: 1,234.56(en-US) or 1.234,56(pt-BR)
    /// </summary>
    Decimal,
    /// <summary>
    /// Format data for monetary values. e.g: $1,234.56(en-US) or R$ 1.234,56(pt-BR)
    /// </summary>
    Money,
    /// <summary>
    /// Format data following pattern dd/MM/yyyy HH:mm:ss, e.g: 31/12/2024 14:30:00
    /// </summary>
    DateTime,
    /// <summary>
    /// Format data following pattern dd/MM/yyyy, e.g: 31/12/2024
    /// </summary>
    Date,
    /// <summary>
    /// Format data following pattern HH:mm:ss, e.g: 14:30:00
    /// </summary>
    Time,
    /// <summary>
    /// Format data following pattern HH:mm, e.g: 14:30
    /// </summary>
    ShortTime,
    /// <summary>    
    /// Format data for boolean values
    /// </summary>
    Boolean
}