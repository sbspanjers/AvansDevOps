using AvansDevOps.Domain.Adapter.DevOpsAdapter;
using AvansDevOps.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsTests.Domain.Adapter;

public class DevOpsAdapterTest
{
    [Fact]
    public void DevOpsAdapterBuildTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IAvansDevOps devOps = new DevOpsAdapter();
        // Act

        devOps.Build();


        // Assert
        string expectedOutput = "Build";

        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void DevOpsAdapterGetAnalysisTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IAvansDevOps devOps = new DevOpsAdapter();
        // Act

        devOps.GetAnalysis();
        string expectedOutput = "Analyse";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());

    }

    [Fact]
    public void DevOpsAdapterDeployTest()
    {
        using StringWriter sw = new();
        // Arrange
        IAvansDevOps devOps = new DevOpsAdapter();
        Console.SetOut(sw);
        // Act

        devOps.Deploy();
        string expectedOutput = "DEVOPS_SYSTEM: Deploy";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void DevOpsAdapterGetPackagesTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IAvansDevOps devOps = new DevOpsAdapter();
        // Act

        devOps.GetPackages();
        string expectedOutput = "Package";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void DevOpsAdapterGetSourcesTest()
    {
        using StringWriter sw = new StringWriter();
        // Arrange
        IAvansDevOps devOps = new DevOpsAdapter();
        Console.SetOut(sw);
        // Act

        devOps.GetSources();
        string expectedOutput = "Sources";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void DevOpsAdapterGetUtilitiesTest()
    {
        using StringWriter sw = new();
        // Arrange
        IAvansDevOps devOps = new DevOpsAdapter();
        Console.SetOut(sw);
        // Act

        devOps.GetUtilities();
        string expectedOutput = "Utility";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void DevOpsAdapterRunTestsTest()
    {
        using StringWriter sw = new();
        // Arrange
        IAvansDevOps devOps = new DevOpsAdapter();
        Console.SetOut(sw);
        // Act

        devOps.RunTests();
        string expectedOutput = "Test";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }
}
