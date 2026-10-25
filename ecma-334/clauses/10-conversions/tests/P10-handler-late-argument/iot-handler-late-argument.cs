/*
Rules: P10-handler-late-argument
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: Accept(item: $"{5}", number: 2);
Into: Accept(number: 2, item: $"{5}");
*/
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public Capture(int length, int holes, int value) { }
    public void AppendFormatted(int value) { }
}
class Program
{
    static void Accept(int number, [InterpolatedStringHandlerArgument("number")] Capture item) { }
    static void Main() { Accept(item: $"{5}", number: 2); }
}
