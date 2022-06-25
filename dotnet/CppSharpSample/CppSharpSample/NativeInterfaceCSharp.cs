namespace CppSharpSample
{
    public static class NativeInterfaceCSharp
    {
        public static CppSharpSampleBinding.NativeFunctionTable CreateNativeFunctionTable(INativeInterface csharp)
        {
            var ret = new CppSharpSampleBinding.NativeFunctionTable();
            ret.Destroy = _ => csharp.Dispose();
            ret.GetValue = _ => csharp.Value;
            ret.SetValue = (_, value) => csharp.Value = value;
            ret.Print = _ => csharp.Print();
            return ret;
        }
    }
}