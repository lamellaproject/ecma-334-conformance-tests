/*
Rules: E11-2-3-constant-convert-integral-enum; E11-2-3-constant-numeric-match
Authority: ECMA-334 7th ed 11.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: source is 0
Into: source is Code.Second
*/
using System;
enum Code : byte { First, Second }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Matches(Code source) { return source is 0; }
    static void Main()
    {
        Check(Matches(Code.First), "zero-converted-enum");
        Check(!Matches(Code.Second), "enum-different");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
