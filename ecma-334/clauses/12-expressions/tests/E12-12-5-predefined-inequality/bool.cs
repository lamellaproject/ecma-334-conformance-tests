/*
Rules: E12-12-5-predefined-inequality; E12-12-5-unequal-same-values; E12-12-5-unequal-different-values; E12-12-5-xor-equivalence; E12-12-1-predefined-bool; E12-12-1-inequality-result
Authority: ECMA-334 7th ed 12.12.5
Version: 7.3
Expected: run
Stdout: OK 4
Generated: clauses/12-expressions/generators/comparisons.py
*/
using System;

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool A(bool value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A(false) != A(false)) == false && (A(false) != A(false)) == (A(false) ^ A(false)) && Kind(A(false) != A(false)) == 1, "case-0");
        Check((A(false) != A(true)) == true && (A(false) != A(true)) == (A(false) ^ A(true)) && Kind(A(false) != A(true)) == 1, "case-1");
        Check((A(true) != A(false)) == true && (A(true) != A(false)) == (A(true) ^ A(false)) && Kind(A(true) != A(false)) == 1, "case-2");
        Check((A(true) != A(true)) == false && (A(true) != A(true)) == (A(true) ^ A(true)) && Kind(A(true) != A(true)) == 1, "case-3");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
