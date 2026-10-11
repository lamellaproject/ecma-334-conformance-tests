/*
Rules: E7-5-4-protected-base-constructor
Authority: ECMA-334 7th ed 7.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected Root(int value)
Into: private Root(int value)
*/
using System;
class Root
{
    public readonly int Value;
    protected Root(int value) { Value = value; }
}
class Branch : Root { public Branch() : base(127) { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Branch().Value == 127, "protected-constructor-in-base-initializer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
