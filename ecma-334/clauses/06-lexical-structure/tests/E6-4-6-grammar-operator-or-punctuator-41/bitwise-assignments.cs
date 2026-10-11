/*
Rules: E6-4-6-grammar-operator-or-punctuator-41; E6-4-6-grammar-operator-or-punctuator-42; E6-4-6-grammar-operator-or-punctuator-43
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: value &= 10;
Into: value |= 10;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 12;
        value &= 10;
        Check(value == 8, "ampersand-equal");
        value = 12; value |= 10;
        Check(value == 14, "bar-equal");
        value = 12; value ^= 10;
        Check(value == 6, "caret-equal");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
