using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Adapter.GitAdapter;

public class GitAdapter : IGit
{

    private GitSharp adaptee;

    public GitAdapter()
    {
        this.adaptee = new GitSharp();
    }
    public void Branch()
    {
        this.adaptee.Branch();
    }

    public void Clone()
    {
            this.adaptee.Clone();
    }

    public void Commit()
    {
        this.adaptee.Commit();
        
    }

    public void Fetch()
    {
        this.adaptee.Fetch();
    }

    public void Merge()
    {
        this.adaptee.Merge();
    }

    public void NewBranch()
    {
        this.adaptee.NewBranch();
    }

    public void Pull()
    {
        this.adaptee.Pull();
    }

    public void Push()
    {
        this.adaptee.Push();
        
    }

    public void Stage()
    {
        this.adaptee.Stage();
    }
}
