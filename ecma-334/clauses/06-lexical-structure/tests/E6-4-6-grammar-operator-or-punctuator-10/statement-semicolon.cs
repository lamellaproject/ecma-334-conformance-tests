/*
Rules: E6-4-6-grammar-operator-or-punctuator-10; E6-4-6-grammar-operator-or-punctuator-21
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: value = 17;
Into: value = 17
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value;
        value = 17;
        value += 29;
        Check(value == 46, "assignment-and-semicolon");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
