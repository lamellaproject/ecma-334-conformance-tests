/*
Rules: E12-6-4-6-exact-block-body; E12-6-4-6-exact-inferred-return
Authority: ECMA-334 7th ed 12.6.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return x + 1;
Into: return x + 1L;
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick(Func<int, int> f) { return 1; }
    static int Pick(Func<int, long> f) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(x => { if (x > 0) return x; return x + 1; }) == 1, "every-block-return-exactly-matches-int-return-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
