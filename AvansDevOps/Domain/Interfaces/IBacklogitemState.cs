﻿namespace AvansDevOps.Domain.Interfaces;

public interface IBacklogitemState
{
    void NextPhase();

    void GoToToDo();

    void GoToReadyForTesting();

    void EditMetaDataBacklogitem();
}
