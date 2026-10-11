/*
Rules: E6-5-8-hidden-caller-line
Authority: ECMA-334 7th ed 6.5.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #line 1
Into: #line 2
*/
using System;
using System.Runtime.CompilerServices;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Line([CallerLineNumber] int number = 0) { return number; }
    static void Main()
    {
#line 1 "hidden.origin"
#line hidden
        Check(Line() == 2, "hidden-keeps-caller-line-information");
#line default
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
