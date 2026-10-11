/*
Rules: E6-4-3-grammar-decimal-digit-character-2
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int digit\u0665 = 37;
Into: int \u0665digit = 37;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int digit\u0665 = 37;
        Check(digit\u0665 == 37, "nd-category-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
