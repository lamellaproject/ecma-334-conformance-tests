/*
Rules: E12-8-1-anonymous-method-form; E12-8-23-anonymous-function-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: delegate { return 3; }
Into: delegate { return 8; }
*/
using System;
delegate int Pick();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pick call = delegate { return 3; };
        Check(call() == 3, "anonymous-method-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
