/*
Rules: E12-10-2-integer-unchecked-truncation; E12-10-2-integer-unchecked-no-report
Authority: ECMA-334 7th ed 12.10.2
Version: 7.3
Expected: run
Stdout: OK 1
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ulong A(ulong value) { return value; }
    static int Kind(ulong value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(unchecked(A(18446744073709551615UL) * A(2UL)) == 18446744073709551614UL, "case-0");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
