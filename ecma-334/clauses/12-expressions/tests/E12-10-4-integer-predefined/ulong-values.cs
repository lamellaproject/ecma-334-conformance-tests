/*
Rules: E12-10-4-integer-predefined; E12-10-4-remainder; E12-10-4-integer-value
Authority: ECMA-334 7th ed 12.10.4
Version: 7.3
Expected: run
Stdout: OK 3
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
        Check(unchecked(A(19UL) % A(4UL)) == 3UL && Kind(unchecked(A(19UL) % A(4UL))) == 1, "case-0");
        Check(unchecked(A(0UL) % A(4UL)) == 0UL && Kind(unchecked(A(0UL) % A(4UL))) == 1, "case-1");
        Check(unchecked(A(3UL) % A(7UL)) == 3UL && Kind(unchecked(A(3UL) % A(7UL))) == 1, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
