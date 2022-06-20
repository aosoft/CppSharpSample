namespace CppSharpSample
{
    public sealed class NativeInterfaceCSharp
    {
        private readonly INativeInterface _csharp;
        
        private NativeInterfaceCSharp(INativeInterface csharp)
        {
            _csharp = csharp;
        }

        public static CppSharpSampleBinding.NativeFunctionTable CreateNativeFunctionTable(INativeInterface csharp)
        {
            var current = new NativeInterfaceCSharp(csharp);
            var ret = new CppSharpSampleBinding.NativeFunctionTable();
            ret.Destroy = current.Destroy;
            ret.GetValue = current.GetValue;
            ret.SetValue = current.SetValue;
            ret.Print = current.Print;
            return ret;
        }

        private void Destroy(IntPtr context) => _csharp.Dispose();
        
        private int GetValue(IntPtr context) => _csharp.Value;

        private void SetValue(IntPtr context, int value) => _csharp.Value = value;

        private void Print(IntPtr context) => _csharp.Print();
    }
}