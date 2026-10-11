/*
Rules: E12-8-22-base-target-form; E12-8-22-entity-form
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: nameof(base.ParentNumber)
Into: nameof(base.Other)
*/
using System;
class Parent { protected int ParentNumber, Other; }
class Receiver : Parent
{
    public string ReadName() { return nameof(base.ParentNumber); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Receiver().ReadName() == "ParentNumber", "base-starts-named-entity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
