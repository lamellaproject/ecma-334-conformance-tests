/*
Rules: E22-5-5-2-caller-line-value; E22-5-5-1-caller-info-substitution; E22-5-5-2-caller-line-eligible; E22-5-5-2-caller-line-directives
Authority: ECMA-334 7th ed 22.5.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [System.Runtime.CompilerServices.CallerLineNumber] long line
Into: long line
*/
using System;
class Caller { public static long Line([System.Runtime.CompilerServices.CallerLineNumber] long line = -1) { return line; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#line 541 "mapped-line.cs"
        long value = Caller.Line();
#line default
        Check(value == 541, "mapped-caller-line");
        Check(Caller.Line(37) == 37, "explicit-argument-preserved");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
