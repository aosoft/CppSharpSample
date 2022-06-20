using CppSharpSample;

Console.WriteLine(Static.Sum(1, 2));
Console.WriteLine(Static.Sum2((a, b) => a + b, 3, 4));

using var intf = new NativeInterfaceCpp();

intf.Value = 10;
Console.WriteLine(intf.Value);
intf.Print();

var x = new NativeInterfaceCSharp();
Static.TestCallback(x);

class NativeInterfaceCSharp : INativeInterface
{
    
    public void Dispose()
    {
    }

    public int Value { get; set; }

    public void Print()
    {
        Console.WriteLine($"Print {Value}");
    }
}