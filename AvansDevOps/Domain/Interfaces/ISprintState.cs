namespace AvansDevOps.Domain.Interfaces;

public interface ISprintState
{
    void NextPhase();

    Sprint EditSprintMetaData(string name, DateTime startDate, DateTime endDate);

    void GotToAfterFinishedState();

    string ToString();

    void CreateReview(string message);

    void FinishSprint();

    void UploadDocument(string documentName, string documentContent);
}
