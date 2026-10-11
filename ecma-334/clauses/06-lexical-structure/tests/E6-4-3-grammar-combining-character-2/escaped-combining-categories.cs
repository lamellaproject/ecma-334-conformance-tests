/*
Rules: E6-4-3-grammar-combining-character-2; E6-4-3-grammar-identifier-part-character-4
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int q\u0300 = 37;
Into: int \u0300q = 37;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int q\u0300 = 37;
        int \u0915\u093E = 41;
        Check(q\u0300 == 37, "mn-category-part");
        Check(\u0915\u093E == 41, "mc-category-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
