/*
Rules: P10-handler-ref; P10-handler-result
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: Consume($"q{7}");
Into: Consume($"q{8}");
*/
using System;
using System.Runtime.CompilerServices;
[InterpolatedStringHandler]
struct Capture
{
    public int Number, Literals;
    public Capture(int length, int holes) { Number = 0; Literals = 0; }
    public void AppendLiteral(string text) { Literals += text.Length; }
    public void AppendFormatted(int value) { Number = value; }
}
class Program
{
    static int checks, failures, calls, observed;
    static void Consume(ref Capture item) { calls++; item.Number += 5; observed = item.Number + item.Literals; }
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static int Main()
    {
        Consume($"q{7}");
        Check(calls == 1, "ref-call");
        Check(observed == 13, "ref-temporary-content");
        Capture local = $"{3}";
        Consume(ref local);
        Check(local.Number == 8, "ordinary-ref-still-aliases");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
