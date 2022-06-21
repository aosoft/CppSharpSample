using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;

namespace CppSharpSampleBindgen
{
    class Library : ILibrary
    {
        private readonly string _includePath;
        private readonly string _outputPath;

        public Library(string includePath, string outputPath)
        {
            _includePath = includePath;
            _outputPath = outputPath;
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
        }

        public void Setup(Driver driver)
        {
            driver.Options.GeneratorKind = GeneratorKind.CSharp;
            driver.Options.OutputDir = _outputPath;
            var module = driver.Options.AddModule("CppSharpSampleNative");
            module.OutputNamespace = "CppSharpSampleBinding";
            module.IncludeDirs.Add(_includePath);
            module.Headers.Add("header.h");
        }

        public void SetupPasses(Driver driver)
        {
            driver.Generator.Context.ParserOptions.LanguageVersion =
                CppSharp.Parser.LanguageVersion.CPP17;
        }
    }
}