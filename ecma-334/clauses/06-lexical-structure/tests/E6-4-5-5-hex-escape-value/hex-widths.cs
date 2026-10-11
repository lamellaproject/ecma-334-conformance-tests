/*
Rules: E6-4-5-5-hex-escape-value; E6-4-5-5-grammar-hexadecimal-escape-sequence-1; E6-4-5-5-grammar-character-3
Authority: ECMA-334 7th ed 6.4.5.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: '\x4F52'
Into: '\x4F53'
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check('\x7' == 7, "one-digit");
        Check('\x2a' == 42, "two-digits");
        Check('\x123' == 291, "three-digits");
        Check('\x4F52' == 20306, "four-digits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
