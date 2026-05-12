using System.Reflection;

namespace Flpcoliveira.TemplateMethodExporter.Abstractions;

public abstract class Exporter<T>(IEnumerable<T> data) where T : class
{
    protected readonly Type _dataType = typeof(T);

    protected abstract Document CreateDocument(IEnumerable<T> data, IEnumerable<ColumnMetadata> metadata);

    public Document ExportDocument()
    {
        var metadata = ExtractColumnMetadata();        
        var document = CreateDocument(data, metadata);
        return document;
    }    

    private IEnumerable<ColumnMetadata> ExtractColumnMetadata()
    {
        return _dataType
        .GetProperties()
        .Where(x =>
        {
            var attribute = x.GetCustomAttribute<ColumnAttribute>();
            return attribute is null || !attribute.Ignore;
        })
        .Select(p =>
        {
            var attribute = p.GetCustomAttribute<ColumnAttribute>();
            return new ColumnMetadata
            {
                Name = p.Name,
                Label = attribute?.Label ?? p.Name,
                Format = attribute?.Format ?? ColumnFormatOptions.Text,
            };
        });
    }
}