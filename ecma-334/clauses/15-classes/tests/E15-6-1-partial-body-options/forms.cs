/*
Rules: E15-6-1-partial-body-options; E15-6-1-grammar-method-modifiers
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static partial void Expression() => Calls = Calls * 10 + 2;
Into: static partial void Expression() => Calls = Calls * 10 + 8;
*/
using System;
partial class Holder
{
    public static int Calls;
    static partial void Block();
    static partial void Expression();
    static partial void Block() { Calls = Calls * 10 + 1; }
    static partial void Expression() => Calls = Calls * 10 + 2;
    public static void Touch() { Block(); Expression(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder.Touch();
        Check(Holder.Calls == 12, "partial-method-semicolon-block-and-expression-forms");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
