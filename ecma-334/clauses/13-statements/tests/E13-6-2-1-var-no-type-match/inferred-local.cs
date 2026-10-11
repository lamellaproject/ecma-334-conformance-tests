/*
Rules: E13-6-2-1-var-no-type-match; E13-6-2-1-form-implicit-local; E13-6-2-2-form-var-local; E13-6-2-2-form-var-declarator; E13-6-2-2-implicit-single-variable; E13-6-2-2-implicit-variable-type; E13-6-2-2-implicit-variable-value
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: var item = Make();
Into: long item = Make();
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Make() { calls++; return 13; }
    static int Kind(int n) { return 1; }
    static int Kind(long n) { return 2; }
    static void Main()
    {
        var item = Make();
        Check(item == 13 && calls == 1, "implicit-value-and-one-evaluation");
        Check(Kind(item) == 1, "implicit-compile-time-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
