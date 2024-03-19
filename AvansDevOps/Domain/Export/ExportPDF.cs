using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Export;

public class ExportPDF : IExportMethod
{
    public void Export()
    {
        Console.WriteLine("Exporting to PDF");
    }
}
