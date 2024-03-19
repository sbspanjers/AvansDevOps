using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Adapter.DevOpsAdapter;

public class DevOpsAdapter : IAvansDevOps
{

    private DevOpsSystem adaptee;

    public DevOpsAdapter()
    {
        this.adaptee = new DevOpsSystem();
    }

    public void Build()
    {
        this.adaptee.Build();
    }

    public void GetAnalysis()
    {
        this.adaptee.Analyse();
    }

    public void Deploy()
    {
        this.adaptee.Deploy();
    }

    public void GetPackages()
    {
        this.adaptee.Package();
    }

    public void GetSources()
    {
        this.adaptee.Sources();
    }

    public void GetUtilities()
    {
        this.adaptee.Utility();
    }

    public void RunTests()
    {
        this.adaptee.Test();
    }
}
