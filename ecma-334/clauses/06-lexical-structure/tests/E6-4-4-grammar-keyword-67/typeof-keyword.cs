/*
Rules: E6-4-4-grammar-keyword-67
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: typeof(int)
Into: int
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Type actual = typeof(int);
        Check(actual != null && actual != typeof(string), "typeof-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
