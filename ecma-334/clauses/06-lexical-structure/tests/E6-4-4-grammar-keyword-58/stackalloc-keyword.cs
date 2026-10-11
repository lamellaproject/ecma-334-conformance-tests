/*
Rules: E6-4-4-grammar-keyword-58
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: stackalloc int[2]
Into: new int[2]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int* items = stackalloc int[2];
        items[0] = 61; items[1] = 67;
        Check(items[0] + items[1] == 128, "stackalloc");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
