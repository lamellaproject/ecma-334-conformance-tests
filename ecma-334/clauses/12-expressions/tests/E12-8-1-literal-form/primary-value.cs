/*
Rules: E12-8-1-literal-form; E12-8-1-primary-nonarray-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int result = 37;
Into: int result = 38;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = 37;
        Check(result == 37, "literal-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
