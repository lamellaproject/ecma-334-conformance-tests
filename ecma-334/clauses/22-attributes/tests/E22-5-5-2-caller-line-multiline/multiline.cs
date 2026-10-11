/*
Rules: E22-5-5-2-caller-line-multiline
Authority: ECMA-334 7th ed 22.5.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [System.Runtime.CompilerServices.CallerLineNumber] int line
Into: int line
*/
using System;
class Caller { public static int Line([System.Runtime.CompilerServices.CallerLineNumber] int line = -1) { return line; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#line 550 "multiline.cs"
        int value = Caller.Line(

        );
#line default
        Check(value >= 550 && value <= 552, "line-within-invocation-span");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
