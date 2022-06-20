namespace CppSharpSample
{
    public static class Static
    {
        public static int Sum(int a, int b) => CppSharpSampleBinding.header.Sum(a, b);

        public static int Sum2(CppSharpSampleBinding.FnSum fn, int a, int b) =>
            CppSharpSampleBinding.header.Sum2(fn, a, b);

        public static void TestCallback(INativeInterface intf)
        {
            using var native = NativeInterfaceCSharp.CreateNativeFunctionTable(intf);
            CppSharpSampleBinding.header.TestCallback(native, IntPtr.Zero);
        }
    }
}