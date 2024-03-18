using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Domain.Interfaces;

public interface IAvansDevOps
{
    void GetSources();

    void GetPackages();

    void Build();

    void RunTests();

    void GetAnalysis();

    void GetDeployments();

    void GetUtilities();


}
