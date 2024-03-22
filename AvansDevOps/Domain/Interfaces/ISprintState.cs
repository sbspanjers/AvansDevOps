namespace AvansDevOps.Domain.Interfaces;

public interface ISprintState
{
    void NextPhase();

    Sprint EditSprintMetaData(string name, DateTime startDate, DateTime endDate);

    void GotToAfterFinishedState(bool deploySuccess);

    string ToString();

    void CreateReview(string message);

    void FinishSprint(bool deploySuccess);

    void UploadDocument(string documentName, string documentContent);
}
