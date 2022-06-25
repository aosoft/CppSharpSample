namespace CppSharpSample
{
    public sealed class NativeInterfaceCpp : IDisposable
    {
        private readonly CppSharpSampleBinding.Delegates.Action___IntPtr _destroy;
        private readonly CppSharpSampleBinding.Delegates.Func_int___IntPtr _getValue;
        private readonly CppSharpSampleBinding.Delegates.Action___IntPtr_int _setValue;
        private readonly CppSharpSampleBinding.Delegates.Action___IntPtr _print;

        private IntPtr _context;

        public NativeInterfaceCpp()
        {
            var native = CppSharpSampleBinding.header.GetFunctionTable();
            _destroy = native.Destroy;
            _getValue = native.GetValue;
            _setValue = native.SetValue;
            _print = native.Print;
            _context = CppSharpSampleBinding.header.CreateNativeContext();
        }
        
        public void Dispose()
        {
            if (_context != IntPtr.Zero)
            {
                _destroy(_context);
                _context = IntPtr.Zero;
            }
        }

        public int Value
        {
            get => _getValue(_context);
            set => _setValue(_context, value);
        }

        public void Print()
        {
            _print(_context);
        }
    }
}