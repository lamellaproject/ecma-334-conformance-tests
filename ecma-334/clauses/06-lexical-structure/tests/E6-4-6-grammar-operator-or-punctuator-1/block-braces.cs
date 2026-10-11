/*
Rules: E6-4-6-grammar-operator-or-punctuator-1; E6-4-6-grammar-operator-or-punctuator-2
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: { int marker = 17; result = marker; }
Into: int marker = 17; result = marker;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = 0;
        { int marker = 17; result = marker; }
        { int marker = 29; result += marker; }
        Check(result == 46, "separate-braced-scopes");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
