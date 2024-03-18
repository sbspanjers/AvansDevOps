using AvansDevOps.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public void GetDeployments()
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
