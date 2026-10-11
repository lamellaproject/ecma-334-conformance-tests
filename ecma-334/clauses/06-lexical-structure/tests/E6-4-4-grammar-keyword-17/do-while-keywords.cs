/*
Rules: E6-4-4-grammar-keyword-17; E6-4-4-grammar-keyword-77
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: do { value += 3; } while (value < 7);
Into: while (value < 7) { value += 3; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 7;
        do { value += 3; } while (value < 7);
        Check(value == 10, "do-while");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
