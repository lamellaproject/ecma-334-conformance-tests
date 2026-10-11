/*
Rules: E6-4-5-3-int-minimum-type; E6-4-5-3-int-minimum-value; E6-4-5-3-int-boundary-other-type
Authority: ECMA-334 7th ed 6.4.5.3
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: Tag(-2147483648)
Into: Tag(-(2147483648))
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Tag(int value) { return 1; }
    static int Tag(uint value) { return 2; }
    static int Tag(long value) { return 3; }
    static void Main()
    {
        Check(Tag(-2147483648) == 1, "immediate-type");
        Check(-2147483648 == -2147483647 - 1, "immediate-value");
        Check(Tag(- /* token, not character adjacency */ 0x80000000) == 1, "hex-immediate");
        Check(Tag(2147483648) == 2, "positive-uint");
        Check(Tag(-(2147483648)) == 3, "parenthesized-long");
        Check(Tag(-2147483648U) == 3, "suffix-excludes-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
