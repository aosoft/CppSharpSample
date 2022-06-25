namespace CppSharpSampleBinding
{
    public partial class NativeFunctionTable
    {
        public static NativeFunctionTable CreateNativeFunctionTable(CppSharpSample.INativeInterface csharp)
        {
            var ret = new NativeFunctionTable();
            ret.Destroy = _ => csharp.Dispose();
            ret.GetValue = _ => csharp.Value;
            ret.SetValue = (_, value) => csharp.Value = value;
            ret.Print = _ => csharp.Print();
            return ret;
        }
    }
}