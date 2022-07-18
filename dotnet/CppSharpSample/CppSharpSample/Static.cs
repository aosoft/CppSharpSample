using System.Runtime.InteropServices;

namespace CppSharpSample
{
    public static class Static
    {
        public static int Sum(int a, int b) => CppSharpSampleBinding.header.Sum(a, b);

        public static int Sum2(CppSharpSampleBinding.FnSum fn, int a, int b) =>
            CppSharpSampleBinding.header.Sum2(fn, a, b);

        public static void PrintText(string text) => CppSharpSampleBinding.header.print_text(text);
        
        public static void TestCallback(INativeInterface intf)
        {
            //using var native = CppSharpSampleBinding.NativeFunctionTable.CreateNativeFunctionTable(intf);
            //CppSharpSampleBinding.header.TestCallback(native, IntPtr.Zero);

            using var native = CppSharpSampleBinding.NativeFunctionTable.CreateNativeFunctionTableWithContext(intf);

            var h = GCHandle.Alloc(intf);
            var context = GCHandle.ToIntPtr(h);
            try
            {
                CppSharpSampleBinding.header.TestCallback(native, context);
            }
            finally
            {
                h.Free();
            }
        }
    }
}