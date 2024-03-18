using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Adapter.GitAdapter;

// This class serves as a third party library, but is just Stubs

public class GitSharp
{
    public void Commit()
    {
        Console.WriteLine("Commit");
    }

    public void Push()
    {
        Console.WriteLine("Push");
    }

    public void Pull()
    {
        Console.WriteLine("Pull");
    }

    public void Merge()
    {
        Console.WriteLine("Merge");
    }

    public void Branch()
    {
        Console.WriteLine("Branch");
    }

    public void NewBranch()
    {
        Console.WriteLine("NewBranch");
    }

    public void Fetch()
    {
        Console.WriteLine("Fetch");
    }

    public void Clone()
    {
        Console.WriteLine("Clone");
    }

    public void Stage()
    {
        Console.WriteLine("Stage");
    }   
}
