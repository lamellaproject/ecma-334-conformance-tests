/*
Rules: E6-4-6-grammar-operator-or-punctuator-22; E6-4-6-grammar-operator-or-punctuator-23; E6-4-6-grammar-operator-or-punctuator-32; E6-4-6-grammar-operator-or-punctuator-33; E6-4-6-grammar-operator-or-punctuator-34; E6-4-6-grammar-operator-or-punctuator-35
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: x < y
Into: x > y
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int x = 31, y = 7;
        bool smaller = x < y;
        Check(!smaller, "less-than");
        Check(x > y, "greater-than");
        Check(x == 31, "equal-equal");
        Check(x != y, "bang-equal");
        Check(y <= 7, "less-equal");
        Check(x >= 31, "greater-equal");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
