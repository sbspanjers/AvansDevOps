namespace AvansDevOps.Domain.Interfaces;

public interface ISprintState
{
    void NextPhase();

    Sprint EditSprintMetaData(string name, DateTime startDate, DateTime endDate);

    void GotToFinishedState();

    string ToString();

    void CreateReview(string message);
}
