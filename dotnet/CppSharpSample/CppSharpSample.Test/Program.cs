using CppSharpSample;

Console.WriteLine(CppSharpSampleBinding.header.Sum(1, 2));
Console.WriteLine(CppSharpSampleBinding.header.Sum2((a, b) => a + b, 3, 4));

using var intf = new NativeInterface();

intf.Value = 10;
Console.WriteLine(intf.Value);
intf.Print();