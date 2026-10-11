/*
Rules: E15-10-1-grammar-overloadable-unary-operator-false
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: bool operator false(Flag x) { return !x.Value; }
Into: bool operator false(Flag x) { return x.Value; }
*/
using System;
class Flag
{
    public bool Value;
    public Flag(bool value) { Value = value; }
    public static bool operator true(Flag x) { return x.Value; }
    public static bool operator false(Flag x) { return !x.Value; }
    public static Flag operator &(Flag a, Flag b) { Program.AndCalls++; return new Flag(a.Value & b.Value); }
}
class Program
{
    static int checks, failures;
    public static int AndCalls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Flag result = new Flag(false) && new Flag(true);
        Check(!result.Value, "operator-false-result");
        Check(AndCalls == 0, "operator-false-short-circuit");
        result = new Flag(true) && new Flag(true);
        Check(result.Value && AndCalls == 1, "operator-false-no-short-circuit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
