/*
Rules: E15-6-2-6-array-expanded-signature-precedence
Authority: ECMA-334 7th ed 15.6.2.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: static int Choose(int direct)
Into: static int Choose(long direct)
*/
using System;
class Program
{
    static int Choose(int direct) { return 31; }
    static int Choose(params int[] packed) { return packed.Length * 10; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Choose(7) == 31, "applicable-matching-signature-precludes-expanded-form");
        Check(Choose(direct: 7) == 31, "matching-named-argument-uses-declared-method");
        Check(Choose(packed: 7) == 10, "inapplicable-declared-method-does-not-preclude-expansion");
        Check(Choose(7, 9) == 20, "different-expanded-signature-remains-applicable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
