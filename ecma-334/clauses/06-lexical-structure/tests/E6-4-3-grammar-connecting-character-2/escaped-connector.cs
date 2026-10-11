/*
Rules: E6-4-3-grammar-connecting-character-2
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int row\u203Fnext = 37;
Into: int \u203Frownext = 37;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int row\u203Fnext = 37;
        Check(row\u203Fnext == 37, "pc-category-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
