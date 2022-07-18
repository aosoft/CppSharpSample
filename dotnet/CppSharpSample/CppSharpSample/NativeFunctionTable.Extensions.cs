using System.Runtime.InteropServices;

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
        
        public static NativeFunctionTable CreateNativeFunctionTableWithContext(CppSharpSample.INativeInterface csharp)
        {
            var ret = new NativeFunctionTable();
            ret.Destroy = static contextPtr =>
            {
                var context = GCHandle.FromIntPtr(contextPtr).Target as CppSharpSample.INativeInterface;
                context?.Dispose();
            };
            ret.GetValue = static contextPtr =>
            {
                var context = GCHandle.FromIntPtr(contextPtr).Target as CppSharpSample.INativeInterface;
                return context?.Value ?? 0;
            };
            ret.SetValue = static (contextPtr, value) =>
            {
                var context = GCHandle.FromIntPtr(contextPtr).Target as CppSharpSample.INativeInterface;
                if (context != null)
                {
                    context.Value = value;
                }
            };
            ret.Print = static contextPtr =>
            {
                var context = GCHandle.FromIntPtr(contextPtr).Target as CppSharpSample.INativeInterface;
                context?.Print();
            };
            
            return ret;
        }
    }
}