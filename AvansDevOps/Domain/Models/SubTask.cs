namespace AvansDevOps.Domain.Models;

public class SubTask
{
    public string Name { get; set; }

    public SubTask(string name)
    {
        this.Name = name;
    }
}