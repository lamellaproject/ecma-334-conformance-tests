/*
Rules: E7-7-1-constructor-parameter-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Branch(int value)
Into: Branch(int renamed)
*/
using System;
class Root { public int BaseValue; public Root(int value) { BaseValue = value; } }
class Branch : Root
{
    public int OwnValue;
    public Branch(int value) : base(value + 1) { OwnValue = value + 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch value = new Branch(131);
        Check(value.BaseValue == 132, "constructor-parameter-in-initializer");
        Check(value.OwnValue == 133, "constructor-parameter-in-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
