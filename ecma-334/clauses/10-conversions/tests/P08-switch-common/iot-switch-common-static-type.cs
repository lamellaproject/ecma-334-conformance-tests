/*
Rules: P08-switch-common
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: new Parent(23)
Into: new Child(23)
*/
using System;

// patterns.md L297; an overload observes the inferred common type without reflection.
class Parent
{
    public int Marker;
    public Parent(int marker) { Marker = marker; }
}
class Child : Parent { public Child(int marker) : base(marker) { } }
class Program
{
    static int checks, failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Stamp(Parent value) { return 1; }
    static int Stamp(Child value) { return 2; }
    static int Read() { return 0; }
    static int Main()
    {
        var result = Read() switch { 0 => new Child(11), _ => new Parent(23) };
        Check(Stamp(result) == 1, "common-type-selects-parent-overload");
        Check(result.Marker == 11, "selected-derived-instance-preserved");
        Check(result is Child, "common-type-conversion-preserves-object-identity-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
