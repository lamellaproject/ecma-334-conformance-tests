/*
Rules: E6-4-4-grammar-keyword-61
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: struct Pair
Into: structure Pair
*/
using System;
struct Pair { public int Number; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pair item = new Pair();
        item.Number = 61;
        Check(item.Number == 61, "struct-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
