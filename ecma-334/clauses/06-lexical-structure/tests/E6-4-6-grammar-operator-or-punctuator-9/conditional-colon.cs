/*
Rules: E6-4-6-grammar-operator-or-punctuator-9; E6-4-6-grammar-operator-or-punctuator-24
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: choice ? 11 : 23
Into: choice ? 11 ; 23
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool choice = false;
        int result = choice ? 11 : 23;
        Check(result == 23, "conditional-punctuation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
