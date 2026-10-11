/*
Rules: E12-16-exception-conversion; E12-16-thrown-value; E12-16-throw-statement-semantics; E12-16-conditional-second; E12-16-no-type; E12-16-implicit-throw-conversion
Authority: ECMA-334 7th ed 12.16
Version: 7.3
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/operand-90a5edc3f8.cs.part
Mutate: throw Make()
Into: throw new Exception()
*/
using System;
class Source
{
    public static implicit operator Exception(Source x) { Program.Trace += "C"; return Program.Saved; }
}
class Program
{
    public static string Trace = "";
    public static Exception Saved = new Exception();
    static Source Make() { Trace += "E"; return new Source(); }
    static bool Choose(bool b) { return b; }
    static int Kind(int x) { return 1; } static int Kind(object x) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        try { int n = Choose(true) ? throw Make() : 19; Check(false, "throw-must-execute"); }
        catch (Exception e) { Check(object.ReferenceEquals(e, Saved) && Trace == "EC", "operand-evaluated-converted-and-thrown-once"); }
        Trace = ""; var value = Choose(false) ? throw new Exception() : 19;
        Check(value == 19 && Kind(value) == 1 && Trace == "", "throw-arm-has-no-type-and-does-not-run");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
