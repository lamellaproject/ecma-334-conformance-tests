/*
Rules: E12-8-1-invocation-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int result = Pick();
Into: int result = 3;
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Pick() { calls++; return 3; }
    static void Main()
    {
        int result = Pick();
        Check(result == 3, "invocation-is-primary-expression");
        Check(calls == 1, "invocation-executes-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
