/*
Rules: E6-4-4-grammar-keyword-29; E6-4-4-grammar-keyword-33
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int item in items
Into: int item as items
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int total = 0;
        int[] items = { 61, 67 };
        foreach (int item in items) total += item;
        Check(total == 128, "foreach-in");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
