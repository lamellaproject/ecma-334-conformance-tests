/*
Rules: E12-6-3-13-effective-block-return; E12-6-3-13-inferred-return-use; E12-6-3-15-common-type-contexts; E12-6-3-15-common-type-variable; E12-6-3-15-common-type-output-inference; E12-6-3-15-common-type-fixing; E12-6-3-7-typed-output
Authority: ECMA-334 7th ed 12.6.3.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return 9L;
Into: return "x";
*/
using System;
class Program
{
    static int checks, failures;
    static Func<P, T> Make<P, T>(P seed, Func<P, T> f) { return f; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<bool, long> result = Make(true, first => { if (first) return 7; return 9L; });
        Check(result(true) == 7L, "int-return-converts-to-inferred-long");
        Check(result(false) == 9L, "long-return-preserved");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
