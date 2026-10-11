/*
Rules: E6-4-6-grammar-operator-or-punctuator-36; E6-4-6-grammar-operator-or-punctuator-37; E6-4-6-grammar-operator-or-punctuator-38; E6-4-6-grammar-operator-or-punctuator-39; E6-4-6-grammar-operator-or-punctuator-40
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: value += 4;
Into: value = 4;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 25;
        value += 4;
        Check(value == 29, "plus-equal");
        value = 25; value -= 4;
        Check(value == 21, "minus-equal");
        value = 25; value *= 4;
        Check(value == 100, "asterisk-equal");
        value = 25; value /= 4;
        Check(value == 6, "slash-equal");
        value = 25; value %= 4;
        Check(value == 1, "percent-equal");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
