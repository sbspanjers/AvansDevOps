using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Interfaces;

public interface IGit
{
    public void Commit();

    public void Push();

    public void Pull();

    public void Merge();

    public void Branch();

    public void NewBranch();

    public void Fetch();

    public void Clone();

    public void Stage();
}
