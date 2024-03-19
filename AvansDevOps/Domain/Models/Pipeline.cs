using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Models;

public class Pipeline
{
    private IAvansDevOps devOps;

    public string Name { get; set; } = string.Empty;

    public void Start()
    {
        // ...
    }

    public void Cancel()
    {
        // ...
    }
}
