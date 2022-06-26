var currentDir = Environment.CurrentDirectory;
while (true)
{
    var info = Directory.GetParent(currentDir);
    if (info == null)
    {
        break;
    }

    var includeDir = Path.Combine(info.FullName, "cpp", "include");
    if (Directory.Exists(includeDir))
    {
        var outputDir = Path.Combine(info.FullName, "dotnet", "CppSharpSample", "CppSharpSample", "Generated");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        CppSharp.ConsoleDriver.Run(new CppSharpSampleBindgen.Library(includeDir, outputDir));
        break;
    }

    currentDir = info.FullName;
}