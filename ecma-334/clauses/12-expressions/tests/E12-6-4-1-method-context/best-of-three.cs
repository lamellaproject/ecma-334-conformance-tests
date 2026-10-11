/*
Rules: E12-6-4-1-method-context; E12-6-4-1-overload-definition; E12-6-4-1-context-candidates; E12-6-4-1-applicable-filter; E12-6-4-1-sole-best; E12-6-4-1-better-than-all; E12-6-4-2-value-conversion; E12-6-4-3-better-conversions; E12-6-4-5-better-exact; E12-6-4-6-exact-identity
Authority: ECMA-334 7th ed 12.6.4.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Pick((short)8)
Into: Pick(8L)
*/
using System;
class Program
{
    static int checks, failures;
    static int Pick(int x) { return 1; }
    static int Pick(long x) { return 2; }
    static int Pick(double x) { return 3; }
    static int Pick(string x) { return 4; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick((short)8) == 1, "int-conversion-better-than-long-and-double-with-string-inapplicable");
        Check(Pick("x") == 4, "sole-applicable-string-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
