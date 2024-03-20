using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.Interfaces;

public interface SprintFactory
{
     Sprint CreateSprint(string name, DateTime startDate, DateTime endDate);
}
