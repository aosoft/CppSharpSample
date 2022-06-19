namespace CppSharpSample
{
    public interface INativeInterface : IDisposable
    {
        int Value { get; set; }
        void Print();
    }
}