using AvansDevOps.Domain.Export;
using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;

namespace DevOpsTests.Domain.Export;

public class ExportTest
{
    [Fact]
    public void ExportPNGWrites()
    {

        // Arrange
        IExportMethod exportMethod = new ExportPNG();
        Sprint sprint = new DeploymentSprint("Test", DateTime.Now, DateTime.Now);

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            exportMethod.Export(sprint);

            // Assert
            string expectedOutput = $"Exporting to PNG...";
                                    
            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void ExportPDFWrites()
    {
        // Arrange
        IExportMethod exportMethod = new ExportPDF();
        Sprint sprint = new DeploymentSprint("Test", DateTime.Now, DateTime.Now);

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            exportMethod.Export(sprint);

            // Assert
            string expectedOutput = $"Exporting to PDF...";
                                    
            Assert.Contains(expectedOutput, sw.ToString());
        }
    }
}
