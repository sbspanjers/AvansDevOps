﻿using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Export;

public class ExportPNG : IExportMethod
{
    public void Export()
    {
        Console.WriteLine("Exporting to PNG");
    }
}
