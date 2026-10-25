/*
Rules: P10-handler-ambiguity
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: Route($"t{3}");
Into: Route((First)$"t{3}");
*/
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct First
{
    public First(int length, int holes) { }
    public void AppendLiteral(string text) { }
    public void AppendFormatted(int value) { }
}
[InterpolatedStringHandler]
struct Second
{
    public Second(int length, int holes) { }
    public void AppendLiteral(string text) { }
    public void AppendFormatted(int value) { }
}
class Program
{
    static void Route(First item) { }
    static void Route(Second item) { }
    static void Main() { Route($"t{3}"); }
}
