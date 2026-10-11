/*
Rules: E6-4-6-grammar-operator-or-punctuator-16; E6-4-6-grammar-operator-or-punctuator-17; E6-4-6-grammar-operator-or-punctuator-18; E6-4-6-grammar-operator-or-punctuator-20
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: x & y
Into: x | y
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int x = 12, y = 10;
        Check((x & y) == 8, "ampersand");
        Check((x | y) == 14, "bar");
        Check((x ^ y) == 6, "caret");
        Check(~x == -13, "tilde");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
