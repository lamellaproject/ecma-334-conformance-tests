/*
Rules: E15-6-2-1-grammar-fixed-parameter
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [System.Runtime.CompilerServices.CallerLineNumber]
Into: 
*/
using System;
class Program
{
    static int Line([System.Runtime.CompilerServices.CallerLineNumber] int line = 0) { return line; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#line 123
        Check(Line() == 123, "fixed-parameter-attribute-is-applied");
#line default
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
