/*
Rules: E12-8-4-enclosing-type-order; E12-8-4-member-lookup
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return Value;
Into: return Shell.Value;
*/
using System;
class Shell
{
    public static int Value = 8;
    public class Nested
    {
        public static int Value = 3;
        public static int Resolve() { return Value; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Shell.Nested.Resolve() == 3, "immediate-enclosing-type-searched-before-outer-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
