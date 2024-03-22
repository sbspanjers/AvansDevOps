using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsTests.Domain.Adapter;

public class GitAdapterTest
{
    [Fact]
    public void GitAdapterCloneTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IGit git = new GitAdapter();
        // Act

        git.Clone();
        string expectedOutput = "Clone";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void GitAdapterCommitTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IGit git = new GitAdapter();
        // Act

        git.Commit();
        string expectedOutput = "Commit";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void GitAdapterFetchTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IGit git = new GitAdapter();
        // Act

        git.Fetch();
        string expectedOutput = "Fetch";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void GitAdapterMergeTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IGit git = new GitAdapter();
        // Act

        git.Merge();
        string expectedOutput = "Merge";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void GitAdapterNewBranchTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IGit git = new GitAdapter();
        // Act

        git.NewBranch();
        string expectedOutput = "NewBranch";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void GitAdapterPullTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IGit git = new GitAdapter();
        // Act

        git.Pull();
        string expectedOutput = "Pull";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void GitAdapterPushTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IGit git = new GitAdapter();
        // Act

        git.Push();
        string expectedOutput = "Push";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void GitAdapterStageTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IGit git = new GitAdapter();
        // Act

        git.Stage();
        string expectedOutput = "Stage";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void GitAdapterBranchTest()
    {
        using StringWriter sw = new();
        // Arrange
        Console.SetOut(sw);
        IGit git = new GitAdapter();
        // Act

        git.Branch();
        string expectedOutput = "Branch";

        // Assert
        Assert.Contains(expectedOutput, sw.ToString());
    }

}
