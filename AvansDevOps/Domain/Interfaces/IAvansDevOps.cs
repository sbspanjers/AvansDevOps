namespace AvansDevOps.Domain.Interfaces;

public interface IAvansDevOps
{
    void GetSources();

    void GetPackages();

    void Build();

    void RunTests();

    void GetAnalysis();

    void Deploy();

    void GetUtilities();
}
