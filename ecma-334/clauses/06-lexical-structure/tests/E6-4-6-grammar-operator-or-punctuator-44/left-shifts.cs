/*
Rules: E6-4-6-grammar-operator-or-punctuator-44; E6-4-6-grammar-operator-or-punctuator-45
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: value <<= 3;
Into: value <= 3;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int moved = 3 << 4;
        Check(moved == 48, "double-less");
        int value = 5;
        value <<= 3;
        Check(value == 40, "double-less-equal");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
