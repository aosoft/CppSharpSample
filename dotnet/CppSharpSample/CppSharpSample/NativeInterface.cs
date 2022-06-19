namespace CppSharpSample
{
    public sealed class NativeInterface : IDisposable
    {
        private readonly CppSharpSampleBinding.Delegates.Action___IntPtr _destroy;
        private readonly CppSharpSampleBinding.Delegates.Func_int___IntPtr _getValue;
        private readonly CppSharpSampleBinding.Delegates.Action___IntPtr_int _setValue;
        private readonly CppSharpSampleBinding.Delegates.Action___IntPtr _print;

        private IntPtr _context;

        public NativeInterface()
        {
            var intf = CppSharpSampleBinding.header.GetFunctionTable();
            _destroy = intf.Destroy;
            _getValue = intf.GetValue;
            _setValue = intf.SetValue;
            _print = intf.Print;
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