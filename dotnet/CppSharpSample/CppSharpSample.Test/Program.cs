using CppSharpSample;

Console.WriteLine(Static.Sum(1, 2));
Console.WriteLine(Static.Sum2((a, b) => a + b, 3, 4));

using var intf = new NativeInterface();

intf.Value = 10;
Console.WriteLine(intf.Value);
intf.Print();