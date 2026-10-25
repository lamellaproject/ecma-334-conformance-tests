/*
Rules: P10-handler-missing-constructor
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: public Capture(int length)
Into: public Capture(int length, int holes)
*/
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public Capture(int length) { }
    public void AppendFormatted(int value) { }
}
class Program
{
    static void Accept(Capture item) { }
    static void Main() { Accept($"{5}"); }
}
