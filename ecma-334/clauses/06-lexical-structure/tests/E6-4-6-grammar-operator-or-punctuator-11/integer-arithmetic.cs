/*
Rules: E6-4-6-grammar-operator-or-punctuator-11; E6-4-6-grammar-operator-or-punctuator-12; E6-4-6-grammar-operator-or-punctuator-13; E6-4-6-grammar-operator-or-punctuator-14; E6-4-6-grammar-operator-or-punctuator-15; E6-3-1-grammar-asterisk-1; E6-3-1-grammar-slash-1; E6-4-1-grammar-token-7
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: int quotient = x / y;
Into: int quotient = x * y;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int x = 23, y = 5;
        int quotient = x / y;
        Check(x + y == 28, "plus");
        Check(x - y == 18, "minus");
        Check(x * y == 115, "asterisk");
        Check(quotient == 4, "slash");
        Check(x % y == 3, "percent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
