using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Export;

public class ExportPNG : IExportMethod
{
    public void Export(Sprint sprint)
    {
        Console.WriteLine("Exporting to PNG...\n~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Sprint: " + sprint.Name);
        Console.WriteLine("Start date: " + sprint.StartDate);
        Console.WriteLine("End date: " + sprint.EndDate);
        Console.WriteLine("Backlog items: " + string.Join(", ", sprint.BacklogItems.Select(x => x.getName())));
        Console.WriteLine("Users: " + string.Join(", ", sprint.Users.Select(x => x.Name)));
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~\nExporting to PNG done!");
    }
}
