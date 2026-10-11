/*
Rules: E12-8-1-sizeof-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: sizeof(int)
Into: sizeof(long)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = sizeof(int);
        Check(result == 4, "sizeof-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
