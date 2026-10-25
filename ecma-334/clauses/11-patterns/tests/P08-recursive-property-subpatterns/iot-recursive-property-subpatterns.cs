/*
Rules: P08-recursive-property-subpatterns
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 5
Mutate: Child: { Code: 47 }
Into: Child: { Code: 48 }
*/
using System;

class Leaf { public int Code; }
class Packet
{
    public int Tag;
    public Leaf Child;
    public int Reads;
    public int Weight { get { Reads++; return 6; } }
}
class Program
{
    static int checks, failures, calls;
    static Packet source;
    static Packet Take() { calls++; return source; }
    static bool Matches() { return Take() is { Tag: 3, Weight: 6, Child: { Code: 47 }, }; }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        source = new Packet { Tag = 3, Child = new Leaf { Code = 47 } };
        calls = 0;
        Check(Matches() && calls == 1 && source.Reads == 1, "nested-success-reads");
        source.Tag = 4;
        Check(!Matches(), "field-mismatch");
        source.Tag = 3; source.Child.Code = 8;
        Check(!Matches(), "nested-field-mismatch");
        source.Child = null;
        Check(!Matches(), "nested-null");
        source = null; calls = 0;
        Check(!Matches() && calls == 1, "outer-null-single-input");
        // A failed match may omit or reorder member reads; no such order is asserted.
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
