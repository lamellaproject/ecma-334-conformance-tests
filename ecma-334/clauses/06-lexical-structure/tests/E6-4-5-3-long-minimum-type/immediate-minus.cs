/*
Rules: E6-4-5-3-long-minimum-type; E6-4-5-3-long-minimum-value; E6-4-5-3-long-boundary-other-type
Authority: ECMA-334 7th ed 6.4.5.3
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: Tag(-9223372036854775808L)
Into: Tag(9223372036854775808L)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Tag(long value) { return 1; }
    static int Tag(ulong value) { return 2; }
    static void Main()
    {
        Check(Tag(-9223372036854775808L) == 1, "upper-l-type");
        Check(Tag(-9223372036854775808l) == 1, "lower-l-type");
        Check(Tag(-9223372036854775808) == 1, "no-suffix-type");
        Check(-9223372036854775808L == -9223372036854775807L - 1L, "minimum-value");
        Check(Tag(9223372036854775808) == 2, "positive-unsuffixed");
        Check(Tag(9223372036854775808l) == 2, "positive-suffixed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
