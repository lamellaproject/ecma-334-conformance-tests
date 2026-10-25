/*
Rules: P10-handler-bad-name
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: [InterpolatedStringHandlerArgument("absent")]
Into: [InterpolatedStringHandlerArgument("number")]
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
    static void Accept(int number, [InterpolatedStringHandlerArgument("absent")] Capture item) { }
    static void Main() { Accept(2, $"{5}"); }
}
