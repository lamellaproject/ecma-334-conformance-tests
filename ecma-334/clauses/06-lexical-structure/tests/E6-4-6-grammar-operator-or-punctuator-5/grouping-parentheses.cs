/*
Rules: E6-4-6-grammar-operator-or-punctuator-5; E6-4-6-grammar-operator-or-punctuator-6
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (4 + 7) * 3
Into: 4 + 7 * 3
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = (4 + 7) * 3;
        Check(result == 33, "grouped-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
