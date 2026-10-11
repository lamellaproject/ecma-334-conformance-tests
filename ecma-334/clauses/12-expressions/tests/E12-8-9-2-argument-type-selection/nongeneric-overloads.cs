/*
Rules: E12-8-9-2-argument-type-selection; E12-8-9-2-nongeneric-applicable; E12-8-9-2-best-overload; E12-8-9-2-runtime-invocation
Authority: ECMA-334 7th ed 12.8.9.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Choose(17)
Into: Choose("17")
*/
using System;
class Program
{
    static int checks, failures;
    static int calls;
    static int Choose(int input) { calls++; return 1; }
    static int Choose(string input) { calls += 10; return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Choose(17) == 1 && calls == 1, "argument-type-selects-int-method");
        Check(Choose("ash") == 2 && calls == 11, "argument-type-selects-string-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
