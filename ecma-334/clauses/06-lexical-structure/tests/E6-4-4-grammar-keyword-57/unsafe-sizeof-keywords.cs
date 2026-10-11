/*
Rules: E6-4-4-grammar-keyword-57; E6-4-4-grammar-keyword-71
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: sizeof(int)
Into: size(int)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int bytes = sizeof(int);
        Check(bytes == 4, "sizeof-int");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
