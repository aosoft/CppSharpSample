namespace CppSharpSample
{
    public sealed class NativeInterface : IDisposable
    {
        private readonly CppSharpSampleBinding.NativeFunctionTable _native;
        private readonly CppSharpSampleBinding.Delegates.Func_int___IntPtr _getValue;
        private readonly CppSharpSampleBinding.Delegates.Action___IntPtr_int _setValue;
        private readonly CppSharpSampleBinding.Delegates.Action___IntPtr _print;

        private IntPtr _context;

        public NativeInterface()
        {
            _native = CppSharpSampleBinding.header.GetFunctionTable();
            _getValue = _native.GetValue;
            _setValue = _native.SetValue;
            _print = _native.Print;
            _context = CppSharpSampleBinding.header.CreateNativeContext();
        }
        
        public void Dispose()
        {
            if (_context != IntPtr.Zero)
            {
                _native.Destroy(_context);
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