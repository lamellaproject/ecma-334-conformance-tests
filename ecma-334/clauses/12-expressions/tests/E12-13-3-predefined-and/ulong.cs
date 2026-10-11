/*
Rules: E12-13-3-predefined-and; E12-13-3-underlying-operation
Authority: ECMA-334 7th ed 12.13.3
Version: 7.3
Expected: run
Stdout: OK 12
Generated: clauses/12-expressions/generators/logical.py
*/
using System;
enum E : ulong { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E A(E value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A((E)(0UL)) & A((E)(18446744073709551615UL))) == (E)(0UL) && Kind(checked(A((E)(0UL)) & A((E)(18446744073709551615UL)))) == 1, "case-0");
        Check(checked(A((E)(18446744073709551615UL)) & A((E)(18446744073709551615UL))) == (E)(18446744073709551615UL) && Kind(checked(A((E)(18446744073709551615UL)) & A((E)(18446744073709551615UL)))) == 1, "case-1");
        Check(checked(A((E)(0UL)) & A((E)(18446744073709551615UL))) == (E)(0UL) && Kind(checked(A((E)(0UL)) & A((E)(18446744073709551615UL)))) == 1, "case-2");
        Check(checked(A((E)(6148914691236517205UL)) & A((E)(12297829382473034410UL))) == (E)(0UL) && Kind(checked(A((E)(6148914691236517205UL)) & A((E)(12297829382473034410UL)))) == 1, "case-3");
        Check(checked(A((E)(6148914691236517205UL)) & A((E)(6148914691236517205UL))) == (E)(6148914691236517205UL) && Kind(checked(A((E)(6148914691236517205UL)) & A((E)(6148914691236517205UL)))) == 1, "case-4");
        Check(checked(A((E)(23UL)) & A((E)(12UL))) == (E)(4UL) && Kind(checked(A((E)(23UL)) & A((E)(12UL)))) == 1, "case-5");
        Check(unchecked(A((E)(0UL)) & A((E)(18446744073709551615UL))) == (E)(0UL) && Kind(unchecked(A((E)(0UL)) & A((E)(18446744073709551615UL)))) == 1, "case-6");
        Check(unchecked(A((E)(18446744073709551615UL)) & A((E)(18446744073709551615UL))) == (E)(18446744073709551615UL) && Kind(unchecked(A((E)(18446744073709551615UL)) & A((E)(18446744073709551615UL)))) == 1, "case-7");
        Check(unchecked(A((E)(0UL)) & A((E)(18446744073709551615UL))) == (E)(0UL) && Kind(unchecked(A((E)(0UL)) & A((E)(18446744073709551615UL)))) == 1, "case-8");
        Check(unchecked(A((E)(6148914691236517205UL)) & A((E)(12297829382473034410UL))) == (E)(0UL) && Kind(unchecked(A((E)(6148914691236517205UL)) & A((E)(12297829382473034410UL)))) == 1, "case-9");
        Check(unchecked(A((E)(6148914691236517205UL)) & A((E)(6148914691236517205UL))) == (E)(6148914691236517205UL) && Kind(unchecked(A((E)(6148914691236517205UL)) & A((E)(6148914691236517205UL)))) == 1, "case-10");
        Check(unchecked(A((E)(23UL)) & A((E)(12UL))) == (E)(4UL) && Kind(unchecked(A((E)(23UL)) & A((E)(12UL)))) == 1, "case-11");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
