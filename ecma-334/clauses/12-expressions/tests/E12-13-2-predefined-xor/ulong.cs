/*
Rules: E12-13-2-predefined-xor; E12-13-2-bitwise-xor; E12-13-2-no-overflow
Authority: ECMA-334 7th ed 12.13.2
Version: 7.3
Expected: run
Stdout: OK 12
Generated: clauses/12-expressions/generators/logical.py
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
        Check(checked(A(0UL) ^ A(18446744073709551615UL)) == 18446744073709551615UL && Kind(checked(A(0UL) ^ A(18446744073709551615UL))) == 1, "case-0");
        Check(checked(A(18446744073709551615UL) ^ A(18446744073709551615UL)) == 0UL && Kind(checked(A(18446744073709551615UL) ^ A(18446744073709551615UL))) == 1, "case-1");
        Check(checked(A(0UL) ^ A(18446744073709551615UL)) == 18446744073709551615UL && Kind(checked(A(0UL) ^ A(18446744073709551615UL))) == 1, "case-2");
        Check(checked(A(6148914691236517205UL) ^ A(12297829382473034410UL)) == 18446744073709551615UL && Kind(checked(A(6148914691236517205UL) ^ A(12297829382473034410UL))) == 1, "case-3");
        Check(checked(A(6148914691236517205UL) ^ A(6148914691236517205UL)) == 0UL && Kind(checked(A(6148914691236517205UL) ^ A(6148914691236517205UL))) == 1, "case-4");
        Check(checked(A(23UL) ^ A(12UL)) == 27UL && Kind(checked(A(23UL) ^ A(12UL))) == 1, "case-5");
        Check(unchecked(A(0UL) ^ A(18446744073709551615UL)) == 18446744073709551615UL && Kind(unchecked(A(0UL) ^ A(18446744073709551615UL))) == 1, "case-6");
        Check(unchecked(A(18446744073709551615UL) ^ A(18446744073709551615UL)) == 0UL && Kind(unchecked(A(18446744073709551615UL) ^ A(18446744073709551615UL))) == 1, "case-7");
        Check(unchecked(A(0UL) ^ A(18446744073709551615UL)) == 18446744073709551615UL && Kind(unchecked(A(0UL) ^ A(18446744073709551615UL))) == 1, "case-8");
        Check(unchecked(A(6148914691236517205UL) ^ A(12297829382473034410UL)) == 18446744073709551615UL && Kind(unchecked(A(6148914691236517205UL) ^ A(12297829382473034410UL))) == 1, "case-9");
        Check(unchecked(A(6148914691236517205UL) ^ A(6148914691236517205UL)) == 0UL && Kind(unchecked(A(6148914691236517205UL) ^ A(6148914691236517205UL))) == 1, "case-10");
        Check(unchecked(A(23UL) ^ A(12UL)) == 27UL && Kind(unchecked(A(23UL) ^ A(12UL))) == 1, "case-11");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
