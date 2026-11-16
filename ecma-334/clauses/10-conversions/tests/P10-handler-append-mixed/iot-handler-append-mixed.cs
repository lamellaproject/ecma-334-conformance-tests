/*
Rules: P10-handler-append-mixed
Authority: csc 5.12.0-1.26529.118 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: public void AppendFormatted(int value) { }
Into: public bool AppendFormatted(int value) { return true; }
*/
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public Capture(int length, int holes) { }
    public bool AppendLiteral(string text) { return true; }
    public void AppendFormatted(int value) { }
}
class Program
{
    static void Accept(Capture item) { }
    static void Main() { Accept($"k{5}"); }
}
