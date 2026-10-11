/*
Rules: E12-14-2-boolean-convertible-operands; E12-14-2-and-left-conversion; E12-14-2-and-true-left; E12-14-2-and-false-left
Authority: ECMA-334 7th ed 12.14.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: A(false, "L") && A(true, "R")
Into: A(false, "L") & A(true, "R")
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
        bool a = A(false, "L") && A(true, "R"); Check(!a && Trace == "LC", "false-conversion-skips-right");
        Trace = ""; bool b = A(true, "L") && A(false, "R"); Check(!b && Trace == "LCRC", "conversions-interleaved-left-to-right");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
