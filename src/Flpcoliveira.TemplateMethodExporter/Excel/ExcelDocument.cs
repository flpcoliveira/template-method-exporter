using Flpcoliveira.TemplateMethodExporter.Abstractions;

namespace Flpcoliveira.TemplateMethodExporter.Excel;

public class ExcelDocument : Document
{
    public override string MimeType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
}