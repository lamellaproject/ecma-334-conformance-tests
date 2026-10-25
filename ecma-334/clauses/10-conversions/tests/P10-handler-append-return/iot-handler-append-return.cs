/*
Rules: P10-handler-append-return
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: public int AppendLiteral(string text) { return 1; }
Into: public bool AppendLiteral(string text) { return true; }
*/
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public Capture(int length, int holes) { }
    public int AppendLiteral(string text) { return 1; }
}
class Program
{
    static void Accept(Capture item) { }
    static void Main() { Accept($"ore"); }
}
