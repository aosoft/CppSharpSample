var currentDir = Environment.CurrentDirectory;
while (true)
{
    var info = Directory.GetParent(currentDir);
    if (info == null)
    {
        break;
    }

    var dir = Path.Combine(info.FullName, "cpp", "include");
    if (Directory.Exists(dir))
    {
        var outDir = Path.Combine(info.FullName, "dotnet", "CppSharpSample", "CppSharpSample", "Generated");
        if (!Directory.Exists(outDir))
        {
            Directory.CreateDirectory(outDir);
        }

        CppSharp.ConsoleDriver.Run(new CppSharpSampleBindgen.Library(dir, outDir));
        break;
    }

    currentDir = info.FullName;
}