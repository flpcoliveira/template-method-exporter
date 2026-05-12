using ClosedXML.Excel;
using Flpcoliveira.TemplateMethodExporter.Abstractions;

namespace Flpcoliveira.TemplateMethodExporter.Excel;


public class ExcelExporter<T>(IEnumerable<T> data) : Exporter<T>(data)
     where T : class
{
     protected override Document CreateDocument(IEnumerable<T> data, IEnumerable<ColumnMetadata> metadata)
     {
          using var workbook = new XLWorkbook();

          var worksheet = workbook.Worksheets.Add("data");
          
          FillHeader(worksheet, metadata);
          FillData(worksheet, data, metadata);

          using var stream = new MemoryStream();
          workbook.SaveAs(stream);
          
          return new ExcelDocument
          {
               Name = $"export-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.xlsx",
               Content = stream.ToArray()
          };
     }

     private static void FillHeader(IXLWorksheet worksheet, IEnumerable<ColumnMetadata> metadata)
     {
          var columnIndex = 1;
          foreach (var column in metadata)
          {
               var cell = worksheet.Cell(1, columnIndex);
               cell.Value = column.Label;
               cell.Style.Font.Bold = true;
               cell.Style.Fill.BackgroundColor = XLColor.LightGray;
               columnIndex++;
          }
     } 
     
     private void FillData(IXLWorksheet worksheet, IEnumerable<T> data, IEnumerable<ColumnMetadata> metadata)
     {
          var rowIndex = 2;
          foreach (var item in data)
          {
               var columnIndex = 1;
               foreach (var column in metadata)
               {
                    var value = _dataType.GetProperty(column.Name)?.GetValue(item);
                    var cell = worksheet.Cell(rowIndex, columnIndex);
                    cell.Value = XLCellValue.FromObject(value);
                    columnIndex++;
               }
               rowIndex++;
          }
     }
}