/*
Rules: E13-6-2-2-implicit-ref-type; E13-6-2-2-implicit-ref-value; E13-6-2-2-form-var-ref-local
Authority: ECMA-334 7th ed 13.6.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ref var alias = ref source;
Into: var alias = source;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(int n) { return 1; }
    static int Kind(long n) { return 2; }
    static void Main()
    {
        long source = 3;
        ref var alias = ref source;
        Check(Kind(alias) == 2, "inferred-ref-compile-time-type");
        alias = 12;
        Check(source == 12, "inferred-ref-alias-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
