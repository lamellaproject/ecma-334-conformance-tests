/*
Rules: E12-14-2-boolean-convertible-operands; E12-14-2-or-left-conversion; E12-14-2-or-true-left; E12-14-2-or-false-left
Authority: ECMA-334 7th ed 12.14.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: A(true, "L") || A(false, "R")
Into: A(true, "L") | A(false, "R")
*/
using System;
class Flag
{
    public bool Value; public Flag(bool b) { Value = b; }
    public static implicit operator bool(Flag x) { Program.Trace += "C"; return x.Value; }
}
class Program
{
    public static string Trace = "";
    static Flag A(bool b, string id) { Trace += id; return new Flag(b); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool a = A(true, "L") || A(false, "R"); Check(a && Trace == "LC", "true-conversion-skips-right");
        Trace = ""; bool b = A(false, "L") || A(true, "R"); Check(b && Trace == "LCRC", "conversions-interleaved-left-to-right");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
