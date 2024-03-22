using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Export;

public class ExportPNG : IExportMethod
{
    public void Export(Sprint sprint)
    {
        Console.WriteLine("Exporting to PNG...\n~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Sprint Details:\n");
        Console.WriteLine($"Sprint: {sprint.Name}");
        Console.WriteLine($"Start date: {sprint.StartDate}");
        Console.WriteLine($"End date: {sprint.EndDate}");

        Console.WriteLine("\nBacklog Items:");
        foreach (var item in sprint.BacklogItems)
        {
            Console.WriteLine("- " + item.getName());
        }

        Console.WriteLine("\nUsers:");
        foreach (var user in sprint.Users)
        {
            Console.WriteLine("- " + user.Name);
        }

        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~\nExporting to PNG done!");

    }
}
