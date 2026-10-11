/*
Rules: E6-4-6-grammar-right-shift-1; E6-4-6-grammar-right-shift-assignment-1
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: 80 >> 3
Into: 80 > 3
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int moved = 80 >> 3;
        Check(moved == 10, "adjacent-greater-tokens");
        int value = 144;
        value >>= 4;
        Check(value == 9, "adjacent-greater-and-greater-equal");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
